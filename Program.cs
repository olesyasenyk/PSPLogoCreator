using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PSPLogoCreator
{
    class Program
    {
        public class Photo
        {
            public static Photo Load(string path)
            {
                return new Photo();
            }

            public void Save()
            {

            }
        }

        public class PhotoProcessor
        {
            public delegate void Action(Photo photo);
            public void Process (string path, Action<Photo> filterHandler)
            {
                var photo = Photo.Load(path);
                filterHandler(photo); // this code doesn't know what filter will be applied. This will be responsibility of the client of this class - Program.cs
                photo.Save();

            }
        }
        public class PhotoFilters
        {
            public void ApplyTransparentBackground(Photo photo)
            {
                
            }
        }
        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
        static void Main(string[] args)
        {
            //PhotoProcessor processor = new();
            //PhotoFilters filters = new();
            //Action<Photo> filterHandler = filters.ApplyTransparentBackground;
            //processor.Process(@"C:\Users\olesia.falafivka\Downloads.ApplePayLogo.png", filterHandler);

            //ImageProcessor.ImageFactory sourceImage = new();
            //sourceImage.Load(@"C:\Users\olesia.falafivka\Downloads\ApplePayLogo.png");

            //System.Drawing.Size webSize = new(64, 102);
            //sourceImage.Resize(webSize);
            //sourceImage.Save(@"C:\Users\olesia.falafivka\Downloads\ApplePayLogo" + "_web" +".png");

            //System.Drawing.Size mobSize = new(80, 42);
            //sourceImage.Resize(mobSize);
            //sourceImage.Save(@"C:\Users\olesia.falafivka\Downloads\ApplePayLogo" + "_mob" + ".png");

            //ImageProcessor.ImageFactory wcapiCmsBackground = new();    
            //wcapiCmsBackground.Load(@"D:\Docs\_AllIcons\empty_CMS_innerimage80.png");

            //ImageProcessor.ImageFactory mobImage = new();
            //mobImage.Load(@"C:\Users\olesia.falafivka\Downloads\ApplePayLogo" + "_mob" + ".png");


            //ImageProcessor.Imaging.ImageLayer topLayer = new();
            //topLayer.Image = (ImageProcessor.Imaging.ImageLayer)mobImage;


            //wcapiCmsBackground.Overlay(mobImage);
            Console.WriteLine("Link to image:");
            //string image = Console.ReadLine();
            string path = @"C:\Users\olesia.falafivka\Downloads\ApplePayLogo.png";
#pragma warning disable CA1416 // Validate platform compatibility
            Bitmap bitmap = new(Image.FromFile(path));
            
            //make web
            Bitmap web = ResizeBitmap(bitmap, 102, 64);
            web.Save($@"C:\Users\olesia.falafivka\Downloads\Web.png", ImageFormat.Png);

            //make mob
            Bitmap mob = ResizeBitmap(bitmap, 80, 42);
            mob.Save($@"C:\Users\olesia.falafivka\Downloads\Mob.png", ImageFormat.Png);

            //bitmap.MakeTransparent();
            //bitmap.Save($@"C:\Users\olesia.falafivka\Downloads\New.png", ImageFormat.Png); // putting .png after New is crucial

#pragma warning restore CA1416 // Validate platform compatibility





        }
    }
}
