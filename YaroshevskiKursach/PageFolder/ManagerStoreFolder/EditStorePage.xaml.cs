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
    /// Логика взаимодействия для EditStorePage.xaml
    /// </summary>
    public partial class EditStorePage : Page
    {
        Store store = new Store();
        public EditStorePage(Store store)
        {
            InitializeComponent();
            DataContext = store;
            this.store.IdStore = store.IdStore;
            ProductCb.ItemsSource = DBEntities.GetContext()
                .Product.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                store = DBEntities.GetContext().Store
                        .FirstOrDefault(u => u.IdStore == store.IdStore);
                store.IdProduct = Int32.Parse(
                    ProductCb.SelectedValue.ToString());
                store.IdStaff = Int32.Parse(
                    StaffCb.SelectedValue.ToString());
                store.NumberOfProductsStore = NumberOfProductsStoreTb.Text;
                store.TotalCostStore = Decimal.Parse(TotalCostStoreTb.Text);
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListStorePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
