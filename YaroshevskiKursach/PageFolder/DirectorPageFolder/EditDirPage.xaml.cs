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

namespace YaroshevskiKursach.PageFolder.DirectorPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditDirPage.xaml
    /// </summary>
    public partial class EditDirPage : Page
    {
        Staff staff = new Staff();
        public EditDirPage(Staff staff)
        {
            InitializeComponent();
            DataContext = staff;

            this.staff.IdStaff = staff.IdStaff;

            UserCb.ItemsSource = DBEntities.GetContext()
                .User.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staff = DBEntities.GetContext().Staff
                        .FirstOrDefault(u => u.IdStaff == staff.IdStaff);
                staff.LastNameStaff = LastNameTb.Text;
                staff.FirstNameStaff = FirstNameTb.Text;
                staff.MiddleNameStaff = MiddleNameTb.Text;
                staff.PhoneNubmerStaff = PhoneNubmerTb.Text;
                staff.EmailStaff = EmailTb.Text;
                staff.IdUser = Int32.Parse(
                    UserCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListDirPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
