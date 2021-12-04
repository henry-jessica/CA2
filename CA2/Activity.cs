using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    //enum
    enum TypeOfActivity
    {
        Air,
        Water,
        Land
    }

    class Activity : IComparable
    {
        #region Properties
        //properties 
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public TypeOfActivity TypeOfActivity { get; set; }

        #endregion
        
        //default Constructors
        public Activity() { }

        //contructor to get all atributes 
        public Activity(string name, DateTime date, decimal cost, TypeOfActivity typeOfActivity, string description)
        {
            this.Name = name;
            this.ActivityDate = date;
            this.Cost = cost;
            this.Description = description;
            TypeOfActivity = typeOfActivity;
        }

        //methods
        public override string ToString()
        {
            string shortDate = ActivityDate.ToShortDateString();
            return $"{Name} - {shortDate}";
        }

        //compare Activity date with others Activety Date 
        int IComparable.CompareTo(object o)
        {
            Activity that = (Activity)o;
            return this.ActivityDate.CompareTo(that.ActivityDate);
        }

    }
}
