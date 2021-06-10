using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class PlaygroundData
    {
        public Tonality mentions = new Tonality();
        public Tonality subs = new Tonality();
        public Tonality involvements = new Tonality();

    }
    public class SocialNetworksData
    {
        public Dictionary<string, PlaygroundData> socialNetworks = new Dictionary<string, PlaygroundData>();
        public Dictionary<string, Dictionary<string, GroupInfo>> socialNetworksGroups = new Dictionary<string, Dictionary<string, GroupInfo>>();

        public string[,] ConvertToArray()
        {
            string[,] array = new string[socialNetworks.Count * 3, 5];
            int i = 0;
            foreach(var sn in socialNetworks)
            {
                array[i, 0] = sn.Key;
                array[i, 1] = sn.Value.mentions.positive.ToString();
                array[i, 2] = sn.Value.subs.positive.ToString();
                array[i, 3] = sn.Value.involvements.positive.ToString();
                array[i, 4] = "Позитивная";

                i++;
                array[i, 0] = sn.Key;
                array[i, 1] = sn.Value.mentions.negative.ToString();
                array[i, 2] = sn.Value.subs.negative.ToString();
                array[i, 3] = sn.Value.involvements.negative.ToString();
                array[i, 4] = "Негативная";

                i++;
                array[i, 0] = sn.Key;
                array[i, 1] = sn.Value.mentions.neutral.ToString();
                array[i, 2] = sn.Value.subs.neutral.ToString();
                array[i, 3] = sn.Value.involvements.neutral.ToString();
                array[i, 4] = "Нейтральная";
                i++;
            }
            return array;
        }
        public void AddSocialNetwork(string playground, int involvements, string tonality, int subs, string group)
        {
            if (socialNetworks.ContainsKey(playground))
            {
                if (!socialNetworksGroups[playground].ContainsKey(group))
                {
                    
                    socialNetworks[playground].subs.AddStr(tonality, subs);
                    socialNetworksGroups[playground].Add(group, new GroupInfo(group, subs, tonality));
                }
                else
                {
                    socialNetworksGroups[playground][group].AddMentions(tonality);
                }
                socialNetworks[playground].mentions.AddStr(tonality, 1);
                socialNetworks[playground].involvements.AddStr(tonality, involvements);
            }
            else
            {
                socialNetworks.Add(playground, new PlaygroundData());
                socialNetworks[playground].subs.AddStr(tonality, subs);
                socialNetworks[playground].mentions.AddStr(tonality, 1);
                socialNetworks[playground].involvements.AddStr(tonality, involvements);

                socialNetworksGroups.Add(playground, new Dictionary<string, GroupInfo>());
                socialNetworksGroups[playground].Add(group, new GroupInfo(group, subs, tonality));
            }
        }
        public void SplitGroupSubs()
        {
            Tonality sumTonality;
            var keysArray = socialNetworksGroups.Keys.ToArray();
            foreach (var infooccasion in keysArray)
            {
                sumTonality = new Tonality();
                foreach (var groupSubs in socialNetworksGroups[infooccasion])
                {
                    sumTonality = sumTonality + groupSubs.Value.GetTonalitySubs();
                }
                socialNetworks[infooccasion].subs = sumTonality;
            }
        }
    }
}
