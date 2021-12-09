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

        //Lists
        List<Activity> ActivitiesList = new List<Activity>();
        List<Activity> ActivitiesSelected = new List<Activity>();
        List<Activity> ActivitiesFiltered = new List<Activity>();


        decimal totalCost = 0;


        public MainWindow()
        {
            InitializeComponent();


            //   Create Activities  
            Activity l1 = new Activity
            {
                Name = "Treking",
                ActivityDate = new DateTime(2021, 06, 03),
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
                Description = "The vigorous demands of mountain biking stimulate your body."
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
                TypeOfActivity = TypeOfActivity.Water,
                Description = "Enjoy in StrandHill beach, very cold water."

            };
            Activity w2 = new Activity
            {
                Name = "Kayaking",
                ActivityDate = new DateTime(2021, 06, 02),
                Cost = 68.40m,
                TypeOfActivity = TypeOfActivity.Water,
                Description = "Experience along the visually styunning southern coastline of Ireland"
            };
            Activity w3 = new Activity
            {
                Name = "Abseling",
                ActivityDate = new DateTime(2021, 06, 03),
                Cost = 40m,
                TypeOfActivity = TypeOfActivity.Water,
                Description = "Experience with professional instructors."
            };

            Activity a1 = new Activity
            {
                Name = "Sailing",
                ActivityDate = new DateTime(2021, 06, 01),
                Cost = 65.90m,
                TypeOfActivity = TypeOfActivity.Air,
                Description = "Enjoy 8 hours sailing in Atlantic Ocean"

            };
            Activity a2 = new Activity
            {
                Name = "Helicopter Tour",
                ActivityDate = new DateTime(2021, 06, 02),
                Cost = 65.90m,
                TypeOfActivity = TypeOfActivity.Air,
                Description = "This is really fancy - 150km."

            };
            Activity a3 = new Activity
            {
                Name = "Hang Gliding",
                ActivityDate = new DateTime(2021, 06, 03),
                Cost = 65.90m,
                TypeOfActivity = TypeOfActivity.Air,
                Description = "Fantastic experience and very safe."

            };


            //Add those to a list 
            ActivitiesList.Add(l1);
            ActivitiesList.Add(l2);
            ActivitiesList.Add(l3);
            ActivitiesList.Add(w1);
            ActivitiesList.Add(w2);
            ActivitiesList.Add(w3);
            ActivitiesList.Add(a1);
            ActivitiesList.Add(a2);
            ActivitiesList.Add(a3);

            //Sort all activities based on the date
            ActivitiesList.Sort();
    

            //Display to a listbox 
            lbxActivities.ItemsSource = ActivitiesList;

        }

        /// <summary>
        /// Button Add Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            Activity selectedActivitity = lbxActivities.SelectedItem as Activity;

            //check if is selected 
            if (selectedActivitity != null)
            {
                bool CheckDate = true;
                //loop through of element of the list 
                for (int i = 0; i < ActivitiesSelected.Count; i++)
                {
                    //check date if is equal display message and return false 
                    if (selectedActivitity.ActivityDate == ActivitiesSelected[i].ActivityDate)
                    {

                        MessageBox.Show("Date conflict, you cannot select two activities on the same date", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Warning);
                        CheckDate = false;
                    }


                } 
                //check if date is different, so date is true will insert from list activities to 
                // selected list
                if (CheckDate == true)
                { 
                
                    ActivitiesList.Remove(selectedActivitity);
                    ActivitiesSelected.Add(selectedActivitity);

                    totalCost = totalCost + selectedActivitity.Cost;
                    tblkCostTotal.Text = totalCost.ToString("C");


                    ActivitiesSelected.Sort();
                }
                //update the list 
                RefreshScreen(); 
            }
            //if did not select element from activity list display erro message 
            else if (selectedActivitity == null)
            {

                MessageBox.Show("No activity selected", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Unkown Error", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void Lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //This will get the selected item from the list 
            Activity activitySelected = lbxActivities.SelectedItem as Activity;

            //check if nothing was selected 
            if (activitySelected != null)
            {
                tblkDescription.Text = activitySelected.Description;

                //it will select the cost referent to activity Selected and convert it string inserting currency simbol 
                tblkCost.Text = activitySelected.Cost.ToString("C");

                //it will display name in the card

                tblkNameActivity.Text = activitySelected.Name; 


            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {

            Activity selectedActivitity = lbxActivitiesSelected.SelectedItem as Activity;

            //check if element was selected remove from the list 
            if (selectedActivitity != null)
            {

                ActivitiesList.Add(selectedActivitity);
                ActivitiesSelected.Remove(selectedActivitity);

                totalCost = totalCost - selectedActivitity.Cost;
                tblkCostTotal.Text = totalCost.ToString("C");

                //update list 
                RefreshScreen();


            }
            //if element was not selected display message when try to remove  
            else if (selectedActivitity == null)
            {

                MessageBox.Show("That nothing has been selected, Most one activity be select", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Unkown Error", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RdbAll_Click(object sender, RoutedEventArgs e)
        {
            ActivitiesFiltered.Clear();

            if (rdbAll.IsChecked == true)
            {//Display all activities 
                RefreshScreen(); 
             
            }
            else if (rdbAir.IsChecked == true)
            { 
                //Disply in the list all Air
                foreach (Activity activity in ActivitiesList)
                {
                    if (activity.TypeOfActivity == TypeOfActivity.Air)
                    {
                        ActivitiesFiltered.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = ActivitiesFiltered;
                    }

                }

            }
            else if (rdbWater.IsChecked == true)
            {
                //Disply in the list all Water 
                foreach (Activity activity in ActivitiesList)
                {
                    if (activity.TypeOfActivity == TypeOfActivity.Water)
                    {
                        ActivitiesFiltered.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = ActivitiesFiltered;
                    }

                }

            }
            else if (rdbLand.IsChecked == true)
            {
                //Disply in the list all Land 
                foreach (Activity activity in ActivitiesList)
                {
                    if (activity.TypeOfActivity == TypeOfActivity.Land)
                    {
                        ActivitiesFiltered.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = ActivitiesFiltered;
                    }

                }

            }
        }
        private void RefreshScreen()
        {
            //update screen
            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = ActivitiesList;

            lbxActivitiesSelected.ItemsSource = null;
            lbxActivitiesSelected.ItemsSource = ActivitiesSelected;
        }

    
    }
}
