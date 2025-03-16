using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Helpers
{
    public class FileAccesHelper 
    {
        public static string GetPathFile(string File) //Método para acceder al archivo de la bdd para establecer la conexión. 
            => System.IO.Path.Combine(FileSystem.AppDataDirectory, File);

        public static string GetAppDirectoy()
            => FileSystem.AppDataDirectory;

    }
}
