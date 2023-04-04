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
    /// Логика взаимодействия для AddOfflinePage.xaml
    /// </summary>
    public partial class AddOfflinePage : Page
    {
        public AddOfflinePage()
        {
            InitializeComponent();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
            StoreCb.ItemsSource = DBEntities.GetContext()
                .Store.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().AvailabilityLocal.Add(new AvailabilityLocal()
            {
                IdStore = Int32.Parse(StoreCb.SelectedValue.ToString()),
                IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString()),
                QuantityAvailabilityLocal = Int32.Parse(QuantitySaleTb.Text),
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListOfflinePage());
        }
    }
}
