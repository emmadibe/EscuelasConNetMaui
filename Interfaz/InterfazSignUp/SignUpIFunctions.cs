using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Interfaz.InterfazSignUp
{
    public interface SignUpIFunctions
    {
        public void _signUp();

        public ObservableCollection<RamaItem> CargarRamas();
    }
}
