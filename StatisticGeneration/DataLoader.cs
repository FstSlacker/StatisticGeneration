using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticGeneration
{
    public static class DataLoader
    {
        public static string[] LoadColumnsTitles(string path)
        {
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet dataSet = excelReader.AsDataSet();
            string[] columns = new string[dataSet.Tables[0].Columns.Count];
            for(int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                columns[i] = dataSet.Tables[0].Rows[0][i].ToString();
            }
            stream.Close();
            excelReader.Close();
            return columns;
        }
        public static Statistic LoadAndApplyData(string path, DataLoadParameters parameters)
        {
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet dataSet = excelReader.AsDataSet();

            List<ProjectData> projects = new List<ProjectData>();
            GeneralData generalData = new GeneralData();
            TonalityGeneralData positiveData = new TonalityGeneralData();
            TonalityGeneralData negativeData = new TonalityGeneralData();
            TonalityGeneralData neutralData = new TonalityGeneralData();
            DynamicData dynamicData = new DynamicData();
            SocialNetworksData socialNetworksData = new SocialNetworksData();

            positiveData.name = "Позитивное информационное поле";
            negativeData.name = "Негативное информационное поле";
            neutralData.name = "Нейтральное информационное поле";
            generalData.name = "Общее информационное поле";

            foreach (var project in parameters.projectColumns)
            {
                ProjectData projectData = new ProjectData();
                projectData.name = project.Key;

                generalData.projectsPSubs.Add(project.Key, new Tonality());
                generalData.projectsPSubsGroups.Add(project.Key, new Dictionary<string, GroupInfo>());

                positiveData.projectsPSubs.Add(project.Key, 0);
                positiveData.projectsPSubsGroups.Add(project.Key, new HashSet<string>());

                negativeData.projectsPSubs.Add(project.Key, 0);
                negativeData.projectsPSubsGroups.Add(project.Key, new HashSet<string>());

                neutralData.projectsPSubs.Add(project.Key, 0);
                neutralData.projectsPSubsGroups.Add(project.Key, new HashSet<string>());

                projects.Add(projectData);
            }

            DataTable table = dataSet.Tables[0];
            for (int i = 1; i < table.Rows.Count; i++)
            {
                string subsStr = table.Rows[i][parameters.subsColumn].ToString();
                subsStr = Regex.Replace(subsStr, "[^0-9]+$", "");
                if (subsStr.Equals("")) subsStr = "0";
                int subs = Convert.ToInt32(subsStr);

                string group = table.Rows[i][parameters.groupColumn].ToString();
                string playground = table.Rows[i][parameters.playgroundColumn].ToString();
                string tonality = table.Rows[i][parameters.tonalityColumn].ToString();
                string infoOccasion = table.Rows[i][parameters.infoOccasionColumn].ToString();
                string date = table.Rows[i][parameters.dateColumn].ToString();
                string link = table.Rows[i][parameters.linkColumn].ToString();

                string reactions = table.Rows[i][parameters.reactionsColumn].ToString();
                string comments = table.Rows[i][parameters.commentsColumn].ToString();
                string reposts = table.Rows[i][parameters.repostsColumn].ToString();
                string author = table.Rows[i][parameters.authorColumn].ToString();

                reactions = Regex.Replace(reactions, "[^0-9]+$", "");
                reactions = reactions.Equals("") ? "0" : reactions;

                comments = Regex.Replace(comments, "[^0-9]+$", "");
                comments = comments.Equals("") ? "0" : comments;

                reposts = Regex.Replace(reposts, "[^0-9]+$", "");
                reposts = reposts.Equals("") ? "0" : reposts;

                int reactionsInt = Convert.ToInt32(reactions);
                int commentsInt = Convert.ToInt32(comments);
                int repostsInt = Convert.ToInt32(reposts);

                int involvementsInt = reactionsInt + commentsInt + repostsInt;


                //Apply data
                generalData.mentions.AddStr(tonality, 1);
                generalData.AddPSubs(group, subs, tonality);
                generalData.AddInfoOccasionPSubs(infoOccasion, group, subs, tonality, link);
                socialNetworksData.AddSocialNetwork(playground, involvementsInt, tonality, subs, group);

                switch (Tonality.ConvertToInt(tonality))
                {
                    case 0:
                        positiveData.AddPlaygroundMentions(playground, 1);
                        positiveData.AddPlaygroundPSubs(playground, group, subs);
                        positiveData.AddInfoOccasionPlaygroundPSubs(infoOccasion, playground, group, subs, link);
                        break;
                    case 1:
                        negativeData.AddPlaygroundMentions(playground, 1);
                        negativeData.AddPlaygroundPSubs(playground, group, subs);
                        negativeData.AddInfoOccasionPlaygroundPSubs(infoOccasion, playground, group, subs, link);
                        break;
                    case 2:
                        neutralData.AddPlaygroundMentions(playground, 1);
                        neutralData.AddPlaygroundPSubs(playground, group, subs);
                        neutralData.AddInfoOccasionPlaygroundPSubs(infoOccasion, playground, group, subs, link);
                        break;
                }
                dynamicData.AddDynamicGeneral(date, tonality, group, subs);
                dynamicData.AddDynamicGeneralTonality(date, group, tonality, subs);
                dynamicData.AddInvolvements(date, tonality, involvementsInt);

                for (int j = 0; j < projects.Count; j++)
                {
                    string project = table.Rows[i][parameters.projectColumns[projects[j].name]].ToString();
                    generalData.AddProjectPSubs(project, group, subs, tonality);

                    switch (Tonality.ConvertToInt(tonality))
                    {
                        case 0:
                            positiveData.AddProjectsPSubs(project, group, subs);
                            break;
                        case 1:
                            negativeData.AddProjectsPSubs(project, group, subs);
                            break;
                        case 2:
                            neutralData.AddProjectsPSubs(project, group, subs);
                            break;
                    }

                    if (!project.Equals(""))
                    {
                        dynamicData.AddProject(date, project, tonality, group, subs);
                        projects[j].AddPSubs(group, tonality, subs);
                        projects[j].AddInfoOccasionPSubs(infoOccasion, link, group, tonality, subs);
                        projects[j].mentions.AddStr(tonality, 1);
                        projects[j].involvement.AddStr(tonality, involvementsInt);
                        projects[j].AddPlaygroundMentions(playground, tonality, 1);

                        projects[j].posts.Add(new PostData() { link = link, likes = reactions, reposts = reposts, comments = comments, tonality = tonality, involvements = involvementsInt.ToString(), author = author });
                    }

                }
            }
            generalData.SplitGroupSubs();
            dynamicData.SplitGroupSubs();
            socialNetworksData.SplitGroupSubs();
            //Sort projects on dynamic data
            var keyList = dynamicData.data.Keys.ToArray();
            for(int i = 0; i < keyList.Length; i++)
            {
                dynamicData.data[keyList[i]].SortProjects();
            }
            //-----------------------------

            for(int i = 0; i < projects.Count; i++)
            {
                projects[i].SplitGroupSubs();
            }
            stream.Close();
            excelReader.Close();
            return new Statistic() { projects = projects, generalData = generalData, positiveData = positiveData, negativeData = negativeData, neutralData = neutralData, dynamicData = dynamicData, socialNetworkData=socialNetworksData};
        }
    }
}
