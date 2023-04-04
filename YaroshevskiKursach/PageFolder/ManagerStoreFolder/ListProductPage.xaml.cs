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
    /// Логика взаимодействия для ListProductPage.xaml
    /// </summary>
    public partial class ListProductPage : Page
    {
        public ListProductPage()
        {
            InitializeComponent();
            ListProductLB.ItemsSource = DBEntities.GetContext().Product.ToList()
                .OrderBy(c => c.IdProduct);
        }

        private void Ref()
        {
            ListProductLB.ItemsSource = DBEntities.GetContext().Product.ToList()
                .OrderBy(c => c.IdProduct);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListProductLB.ItemsSource = DBEntities.GetContext()
                .Product.Where(u => u.IdProduct.ToString()
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.IdProduct);
            if (ListProductLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            Product product = ListProductLB.SelectedItem as Product;
            VariableClass.IdProduct = product.IdProduct;
            this.NavigationService.Navigate(new EditProductPage(ListProductLB.SelectedItem as Product));
            Ref();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Product product = ListProductLB.SelectedItem as Product;

            if (ListProductLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите продукт" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"продукт под номером " +
                    $"{product.IdProduct}?"))
                {
                    DBEntities.GetContext().Product
                        .Remove(ListProductLB.SelectedItem as Product);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Продукт удален");
                    ListProductLB.ItemsSource = DBEntities.GetContext()
                        .Product.ToList().OrderBy(u => u.IdProduct);
                }

            }
        }
    }
}
