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
    /// Логика взаимодействия для EditOnlinePage.xaml
    /// </summary>
    public partial class EditOnlinePage : Page
    {
        AvailabilityInternet availabilityInternet = new AvailabilityInternet();
        public EditOnlinePage(AvailabilityInternet availabilityInternet)
        {
            InitializeComponent();
            DataContext = availabilityInternet;
            this.availabilityInternet.IdAvailabilityInternet = availabilityInternet.IdAvailabilityInternet;
            StoreCb.ItemsSource = DBEntities.GetContext()
                .Store.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .AvailabilityInternet.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AvailabilityInternet availabilityInternet = DBEntities.GetContext().AvailabilityInternet.
                FirstOrDefault(s => s.IdAvailabilityInternet == VariableClass.IdOnline);
                availabilityInternet.IdStore = Int32.Parse(StoreCb.Text);
                availabilityInternet.IdStaff = Int32.Parse(StaffCb.Text);
                availabilityInternet.QuantityAvailabilityInternet = Int32.Parse(QuantitySaleTb.Text);
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Товар в онлайн успешно отредактирован");
                NavigationService.Navigate(new ListOnlinePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
