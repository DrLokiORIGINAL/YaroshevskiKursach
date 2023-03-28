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
using YaroshevskiKursach.PageFolder.StaffFolder;

namespace YaroshevskiKursach.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainStaffWindow.xaml
    /// </summary>
    public partial class MainStaffWindow : Window
    {
        public MainStaffWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.StaffFolder.ListOnlinePage());
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOnline.IsSelected)
            {
                MaiFrame.Navigate(new ListOnlinePage());
            }

            else if (AddOnline.IsSelected)
            {
                MaiFrame.Navigate(new AddOnlinePage());
            }

            else if (ListOffline.IsSelected)
            {
                MaiFrame.Navigate(new ListOfflinePage());
            }

            else if (AddOffline.IsSelected)
            {
                MaiFrame.Navigate(new AddOfflinePage());
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MBClass.QestionMB("Вы действительно хотите выйти из аккаунта?"))
            {
                new AuthorizationWindow().Show();
                Close();
            }
        }
    }
}
