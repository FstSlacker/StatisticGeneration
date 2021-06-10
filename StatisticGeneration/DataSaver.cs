using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticGeneration
{
    public static class DataSaver
    {
        private static void WriteProjectData(ProjectData projectData, Microsoft.Office.Interop.Excel._Application app)
        {
            Microsoft.Office.Interop.Excel.Worksheet worksheet = app.Worksheets.Add(Type.Missing);
            projectData.Sort();
            string worksheetName = projectData.name;
            if(worksheetName.Length > 31)
            {
                worksheetName = worksheetName.Substring(0, 31);
            }
            worksheet.Name = worksheetName;
            int column = 1;
            worksheet.Cells[1, column] = "Название";
            worksheet.Cells[2, column] = projectData.name;

            column+=2;//разделение
            worksheet.Cells[1, column] = "Упоминания_количество";
            worksheet.Cells[2, column] = projectData.mentions.positive.ToString();
            worksheet.Cells[3, column] = projectData.mentions.negative.ToString();
            worksheet.Cells[4, column] = projectData.mentions.neutral.ToString();

            column++;
            worksheet.Cells[1, column] = "Упоминания_тональность";
            worksheet.Cells[2, column] = "Позитивная";
            worksheet.Cells[3, column] = "Негативная";
            worksheet.Cells[4, column] = "Нейтральная";

            column+=2;//разделение
            worksheet.Cells[1, column] = "Аудитория_количество";
            worksheet.Cells[2, column] = projectData.psubs.positive.ToString();
            worksheet.Cells[3, column] = projectData.psubs.negative.ToString();
            worksheet.Cells[4, column] = projectData.psubs.neutral.ToString();

            column++;
            worksheet.Cells[1, column] = "Аудитория_тональность";
            worksheet.Cells[2, column] = "Позитивная";
            worksheet.Cells[3, column] = "Негативная";
            worksheet.Cells[4, column] = "Нейтральная";

            column+=2;//разделение
            worksheet.Cells[1, column] = "Вовлечение_количество";
            worksheet.Cells[2, column] = projectData.involvement.positive.ToString();
            worksheet.Cells[3, column] = projectData.involvement.negative.ToString();
            worksheet.Cells[4, column] = projectData.involvement.neutral.ToString();

            column++;
            worksheet.Cells[1, column] = "Вовлечение_тональность";
            worksheet.Cells[2, column] = "Позитивная";
            worksheet.Cells[3, column] = "Негативная";
            worksheet.Cells[4, column] = "Нейтральная";

            column += 2;//разделение
            worksheet.Cells[1, column] = "Источник_название";
            worksheet.Cells[1, column + 1] = "Источник_упоминание";
            worksheet.Cells[1, column + 2] = "Источник_тональность";
            int row = 2;
            foreach (var pment in projectData.playgroundMentions)
            {
                worksheet.Cells[row, column] = pment.Key;
                worksheet.Cells[row, column + 1] = pment.Value.positive.ToString();
                worksheet.Cells[row, column + 2] = "Позитивная";
                row++;
                worksheet.Cells[row, column] = pment.Key;
                worksheet.Cells[row, column + 1] = pment.Value.negative.ToString();
                worksheet.Cells[row, column + 2] = "Негативная";
                row++;
                worksheet.Cells[row, column] = pment.Key;
                worksheet.Cells[row, column + 1] = pment.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Нейтральная";
                row++;
            }

            column += 3;//разделение
            worksheet.Cells[1, column] = "Инфоповоды_название";
            worksheet.Cells[1, column + 1] = "Инфоповоды_количество";
            worksheet.Cells[1, column + 2] = "Инфоповоды_тональность";
            worksheet.Cells[1, column + 3] = "Инфоповоды_ссылка";
            row = 2;
            foreach (var infoOccasion in projectData.infoOccasionPSubs)
            {
                worksheet.Cells[row, column] = infoOccasion.Key;
                worksheet.Cells[row, column + 1] = infoOccasion.Value.positive.ToString();
                worksheet.Cells[row, column + 2] = "Позитивная";
                worksheet.Cells[row, column + 3] = projectData.infoOccasionLinks[infoOccasion.Key].Key;
                row++;
                worksheet.Cells[row, column] = infoOccasion.Key;
                worksheet.Cells[row, column + 1] = infoOccasion.Value.negative.ToString();
                worksheet.Cells[row, column + 2] = "Негативная";
                row++;
                worksheet.Cells[row, column] = infoOccasion.Key;
                worksheet.Cells[row, column + 1] = infoOccasion.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Нейтральная";
                row++;
            }

            column += 4;
            worksheet.Cells[1, column] = "Ссылка";
            worksheet.Cells[1, column + 1] = "Лайки";
            worksheet.Cells[1, column + 2] = "Комментарии";
            worksheet.Cells[1, column + 3] = "Репосты";
            worksheet.Cells[1, column + 4] = "Вовлечение";
            worksheet.Cells[1, column + 5] = "Тональность";
            worksheet.Cells[1, column + 5] = "Автор";
            row = 2;

            Range c1 = (Range)worksheet.Cells[row, column];
            Range c2 = (Range)worksheet.Cells[row + projectData.posts.Count - 1, column + 6];
            Range range = worksheet.get_Range(c1, c2);
            range.Value = ProjectData.ConvertPostsListToArray(projectData.posts);

        }
        private static void WriteSocialNetworksData(SocialNetworksData socialNetworksData, _Application app)
        {
            Worksheet worksheet = app.Worksheets.Add(Type.Missing);
            worksheet.Name = "Соц. сети";

            worksheet.Cells[1, 1] = "Дата";
            worksheet.Cells[1, 2] = "Источник";
            worksheet.Cells[1, 3] = "Упоминания";
            worksheet.Cells[1, 4] = "Аудитория";
            worksheet.Cells[1, 5] = "Вовлечение";
            worksheet.Cells[1, 6] = "Тональность";

            int row = 2;
            int column = 2;

            Range c1 = (Range)worksheet.Cells[row, column];
            Range c2 = (Range)worksheet.Cells[row + socialNetworksData.socialNetworks.Count * 3 - 1, column + 4];
            Range range = worksheet.get_Range(c1, c2);
            range.Value = socialNetworksData.ConvertToArray();
        }
        private static void WriteGeneralData(GeneralData generalData, Microsoft.Office.Interop.Excel._Application app)
        {
            Microsoft.Office.Interop.Excel.Worksheet worksheet = app.Worksheets.Add(Type.Missing);
            generalData.Sort();
            worksheet.Name = "Общее";
            int column = 1;
            worksheet.Cells[1, column] = "Название";
            worksheet.Cells[2, column] = generalData.name;

            column+=2;//разделение
            worksheet.Cells[1, column] = "Упоминания_количество";
            worksheet.Cells[2, column] = generalData.mentions.positive.ToString();
            worksheet.Cells[3, column] = generalData.mentions.negative.ToString();
            worksheet.Cells[4, column] = generalData.mentions.neutral.ToString();

            column++;
            worksheet.Cells[1, column] = "Упоминания_тональность";
            worksheet.Cells[2, column] = "Позитивная";
            worksheet.Cells[3, column] = "Негативная";
            worksheet.Cells[4, column] = "Нейтральная";

            column+=2;//разделение
            worksheet.Cells[1, column] = "Аудитория_количество";
            worksheet.Cells[2, column] = generalData.psubs.positive.ToString();
            worksheet.Cells[3, column] = generalData.psubs.negative.ToString();
            worksheet.Cells[4, column] = generalData.psubs.neutral.ToString();

            column++;
            worksheet.Cells[1, column] = "Аудитория_тональность";
            worksheet.Cells[2, column] = "Позитивная";
            worksheet.Cells[3, column] = "Негативная";
            worksheet.Cells[4, column] = "Нейтральная";

            column+=2;//разделение
            worksheet.Cells[1, column] = "Инфоповоды_название";
            worksheet.Cells[1, column + 1] = "Инфоповоды_количество";
            worksheet.Cells[1, column + 2] = "Инфоповоды_тональность";
            worksheet.Cells[1, column + 3] = "Инфоповоды_ссылка";
            int row = 2;
            foreach (var infoOccasion in generalData.infoOccasionPSubs)
            {
                worksheet.Cells[row, column] = infoOccasion.Key;
                worksheet.Cells[row, column + 1] = infoOccasion.Value.positive.ToString();
                worksheet.Cells[row, column + 2] = "Позитивная";
                worksheet.Cells[row, column + 3] = generalData.infoOccasionLinks[infoOccasion.Key].Key;
                row++;
                worksheet.Cells[row, column] = infoOccasion.Key;
                worksheet.Cells[row, column + 1] = infoOccasion.Value.negative.ToString();
                worksheet.Cells[row, column + 2] = "Негативная";
                row++;
                worksheet.Cells[row, column] = infoOccasion.Key;
                worksheet.Cells[row, column + 1] = infoOccasion.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Нейтральная";
                row++;
            }

            column += 5;//разделение
            worksheet.Cells[1, column] = "Проекты_название";
            worksheet.Cells[1, column + 1] = "Проекты_количество";
            worksheet.Cells[1, column + 2] = "Проекты_тональность";
            row = 2;


            foreach (var project in generalData.projectsPSubs)
            {
                worksheet.Cells[row, column] = project.Key;
                worksheet.Cells[row, column + 1] = project.Value.positive.ToString();
                worksheet.Cells[row, column + 2] = "Позитивная";
                row++;
                worksheet.Cells[row, column] = project.Key;
                worksheet.Cells[row, column + 1] = project.Value.negative.ToString();
                worksheet.Cells[row, column + 2] = "Негативная";
                row++;
                worksheet.Cells[row, column] = project.Key;
                worksheet.Cells[row, column + 1] = project.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Нейтральная";
                row++;
            }
        }
        private static void WriteTonalityGeneralData(TonalityGeneralData tonalityData, Microsoft.Office.Interop.Excel._Application app, string tonality)
        {
            Microsoft.Office.Interop.Excel.Worksheet worksheet = app.Worksheets.Add(Type.Missing);
            tonalityData.Sort();
            worksheet.Name = tonality;
            int column = 1;
            worksheet.Cells[1, column] = "Название";
            worksheet.Cells[2, column] = tonalityData.name;

            column+=2;//разделение
            int row = 2;
            worksheet.Cells[1, column] = "Площадки_упоминания_название";
            worksheet.Cells[1, column + 1] = "Площадки_упоминания_количество";
            worksheet.Cells[1, column + 2] = "Площадки_упоминания_тональность";
            foreach (var playground in tonalityData.playgroundMentions)
            {
                worksheet.Cells[row, column] = playground.Key;
                worksheet.Cells[row, column + 1] = playground.Value.ToString();
                worksheet.Cells[row, column + 2] = tonality;
                row++;
            }

            column += 4;//разделение
            row = 2;
            worksheet.Cells[1, column] = "Площадки_аудитория_название";
            worksheet.Cells[1, column + 1] = "Площадки_аудитория_количество";
            worksheet.Cells[1, column + 2] = "Площадки_аудитория_тональность";
            foreach (var playground in tonalityData.playgroundPSubs)
            {
                worksheet.Cells[row, column] = playground.Key;
                worksheet.Cells[row, column + 1] = playground.Value.ToString();
                worksheet.Cells[row, column + 2] = tonality;
                row++;
            }

            column += 4;//разделение
            row = 2;
            worksheet.Cells[1, column] = "Инфоповоды_название";
            worksheet.Cells[1, column + 1] = "Инфоповоды_количество";
            worksheet.Cells[1, column + 2] = "Инфоповоды_площадка";
            worksheet.Cells[1, column + 3] = "Инфоповоды_ссылка";
            foreach (var infoOccasion in tonalityData.infoOccasionPlaygroundPSubs)
            {
                worksheet.Cells[row, column + 3] = tonalityData.infoOccasionLinks[infoOccasion.Key].Key;
                foreach (var playground in infoOccasion.Value)
                {
                    worksheet.Cells[row, column] = infoOccasion.Key;
                    worksheet.Cells[row, column + 1] = playground.Value.ToString();
                    worksheet.Cells[row, column + 2] = playground.Key;
                    row++;
                }
            }

            column += 5;//разделение
            row = 2;
            worksheet.Cells[1, column] = "Проекты_название";
            worksheet.Cells[1, column + 1] = "Проекты_количество";
            worksheet.Cells[1, column + 2] = "Проекты_тональность";
            foreach (var project in tonalityData.projectsPSubs)
            {
                worksheet.Cells[row, column] = project.Key;
                worksheet.Cells[row, column + 1] = project.Value.ToString();
                worksheet.Cells[row, column + 2] = tonality;
                row++;
            }

        }

        private static void WriteDynamicData(DynamicData dynamicData, Microsoft.Office.Interop.Excel._Application app)
        {
            Microsoft.Office.Interop.Excel.Worksheet worksheet = app.Worksheets.Add(Type.Missing);
            dynamicData.Sort();
            worksheet.Name = "Динамика";
            int column = 1;
            int row = 2;
            worksheet.Cells[1, column] = "Дата";
            foreach(var val in dynamicData.data)
            {
                worksheet.Cells[row, column] = val.Key;
                worksheet.Cells[row + 1, column] = val.Key;
                worksheet.Cells[row + 2, column] = val.Key;
                row += 3;
            }

            column++;
            row = 2;
            worksheet.Cells[1, column] = "Общее_количество";
            worksheet.Cells[1, column + 1] = "Общее_тональность";
            foreach (var val in dynamicData.data)
            {
                worksheet.Cells[row, column] = val.Value.generalData.positive;
                worksheet.Cells[row + 1, column] = val.Value.generalData.negative;
                worksheet.Cells[row + 2, column] = val.Value.generalData.neutral;
                worksheet.Cells[row, column + 1] = "Позитивная";
                worksheet.Cells[row + 1, column + 1] = "Негативная";
                worksheet.Cells[row + 2, column + 1] = "Нейтральная";
                row += 3;
            }

            column += 3;//разделение
            row = 2;
            worksheet.Cells[1, column] = "Позитивная_количество";
            worksheet.Cells[1, column + 1] = "Позитивная_тональность";
            foreach (var val in dynamicData.data)
            {
                worksheet.Cells[row, column] = val.Value.positiveData.ToString();
                worksheet.Cells[row, column + 1] = "Позитивная";
                row += 3;
            }

            column += 3;//разделение
            row = 2;
            worksheet.Cells[1, column] = "Негативная_количество";
            worksheet.Cells[1, column + 1] = "Негативная_тональность";
            foreach (var val in dynamicData.data)
            {
                worksheet.Cells[row, column] = val.Value.negativeData.ToString();
                worksheet.Cells[row, column + 1] = "Негативная";
                row += 3;
            }

            column += 3;//разделение
            row = 2;
            worksheet.Cells[1, column] = "Нейтральная_количество";
            worksheet.Cells[1, column + 1] = "Нейтральная_тональность";
            foreach (var val in dynamicData.data)
            {
                worksheet.Cells[row, column] = val.Value.neutralData.ToString();
                worksheet.Cells[row, column + 1] = "Нейтральная";
                row += 3;
            }

            column += 3;//разделение
            int columnStart = column;
            int rowStart = 2;
            foreach(var date in dynamicData.data)
            {
                column = columnStart;
                foreach(var project in date.Value.projectsData)
                {
                    row = rowStart;
                    worksheet.Cells[1, column] = project.Key + "_количество";
                    worksheet.Cells[1, column + 1] = project.Key + "_тональность";

                    worksheet.Cells[row, column] = project.Value.positive.ToString();
                    worksheet.Cells[row + 1, column] = project.Value.negative.ToString();
                    worksheet.Cells[row + 2, column] = project.Value.neutral.ToString();

                    worksheet.Cells[row, column + 1] = "Позитивная";
                    worksheet.Cells[row + 1, column + 1] = "Негативная";
                    worksheet.Cells[row + 2, column + 1] = "Нейтральная";
                    column += 3;//разделение
                }
                rowStart += 3;
            }
        }
        public static void SaveAsExcelFile(Statistic statistic, string path)
        {
            Microsoft.Office.Interop.Excel._Application app = null;
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
            }
            catch (Exception err)
            {
                throw new Exception("Не удалось открыть приложение Microsoft Excel");
            }
            try
            {
                Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
                WriteDynamicData(statistic.dynamicData, app);
                for (int i = 0; i < statistic.projects.Count; i++)
                {
                    WriteProjectData(statistic.projects[i], app);
                }
                WriteTonalityGeneralData(statistic.neutralData, app, "Нейтральная");
                WriteTonalityGeneralData(statistic.negativeData, app, "Негативная");
                WriteTonalityGeneralData(statistic.positiveData, app, "Позитивная");
                WriteGeneralData(statistic.generalData, app);
                WriteSocialNetworksData(statistic.socialNetworkData, app);
                workbook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                if (app != null) app.Quit();
            }
            catch (Exception err)
            {
                if (app != null) app.Quit();
                MessageBox.Show(err.ToString());
                throw new Exception(err.Message);//"Не удалось записать файл");
            }
        }
        /*
        public static void SaveAsExcelFile(List<ProjectData> projects, string path)
        {
            Microsoft.Office.Interop.Excel._Application app = null;
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
            }
            catch(Exception err)
            {
                throw new Exception("Не удалось открыть приложение Microsoft Excel");
            }
            try
            {
                Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
                for(int i = 0;i < projects.Count; i++)
                {
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = app.Worksheets.Add(Type.Missing);
                    worksheet.Name = "Проект_" + (i+1).ToString();
                    int column = 1;
                    worksheet.Cells[1, column] = "Название_проекта";
                    worksheet.Cells[2, column] = projects[i].name;

                    column += 1;
                    worksheet.Cells[1, column] = "Просмотры_Позитив";
                    worksheet.Cells[1, column + 1] = "Просмотры_Негатив";
                    worksheet.Cells[1, column + 2] = "Просмотры_Нейтрал";
                    worksheet.Cells[2, column] = projects[i].views.positive.ToString();
                    worksheet.Cells[2, column + 1] = projects[i].views.negative.ToString();
                    worksheet.Cells[2, column + 2] = projects[i].views.neutral.ToString();

                    column += 3;
                    worksheet.Cells[1, column] = "Упоминания_Позитив";
                    worksheet.Cells[1, column + 1] = "Упоминания_Негатив";
                    worksheet.Cells[1, column + 2] = "Упоминания_Нейтрал";
                    worksheet.Cells[2, column] = projects[i].mentions.positive.ToString();
                    worksheet.Cells[2, column + 1] = projects[i].mentions.negative.ToString();
                    worksheet.Cells[2, column + 2] = projects[i].mentions.neutral.ToString();

                    column += 3;
                    worksheet.Cells[1, column] = "Площадки";
                    worksheet.Cells[1, column + 1] = "Площадки_Позитив";
                    worksheet.Cells[1, column + 2] = "Площадки_Негатив";
                    worksheet.Cells[1, column + 3] = "Площадки_Нейтрал";
                    int row = 2;
                    foreach(var playground in projects[i].playgroundsSubs)
                    {
                        worksheet.Cells[row, column] = playground.Key;
                        worksheet.Cells[row, column + 1] = playground.Value.positive.ToString();
                        worksheet.Cells[row, column + 2] = playground.Value.negative.ToString();
                        worksheet.Cells[row, column + 3] = playground.Value.neutral.ToString();
                        row++;
                    }

                    column += 4;
                    worksheet.Cells[1, column] = "Подпроекты";
                    worksheet.Cells[1, column + 1] = "Подпроекты_Позитив";
                    worksheet.Cells[1, column + 2] = "Подпроекты_Негатив";
                    worksheet.Cells[1, column + 3] = "Подпроекты_Нейтрал";
                    row = 2;
                    foreach (var subproject in projects[i].subProjectsPSubs)
                    {
                        worksheet.Cells[row, column] = subproject.Key;
                        worksheet.Cells[row, column + 1] = subproject.Value.positive.ToString();
                        worksheet.Cells[row, column + 2] = subproject.Value.negative.ToString();
                        worksheet.Cells[row, column + 3] = subproject.Value.neutral.ToString();
                        row++;
                    }

                    column += 4;
                    worksheet.Cells[1, column] = "Инфоповоды";
                    worksheet.Cells[1, column + 1] = "Инфоповоды_Позитив";
                    worksheet.Cells[1, column + 2] = "Инфоповоды_Негатив";
                    worksheet.Cells[1, column + 3] = "Инфоповоды_Нейтрал";
                    row = 2;
                    foreach (var infooccasion in projects[i].infoOccasionPSubs)
                    {
                        worksheet.Cells[row, column] = infooccasion.Key;
                        worksheet.Cells[row, column + 1] = infooccasion.Value.positive.ToString();
                        worksheet.Cells[row, column + 2] = infooccasion.Value.negative.ToString();
                        worksheet.Cells[row, column + 3] = infooccasion.Value.neutral.ToString();
                        row++;
                    }

                    column += 4;
                    worksheet.Cells[1, column] = "Динамика";
                    worksheet.Cells[1, column + 1] = "Динамика_Позитив";
                    worksheet.Cells[1, column + 2] = "Динамика_Негатив";
                    worksheet.Cells[1, column + 3] = "Динамика_Нейтрал";
                    row = 2;
                    foreach (var date in projects[i].datePSubs)
                    {
                        worksheet.Cells[row, column] = date.Key;
                        worksheet.Cells[row, column + 1] = date.Value.positive.ToString();
                        worksheet.Cells[row, column + 2] = date.Value.negative.ToString();
                        worksheet.Cells[row, column + 3] = date.Value.neutral.ToString();
                        row++;
                    }
                }
                workbook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                 }
            catch (Exception err)
            {
                if (app != null) app.Quit();
                throw new Exception(err.Message);//"Не удалось записать файл");
            }
        }
        */
        /*
        private static void WriteProject(Worksheet worksheet, ProjectData project)
        {
            int column = 1;
            worksheet.Cells[1, column] = "Название";
            worksheet.Cells[2, column] = project.name;

            column += 1;
            worksheet.Cells[1, column] = "Просмотры_количество";
            worksheet.Cells[1, column + 1] = "Просмотры_тональность";
            worksheet.Cells[2, column] = project.views.positive.ToString();
            worksheet.Cells[3, column] = project.views.negative.ToString();
            worksheet.Cells[4, column] = project.views.neutral.ToString();
            worksheet.Cells[2, column + 1] = "Позитивные";
            worksheet.Cells[3, column + 1] = "Негативные";
            worksheet.Cells[4, column + 1] = "Нейтральные";

            column += 2;
            worksheet.Cells[1, column] = "Упоминания_количество";
            worksheet.Cells[1, column + 1] = "Упоминания_тональность";
            worksheet.Cells[2, column] = project.mentions.positive.ToString();
            worksheet.Cells[3, column] = project.mentions.negative.ToString();
            worksheet.Cells[4, column] = project.mentions.neutral.ToString();
            worksheet.Cells[2, column + 1] = "Позитивные";
            worksheet.Cells[3, column + 1] = "Негативные";
            worksheet.Cells[4, column + 1] = "Нейтральные";

            column += 2;
            worksheet.Cells[1, column] = "Площадки_названия";
            worksheet.Cells[1, column + 1] = "Площадки_количество";
            worksheet.Cells[1, column + 2] = "Площадки_тональность";
            int row = 2;
            foreach (var playground in project.playgroundsSubs)
            {
                worksheet.Cells[row, column] = playground.Key;
                worksheet.Cells[row + 1, column] = playground.Key;
                worksheet.Cells[row + 2, column] = playground.Key;
                worksheet.Cells[row, column + 1] = playground.Value.positive.ToString();
                worksheet.Cells[row + 1, column + 1] = playground.Value.negative.ToString();
                worksheet.Cells[row + 2, column + 1] = playground.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Позитивные";
                worksheet.Cells[row + 1, column + 2] = "Негативные";
                worksheet.Cells[row + 2, column + 2] = "Нейтральные";
                row += 3;
            }

            column += 3;
            worksheet.Cells[1, column] = "Подпроекты_названия";
            worksheet.Cells[1, column + 1] = "Подпроекты_количество";
            worksheet.Cells[1, column + 2] = "Подпроекты_тональность";
            row = 2;
            foreach (var subproject in project.subProjectsPSubs)
            {
                worksheet.Cells[row, column] = subproject.Key;
                worksheet.Cells[row + 1, column] = subproject.Key;
                worksheet.Cells[row + 2, column] = subproject.Key;
                worksheet.Cells[row, column + 1] = subproject.Value.positive.ToString();
                worksheet.Cells[row + 1, column + 1] = subproject.Value.negative.ToString();
                worksheet.Cells[row + 2, column + 1] = subproject.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Позитивные";
                worksheet.Cells[row + 1, column + 2] = "Негативные";
                worksheet.Cells[row + 2, column + 2] = "Нейтральные";
                row += 3;
            }

            column += 3;
            worksheet.Cells[1, column] = "Инфоповоды_названия";
            worksheet.Cells[1, column + 1] = "Инфоповоды_количество";
            worksheet.Cells[1, column + 2] = "Инфоповоды_тональность";
            row = 2;
            foreach (var infooccasion in project.infoOccasionPSubs)
            {
                worksheet.Cells[row, column] = infooccasion.Key;
                worksheet.Cells[row + 1, column] = infooccasion.Key;
                worksheet.Cells[row + 2, column] = infooccasion.Key;
                worksheet.Cells[row, column + 1] = infooccasion.Value.positive.ToString();
                worksheet.Cells[row + 1, column + 1] = infooccasion.Value.negative.ToString();
                worksheet.Cells[row + 2, column + 1] = infooccasion.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Позитивные";
                worksheet.Cells[row + 1, column + 2] = "Негативные";
                worksheet.Cells[row + 2, column + 2] = "Нейтральные";
                row += 3;
            }

            column += 3;
            worksheet.Cells[1, column] = "Динамика_названия";
            worksheet.Cells[1, column + 1] = "Динамика_количество";
            worksheet.Cells[1, column + 2] = "Динамика_тональность";
            row = 2;
            foreach (var date in project.datePSubs)
            {
                worksheet.Cells[row, column] = date.Key;
                worksheet.Cells[row + 1, column] = date.Key;
                worksheet.Cells[row + 2, column] = date.Key;
                worksheet.Cells[row, column + 1] = date.Value.positive.ToString();
                worksheet.Cells[row + 1, column + 1] = date.Value.negative.ToString();
                worksheet.Cells[row + 2, column + 1] = date.Value.neutral.ToString();
                worksheet.Cells[row, column + 2] = "Позитивные";
                worksheet.Cells[row + 1, column + 2] = "Негативные";
                worksheet.Cells[row + 2, column + 2] = "Нейтральные";
                row += 3;
            }
        }
        public static void SaveAsExcelFile2(Statistic statistic, string path)
        {
            Microsoft.Office.Interop.Excel._Application app = null;
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
            }
            catch (Exception err)
            {
                throw new Exception("Не удалось открыть приложение Microsoft Excel");
            }
            try
            {
                Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
                List<ProjectData> projects = statistic.projects;
                for (int i = 0; i < projects.Count; i++)
                {
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = app.Worksheets.Add(Type.Missing);
                    worksheet.Name = "Проект" + (i + 1).ToString();
                    WriteProject(worksheet, projects[i]);
                }
                Microsoft.Office.Interop.Excel.Worksheet worksheetSum = app.Worksheets.Add(Type.Missing);
                worksheetSum.Name = "Общая";
                WriteProject(worksheetSum, statistic.projectsSum);

                workbook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception err)
            {
                if (app != null) app.Quit();
                throw new Exception(err.Message);//"Не удалось записать файл");
            }
        }*/
        public static void SaveDataAsJson(List<ProjectData> projects, string path)
        {
            var f = File.Create(path);
            f.Close();
            StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Open, FileAccess.ReadWrite), Encoding.UTF8);
            string jsonStr = JsonConvert.SerializeObject(projects[0]);
            sw.Write(jsonStr);
            sw.Close();
        }
        public static void CreateErrorLog(string errorMessage)
        {
            try
            {
                var f = File.Create("error_logs.txt");
                f.Close();
                StreamWriter sw = new StreamWriter(new FileStream("error_logs.txt", FileMode.Open, FileAccess.ReadWrite), Encoding.UTF8);
                sw.Write(errorMessage);
                sw.Close();
            }catch(Exception e) { }
            
            
        }
    }
    
}
