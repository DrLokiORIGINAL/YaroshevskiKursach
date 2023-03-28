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

namespace YaroshevskiKursach.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditAdminPage.xaml
    /// </summary>
    public partial class EditAdminPage : Page
    {
        User user = new User();
        public EditAdminPage(User user)
        {
            InitializeComponent();
            DataContext = user;

            this.user.IdUser = user.IdUser;

            RoleCb.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user = DBEntities.GetContext().User
                        .FirstOrDefault(u => u.IdUser == user.IdUser);
                user.LoginUser = LoginTb.Text;
                user.PasswordUser = PasswordTb.Text;
                user.IdRole = Int32.Parse(
                    RoleCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListAdminPage());
            }
            catch(Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
