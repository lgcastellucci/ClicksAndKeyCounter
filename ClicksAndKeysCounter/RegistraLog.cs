
namespace ClicksAndKeysCounter
{
    internal class RegistraLog
    {
        public static bool LogDetalhado(string strMensagem)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} => {strMensagem}");

            string erro = "";

            try
            {
                string caminhoArquivo = AppContext.BaseDirectory;
                erro = "1";

                caminhoArquivo = Path.Combine(caminhoArquivo, "log");
                if (!Directory.Exists(caminhoArquivo))
                {
                    Directory.CreateDirectory(caminhoArquivo);
                }

                caminhoArquivo = Path.Combine(caminhoArquivo, "ArquivoLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                erro = "2";

                if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    erro = "3";

                    arquivo.Close();
                    erro = "4";
                }

                using (StreamWriter w = File.AppendText(caminhoArquivo))
                {
                    erro = "5";
                    try
                    {
                        w.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} => {strMensagem}");
                        erro = "6";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("erro " + erro);

                        Console.WriteLine(ex);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("erro " + erro);
                Console.WriteLine(ex);

                return false;
            }
        }
    }
}
