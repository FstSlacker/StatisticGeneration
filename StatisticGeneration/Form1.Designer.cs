namespace StatisticGeneration
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbGroupColumn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSubsColumn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInfoOccasionColumn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPlaygroundColumn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbProjectsColumn = new System.Windows.Forms.TextBox();
            this.btApply = new System.Windows.Forms.Button();
            this.ofdOpenData = new System.Windows.Forms.OpenFileDialog();
            this.lbFileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTonalityColumn = new System.Windows.Forms.TextBox();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.lbSavedFileName = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.divider1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDataColumn = new System.Windows.Forms.TextBox();
            this.btTest = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tbLinkColumn = new System.Windows.Forms.TextBox();
            this.pbLoadFileIcon = new System.Windows.Forms.PictureBox();
            this.btHelp1 = new System.Windows.Forms.Button();
            this.btSaveFile = new System.Windows.Forms.Button();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.pbSaveFileIcon = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbReactionColumn = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbCommentsColumn = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbRepostsColumn = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadFileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveFileIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tbGroupColumn
            // 
            this.tbGroupColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbGroupColumn.Location = new System.Drawing.Point(174, 110);
            this.tbGroupColumn.Name = "tbGroupColumn";
            this.tbGroupColumn.Size = new System.Drawing.Size(65, 23);
            this.tbGroupColumn.TabIndex = 2;
            this.tbGroupColumn.Text = "R";
            this.tbGroupColumn.TextChanged += new System.EventHandler(this.tbGroupColumn_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Колонка с URL сообществ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Колонка с подписчиками:";
            // 
            // tbSubsColumn
            // 
            this.tbSubsColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbSubsColumn.Location = new System.Drawing.Point(174, 136);
            this.tbSubsColumn.Name = "tbSubsColumn";
            this.tbSubsColumn.Size = new System.Drawing.Size(65, 23);
            this.tbSubsColumn.TabIndex = 4;
            this.tbSubsColumn.Text = "S";
            this.tbSubsColumn.TextChanged += new System.EventHandler(this.tbSubsColumn_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Колонка с инфоповодами:";
            // 
            // tbInfoOccasionColumn
            // 
            this.tbInfoOccasionColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbInfoOccasionColumn.Location = new System.Drawing.Point(174, 162);
            this.tbInfoOccasionColumn.Name = "tbInfoOccasionColumn";
            this.tbInfoOccasionColumn.Size = new System.Drawing.Size(65, 23);
            this.tbInfoOccasionColumn.TabIndex = 6;
            this.tbInfoOccasionColumn.Text = "B";
            this.tbInfoOccasionColumn.TextChanged += new System.EventHandler(this.tbInfoOccasionColumn_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label5.Location = new System.Drawing.Point(12, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Колонка с площадками:";
            // 
            // tbPlaygroundColumn
            // 
            this.tbPlaygroundColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbPlaygroundColumn.Location = new System.Drawing.Point(174, 188);
            this.tbPlaygroundColumn.Name = "tbPlaygroundColumn";
            this.tbPlaygroundColumn.Size = new System.Drawing.Size(65, 23);
            this.tbPlaygroundColumn.TabIndex = 10;
            this.tbPlaygroundColumn.Text = "P";
            this.tbPlaygroundColumn.TextChanged += new System.EventHandler(this.tbPlaygroundColumn_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label6.Location = new System.Drawing.Point(12, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Колонки с проектами:";
            // 
            // tbProjectsColumn
            // 
            this.tbProjectsColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbProjectsColumn.Location = new System.Drawing.Point(174, 292);
            this.tbProjectsColumn.Name = "tbProjectsColumn";
            this.tbProjectsColumn.Size = new System.Drawing.Size(172, 23);
            this.tbProjectsColumn.TabIndex = 12;
            this.tbProjectsColumn.Text = "AR,AV,BI,BK,BO,BU,BY,CC,CJ,CV,DH,DM,DP,EE";
            this.tbProjectsColumn.TextChanged += new System.EventHandler(this.tbProjectsColumn_TextChanged);
            // 
            // btApply
            // 
            this.btApply.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btApply.Location = new System.Drawing.Point(262, 444);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(117, 23);
            this.btApply.TabIndex = 14;
            this.btApply.Text = "Обработать";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // ofdOpenData
            // 
            this.ofdOpenData.Filter = "Книга Excel|*.xlsx";
            this.ofdOpenData.Title = "Исходный файл";
            this.ofdOpenData.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenData_FileOk);
            // 
            // lbFileName
            // 
            this.lbFileName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFileName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbFileName.Location = new System.Drawing.Point(39, 27);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(254, 19);
            this.lbFileName.TabIndex = 15;
            this.lbFileName.Text = "Файл не выбран";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label7.Location = new System.Drawing.Point(12, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Колонка с тональностью:";
            // 
            // tbTonalityColumn
            // 
            this.tbTonalityColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbTonalityColumn.Location = new System.Drawing.Point(174, 214);
            this.tbTonalityColumn.Name = "tbTonalityColumn";
            this.tbTonalityColumn.Size = new System.Drawing.Size(65, 23);
            this.tbTonalityColumn.TabIndex = 17;
            this.tbTonalityColumn.Text = "J";
            this.tbTonalityColumn.TextChanged += new System.EventHandler(this.tbTonalityColumn_TextChanged);
            // 
            // sfdSaveFile
            // 
            this.sfdSaveFile.Filter = "Книга Excel|*.xlsx";
            this.sfdSaveFile.Title = "Файл сохранения";
            this.sfdSaveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdSaveFile_FileOk);
            // 
            // lbSavedFileName
            // 
            this.lbSavedFileName.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lbSavedFileName.Location = new System.Drawing.Point(39, 67);
            this.lbSavedFileName.Name = "lbSavedFileName";
            this.lbSavedFileName.Size = new System.Drawing.Size(254, 19);
            this.lbSavedFileName.TabIndex = 19;
            this.lbSavedFileName.Text = "Статистика.xlsx";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(391, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Maximum = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Value = 1;
            this.progressBar.Visible = false;
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(145, 17);
            this.lbStatus.Text = "Состояние: нет процесса";
            this.lbStatus.Visible = false;
            // 
            // divider1
            // 
            this.divider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.divider1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.divider1.Location = new System.Drawing.Point(0, 13);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(500, 1);
            this.divider1.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Входной файл (.xlsx):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Выходной файл (.xlsx):";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(-1, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(500, 1);
            this.label10.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Настройки параметров:";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(0, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(500, 1);
            this.label12.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(-55, 434);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(500, 1);
            this.label13.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label14.Location = new System.Drawing.Point(12, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 15);
            this.label14.TabIndex = 31;
            this.label14.Text = "Колонка с датой:";
            // 
            // tbDataColumn
            // 
            this.tbDataColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbDataColumn.Location = new System.Drawing.Point(174, 240);
            this.tbDataColumn.Name = "tbDataColumn";
            this.tbDataColumn.Size = new System.Drawing.Size(65, 23);
            this.tbDataColumn.TabIndex = 30;
            this.tbDataColumn.Text = "C";
            this.tbDataColumn.TextChanged += new System.EventHandler(this.tbDataColumn_TextChanged);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(180, 443);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 32;
            this.btTest.Text = "test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Visible = false;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label15.Location = new System.Drawing.Point(12, 269);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(161, 15);
            this.label15.TabIndex = 34;
            this.label15.Text = "Колонка с URL публикаций:";
            // 
            // tbLinkColumn
            // 
            this.tbLinkColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbLinkColumn.Location = new System.Drawing.Point(174, 266);
            this.tbLinkColumn.Name = "tbLinkColumn";
            this.tbLinkColumn.Size = new System.Drawing.Size(65, 23);
            this.tbLinkColumn.TabIndex = 33;
            this.tbLinkColumn.Text = "I";
            this.tbLinkColumn.TextChanged += new System.EventHandler(this.tbLinkColumn_TextChanged);
            // 
            // pbLoadFileIcon
            // 
            this.pbLoadFileIcon.Image = global::StatisticGeneration.Properties.Resources.xlsx_icon_transparent;
            this.pbLoadFileIcon.Location = new System.Drawing.Point(15, 22);
            this.pbLoadFileIcon.Name = "pbLoadFileIcon";
            this.pbLoadFileIcon.Size = new System.Drawing.Size(24, 24);
            this.pbLoadFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadFileIcon.TabIndex = 35;
            this.pbLoadFileIcon.TabStop = false;
            this.pbLoadFileIcon.Visible = false;
            // 
            // btHelp1
            // 
            this.btHelp1.Image = global::StatisticGeneration.Properties.Resources.question_mark;
            this.btHelp1.Location = new System.Drawing.Point(352, 291);
            this.btHelp1.Name = "btHelp1";
            this.btHelp1.Size = new System.Drawing.Size(27, 25);
            this.btHelp1.TabIndex = 28;
            this.btHelp1.UseVisualStyleBackColor = true;
            this.btHelp1.Click += new System.EventHandler(this.btHelp1_Click);
            // 
            // btSaveFile
            // 
            this.btSaveFile.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btSaveFile.Image = global::StatisticGeneration.Properties.Resources.save;
            this.btSaveFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveFile.Location = new System.Drawing.Point(299, 63);
            this.btSaveFile.Name = "btSaveFile";
            this.btSaveFile.Size = new System.Drawing.Size(80, 23);
            this.btSaveFile.TabIndex = 20;
            this.btSaveFile.Text = "Выбрать";
            this.btSaveFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSaveFile.UseVisualStyleBackColor = true;
            this.btSaveFile.Click += new System.EventHandler(this.btSaveFile_Click);
            // 
            // btOpenFile
            // 
            this.btOpenFile.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btOpenFile.Image = global::StatisticGeneration.Properties.Resources.folder_v3;
            this.btOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenFile.Location = new System.Drawing.Point(299, 23);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(80, 23);
            this.btOpenFile.TabIndex = 16;
            this.btOpenFile.Text = "Выбрать";
            this.btOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // pbSaveFileIcon
            // 
            this.pbSaveFileIcon.Image = global::StatisticGeneration.Properties.Resources.xlsx_icon_transparent;
            this.pbSaveFileIcon.Location = new System.Drawing.Point(15, 62);
            this.pbSaveFileIcon.Name = "pbSaveFileIcon";
            this.pbSaveFileIcon.Size = new System.Drawing.Size(24, 24);
            this.pbSaveFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSaveFileIcon.TabIndex = 36;
            this.pbSaveFileIcon.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(12, 448);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 14);
            this.label16.TabIndex = 37;
            this.label16.Text = "v1.5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Колонка с суммой реакций:";
            // 
            // tbReactionColumn
            // 
            this.tbReactionColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbReactionColumn.Location = new System.Drawing.Point(174, 331);
            this.tbReactionColumn.Name = "tbReactionColumn";
            this.tbReactionColumn.Size = new System.Drawing.Size(65, 23);
            this.tbReactionColumn.TabIndex = 38;
            this.tbReactionColumn.Text = "R";
            this.tbReactionColumn.TextChanged += new System.EventHandler(this.tbReactionColumn_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(12, 363);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(162, 15);
            this.label17.TabIndex = 41;
            this.label17.Text = "Колонка с комментариями:";
            // 
            // tbCommentsColumn
            // 
            this.tbCommentsColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbCommentsColumn.Location = new System.Drawing.Point(174, 360);
            this.tbCommentsColumn.Name = "tbCommentsColumn";
            this.tbCommentsColumn.Size = new System.Drawing.Size(65, 23);
            this.tbCommentsColumn.TabIndex = 40;
            this.tbCommentsColumn.Text = "R";
            this.tbCommentsColumn.TextChanged += new System.EventHandler(this.tbCommentsColumn_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(12, 392);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 15);
            this.label18.TabIndex = 43;
            this.label18.Text = "Колонка с репостами:";
            // 
            // tbRepostsColumn
            // 
            this.tbRepostsColumn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tbRepostsColumn.Location = new System.Drawing.Point(174, 389);
            this.tbRepostsColumn.Name = "tbRepostsColumn";
            this.tbRepostsColumn.Size = new System.Drawing.Size(65, 23);
            this.tbRepostsColumn.TabIndex = 42;
            this.tbRepostsColumn.Text = "R";
            this.tbRepostsColumn.TextChanged += new System.EventHandler(this.tbRepostsColumn_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 496);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbRepostsColumn);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbCommentsColumn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbReactionColumn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pbSaveFileIcon);
            this.Controls.Add(this.pbLoadFileIcon);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbLinkColumn);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbDataColumn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btHelp1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btSaveFile);
            this.Controls.Add(this.lbSavedFileName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbTonalityColumn);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbProjectsColumn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPlaygroundColumn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbInfoOccasionColumn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSubsColumn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGroupColumn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(407, 424);
            this.Name = "MainForm";
            this.Text = "Statistic Generation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadFileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveFileIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbGroupColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSubsColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInfoOccasionColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPlaygroundColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbProjectsColumn;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.OpenFileDialog ofdOpenData;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTonalityColumn;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.Label lbSavedFileName;
        private System.Windows.Forms.Button btSaveFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btHelp1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbDataColumn;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbLinkColumn;
        private System.Windows.Forms.PictureBox pbLoadFileIcon;
        private System.Windows.Forms.PictureBox pbSaveFileIcon;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbReactionColumn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbCommentsColumn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbRepostsColumn;
    }
}

