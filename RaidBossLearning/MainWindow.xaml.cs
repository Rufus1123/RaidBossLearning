using Microsoft.Win32;
using RaidBossLearning.Enums;
using RaidBossLearning.Helpers;
using RaidBossLearning.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using RaidBossLearning.ImageProperties;

namespace RaidBossLearning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int offsetX = 10;
        private BitmapImage _singleImage;
        private CroppedBitmap _croppedImage;
        private RaidbossIconData _raidbossIconData = new RaidbossIconData();
        private RaidLevel _raidLevel;
        private GymColor _gymColor;

        public MainWindow()
        {
            InitializeComponent();
            _raidbossIconData.LoadIconData();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                _singleImage = new BitmapImage(new Uri(op.FileName));
                imgPhoto.Source = _singleImage;
                imgPhoto.Margin = new Thickness(offsetX, 0, offsetX, 0);
            }
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            if(_singleImage != null && _raidLevel != RaidLevel.Unknown && _gymColor != GymColor.Unknown)
            {
                geometryGroepFull.Children.Clear();
                geometryGroepCrop.Children.Clear();
                var process = new ProcessImage(_raidbossIconData.IconData, _singleImage, _raidLevel, _gymColor);
                var imageProperty = process.GetImageProperty();

                if (imageProperty != null)
                {
                    _croppedImage = process.GetCroppedImage(imageProperty);
                    RectangleGeometry rg = GenerateRectangleGeometryFull(imageProperty);
                    geometryGroepFull.Children.Add(rg);

                    croppedImg.Source = _croppedImage;
                    croppedImg.Margin = new Thickness(offsetX, 0, offsetX, 0);
                    croppedImg.UpdateLayout();

                    foreach(var icon in imageProperty.IconsList)
                    {
                        RectangleGeometry rgIcon = GenerateRectangleGeometryCropped(icon, imageProperty.IconsArea);
                        geometryGroepCrop.Children.Add(rgIcon);
                    }
                }
            }
        }

        private RectangleGeometry GenerateRectangleGeometryFull(ImageProperty imageProperty)
        {
            var scaleX = imgPhoto.ActualWidth / imageProperty.Resolution.Width;
            var scaleY = imgPhoto.ActualHeight / imageProperty.Resolution.Height;
            var rect = new Rect
            {
                X = imageProperty.IconsArea.Left * scaleX + offsetX,
                Y = imageProperty.IconsArea.Top * scaleY,
                Width = imageProperty.IconsArea.Width * scaleX,
                Height = imageProperty.IconsArea.Height * scaleY
            };
            var rg = new RectangleGeometry(rect);
            return rg;
        }

        private RectangleGeometry GenerateRectangleGeometryCropped(ImageProperties.Rectangle icon, ImageProperties.Rectangle iconArea)
        {
            var scaleX = croppedImg.ActualWidth / iconArea.Width;
            var scaleY = croppedImg.ActualHeight / iconArea.Height;
            var rect = new Rect
            {
                X = (icon.Left - iconArea.Left) * scaleX + offsetX,
                Y = (icon.Top - iconArea.Top) * scaleY,
                Width = icon.Width * scaleX,
                Height = icon.Height * scaleY
            };
            var rg = new RectangleGeometry(rect);
            return rg;
        }

        private void RaidLevelsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _raidLevel = (RaidLevel)Enum.Parse(typeof(RaidLevel), raidLevelsBox.SelectedValue.ToString());
        }

        private void GymColorsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _gymColor = (GymColor) Enum.Parse(typeof(GymColor), gymColorsBox.SelectedValue.ToString());
        }
    }
}
