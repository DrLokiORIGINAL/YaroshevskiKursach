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
    /// Логика взаимодействия для EditSalePage.xaml
    /// </summary>
    public partial class EditSalePage : Page
    {
        Sale sale = new Sale();
        public EditSalePage(Sale sale)
        {
            InitializeComponent();
            DataContext = sale;

            this.sale.IdSale = sale.IdSale;

            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sale sale = DBEntities.GetContext().Sale.
                FirstOrDefault(s => s.IdSale == VariableClass.IdSale);
                sale.DateSale = DateTime.Parse(DateSaleTb.Text);
                sale.QuantitySale = Int32.Parse(QuantitySaleTb.Text);
                sale.IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Продажа успешно отредактирован");
                NavigationService.Navigate(new ListSalePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
