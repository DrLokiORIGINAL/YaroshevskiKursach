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
    /// Логика взаимодействия для AddStorePage.xaml
    /// </summary>
    public partial class AddStorePage : Page
    {
        Store store = new Store();
        public AddStorePage()
        {
            InitializeComponent();
            ProductCb.ItemsSource = DBEntities.GetContext()
                .Product.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var storeAdd = new Store()
                {
                    IdProduct = Int32.Parse(ProductCb.SelectedValue.ToString()),
                    IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString()),
                    NumberOfProductsStore = NumberOfProductsStoreTb.Text,
                    TotalCostStore = Decimal.Parse(TotalCostStoreTb.Text),
                };
                DBEntities.GetContext().Store.Add(storeAdd);
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Товар добавлен");
                NavigationService.Navigate(new ListStorePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
