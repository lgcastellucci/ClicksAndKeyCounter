using System.Drawing.Imaging;

namespace ClicksAndKeysCounter
{
    internal class SaveImage
    {
        private static string GetDirectoryPath()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "images");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
        private static string GetFileName()
        {
            return "mouse_click_positions" + DateTime.Now.ToString("yyyyMMdd") + ".png";
        }

        private static Bitmap CreateEmptyBitmap(Color c, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(c);
            }
            return bmp;
        }

        public static void UpdateImage(int x, int y)
        {
            string imageFilePath = Path.Combine(GetDirectoryPath(), GetFileName());
            string ImageNewFilePath = Path.Combine(GetDirectoryPath(), "temp.png");

            Bitmap image;
            if (File.Exists(imageFilePath))
                image = new Bitmap(imageFilePath);
            else
                image = CreateEmptyBitmap(Color.White, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);

            var graphics = Graphics.FromImage(image);

            // Desenha um círculo na posição do clique
            int circleRadius = 2;
            graphics.FillEllipse(Brushes.Black, x - circleRadius, y - circleRadius, 2 * circleRadius, 2 * circleRadius);

            // Salva a imagem em um arquivo
            image.Save(ImageNewFilePath, ImageFormat.Png);

            graphics.Dispose();
            image.Dispose();

            File.Delete(imageFilePath);
            File.Move(ImageNewFilePath, imageFilePath);
        }

        public static Bitmap GetImage()
        {
            string imageFilePath = Path.Combine(GetDirectoryPath(), GetFileName());

            if (File.Exists(imageFilePath))
                return new Bitmap(imageFilePath);
            else
                return CreateEmptyBitmap(Color.White, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
        }

    }
}
