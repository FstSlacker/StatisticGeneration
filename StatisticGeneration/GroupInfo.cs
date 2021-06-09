using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class GroupInfo
    {
        public string name;
        public Tonality mentions = new Tonality();
        public int subs = 0;

        public GroupInfo(string groupName, int groupSubs, string tonality)
        {
            name = groupName;
            subs = groupSubs;
            AddMentions(tonality);
        }
        public void AddMentions(string tonality)
        {
            mentions.AddStr(tonality, 1);
        }
        public Tonality GetTonalitySubs()
        {
            int maxMent = mentions.Sum();
            if (maxMent == 0) return new Tonality();
            float kPos = (float)mentions.positive / (float)maxMent;
            float kNeg = (float)mentions.negative / (float)maxMent;
            float kNeu = (float)mentions.neutral / (float)maxMent;
            Tonality res = new Tonality();
            res.positive = Convert.ToInt32(kPos * subs);
            res.negative = Convert.ToInt32(kNeg * subs);
            res.neutral = Convert.ToInt32(kNeu * subs);
            return res;
        }
    }
}
