using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace my_project
{
    /// <summary>
    /// Interaction logic for singin.xaml
    /// </summary>
    public partial class singin : Page
    {
        dateEntities db =new dateEntities();
        string gender;
        public singin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userr add = new userr();
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-B])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()]).+$");
                int age = int.Parse(txtage.Text);
                if (regex.IsMatch(txtpassword.Text))
                { 
                    add.password = txtpassword.Text;

                    if (txtphone.Text.Length == 11 && age >= 18 && age <= 60)
                    {
                        add.username = txtname.Text;
                         add.phone = txtphone.Text;
                         add.age = age;
                         add.city = comb.Text;
                         db.userrs.Add(add);
                         db.SaveChanges();
                          MessageBox.Show("hello");
                         string name = txtname.Text;
                         profile profile = new profile(name);
                         this.NavigationService.Navigate(profile);

                    }
                    else
                    { 
                        MessageBox.Show("check phone or age in your date");

                    }
                  



            }
                else
                {
                    MessageBox.Show("the password is weak ");
                }
            }
            catch
            {
                MessageBox.Show("arror");
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gender = "m";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            gender = "f";
        }
    }
}
