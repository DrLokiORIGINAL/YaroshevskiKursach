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

namespace YaroshevskiKursach.PageFolder.ManagerStoreFolder
{
    /// <summary>
    /// Логика взаимодействия для ListStorePage.xaml
    /// </summary>
    public partial class ListStorePage : Page
    {
        public ListStorePage()
        {
            InitializeComponent();
            ListStoreDG.ItemsSource = DBEntities.GetContext().Store.ToList()
                .OrderBy(c => c.IdStore);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListStoreDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "товар для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditStorePage(ListStoreDG.SelectedItem as Store));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Store store = ListStoreDG.SelectedItem as Store;

            if (ListStoreDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите товар " +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"товар под номером? " +
                    $"{store.IdStore}?"))
                {
                    DBEntities.GetContext().Store
                        .Remove(ListStoreDG.SelectedItem as Store);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Товар удален");
                    ListStoreDG.ItemsSource = DBEntities.GetContext()
                        .Store.ToList().OrderBy(u => u.IdStore);
                }

            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListStoreDG.ItemsSource = DBEntities.GetContext()
                .Store.Where(u => u.IdStore.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdStore);
            if (ListStoreDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}
