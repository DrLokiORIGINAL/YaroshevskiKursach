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
    /// Логика взаимодействия для ListSalePage.xaml
    /// </summary>
    public partial class ListSalePage : Page
    {
        public ListSalePage()
        {
            InitializeComponent();
            ListSaleDG.ItemsSource = DBEntities.GetContext().Sale.ToList()
                .OrderBy(c => c.IdSale);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Sale sale = ListSaleDG.SelectedItem as Sale;

            if (ListSaleDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите продажу" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"данную продажу " +
                    $"{sale.IdSale}?"))
                {
                    DBEntities.GetContext().Sale
                        .Remove(ListSaleDG.SelectedItem as Sale);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Продажа удалена");
                    ListSaleDG.ItemsSource = DBEntities.GetContext()
                        .Sale.ToList().OrderBy(u => u.IdSale);
                }

            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListSaleDG.ItemsSource = DBEntities.GetContext()
                .Sale.Where(u => u.IdSale.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdSale);
            if (ListSaleDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListSaleDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "продажу для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditSalePage(ListSaleDG.SelectedItem as Sale));
            }
        }
    }
}
