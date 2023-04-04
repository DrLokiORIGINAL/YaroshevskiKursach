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
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        Product product = new Product();
        public EditProductPage(Product product)
        {
            InitializeComponent();
            DataContext = product;
            this.product.IdProduct = product.IdProduct;
            ClothesCb.ItemsSource = DBEntities.GetContext().Clothes.ToList().OrderBy(u => u.IdClothes);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = DBEntities.GetContext().Product.
                FirstOrDefault(s => s.IdProduct == VariableClass.IdProduct);
            product.IdClothes = Int32.Parse(
                        ClothesCb.SelectedValue.ToString());
            product.PriceForOneUnitProduct = Decimal.Parse(PriceTB.Text);
            product.AllAboutProduct = AllTB.Text;
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Поользователь успешно отредактирован");
            NavigationService.Navigate(new ListProductPage());
        }
    }
}
