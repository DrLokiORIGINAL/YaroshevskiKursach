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
    /// Логика взаимодействия для ListClothesPage.xaml
    /// </summary>
    public partial class ListClothesPage : Page
    {
        public ListClothesPage()
        {
            InitializeComponent();
            ListReaderLB.ItemsSource = DBEntities.GetContext().Clothes.ToList()
                .OrderBy(c => c.IdClothes);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListReaderLB.ItemsSource = DBEntities.GetContext()
                .Clothes.Where(u => u.IdClothes.ToString()
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.IdClothes);
            if (ListReaderLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListReaderLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "одежду для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditClothesPage(ListReaderLB.SelectedItem as Clothes));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Clothes clothes = ListReaderLB.SelectedItem as Clothes;

            if (ListReaderLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите Одежду" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранную одежду? " +
                    $"{clothes.IdClothes}?"))
                {
                    DBEntities.GetContext().Clothes
                        .Remove(ListReaderLB.SelectedItem as Clothes);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранная одежда удалена");
                    ListReaderLB.ItemsSource = DBEntities.GetContext()
                        .Clothes.ToList().OrderBy(u => u.IdClothes);
                }

            }
        }
    }
}
