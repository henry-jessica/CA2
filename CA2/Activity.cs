using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public enum TypeOfActivity { Air, Water, Land }
    class Activity : IComparable
    {
        private string name;
        private DateTime activityDate;
        private decimal cost;
        private string  description;

        public Activity()
        {

        }

        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;
            return this.activityDate.CompareTo(that.activityDate);
        }

    }
}
