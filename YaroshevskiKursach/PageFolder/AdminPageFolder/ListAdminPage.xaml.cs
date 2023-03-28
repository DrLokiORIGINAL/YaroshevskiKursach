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
    /// Логика взаимодействия для ListAdminPage.xaml
    /// </summary>
    public partial class ListAdminPage : Page
    {
        public ListAdminPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().User.ToList()
                .OrderBy(c => c.IdUser);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditAdminPage(ListAdminDG.SelectedItem as User));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .User.Where(u => u.LoginUser
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.LoginUser);
            if (ListAdminDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            User user = ListAdminDG.SelectedItem as User;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"пользователя с логином " +
                    $"{user.LoginUser}?"))
                {
                    DBEntities.GetContext().User
                        .Remove(ListAdminDG.SelectedItem as User);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Пользователь удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .User.ToList().OrderBy(u => u.LoginUser);
                }

            }
        }
    }
}
