using System.IO;

namespace GerarClasses.Classes
{
    public static class LerTemplate
    {
        public static string Ler(params string[] pathArquivo)
        {
            string result = "";

            var path = Path.Combine(pathArquivo);
            if (File.Exists(path))
            {
                result = File.ReadAllText(path);
            }
            return result;
        }
    }
}
