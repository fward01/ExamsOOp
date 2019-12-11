using System;
using System.Collections.Generic;
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
using System.Collections;
using System.Collections.ObjectModel;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        ObservableCollection<Player> ActivityList;//list to gather activities

        ObservableCollection<Player> SelectedList = new ObservableCollection<Player>();//list for the activites selected

        ObservableCollection<Player> FilteredList = new ObservableCollection<Player>();//list for filtering
        public enum Position { GoalKeeper,Defender,Midfielder,Foward}
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                string[] firstName = new string[18];
                string[] lastName = new string[18];
                DateTime[] dateOfBirth = new DateTime[18];
                for (int i = 0; i < firstName.Length; i++)
                {
                    firstName[i] = Random.GenerateFirstName(i);

                }
                for (int i = 0; i < lastName.Length; i++)
                {
                    lastName[i] = Random.GenerateLastName(i);

                }
                for (int i = 0; i < dateOfBirth.Length; i++)
                {
                    dateOfBirth[i] = Random.GenerateDoB(i);

                }
                Player Player1 = new Player(firstName[1], lastName[1], Position.GoalKeeper, dateOfBirth[1]);
                Player Player2 = new Player(firstName[2], lastName[2], Position.GoalKeeper, dateOfBirth[2]);
                Player Player3 = new Player(firstName[3], lastName[3], Position.Defender, dateOfBirth[3]);
                Player Player4 = new Player(firstName[4], lastName[4], Position.Defender, dateOfBirth[4]);
                Player Player5 = new Player(firstName[5], lastName[5], Position.Defender, dateOfBirth[5]);
                Player Player6 = new Player(firstName[6], lastName[6], Position.Defender, dateOfBirth[6]);
                Player Player7 = new Player(firstName[7], lastName[7], Position.Defender, dateOfBirth[7]);
                Player Player8 = new Player(firstName[8], lastName[8], Position.Defender, dateOfBirth[8]);
                Player Player9 = new Player(firstName[9], lastName[9], Position.Midfielder, dateOfBirth[9]);
                Player Player10 = new Player(firstName[10], lastName[10], Position.Midfielder, dateOfBirth[10]);
                Player Player11 = new Player(firstName[11], lastName[11], Position.Midfielder, dateOfBirth[11]);
                Player Player12 = new Player(firstName[12], lastName[12], Position.Midfielder, dateOfBirth[12]);
                Player Player13 = new Player(firstName[13], lastName[13], Position.Midfielder, dateOfBirth[13]);
                Player Player14 = new Player(firstName[14], lastName[14], Position.Midfielder, dateOfBirth[14]);
                Player Player15 = new Player(firstName[15], lastName[15], Position.Foward, dateOfBirth[15]);
                Player Player16 = new Player(firstName[16], lastName[16], Position.Foward, dateOfBirth[16]);
                Player Player17 = new Player(firstName[17], lastName[17], Position.Foward, dateOfBirth[17]);
                Player Player18 = new Player(firstName[18], lastName[18], Position.Foward, dateOfBirth[18]);
                ActivityList = new ObservableCollection<Player>();
                ActivityList.Add(Player1);
                ActivityList.Add(Player2);
                ActivityList.Add(Player3);
                ActivityList.Add(Player4);
                ActivityList.Add(Player5);
                ActivityList.Add(Player6);
                ActivityList.Add(Player7);
                ActivityList.Add(Player8);
                ActivityList.Add(Player9);
                ActivityList.Add(Player10);
                ActivityList.Add(Player11);
                ActivityList.Add(Player12);
                ActivityList.Add(Player13);
                ActivityList.Add(Player14);
                ActivityList.Add(Player15);
                ActivityList.Add(Player16);
                ActivityList.Add(Player17);
                ActivityList.Add(Player18);
                ActivityList = new ObservableCollection<Player>(ActivityList.OrderBy(i => i.Preferredpostion));
                SelectedPlayersListBox.ItemsSource = SelectedList;
                AllPlayersListBox.ItemsSource = ActivityList;
                Count.Text = "11";
            }
            catch(IndexOutOfRangeException)
            {

            }





        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int playercount = 0;
            bool conflict = false;
            Player selected = AllPlayersListBox.SelectedItem as Player;
            foreach (Player player in SelectedList)
            {
                if (SelectedPlayersListBox.Items.Count==11)
                {
                    conflict = true;
                    MessageBox.Show("Too many players!");
                }
                
            }
            if (conflict == false)
            {
                SelectedList.Add(selected);
                ActivityList.Remove(selected);
                playercount = int.Parse(Count.Text) - 1;
                ActivityList = new ObservableCollection<Player>(ActivityList.OrderBy(i => i.Preferredpostion));
                SelectedList = new ObservableCollection<Player>(SelectedList.OrderBy(i => i.Preferredpostion));

            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int playercount = 0;
            Player selected = SelectedPlayersListBox.SelectedItem as Player;
            if (selected != null)
            {
                SelectedList.Remove(selected);
                ActivityList.Add(selected);
                playercount = int.Parse(Count.Text) + 1;
                SelectedList = new ObservableCollection<Player>(SelectedList.OrderBy(i => i.Preferredpostion));
                ActivityList = new ObservableCollection<Player>(ActivityList.OrderBy(i => i.Preferredpostion));
            }
        }
        public class Player
        {
            private string firstname;
            private string surname;
            private Position preferredpostion;
            private DateTime dateOfBirth;
            private int age;

            public string Firstname { get => firstname; set => firstname = value; }
            public string Surname { get => surname; set => surname = value; }
            public Position Preferredpostion { get => preferredpostion; set => preferredpostion = value; }
            public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
            public int Age { get => age; set => age = value; }
            public Player(string _firstname, string _lastname, Position _position,DateTime _DoB)
            {
                Firstname = _firstname;
                Surname = _lastname;
                Preferredpostion = _position;
                DateOfBirth = _DoB;
                CalculateAge(DateOfBirth);
            }
            public int CalculateAge(DateTime i)
            {
                Age = DateTime.Now.Year - i.Year;
                return Age;
            }
            public override string ToString()
            {
                return (Firstname + " " + Surname + " (" + Age + ") " + Preferredpostion);
            }

        }
        public class Random
        {
            public static string GenerateFirstName(int len)
            {
                string[] firstNames = {
                "Adam", "Amelia", "Ava", "Chloe", "Conor", "Daniel", "Emily",
                "Emma", "Grace", "Hannah", "Harry", "Jack", "James",
                "Lucy", "Luke", "Mia", "Michael", "Noah", "Sean", "Sophie"};
                string FirstName = "";
                System.Random rand = new System.Random(DateTime.Now.Second);
                if (rand.Next(1, 2) == 1)
                {
                    FirstName = firstNames[rand.Next(0, firstNames.Length - 1)];
                }
                return FirstName;
            }
            public static string GenerateLastName(int len)
            {
                string[] lastNames = {
                "Brennan", "Byrne", "Daly", "Doyle", "Dunne", "Fitzgerald", "Kavanagh",
                "Kelly", "Lynch", "McCarthy", "McDonagh", "Murphy", "Nolan", "O'Brien",
                "O'Connor", "O'Neill", "O'Reilly", "O'Sullivan", "Ryan", "Walsh"
                };
                string LastName = "";
                System.Random rand = new System.Random(DateTime.Now.Second);
                if (rand.Next(1, 2) == 1)
                {
                    LastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                }
                return LastName;
            }
            public static DateTime GenerateDoB(int len)
            {
                DateTime start= new DateTime(1989, 1, 1);
                DateTime finish = new DateTime(1999, 12, 31);
                System.Random gen = new System.Random();
                TimeSpan timeSpan = finish - start;
                var randomTest = new System.Random();
                TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                DateTime newDate = start + newSpan;
                return newDate;
            }
        }
    }
}
