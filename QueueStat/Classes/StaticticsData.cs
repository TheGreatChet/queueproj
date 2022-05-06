using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace QueueStat.Classes
{
    public class StaticticsData
    {
        public int Month;
        public int Year;
        public int SumCount;
        public Dictionary<int, int> OperationCountList { get; set; }
        public StaticticsData(int year, int month, Dictionary<int, int> opercount)
        {
            Year = year;
            Month = month;
            OperationCountList = opercount;
        }        
        public void CountSummary()
        {
            foreach (KeyValuePair<int, int> kvp in OperationCountList)
            {
                SumCount += kvp.Value;
            }
        }
    }
}
