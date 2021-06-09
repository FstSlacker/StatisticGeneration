using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticGeneration
{
    public class Statistic
    {
        public GeneralData generalData;
        public List<ProjectData> projects;
        public TonalityGeneralData positiveData;
        public TonalityGeneralData negativeData;
        public TonalityGeneralData neutralData;
        public DynamicData dynamicData;
    }
    /*
    public class Statistic
    {
        public List<ProjectData> projects;
        public ProjectData projectsSum;
    }
    */
}
