using EscuelaConMaui.Interfaz.InterrfazLogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Services.ServicesLogIn
{
    public class LoginFunctions : LoginIFunctions //Implementa la interfaz. 
    {

        public void logueIn(string text)
            => Console.WriteLine(text); 
    }
}
