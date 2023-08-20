
namespace ClicksAndKeysCounter
{
    internal class RegistraLog
    {
        public static string messageLeftButtonClick = "Left Button Clicks";
        public static string messageRightButtonClick = "Right Button Clicks";
        public static string messageKeyPress = "Keys Pressed";

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

        public static bool RegisterSetCount(string button, int count)
        {
            if (button == "L")
                return LogDetalhado(messageLeftButtonClick + " : " + count.ToString());
            if (button == "R")
                return LogDetalhado(messageRightButtonClick + " : " + count.ToString());
            if (button == "K")
               return LogDetalhado(messageKeyPress + " : " + count.ToString());

            return false;
        }

        public static int GetLastCount(string button)
        {
            string filePath = GetFilePath();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (button == "L")
                {
                    if (lines[i].Contains(messageLeftButtonClick))
                    {
                        string[] line = lines[i].Split(':');
                        if (!string.IsNullOrWhiteSpace(line[line.Length - 1]))
                        {
                            return Convert.ToInt32(line[line.Length - 1].Trim());
                        }
                    }
                }
                else if (button == "R")
                {
                    if (lines[i].Contains(messageRightButtonClick))
                    {
                        string[] line = lines[i].Split(':');
                        return Convert.ToInt32(line[line.Length - 1].Trim());
                    }
                }
                else if (button == "K")
                {
                    if (lines[i].Contains(messageKeyPress))
                    {
                        string[] line = lines[i].Split(':');
                        return Convert.ToInt32(line[line.Length - 1].Trim());
                    }
                }

            }

            return 0;
        }

    }
}
