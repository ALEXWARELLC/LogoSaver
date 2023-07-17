using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DragonAPI.Plugins.Image2D
{
    public class Image2D
    {
        //GetImage();
        public static Image GetImage(string Location)
        {
            return Image.FromFile(Location);
        }
        public static Image GetImage(Stream FileStream)
        {
            return Image.FromStream(FileStream);
        }
        //GetImageSize();
        public static Size GetImageSize(Image SourceImage)
        {
            return SourceImage.Size;
        }
        public static Size GetImageSize(string SourceFile)
        {
            return Image.FromFile(SourceFile).Size;
        }
        public static Size GetImageSize(Stream SourceStream)
        {
            return Image.FromStream(SourceStream).Size;
        }
        //GetImageDPI();
        public static float GetImageDPI(Image SourceImage)
        {
            return SourceImage.HorizontalResolution;
        }
        public static float GetImageDPI(string SourceFile)
        {
            return Image.FromFile(SourceFile).HorizontalResolution;
        }
        public static float GetImageDPI(Stream SourceStream)
        {
            return Image.FromStream(SourceStream).HorizontalResolution;
        }
        //GetImagesFromDirectory();
        public List<Image> GetImagesFromDirectory(string SearchDirectory, string Extension)
        {
            List<Image> imagesToLoad = new List<Image>();
            foreach (string file in Directory.GetFiles(SearchDirectory))
            {
                if (new FileInfo(file).Extension == Extension)
                {
                    imagesToLoad.Add(Image.FromFile(file));
                }
            }
            return imagesToLoad;
        }
    }
}
