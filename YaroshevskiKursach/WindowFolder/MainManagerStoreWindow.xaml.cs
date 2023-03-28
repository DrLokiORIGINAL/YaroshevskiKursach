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
using YaroshevskiKursach.PageFolder.ManagerStoreFolder;

namespace YaroshevskiKursach.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainManagerStoreWindow.xaml
    /// </summary>
    public partial class MainManagerStoreWindow : Window
    {
        public MainManagerStoreWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.ManagerStoreFolder.ListStorePage());
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListStore.IsSelected)
            {
                MaiFrame.Navigate(new ListStorePage());
            }

            else if (AddStore.IsSelected)
            {
                MaiFrame.Navigate(new AddStorePage());
            }

            else if (ListProduct.IsSelected)
            {
                MaiFrame.Navigate(new ListProductPage());
            }

            else if (AddProduct.IsSelected)
            {
                MaiFrame.Navigate(new AddProductPage());
            }

            else if (ListClothes.IsSelected)
            {
                MaiFrame.Navigate(new ListClothesPage());
            }

            else if (AddClothes.IsSelected)
            {
                MaiFrame.Navigate(new AddClothesPage());
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
