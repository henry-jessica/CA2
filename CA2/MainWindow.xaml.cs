using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       // ObservableCollection<Activity> activities;

        public MainWindow()
        {
            InitializeComponent();


            //   Create Activities  
            Activity l1 = new Activity
            {
                Name = "Treking",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 40.00m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Half day lakeland with island picnic."
            };

            Activity l2 = new Activity
            {
                Name = "Mountain Biking",
                ActivityDate = new DateTime(2021, 06, 02),
                Cost = 45.00m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "The vigorous demands of mountain biking stimulate your body to release natural endorphins, which are the body’s way of feeling good and getting more energy - Bike rental is included in the price."
            };
            Activity l3 = new Activity
            {
                Name = "Golf",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 62.50m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Enjoy the best game in Rosses Point Link Golf Course."
            };

            Activity w1 = new Activity
            {
                Name = "Surfing",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 65.90m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Half day lakeland with island picnic."

            };
            Activity w2 = new Activity
            {
                Name = "Kayaking",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 68.40m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Half day lakeland with island picnic."
            };
            Activity w3 = new Activity
            {
                Name = "Abseling",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 40m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Half day lakeland with island picnic."
            };

            Activity a1 = new Activity
            {
                Name = "Sailing",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 65.90m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Half day lakeland with island picnic."

            };
            Activity a2 = new Activity
            {
                Name = "Helicopter Tour",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 65.90m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Half day lakeland with island picnic."

            };
            Activity a3 = new Activity
            {
                Name = "Hang Gliding",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 65.90m,
                TypeOfActivity = TypeOfActivity.Land,
                Description = "Half day lakeland with island picnic."

            };

            //create a list 
            List<Activity> activities = new List<Activity>();
             //activities = new ObservableCollection<Activity>();

            //Add those to a list 
            activities.Add(l1);
            activities.Add(l2);
            activities.Add(l3);
            activities.Add(w1);
            activities.Add(w2);
            activities.Add(w3);
            activities.Add(a1);
            activities.Add(a2);
            activities.Add(a3);

            //Sort all activities based on the date
            activities.Sort();

            //Display to a listbox 
            lbxActivities.ItemsSource = activities;

        }
    }
}
