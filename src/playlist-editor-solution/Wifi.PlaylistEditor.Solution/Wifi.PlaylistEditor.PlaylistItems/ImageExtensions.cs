using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.PlaylistItems
{
    internal static class ImageExtensions
    {
        public static Image ResizeAndFill(this Image originalImage, 
                                          int targetWidth, int targetHeight, 
                                          Color fillColor)
        {
            // Berechne das Verhältnis zur Skalierung
            float ratioX = (float)targetWidth / originalImage.Width;
            float ratioY = (float)targetHeight / originalImage.Height;
            float ratio = Math.Min(ratioX, ratioY);

            // Berechne neue Größe des Bildes
            int newWidth = (int)(originalImage.Width * ratio);
            int newHeight = (int)(originalImage.Height * ratio);

            // Berechne Position zum Zentrieren des Bildes
            int posX = (targetWidth - newWidth) / 2;
            int posY = (targetHeight - newHeight) / 2;

            Image newImage = new Bitmap(targetWidth, targetHeight);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                // Fülle den Hintergrund mit der angegebenen Farbe
                graphics.Clear(fillColor);

                // Zeichne das verkleinerte Bild auf das neue Bild
                graphics.DrawImage(originalImage, posX, posY, newWidth, newHeight);
            }

            // Speichere das neue Bild
            return newImage;
        }

    }
}
