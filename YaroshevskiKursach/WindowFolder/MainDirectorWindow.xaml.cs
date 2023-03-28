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
using YaroshevskiKursach.PageFolder.DirectorPageFolder;

namespace YaroshevskiKursach.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainDirectorWindow.xaml
    /// </summary>
    public partial class MainDirectorWindow : Window
    {
        public MainDirectorWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.DirectorPageFolder.ListDirPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListStaff.IsSelected)
            {
                MaiFrame.Navigate(new ListDirPage());
            }

            else if (AddStaff.IsSelected)
            {
                MaiFrame.Navigate(new AddDirPage());
            }

            else if (ListSale.IsSelected)
            {
                MaiFrame.Navigate(new ListSalePage());
            }
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
