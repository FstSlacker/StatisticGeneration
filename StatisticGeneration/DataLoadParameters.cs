using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public struct ProjectParameters{
        public int column;
        public Dictionary<string, int> subprojectColumns;
    }
    public class DataLoadParameters
    {
        public Dictionary<string, int> projectColumns;
        public int groupColumn;
        public int subsColumn;
        public int infoOccasionColumn;
        public int viewsColumn;
        public int playgroundColumn;
        public int tonalityColumn;
        public int dateColumn;
        public int linkColumn;
        public int reactionsColumn;
        public int commentsColumn;
        public int repostsColumn;
        public void SetReactionsColumn(string columnName)
        {
            reactionsColumn = ColumnNameToNumber(columnName);
        }
        public void SetCommentsColumn(string columnName)
        {
            commentsColumn = ColumnNameToNumber(columnName);
        }
        public void SetRepostsColumn(string columnName)
        {
            repostsColumn = ColumnNameToNumber(columnName);
        }
        public void SetGroupColumn(string columnName)
        {
            groupColumn = ColumnNameToNumber(columnName);
        }
        public void SetSubsColumn(string columnName)
        {
            subsColumn = ColumnNameToNumber(columnName);
        }
        public void SetInfoOccasionColumn(string columnName)
        {
            infoOccasionColumn = ColumnNameToNumber(columnName);
        }
        public void SetViewsColumn(string columnName)
        {
            viewsColumn = ColumnNameToNumber(columnName);
        }
        public void SetPlaygroundColumn(string columnName)
        {
            playgroundColumn = ColumnNameToNumber(columnName);
        }
        public void SetTonalityColumn(string columnName)
        {
            tonalityColumn = ColumnNameToNumber(columnName);
        }
        public void SetDateColumn(string columnName)
        {
            dateColumn = ColumnNameToNumber(columnName);
        }
        public void SetLinkColumn(string columnName)
        {
            linkColumn = ColumnNameToNumber(columnName);
        }
        /*
        private void AddProjectColumn(string columnName, string name)
        {
            if (!projectColumns.ContainsKey(name))
            {
                ProjectParameters projectParams;
                projectParams.column = ColumnNameToNumber(columnName);
                projectParams.subprojectColumns = new Dictionary<string, int>();
                projectColumns.Add(name, projectParams);
            }
        }
        private void AddSubProjectColumn(string columnName, string projectName, string subProjectName)
        {
            if (projectColumns.ContainsKey(projectName))
            {
                if (!projectColumns[projectName].subprojectColumns.ContainsKey(subProjectName))
                {
                    projectColumns[projectName].subprojectColumns.Add(subProjectName, ColumnNameToNumber(columnName));
                }
            }
        }
        */
        /*
        private bool CheckField(string field)
        {
            int scopes = 0;
            for(int i = 0; i < field.Length; i++)
            {
                if (field[i] == '(') scopes++;
                if (field[i] == ')') scopes--;
                if(scopes > 1 || scopes < -1)
                {
                    return false;
                }
                if(field[i] < 'A' || field[i] > 'Z' || field[i] != ';' || field[i] != ',' || field[i] != ':' || field[i] != '(' || field[i] != ')')
                {
                    return false;
                }
            }
            return true;
        }*/
        public void SetProjectsColumns(string columnsNames, string[] columnTitles)
        {
            columnsNames = columnsNames.ToUpper();
            //columnsNames = Regex.Replace(columnsNames, "[^A-Z,()]")
            columnsNames = columnsNames.Replace(" ", "");
            projectColumns = new Dictionary<string, int>();
            string[] projectColumnsStr = columnsNames.Split(',');
            for (int i = 0; i < projectColumnsStr.Length; i++)
            {
                int columnInd = ColumnNameToNumber(projectColumnsStr[i]);
                projectColumns.Add(columnTitles[columnInd], columnInd);
            }
        }
        /*
        public void SetProjectsColumns(string columnsNames, string[] columnTitles)
        {
            columnsNames = columnsNames.ToUpper();
            //if (!CheckField(columnsNames)) throw new Exception("Ошибка правильности поля.");
            //columnsNames = Regex.Replace(columnsNames, "[^A-Z,()]")
            projectColumns = new Dictionary<string, ProjectParameters>();
            string[] projectColumnsStr = columnsNames.Split(';');
            for(int i = 0; i < projectColumnsStr.Length; i++)
            {
                string[] projectStr = projectColumnsStr[i].Split('(');

                int columnInd = ColumnNameToNumber(projectStr[0]);
                ProjectParameters pp;
                pp.column = columnInd;
                pp.subprojectColumns = new Dictionary<string, int>();
                projectColumns.Add(columnTitles[columnInd], pp);
                if(projectStr.Length > 1)
                {
                    string subprojectStr = projectStr[1];
                    subprojectStr = subprojectStr.Replace(")", "");
                    string[] subprojectsColumns = subprojectStr.Split(',');
                    for(int j = 0;j< subprojectsColumns.Length; j++)
                    {
                        if (subprojectsColumns[j].Contains(':'))
                        {
                            for(int k = ColumnNameToNumber(subprojectsColumns[j].Split(':')[0]); k<= ColumnNameToNumber(subprojectsColumns[j].Split(':')[1]); k++)
                            {
                                projectColumns[columnTitles[columnInd]].subprojectColumns.Add(columnTitles[k], k);
                            }
                        }
                        else
                        {
                            int subPrjInd = ColumnNameToNumber(subprojectsColumns[j]);
                            projectColumns[columnTitles[columnInd]].subprojectColumns.Add(columnTitles[subPrjInd], subPrjInd);
                        }
                        
                    }
                }
            }
        }
        */
        private static int ColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("Название столбца не должно быть пустым.");
            columnName = columnName.ToUpperInvariant();
            int sum = 0;
            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }
            return (sum-1);
        }
    }
}
