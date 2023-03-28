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
using System.Windows.Shapes;
using YaroshevskiKursach.ClassFolder;
using YaroshevskiKursach.DataFolder;

namespace YaroshevskiKursach.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginTBl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginTB.Focus();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void PasswordPsb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordPsb.Password) && PasswordPsb.Password.Length > 0)
                PasswordTB.Visibility = Visibility.Collapsed;
            else
                PasswordTB.Visibility = Visibility.Visible;
        }

        private void PasswordTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordPsb.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(LoginTB.Text))
                {
                    MBClass.ErrorMB("Введите логин");
                    LoginTB.Focus();
                }
                if (string.IsNullOrEmpty(PasswordPsb.Password))
                {
                    MBClass.ErrorMB("Введите пароль");
                    PasswordPsb.Focus();
                }
                else
                {
                    try
                    {
                        var user = DBEntities.GetContext().User.FirstOrDefault
                            (u => u.LoginUser == LoginTB.Text);
                        if (user == null)
                        {
                            MBClass.ErrorMB("Пользователь не найден");
                            LoginTB.Focus();
                            return;
                        }
                        if (user.PasswordUser != PasswordPsb.Password)
                        {
                            MBClass.ErrorMB("Введен не правильный пароль");
                            PasswordPsb.Focus();
                            return;
                        }
                        else
                        {
                            switch (user.IdRole)
                            {
                                case 2:
                                    new MainAdminWindow().Show();
                                    this.Close();
                                    break;

                                case 3:
                                    MainDirectorWindow dirWindow = new MainDirectorWindow();
                                    dirWindow.Show();
                                    this.Close();
                                    break;

                                case 4:
                                    MainManagerStoreWindow ManagerStoreWindow = new MainManagerStoreWindow();
                                    ManagerStoreWindow.Show();
                                    this.Close();
                                    break;

                                case 5:
                                    MainStaffWindow StaffWindow = new MainStaffWindow();
                                    StaffWindow.Show();
                                    this.Close();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MBClass.ErrorMB(ex);
                    }
                }
            }
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTB.Text) && LoginTB.Text.Length > 0)
                LoginTBl.Visibility = Visibility.Collapsed;
            else
                LoginTBl.Visibility = Visibility.Visible;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
