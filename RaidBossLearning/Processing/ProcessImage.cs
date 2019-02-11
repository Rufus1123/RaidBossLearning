using RaidBossLearning.Enums;
using RaidBossLearning.ImageProperties;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace RaidBossLearning.Processing
{
    public class ProcessImage
    {
        private BitmapImage _screenshot;
        private CroppedBitmap _raidbossIconsOnly;
        private List<ImageProperty> _imageProperties;
        private readonly RaidLevel _raidLevel;
        private readonly GymColor _gymColor;

        public ProcessImage(List<ImageProperty> imageProperties, BitmapImage img, RaidLevel raidLevel, GymColor color)
        {
            _imageProperties = imageProperties;
            _screenshot = img;
            _raidLevel = raidLevel;
            _gymColor = color;
        }

        public ImageProperty GetImageProperty()
        {
            var resolution = new Resolution { Width = _screenshot.PixelWidth, Height = _screenshot.PixelHeight };
            
            int stride = _screenshot.PixelWidth * 4;
            byte[] pixels = new byte[_screenshot.PixelHeight * stride];
            _screenshot.CopyPixels(pixels, stride, 0);
            var greenPixel = pixels.Length - 3;

            return _imageProperties.Find(ip => ip.RaidLevel == _raidLevel && 
                ip.Resolution.Equals(resolution) &&
                ip.ContainsBar == (greenPixel > 30 && greenPixel < 100));
        }

        public CroppedBitmap GetCroppedImage(ImageProperty result)
        {
            // Cut the rectangular area where the raidboss icons are
            var iconsArea = result.IconsArea;
            var iconsList = result.IconsList;

            _raidbossIconsOnly = new CroppedBitmap(
                _screenshot,
                new System.Windows.Int32Rect(iconsArea.Left, iconsArea.Top, iconsArea.Width, iconsArea.Height));

            return _raidbossIconsOnly;
        }

        public void TrainImage()
        {
            // Send image to the API for training
        }
    }
}
