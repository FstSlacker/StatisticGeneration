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
        public Dictionary<string, HashSet<string>> socialNetworksGroups = new Dictionary<string, HashSet<string>>();

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
                if (!socialNetworksGroups[playground].Contains(group))
                {
                    
                    socialNetworks[playground].subs.AddStr(tonality, subs);
                    socialNetworksGroups[playground].Add(group);
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

                socialNetworksGroups.Add(playground, new HashSet<string>());
                socialNetworksGroups[playground].Add(group);
            }
        }
    }
}
