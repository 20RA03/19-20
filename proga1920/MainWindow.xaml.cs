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
using System.Data.Entity;

namespace proga1920
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        AeroflotEntities db = AeroflotEntities.GetContext();

        private void Window_Loaded(object sender, RoutedEventArgs e, Window mainWindow)
        {
            db.Aeroflots.Load();
            dataGrid1.ItemsSource = db.Aeroflots.Local.ToBindingList();

            Авторизация w = new Авторизация();
            w.Owner = mainWindow;
            w.ShowDialog();

            if (Convert.ToBoolean(Class2.логин) == false) Close();

            string right;
            if (Class2.доступ == "A") right = "Администратор";
            else
            {
                right = "Пользователь";

                //btnDelete.IsEnabled = false;
            }

            mainWindow.Title = mainWindow.Title + " " + Class2.фамилия + " " +
                Class2.имя + "(" + right + ")";

        }

        private void bb1_Click(object sender, RoutedEventArgs e)
        {
            Add f = new Add();
            f.ShowDialog();
            dataGrid1.Focus();

            db.Aeroflots.Load();
            dataGrid1.ItemsSource = db.Aeroflots.ToList();
            dataGrid1.ItemsSource = db.Aeroflots.Local.ToBindingList();
        }

        private void bb2_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                Aeroflot row = (Aeroflot)dataGrid1.Items[indexRow];

                Class1.номер_рейса = row.номер_рейса;
                Class1.пункт_назначения = row.пункт_назначения;
                Class1.время_вылета = row.время_вылета;
                Class1.время_прибытия = row.время_прибытия;
                Class1.количество_свободных_мест = row.количество_свободных_мест;
                Class1.тип_самолета = row.тип_самолета;
                Class1.вместимость_самолета = row.вместимость_самолета;

                Edit f = new Edit();
                f.ShowDialog();

                dataGrid1.Items.Refresh();
                dataGrid1.Focus();
            }
        }

        private void bb3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("удалить запись?", "удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Aeroflot row = (Aeroflot)dataGrid1.SelectedItems[0];

                    db.Aeroflots.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("выберите запись");
                }
            }
        }
    }
}
