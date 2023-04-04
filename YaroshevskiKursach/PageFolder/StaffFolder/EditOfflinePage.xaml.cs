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
    /// Логика взаимодействия для EditOfflinePage.xaml
    /// </summary>
    public partial class EditOfflinePage : Page
    {
        AvailabilityLocal availabilityLocal = new AvailabilityLocal();
        public EditOfflinePage(AvailabilityLocal availabilityLocal)
        {
            InitializeComponent();
            DataContext = availabilityLocal;
            this.availabilityLocal.IdAvailabilityLocal = availabilityLocal.IdAvailabilityLocal;
            StoreCb.ItemsSource = DBEntities.GetContext()
                .Store.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .AvailabilityLocal.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AvailabilityLocal availabilityLocal = DBEntities.GetContext().AvailabilityLocal.
                FirstOrDefault(s => s.IdAvailabilityLocal == VariableClass.IdOffline);
                availabilityLocal.IdStore = Int32.Parse(StoreCb.Text);
                availabilityLocal.IdStaff = Int32.Parse(StaffCb.Text);
                availabilityLocal.QuantityAvailabilityLocal = Int32.Parse(QuantityAvailabilityLocalTb.Text);
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Товар в оффлайн успешно отредактирован");
                NavigationService.Navigate(new ListOfflinePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
