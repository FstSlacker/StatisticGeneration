using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class DynamicData
    {

        public Dictionary<string, DynamicContent> data = new Dictionary<string, DynamicContent>();

        private void AddDate(string date)
        {
            if (!data.ContainsKey(date))
            {
                data.Add(date, new DynamicContent());
            }   
        }
        public void AddDynamicGeneral(string date, string tonality, string group, int subs)
        {
            AddDate(date);
            data[date].AddGeneralData(tonality, group, subs);
        }
        public void SplitGroupSubs()
        {
            var keysArray = data.Keys.ToArray();
            foreach(var dataKey in keysArray)
            {
                data[dataKey].SplitGroupSubs();
            }
        }
        public void AddDynamicGeneralTonality(string date, string group, string tonality, int subs)
        {
            AddDate(date);
            switch (Tonality.ConvertToInt(tonality))
            {
                case 0:
                    data[date].AddPositiveData(group, subs);
                    break;
                case 1:
                    data[date].AddNegativeData(group, subs);
                    break;
                case 2:
                    data[date].AddNeutralData(group, subs);
                    break;
            }
        }
        public void AddProject(string date, string project, string tonality, string group, int subs)
        {
            AddDate(date);
            data[date].AddProjectsData(project, tonality, group, subs);
        }
        private void SortByDate()
        {
            var sortedList = data.ToList();
            sortedList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
            data = sortedList.ToDictionary(t => t.Key, t => t.Value);
        }
        public void Sort()
        {
            SortByDate();
        }
    }
}
