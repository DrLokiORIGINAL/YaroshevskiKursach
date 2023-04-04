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
    /// Логика взаимодействия для ListOfflinePage.xaml
    /// </summary>
    public partial class ListOfflinePage : Page
    {
        public ListOfflinePage()
        {
            InitializeComponent();
            ListLocalDG.ItemsSource = DBEntities.GetContext().AvailabilityLocal.ToList()
                .OrderBy(c => c.IdAvailabilityLocal);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListLocalDG.ItemsSource = DBEntities.GetContext()
                .AvailabilityLocal.Where(u => u.IdAvailabilityLocal.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdAvailabilityLocal);
            if (ListLocalDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            AvailabilityLocal availabilityLocal = ListLocalDG.
                SelectedItem
                as AvailabilityLocal;

            if (ListLocalDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите товар " +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"товар под номером " +
                    $"{availabilityLocal.IdAvailabilityLocal}?"))
                {
                    DBEntities.GetContext().AvailabilityLocal
                        .Remove(ListLocalDG.SelectedItem as AvailabilityLocal);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Товар удален");
                    ListLocalDG.ItemsSource = DBEntities.GetContext()
                        .AvailabilityLocal.ToList().OrderBy(u => u.IdAvailabilityLocal);
                }

            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListLocalDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "товар для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditOfflinePage(ListLocalDG.SelectedItem as AvailabilityLocal));
            }
        }
    }
}
