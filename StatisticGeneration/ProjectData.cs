using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class PostData
    {
        public string link;
        public string likes;
        public string comments;
        public string reposts;
        public string involvements;
        public string tonality;
        public string author;
    }
    public class ProjectData
    {
        public string name;
        
        //Statistic
        public Tonality mentions = new Tonality();//Упоминания
        public Tonality psubs = new Tonality();
        public Tonality involvement = new Tonality();//Вовлечённость
        public Dictionary<string, Tonality> playgroundMentions = new Dictionary<string, Tonality>();
        public Dictionary<string, Tonality> infoOccasionPSubs = new Dictionary<string, Tonality>();
        public Dictionary<string, KeyValuePair<string, int>> infoOccasionLinks = new Dictionary<string, KeyValuePair<string, int>>();
        public List<PostData> posts = new List<PostData>();
        //Groups dicts
        public Dictionary<string, GroupInfo> psubsGroups = new Dictionary<string, GroupInfo>();
        public Dictionary<string, Dictionary<string, GroupInfo>> infoOccasionsGroups = new Dictionary<string, Dictionary<string, GroupInfo>>();

        public static string[,] ConvertPostsListToArray(List<PostData> postsData)
        {
            string[,] array = new string[postsData.Count, 7];
            for(int i = 0; i < postsData.Count; i++)
            {
                array[i, 0] = postsData[i].link;
                array[i, 1] = postsData[i].likes;
                array[i, 2] = postsData[i].comments;
                array[i, 3] = postsData[i].reposts;
                array[i, 4] = postsData[i].involvements;
                array[i, 5] = postsData[i].tonality;
                array[i, 6] = postsData[i].author;
            }
            return array;
        }

        public void AddPSubs(string group, string tonality, int subs)
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
        public void AddPlaygroundMentions(string playground, string tonality, int count)
        {
            if (!playgroundMentions.ContainsKey(playground))
            {
                Tonality _tonality = new Tonality();
                _tonality.AddStr(tonality, count);
                playgroundMentions.Add(playground, _tonality);
            }
            else
            {
                playgroundMentions[playground].AddStr(tonality, count);
            }
        }
        public void AddInfoOccasionPSubs(string infoOccasion, string link, string group, string tonality, int subs)
        {
            if (infoOccasion.Equals("")) return;
            if (infoOccasionPSubs.ContainsKey(infoOccasion))
            {
                if (!infoOccasionsGroups[infoOccasion].ContainsKey(group))
                {
                    infoOccasionPSubs[infoOccasion].AddStr(tonality, subs);
                    infoOccasionsGroups[infoOccasion].Add(group, new GroupInfo(group, subs, tonality));
                    if(subs > infoOccasionLinks[infoOccasion].Value)
                    {
                        infoOccasionLinks[infoOccasion] = new KeyValuePair<string, int>(link, subs);
                    }
                }
                else
                {
                    infoOccasionsGroups[infoOccasion][group].AddMentions(tonality);
                }
            }
            else
            {
                infoOccasionPSubs.Add(infoOccasion, new Tonality());
                infoOccasionsGroups.Add(infoOccasion, new Dictionary<string, GroupInfo>());
                infoOccasionPSubs[infoOccasion].AddStr(tonality, subs);
                infoOccasionsGroups[infoOccasion].Add(group, new GroupInfo(group, subs, tonality));
                infoOccasionLinks.Add(infoOccasion, new KeyValuePair<string, int>(link, subs));
            }
        }
        public void SplitGroupSubs()
        {
            Tonality sumTonality = new Tonality();
            foreach (var groupSubs in psubsGroups)
            {
                sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
            }
            psubs = sumTonality;

            var keysArray = infoOccasionPSubs.Keys.ToArray();
            foreach (var infooccasion in keysArray)
            {
                sumTonality = new Tonality();
                foreach (var groupSubs in infoOccasionsGroups[infooccasion])
                {
                    sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
                }
                infoOccasionPSubs[infooccasion] = sumTonality;
            }

        }
        private void SortInfoOccasionPSubs()
        {
            var sortedList = infoOccasionPSubs.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.Sum().CompareTo(pair1.Value.Sum()));
            infoOccasionPSubs = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        private void SortPlaygroundMentions()
        {
            var sortedList = playgroundMentions.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.Sum().CompareTo(pair1.Value.Sum()));
            playgroundMentions = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        public void Sort()
        {
            SortInfoOccasionPSubs();
            SortPlaygroundMentions();
        }
        //public Dictionary<string, HashSet<string>> dateGroups = new Dictionary<string, HashSet<string>>();
        //public Dictionary<string, Tonality> datePSubs = new Dictionary<string, Tonality>();

        //public Dictionary<string, HashSet<string>> subProjectsGroups = new Dictionary<string, HashSet<string>>();
        //public Dictionary<string, Tonality> subProjectsPSubs = new Dictionary<string, Tonality>();
        //public Dictionary<string, HashSet<string>> playgroundsGroups = new Dictionary<string, HashSet<string>>();
        //public Tonality views = new Tonality();
        //public Dictionary<string, Tonality> playgroundsSubs = new Dictionary<string, Tonality>();
    }
}
