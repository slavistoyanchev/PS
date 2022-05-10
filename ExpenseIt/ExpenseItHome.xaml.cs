using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ExpenseIt
{
    
    
    public partial class ExpenseItHome : Window,  INotifyPropertyChanged
    {

        public List<Person> ExpenseDataSource { get; set; }
        private DateTime lastChecked;

        public event PropertyChangedEventHandler PropertyChanged;

        public string MainCaptionText { get; set; }
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                // Извикване на PropertyChanged
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }
        public ExpenseItHome()
        {
            PersonsChecked = new ObservableCollection<string>();
            InitializeComponent();
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
            this.DataContext = this;

            ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name="Mike",
                    Department ="Legal",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
                        new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
                    }
                },
                new Person()
                {
                    Name ="Lisa",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                        new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                    }
                },
                new Person()
                {
                    Name="John",
                    Department ="Engineering",
                    Expenses = new List<Expense>()

                    {
                        new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                        new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                        new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                    }
                },
                new Person()
                {
                    Name="Mary",
                    Department ="Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name="Theo",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                Name="David",
                Department ="Management",
                Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Bank card", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name="James",
                    Department ="Engeneer",
                    Expenses = new List<Expense>()

                    {
                        new Expense() { ExpenseType="Subscription", ExpenseAmount=50 },
                        new Expense() { ExpenseType="New computers", ExpenseAmount=600 },
                        new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                    }
                }
            };
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("ExpenseIt", "Open report?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    ExpenseReport expenseReport = new ExpenseReport();
            //    expenseReport.Width = Width;
            //    expenseReport.Height = Height;
            //    expenseReport.Show();
            //    this.Show();
            //}
            ExpenseReport expenseReport = new ExpenseReport();
            expenseReport.Show();

        }
        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)

        {
            LastChecked = DateTime.Now;
            //PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
            PersonsChecked.Add(peopleListBox.SelectedItem.ToString());
        }
    }

}

    

