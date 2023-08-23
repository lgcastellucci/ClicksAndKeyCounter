using System.Drawing.Imaging;

namespace ClicksAndKeysCounter
{
    internal class SaveImage
    {
        static string identificationFileName = "mouse_click_positions";

        private static string GetDirectoryPath()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "images");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        private static string GetFileName()
        {
            return identificationFileName + DateTime.Now.ToString("yyyyMMdd") + ".png";
        }

        private static string GetFilePath()
        {
            return Path.Combine(GetDirectoryPath(), GetFileName());
        }

        private static Bitmap CreateEmptyBitmap(Color c, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            var g = Graphics.FromImage(bmp);
            g.Clear(c);
            return bmp;
        }

        private static Bitmap CreateEmptyBitmapWhiteScreenLength()
        {
            return CreateEmptyBitmap(Color.White, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
        }

        public static void UpdateImage(int x, int y)
        {
            string imageFilePath = GetFilePath();
            string imageNewFilePath = Path.Combine(GetDirectoryPath(), "temp.png");

            Bitmap image;
            if (File.Exists(imageFilePath))
            {
                File.Move(imageFilePath, imageNewFilePath, true);
                image = new Bitmap(imageNewFilePath);
            }
            else
                image = CreateEmptyBitmapWhiteScreenLength();

            var graphics = Graphics.FromImage(image);

            // Desenha um círculo na posição do clique
            int circleRadius = 2;
            graphics.FillEllipse(Brushes.Black, x - circleRadius, y - circleRadius, 2 * circleRadius, 2 * circleRadius);

            // Salva a imagem em um arquivo
            image.Save(imageFilePath, ImageFormat.Png);

            graphics.Dispose();
            image.Dispose();

            File.Delete(imageNewFilePath);
        }

        public static Bitmap GetImage(DateTime dateTime)
        {
            string imageFilePath = Path.Combine(GetDirectoryPath(), identificationFileName + dateTime.ToString("yyyyMMdd") + ".png");
            string imageViewFilePath = Path.Combine(GetDirectoryPath(), "tempView.png");

            if (File.Exists(imageFilePath))
            {
                File.Copy(imageFilePath, imageViewFilePath, true);
                var image = new Bitmap(imageViewFilePath);
                var newImage = new Bitmap(image);
                image.Dispose();

                return newImage;
            }
            return CreateEmptyBitmapWhiteScreenLength();
        }
    }
}
