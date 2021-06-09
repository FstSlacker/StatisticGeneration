using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class Tonality
    {
        public int negative = 0;
        public int positive = 0;
        public int neutral = 0;

        public void AddStr(string tonality, int count)
        {
            tonality = tonality.ToLower();
            if (tonality.Equals("позитивная"))
            {
                positive += count;
            }else if (tonality.Equals("негативная"))
            {
                negative += count;
            }else if (tonality.Equals("нейтральная"))
            {
                neutral += count;
            }
        }
        public static int ConvertToInt(string tonality)
        {
            tonality = tonality.ToLower();
            if (tonality.Equals("позитивная"))
            {
                return 0;
            }
            else if (tonality.Equals("негативная"))
            {
                return 1;
            }
            else if (tonality.Equals("нейтральная"))
            {
                return 2;
            }
            return -1;
        }
        public static Tonality operator+(Tonality left, Tonality right)
        {
            left.positive = left.positive + right.positive;
            left.negative = left.negative + right.negative;
            left.neutral = left.neutral + right.neutral;
            return left;
        }
        public int Sum()
        {
            return (negative + positive + neutral);
        }
    }
}
