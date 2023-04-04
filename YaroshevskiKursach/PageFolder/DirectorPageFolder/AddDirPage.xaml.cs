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
    /// Логика взаимодействия для AddDirPage.xaml
    /// </summary>
    public partial class AddDirPage : Page
    {
        public AddDirPage()
        {
            InitializeComponent();
            UserCb.ItemsSource = DBEntities.GetContext()
                .User.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Staff.Add(new Staff()
            {
                LastNameStaff = LastNameTb.Text,
                FirstNameStaff = FirstNameTb.Text,
                MiddleNameStaff = MiddleNameTb.Text,
                PhoneNubmerStaff = PhoneNubmerTb.Text,
                EmailStaff = EmailTb.Text,
                IdUser = Int32.Parse(UserCb.SelectedValue.ToString()),
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListDirPage());
        }
    }
}
