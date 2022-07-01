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
using System.Windows.Shapes;
using System.Data.Entity;

namespace proga1920
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Window
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //txtLogin.Focus();
            _ = Convert.ToBoolean(Class2.логин) == false;
        }

        AeroflotEntities db = AeroflotEntities.GetContext();

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            var user = from p in db.Authorizations
                       where p.логин == Convert.ToDouble(t1.Text) && Convert.ToString(p.пароль) == t2.Text
                       select p;

            if (user.Count() == 1)
            {
                Class2.логин = Convert.ToString(true);
                Class2.фамилия = user.First().фамилия;
                Class2.имя = user.First().имя;
                Class2.доступ = user.First().доступ;
                Close();
            }
            else
            {
                MessageBox.Show("логин или пароль не верны! повторите ввод");
                t1.Focus();
            }
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
