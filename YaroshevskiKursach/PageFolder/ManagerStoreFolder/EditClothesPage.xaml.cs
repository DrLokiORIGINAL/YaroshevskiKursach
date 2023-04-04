using Microsoft.Win32;
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

namespace YaroshevskiKursach.PageFolder.ManagerStoreFolder
{
    /// <summary>
    /// Логика взаимодействия для EditClothesPage.xaml
    /// </summary>
    public partial class EditClothesPage : Page
    {
        Clothes clothes = new Clothes();
        public EditClothesPage(Clothes clothes)
        {
            InitializeComponent();
            DataContext = clothes;
            CollectionCb.ItemsSource = DBEntities.GetContext().Clothes.ToList().OrderBy(u => u.IdCollection);
            SeasonCb.ItemsSource = DBEntities.GetContext().Clothes.ToList().OrderBy(u => u.IdSeason);
            TypeOfClothingCb.ItemsSource = DBEntities.GetContext().Clothes.ToList().OrderBy(u => u.IdTypeOfClothing);
            GenderCb.ItemsSource = DBEntities.GetContext().Clothes.ToList().OrderBy(u => u.IdGender);
            ViewOfClothingCb.ItemsSource = DBEntities.GetContext().Clothes.ToList().OrderBy(u => u.IdViewIdOfClothing);
        }

        string selectedFileName = "";
        private void AddPhoto()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                selectedFileName = op.FileName;
                clothes.PhotoClothes = ImageClass.ConvertImageToByteArray(selectedFileName);
                PhotoIm.Source = ImageClass.ConvertByteArrayToImage(clothes.PhotoClothes);
            }

        }

        private void EditCLothes()
        {
            try
            {
                if (selectedFileName == "")
                {
                    clothes = DBEntities.GetContext().Clothes.FirstOrDefault(r => r.IdClothes == clothes.IdClothes);
                    clothes.IdCollection = Int32.Parse(CollectionCb.SelectedValue.ToString());
                    clothes.IdSeason = Int32.Parse(SeasonCb.SelectedValue.ToString());
                    clothes.IdTypeOfClothing = Int32.Parse(TypeOfClothingCb.SelectedValue.ToString());
                    clothes.IdGender = Int32.Parse(GenderCb.SelectedValue.ToString());
                    clothes.IdViewIdOfClothing = Int32.Parse(ViewOfClothingCb.SelectedValue.ToString());
                    DBEntities.GetContext().SaveChanges();
                }
                else
                {
                    clothes = DBEntities.GetContext().Clothes.FirstOrDefault(r => r.IdClothes == clothes.IdClothes);
                    clothes.IdCollection = Int32.Parse(CollectionCb.SelectedValue.ToString());
                    clothes.IdSeason = Int32.Parse(SeasonCb.SelectedValue.ToString());
                    clothes.IdTypeOfClothing = Int32.Parse(TypeOfClothingCb.SelectedValue.ToString());
                    clothes.IdGender = Int32.Parse(GenderCb.SelectedValue.ToString());
                    clothes.IdViewIdOfClothing = Int32.Parse(ViewOfClothingCb.SelectedValue.ToString());
                    clothes.PhotoClothes = ImageClass.ConvertImageToByteArray(selectedFileName);
                    DBEntities.GetContext().SaveChanges();
                }
                MBClass.InformationMB("Одежда отредактирована");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            EditCLothes();
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
    }
}
