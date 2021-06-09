using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class GeneralData
    {
        public string name;

        //Statistic
        public Tonality mentions = new Tonality();
        public Tonality psubs = new Tonality();
        public Dictionary<string, Tonality> infoOccasionPSubs = new Dictionary<string, Tonality>();
        public Dictionary<string, Tonality> projectsPSubs = new Dictionary<string, Tonality>();
        public Dictionary<string, KeyValuePair<string, int>> infoOccasionLinks = new Dictionary<string, KeyValuePair<string, int>>();

        //Groups dicts
        public Dictionary<string, GroupInfo> psubsGroups = new Dictionary<string, GroupInfo>();
        public Dictionary<string, Dictionary<string, GroupInfo>> infoOccasionPSubsGroups = new Dictionary<string, Dictionary<string, GroupInfo>>();
        public Dictionary<string, Dictionary<string, GroupInfo>> projectsPSubsGroups = new Dictionary<string, Dictionary<string, GroupInfo>>();

        public void AddInfoOccasionPSubs(string infoOccasion, string group, int subs, string tonality, string link)
        {
            if (infoOccasion.Equals("")) return;
            if (infoOccasionPSubs.ContainsKey(infoOccasion))
            {
                if (!infoOccasionPSubsGroups[infoOccasion].ContainsKey(group))
                {
                    infoOccasionPSubs[infoOccasion].AddStr(tonality, subs);
                    infoOccasionPSubsGroups[infoOccasion].Add(group, new GroupInfo(group, subs, tonality));
                    if(subs > infoOccasionLinks[infoOccasion].Value)
                    {
                        infoOccasionLinks[infoOccasion] = new KeyValuePair<string, int>(link, subs);
                    }
                }
                else
                {
                    infoOccasionPSubsGroups[infoOccasion][group].AddMentions(tonality);
                }
            }
            else
            {
                infoOccasionPSubs.Add(infoOccasion, new Tonality());
                infoOccasionPSubsGroups.Add(infoOccasion, new Dictionary<string, GroupInfo>());
                infoOccasionLinks.Add(infoOccasion, new KeyValuePair<string, int>(link, subs));
                infoOccasionPSubs[infoOccasion].AddStr(tonality, subs);
                infoOccasionPSubsGroups[infoOccasion].Add(group, new GroupInfo(group, subs, tonality));
            }
        }

        public void AddProjectPSubs(string project, string group, int subs, string tonality)
        {
            if (project.Equals("")) return;
            if (projectsPSubs.ContainsKey(project))
            {
                if (!projectsPSubsGroups[project].ContainsKey(group))
                {
                    projectsPSubs[project].AddStr(tonality, subs);
                    projectsPSubsGroups[project].Add(group, new GroupInfo(group, subs, tonality));
                }
                else
                {
                    projectsPSubsGroups[project][group].AddMentions(tonality);
                }
            }
            else
            {
                projectsPSubs.Add(project, new Tonality());
                projectsPSubsGroups.Add(project, new Dictionary<string, GroupInfo>());
                projectsPSubs[project].AddStr(tonality, subs);
                projectsPSubsGroups[project].Add(group, new GroupInfo(group, subs, tonality));
            }
        }
        public void AddPSubs(string group, int subs, string tonality)
        {
            if (!psubsGroups.ContainsKey(group))
            {
                psubs.AddStr(tonality, subs);
                psubsGroups.Add(group, new GroupInfo(group, subs, tonality));
            }
            else
            {
                psubsGroups[group].AddMentions(tonality);
            }
        }
        public void SplitGroupSubs()
        {
            Tonality sumTonality = new Tonality();
            foreach(var groupSubs in psubsGroups)
            {
                sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
            }
            psubs = sumTonality;

            var keysArray = infoOccasionPSubs.Keys.ToArray();
            foreach(var infooccasion in keysArray)
            {
                sumTonality = new Tonality();
                foreach (var groupSubs in infoOccasionPSubsGroups[infooccasion])
                {
                    sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
                }
                infoOccasionPSubs[infooccasion] = sumTonality;
            }

            keysArray = projectsPSubs.Keys.ToArray();
            foreach (var project in keysArray)
            {
                sumTonality = new Tonality();
                foreach (var groupSubs in projectsPSubsGroups[project])
                {
                    sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
                }
                projectsPSubs[project] = sumTonality;
            }
        }
        private void SortInfoOccasions()
        {
            var sortedList = infoOccasionPSubs.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.Sum().CompareTo(pair1.Value.Sum()));
            infoOccasionPSubs = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        private void SortProjects()
        {
            var sortedList = projectsPSubs.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.Sum().CompareTo(pair1.Value.Sum()));
            projectsPSubs = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        public void Sort()
        {
            SortInfoOccasions();
            SortProjects();
        }

    }
}
