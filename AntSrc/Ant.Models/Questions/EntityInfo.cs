using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;

namespace Ant.Models.Questions
{
    public class EntityInfo
    {
        public string CrUser{set;get;}
        public DateTime CrTime{set;get;}
        public DateTime LastModified{set;get;}

        public string CrDay
        {
            get
            {
                return CrTime.ToString("yyyy年MM月dd日");
            }
        }

        public string LastModifiedDay
        {
            get
            {
                return LastModified.ToString("yyyy年MM月dd日");
            }
        }

    }
}
