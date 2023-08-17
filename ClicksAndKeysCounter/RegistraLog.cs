
namespace ClicksAndKeysCounter
{
    internal class RegistraLog
    {
        private static string GetFilePath()
        {
            string caminhoArquivo = AppContext.BaseDirectory;

            caminhoArquivo = Path.Combine(caminhoArquivo, "log");
            if (!Directory.Exists(caminhoArquivo))
                Directory.CreateDirectory(caminhoArquivo);

            caminhoArquivo = Path.Combine(caminhoArquivo, "ArquivoLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            if (!File.Exists(caminhoArquivo))
            {
                FileStream arquivo = File.Create(caminhoArquivo);
                arquivo.Close();
            }

            return caminhoArquivo;
        }

        public static bool LogDetalhado(string strMensagem)
        {
            try
            {
                string filePath = GetFilePath();
                using (StreamWriter w = File.AppendText(filePath))
                {
                    try
                    {
                        w.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} => {strMensagem}");
                        w.Close();
                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int GetLastCountLeftClicks()
        {
            string filePath = GetFilePath();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (lines[i].Contains("Left Button Clicks: "))
                {
                    string[] line = lines[i].Split(':');
                    return Convert.ToInt32(line[line.Length-1].Trim());
                }
            }

            return 0;
        }

        public static int GetLastCountRightClicks()
        {
            string filePath = GetFilePath();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (lines[i].Contains("Right Button Clicks: "))
                {
                    string[] line = lines[i].Split(':');
                    return Convert.ToInt32(line[line.Length - 1].Trim());
                }
            }

            return 0;
        }
    }
}
