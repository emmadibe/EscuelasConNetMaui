using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EscuelaConMaui.Interfaz.InterrfazLogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.ViewModels
{
    public partial class LoginViewModel : ObservableObject //Extiende de ObservableObject. Esta clase, que me la otorga el toolkit de MVVM, hace que todas las propiedades sean Observable y los comandos sean Observables. Permite a mi clase ser usada desde una vista. 
    {
        private readonly LoginIFunctions functions; 

        public LoginViewModel()
            => this.functions = App.Current.Services.GetRequiredService<LoginIFunctions>();//Le digo al software que quiero acceder al servicio de tipo LoginIFunctions. Estoy inyectando la dependencia (LoginIFunctions) por MÉTODO. 

        [RelayCommand] //Propiedad de toolkit que establece al método por debajo como comando, lo cual me permite usarlo en la o en las vistas asociadas a mi clase viewModel. 
        public void logueIn()
        {
            this.functions.logueIn("Holaaaa");
        }
    }

    
}
