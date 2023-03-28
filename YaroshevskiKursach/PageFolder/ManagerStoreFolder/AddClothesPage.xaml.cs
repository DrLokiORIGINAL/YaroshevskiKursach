using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddClothesPage.xaml
    /// </summary>
    public partial class AddClothesPage : Page
    {
        Clothes clothes = new Clothes();
        TypeOfClothing typeOfClothing = new TypeOfClothing();
        public AddClothesPage()
        {
            InitializeComponent();
            CollectionCB.ItemsSource = DBEntities.GetContext().Collection.ToList();
            SeasonCB.ItemsSource = DBEntities.GetContext().Season.ToList();
            TypeOfClothingCB.ItemsSource = DBEntities.GetContext().TypeOfClothing.ToList();
            GenderCB.ItemsSource = DBEntities.GetContext().Gender.ToList();
            ViewOfClothingCB.ItemsSource = DBEntities.GetContext().ViewOfClothing.ToList();
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }

        private void AddClothesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClothesAdd();
                TypeOfClothingAdd();

                MBClass.InformationMB("Одежда добавлена");
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void ClothesAdd()
        {
            var clothesAdd = new Clothes()
            {
                IdCollection = Int32.Parse(CollectionCB.SelectedValue.ToString()),
                IdSeason = Int32.Parse(SeasonCB.SelectedValue.ToString()),
                IdTypeOfClothing = Int32.Parse(TypeOfClothingCB.SelectedValue.ToString()),
                IdGender = Int32.Parse(GenderCB.SelectedValue.ToString()),

            };
            DBEntities.GetContext().Clothes.Add(clothesAdd);
            DBEntities.GetContext().SaveChanges();
            clothes.IdClothes = clothesAdd.IdClothes;
        }

        private void TypeOfClothingAdd()
        {
            var TypeOfClothingAdd = new TypeOfClothing()
            {
                IdViewIdOfClothing = Int32.Parse(ViewOfClothingCB.SelectedValue.ToString()),
            };
            DBEntities.GetContext().TypeOfClothing.Add(TypeOfClothingAdd);
            DBEntities.GetContext().SaveChanges();
            typeOfClothing.IdTypeOfClothing = TypeOfClothingAdd.IdTypeOfClothing;
        }

        string selectedFileName = "";

        private void AddPhoto()
        {
            try
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
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
