using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Interfaz
{
    internal interface GeneralsIFunctions
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null);

    }
}
