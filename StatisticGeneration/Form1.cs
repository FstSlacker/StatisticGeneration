using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticGeneration
{
    public partial class MainForm : Form
    {
        private string filePath = "";
        private string saveFilePath = "";
        private delegate void ProgressDelegate(string status);
        private delegate void ApplyControlDelegate(bool endStatus);
        private string formParameterspath = "formParameters.param";
        public MainForm()
        {
            InitializeComponent();
        }
        public void SaveFormParameters()
        {
            try
            {
                if (!File.Exists(formParameterspath))
                {
                    var fc = File.Create(formParameterspath);
                    fc.Close();
                }
                StreamWriter sw = new StreamWriter(formParameterspath);
                sw.Write(tbGroupColumn.Text + ";" + tbSubsColumn.Text + ";" + tbInfoOccasionColumn.Text + ";" + /*tbViewsColumn.Text*/"NaN" + ";" + tbPlaygroundColumn.Text + ";" + tbTonalityColumn.Text + ";" + tbDataColumn.Text + ";" + tbLinkColumn.Text + ";" + tbProjectsColumn.Text + ";" + tbReactionColumn.Text + ";" + tbCommentsColumn.Text + ";" + tbRepostsColumn.Text + ";" + tbAuthorColumn.Text);
                sw.Close();
            }
            catch (Exception e)
            {

            }

        }
        public void LoadFormParameters()
        {
            try
            {
                StreamReader sr = new StreamReader(formParameterspath);
                string[] p = sr.ReadToEnd().Split(';');
                tbGroupColumn.Text = p[0];
                tbSubsColumn.Text = p[1];
                tbInfoOccasionColumn.Text = p[2];
                //tbViewsColumn.Text = p[3];
                tbPlaygroundColumn.Text = p[4];
                tbTonalityColumn.Text = p[5];
                tbDataColumn.Text = p[6];
                tbLinkColumn.Text = p[7];
                tbProjectsColumn.Text = p[8];
                tbReactionColumn.Text = p[9];
                tbCommentsColumn.Text = p[10];
                tbRepostsColumn.Text = p[11];
                tbAuthorColumn.Text = p[12];
                sr.Close();
            }
            catch (Exception e)
            {

            }
        }
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            ofdOpenData.ShowDialog();
        }

        private void ofdOpenData_FileOk(object sender, CancelEventArgs e)
        {
            filePath = ofdOpenData.FileName;
            lbFileName.Text = ofdOpenData.SafeFileName;
            lbFileName.Font = new Font(lbFileName.Font, FontStyle.Regular);
            pbLoadFileIcon.Visible = true;
        }
        private void ChangeStatus(string status)
        {
            lbStatus.Text = status;
        }
        private void ApplyControl(bool end)
        {
            progressBar.Visible = !end;
            lbStatus.Visible = !end;
            btApply.Enabled = end;
        }
        private void btApply_Click(object sender, EventArgs e)
        {
            //BeginInvoke(new MyDelegateText(PrintProccess), "Группа:" + fgroup_ind.ToString() + " считывание...");
            SaveFormParameters();
            if (filePath.Equals(""))
            {
                MessageBox.Show("Выберите файл.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new Thread(() =>
            {
                BeginInvoke(new ApplyControlDelegate(ApplyControl), false);
                BeginInvoke(new ProgressDelegate(ChangeStatus), "Чтение файла...");
                DataLoadParameters parameters = new DataLoadParameters();
                string[] columnsTitles = null;
                try
                {
                    columnsTitles = DataLoader.LoadColumnsTitles(filePath);
                }catch(Exception err)
                {
                    BeginInvoke(new ApplyControlDelegate(ApplyControl), true);
                    MessageBox.Show("Не удалось открыть файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataSaver.CreateErrorLog(err.Message + " " + err.ToString());
                    return;
                }
                try
                {
                    parameters.SetGroupColumn(tbGroupColumn.Text);
                    parameters.SetSubsColumn(tbSubsColumn.Text);
                    //parameters.SetViewsColumn(tbViewsColumn.Text);
                    parameters.SetInfoOccasionColumn(tbInfoOccasionColumn.Text);
                    parameters.SetPlaygroundColumn(tbPlaygroundColumn.Text);
                    parameters.SetTonalityColumn(tbTonalityColumn.Text);
                    parameters.SetDateColumn(tbDataColumn.Text);
                    parameters.SetLinkColumn(tbLinkColumn.Text);
                    parameters.SetProjectsColumns(tbProjectsColumn.Text, columnsTitles);
                    parameters.SetReactionsColumn(tbReactionColumn.Text);
                    parameters.SetCommentsColumn(tbCommentsColumn.Text);
                    parameters.SetRepostsColumn(tbRepostsColumn.Text);
                    parameters.SetAuthorColumn(tbAuthorColumn.Text);
                }
                catch (Exception err)
                {
                    BeginInvoke(new ApplyControlDelegate(ApplyControl), true);
                    MessageBox.Show("Некоторые поля заполнены некорректно. Проверьте правильность полей и повторите еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataSaver.CreateErrorLog(err.Message + " " + err.ToString());
                    return;
                }
                BeginInvoke(new ProgressDelegate(ChangeStatus), "Обработка данных...");
                Statistic statistic = null;
                try
                {
                    statistic = DataLoader.LoadAndApplyData(filePath, parameters);
                }
                catch (Exception err)
                {
                    BeginInvoke(new ApplyControlDelegate(ApplyControl), true);
                    MessageBox.Show("Произошла ошибка обработки данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataSaver.CreateErrorLog(err.Message + " " + err.ToString());
                    return;
                }
                BeginInvoke(new ProgressDelegate(ChangeStatus), "Сохранение результата...");
                try
                {
                    //DataSaver.SaveDataAsJson(projects, "testJson.json");
                    //DataSaver.SaveData(projects, saveFilePath);
                    DataSaver.SaveAsExcelFile(statistic, saveFilePath);
                }
                catch (Exception err)
                {
                    BeginInvoke(new ApplyControlDelegate(ApplyControl), true);
                    MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataSaver.CreateErrorLog(err.Message + " " + err.ToString());
                    return;
                }
                BeginInvoke(new ApplyControlDelegate(ApplyControl), true);
                MessageBox.Show("Обработка завершена. Файл сохранён.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }).Start();
            
        }
        private void FilterColumnText(TextBox tb)
        {
            int cursor = tb.SelectionStart;
            string text = tb.Text.ToUpper();
            text = Regex.Replace(text, "[^A-Z]", "");
            tb.Text = text;
            tb.SelectionStart = cursor;
            tb.SelectionLength = 0;
        }
        private void FilterColumnText(TextBox tb, bool separater)
        {
            int cursor = tb.SelectionStart;
            string text = tb.Text.ToUpper();
            text = Regex.Replace(text, "[^A-Z,]", "");
            tb.Text = text;
            tb.SelectionStart = cursor;
            tb.SelectionLength = 0;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lbSavedFileName.Text = "Статистика_" + DateTime.Today.ToString("dd/MM/yyyy").Replace('.', '_') + ".xlsx";
            saveFilePath = Environment.CurrentDirectory + @"\" + "Статистика_" + DateTime.Today.ToString("dd/MM/yyyy").Replace('.', '_') + ".xlsx";
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 50;
            LoadFormParameters();
        }

        private void btSaveFile_Click(object sender, EventArgs e)
        {
            sfdSaveFile.FileName = saveFilePath;
            sfdSaveFile.ShowDialog();
        }

        private void sfdSaveFile_FileOk(object sender, CancelEventArgs e)
        {
            saveFilePath = sfdSaveFile.FileName;
            FileInfo fi = new FileInfo(saveFilePath);
            lbSavedFileName.Text = fi.Name;
        }

        private void btHelp1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В данном поле необходимо указать колонки проектов через запятую. \n\nПример: A,B,C", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btTest_Click(object sender, EventArgs e)
        {

        }

        private void tbGroupColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbGroupColumn);
        }

        private void tbSubsColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbSubsColumn);
        }

        private void tbInfoOccasionColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbInfoOccasionColumn);
        }

        private void tbViewsColumn_TextChanged(object sender, EventArgs e)
        {
            //FilterColumnText(tbViewsColumn);
        }

        private void tbPlaygroundColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbPlaygroundColumn);
        }

        private void tbTonalityColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbTonalityColumn);
        }

        private void tbDataColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbDataColumn);
        }

        private void tbLinkColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbLinkColumn);
        }

        private void tbProjectsColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbProjectsColumn, true);
        }

        private void tbReactionColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbReactionColumn);
        }

        private void tbCommentsColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbCommentsColumn);
        }

        private void tbRepostsColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbRepostsColumn);
        }

        private void tbAuthorColumn_TextChanged(object sender, EventArgs e)
        {
            FilterColumnText(tbAuthorColumn);
        }
    }
}
