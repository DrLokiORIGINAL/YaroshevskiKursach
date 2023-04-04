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
    /// Логика взаимодействия для AddSalePage.xaml
    /// </summary>
    public partial class AddSalePage : Page
    {
        public AddSalePage()
        {
            InitializeComponent();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Sale.Add(new Sale()
            {
                DateSale = DateTime.Parse(DateSaleTb.Text),
                QuantitySale = Int32.Parse(QuantitySaleTb.Text),
                IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString()),
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListSalePage());
        }
    }
}
