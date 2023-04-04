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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        Product product = new Product();
        public AddProductPage()
        {
            InitializeComponent();
            ClothesCB.ItemsSource = DBEntities.GetContext()
                .Clothes.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productAdd = new Product()
                {
                    IdClothes = Int32.Parse(ClothesCB.SelectedValue.ToString()),
                    PriceForOneUnitProduct = Decimal.Parse(PriceTB.Text),
                    AllAboutProduct = AllTB.Text,
                };
                DBEntities.GetContext().Product.Add(productAdd);
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Продукт добавлен");
                NavigationService.Navigate(new ListProductPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
