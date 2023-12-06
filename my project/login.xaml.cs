using System;
using System.CodeDom;
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

namespace my_project
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        dateEntities db = new dateEntities();
        public login()
        {
            InitializeComponent();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            userr user = new userr();
            if (txtname.Text != "" & txtpass.Text != "")
            {
              user = db.userrs.First(x => x.username == txtname.Text && x.password == txtpass.Text);
               if (user != null)
               {
                   MessageBox.Show("hello");
                   string name = txtname.Text;
                   profile profile = new profile(name);
                   this.NavigationService.Navigate(profile);
                    txtname.Text = "";
                    txtpass.Text = "";
               }
                else
                {
                    MessageBox.Show("not find");
                }

            }
            else
            {
                MessageBox.Show("enter date");
            }
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            singin singin = new singin();
            this.NavigationService.Navigate(singin);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            forget forget=new forget();
            this.NavigationService.Navigate(forget);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            adminlogn adminlogn = new adminlogn();
            this.NavigationService.Navigate(adminlogn);
        }
    }
}
