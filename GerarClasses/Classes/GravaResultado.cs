using System.IO;

namespace GerarClasses.Classes
{
    public static class GravarResultado
    {
        public static bool Gravar(bool efetuarReplace, string dados, string nomeDoArquivo, params string[] pathDiretorio)
        {
            if (!Directory.Exists(Path.Combine(pathDiretorio)))
            {
                Directory.CreateDirectory(Path.Combine(pathDiretorio));
            }
            string pathArquivo = Path.Combine(pathDiretorio);
            pathArquivo = Path.Combine(pathArquivo, nomeDoArquivo);
            if (!File.Exists(pathArquivo))
            {
                File.WriteAllText(pathArquivo, dados);
                return true;
            }
            if (efetuarReplace)
            {
                File.WriteAllText(pathArquivo, dados);
            }
            return true;
        }
    }
}
