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

namespace proga1920
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }

        AeroflotEntities db = AeroflotEntities.GetContext();

        Aeroflot p1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.Aeroflots.Where(p => p.номер_рейса == Class1.номер_рейса).FirstOrDefault();

            tt1.Text = Convert.ToString(p1.номер_рейса);
            tt2.Text = Convert.ToString(p1.пункт_назначения);
            tt3.Text = Convert.ToString(p1.время_вылета);
            tt4.Text = Convert.ToString(p1.время_прибытия);
            tt5.Text = Convert.ToString(p1.количество_свободных_мест);
            tt6.Text = Convert.ToString(p1.тип_самолета);
            tt7.Text = Convert.ToString(p1.вместимость_самолета);
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (tt1.Text.Length == 0)
            {
                errors.AppendLine("ошибка");
            }

            if (tt2.Text.Length == 0)
            {
                errors.AppendLine("ошибка");
            }

            if (tt3.Text.Length == 0)
            {
                errors.AppendLine("ошибка");
            }

            if (tt4.Text.Length == 0)
            {
                errors.AppendLine("ошибка");
            }

            if (tt5.Text.Length == 0)
            {
                errors.AppendLine("ошибка");
            }

            if (tt6.Text.Length == 0)
            {
                errors.AppendLine("ошибка");
            }

            if (tt7.Text.Length == 0)
            {
                errors.AppendLine("ошибка");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.номер_рейса = Convert.ToInt32(tt1.Text);
            p1.пункт_назначения = tt2.Text;
            p1.время_вылета = Convert.ToDateTime(tt3.Text);
            p1.время_прибытия = Convert.ToDateTime(tt4.Text);
            p1.количество_свободных_мест = Convert.ToInt32(tt5.Text);
            p1.тип_самолета = tt6.Text;
            p1.вместимость_самолета = Convert.ToInt32(tt7.Text);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
