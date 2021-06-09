using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class DynamicContent
    {
        public Tonality generalData = new Tonality();
        public int positiveData = 0;
        public int negativeData = 0;
        public int neutralData = 0;
        public Dictionary<string, Tonality> projectsData = new Dictionary<string, Tonality>();

        //Groups dicts
        private Dictionary<string, GroupInfo> generalDataGroups = new Dictionary<string, GroupInfo>();
        private HashSet<string> positiveDataGroups = new HashSet<string>();
        private HashSet<string> negativeDataGroups = new HashSet<string>();
        private HashSet<string> neutralDataGroups = new HashSet<string>();
        private Dictionary<string, Dictionary<string, GroupInfo>> projectsDataGroups = new Dictionary<string, Dictionary<string, GroupInfo>>();

        public void AddGeneralData(string tonality, string group, int subs)
        {
            if (!generalDataGroups.ContainsKey(group))
            {
                generalDataGroups.Add(group, new GroupInfo(group, subs, tonality));
                generalData.AddStr(tonality, subs);
            }
            else
            {
                generalDataGroups[group].AddMentions(tonality);
            }
        }
        public void AddPositiveData(string group, int subs)
        {
            if (!positiveDataGroups.Contains(group))
            {
                positiveDataGroups.Add(group);
                positiveData += subs;
            }
        }
        public void AddNegativeData(string group, int subs)
        {
            if (!negativeDataGroups.Contains(group))
            {
                negativeDataGroups.Add(group);
                negativeData += subs;
            }
        }
        public void AddNeutralData(string group, int subs)
        {
            if (!neutralDataGroups.Contains(group))
            {
                neutralDataGroups.Add(group);
                neutralData += subs;
            }
        }
        public void AddProjectsData(string project, string tonality, string group, int subs)
        {
            if (projectsData.ContainsKey(project))
            {
                if (!projectsDataGroups[project].ContainsKey(group))
                {
                    projectsDataGroups[project].Add(group, new GroupInfo(group, subs, tonality));
                    projectsData[project].AddStr(tonality, subs);
                }
                else
                {
                    projectsDataGroups[project][group].AddMentions(tonality);
                }
            }
            else
            {
                projectsData.Add(project, new Tonality());
                projectsDataGroups.Add(project, new Dictionary<string, GroupInfo>());

                projectsData[project].AddStr(tonality, subs);
                projectsDataGroups[project].Add(group, new GroupInfo(group, subs, tonality));
            }
        }
        public void SplitGroupSubs()
        {
            Tonality sumTonality = new Tonality();
            foreach (var groupSubs in generalDataGroups)
            {
                sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
            }
            generalData = sumTonality;

            var keysArray = projectsData.Keys.ToArray();
            foreach (var project in keysArray)
            {
                sumTonality = new Tonality();
                foreach (var groupSubs in projectsDataGroups[project])
                {
                    sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
                }
                projectsData[project] = sumTonality;
            }
        }
        public void SortProjects()
        {
            var sortedList = projectsData.ToList();
            sortedList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
            projectsData = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
    }
}
