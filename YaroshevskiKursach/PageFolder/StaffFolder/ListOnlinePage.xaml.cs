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
using YaroshevskiKursach.ClassFolder;
using YaroshevskiKursach.DataFolder;

namespace YaroshevskiKursach.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для ListOnlinePage.xaml
    /// </summary>
    public partial class ListOnlinePage : Page
    {
        public ListOnlinePage()
        {
            InitializeComponent();
            ListOnlineDG.ItemsSource = DBEntities.GetContext().AvailabilityInternet.ToList()
                .OrderBy(c => c.IdAvailabilityInternet);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListOnlineDG.ItemsSource = DBEntities.GetContext()
                .AvailabilityInternet.Where(u => u.IdAvailabilityInternet.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdAvailabilityInternet);
            if (ListOnlineDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListOnlineDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "товар для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditOnlinePage(ListOnlineDG.SelectedItem as AvailabilityInternet));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            AvailabilityInternet availabilityInternet = ListOnlineDG.
                SelectedItem
                as AvailabilityInternet;

            if (ListOnlineDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите товар " +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"товар под номером " +
                    $"{availabilityInternet.IdAvailabilityInternet}?"))
                {
                    DBEntities.GetContext().AvailabilityInternet
                        .Remove(ListOnlineDG.SelectedItem as AvailabilityInternet);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Товар удален");
                    ListOnlineDG.ItemsSource = DBEntities.GetContext()
                        .AvailabilityInternet.ToList().OrderBy(u => u.IdAvailabilityInternet);
                }

            }
        }
    }
}
