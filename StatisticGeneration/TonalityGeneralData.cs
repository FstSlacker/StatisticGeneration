using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class TonalityGeneralData
    {
        public string name;

        //Statistic dicts
        public Dictionary<string, int> playgroundMentions = new Dictionary<string, int>();
        public Dictionary<string, int> playgroundPSubs = new Dictionary<string, int>();
        public Dictionary<string, Dictionary<string, int>> infoOccasionPlaygroundPSubs = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<string, int> projectsPSubs = new Dictionary<string, int>();
        public Dictionary<string, KeyValuePair<string, int>> infoOccasionLinks = new Dictionary<string, KeyValuePair<string, int>>();

        //Groups dicts
        public Dictionary<string, HashSet<string>> playgroundPSubsGroups = new Dictionary<string, HashSet<string>>();
        public Dictionary<string, HashSet<string>> infoOccasionPlaygroundPSubsGroups = new Dictionary<string, HashSet<string>>();
        public Dictionary<string, HashSet<string>> projectsPSubsGroups = new Dictionary<string, HashSet<string>>();

        public void AddPlaygroundMentions(string playground, int mentions)
        {
            if (!playgroundMentions.ContainsKey(playground))
            {
                playgroundMentions.Add(playground, 0);
            }
            playgroundMentions[playground] += mentions;
        }
        public void AddPlaygroundPSubs(string playground, string group, int subs)
        {
            if (playgroundPSubs.ContainsKey(playground))
            {
                if (!playgroundPSubsGroups[playground].Contains(group))
                {
                    playgroundPSubs[playground] += subs;
                    playgroundPSubsGroups[playground].Add(group);
                }
            }
            else
            {
                playgroundPSubs.Add(playground, 0);
                playgroundPSubsGroups.Add(playground, new HashSet<string>());

                playgroundPSubs[playground] += subs;
                playgroundPSubsGroups[playground].Add(group);
            }
        }
        public void AddInfoOccasionPlaygroundPSubs(string infoOccasion, string playground, string group, int subs, string link)
        {
            if (infoOccasion.Equals("")) return;
            if (infoOccasionPlaygroundPSubs.ContainsKey(infoOccasion))
            {
                if (!infoOccasionPlaygroundPSubs[infoOccasion].ContainsKey(playground))
                {
                    infoOccasionPlaygroundPSubs[infoOccasion].Add(playground, 0);
                }
                if (!infoOccasionPlaygroundPSubsGroups[infoOccasion].Contains(group))
                {
                    infoOccasionPlaygroundPSubs[infoOccasion][playground] += subs;
                    infoOccasionPlaygroundPSubsGroups[infoOccasion].Add(group);
                    if(subs > infoOccasionLinks[infoOccasion].Value)
                    {
                        infoOccasionLinks[infoOccasion] = new KeyValuePair<string, int>(link, subs);
                    }
                }
            }
            else
            {
                infoOccasionPlaygroundPSubs.Add(infoOccasion, new Dictionary<string, int>());
                infoOccasionPlaygroundPSubsGroups.Add(infoOccasion, new HashSet<string>());
                infoOccasionLinks.Add(infoOccasion, new KeyValuePair<string, int>(link, subs));

                infoOccasionPlaygroundPSubs[infoOccasion].Add(playground, subs);
                infoOccasionPlaygroundPSubsGroups[infoOccasion].Add(group);
            }
        }
        public void AddProjectsPSubs(string project, string group, int subs)
        {
            if (project.Equals("")) return;
            if (projectsPSubs.ContainsKey(project))
            {
                if (!projectsPSubsGroups[project].Contains(group))
                {
                    projectsPSubs[project] += subs;
                    projectsPSubsGroups[project].Add(group);
                }
            }
            else
            {
                projectsPSubs.Add(project, subs);
                projectsPSubsGroups.Add(project, new HashSet<string>());

                projectsPSubsGroups[project].Add(group);
            }
        }
        private void SortPlaygroundMentions()
        {
            var sortedList = playgroundMentions.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            playgroundMentions = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        private void SortPlaygroundPSubs()
        {
            var sortedList = playgroundPSubs.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            playgroundPSubs = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        private void SortProjectsPSubs()
        {
            var sortedList = projectsPSubs.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            projectsPSubs = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        private void SortInfoOccasionPlaygroundPSubs()
        {
            var sortedList = infoOccasionPlaygroundPSubs.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.Values.Sum().CompareTo(pair1.Value.Values.Sum()));
            infoOccasionPlaygroundPSubs = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        public void Sort()
        {
            SortPlaygroundMentions();
            SortPlaygroundPSubs();
            SortProjectsPSubs();
            SortInfoOccasionPlaygroundPSubs();
        }
    }
}
