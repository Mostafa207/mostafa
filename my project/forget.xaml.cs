using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for forget.xaml
    /// </summary>
    public partial class forget : Page
    {
        dateEntities db = new dateEntities();
        public forget()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userr forg = new userr();
            forg = db.userrs.First(x => x.phone == txtphone.Text);
            if (forg.phone == txtphone.Text)
            {
                Regex regex = new Regex(@"^(?=.*[A-B])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()]).+$");
                if (regex.IsMatch(txtpass.Text))
                {
                    forg.password = txtpass.Text;
                    if (txtpass.Text == txtpass1.Text)
                    {
                        db.userrs.AddOrUpdate(forg);
                        db.SaveChanges();
                        MessageBox.Show("pass is change");
                        login login = new login();
                        this.NavigationService.Navigate(login);
                    }
                    else
                    {
                        MessageBox.Show("paasswor invalid ");
                    }
                }
                else
                {
                    MessageBox.Show("the pass is weak");
                }
            }

        }


    }
}
