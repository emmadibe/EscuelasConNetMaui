using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EscuelaConMaui.Interfaz.InterrfazLogIn;
using EscuelaConMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.ViewModels
{
    public partial class LoginViewModel : ObservableObject //Extiende de ObservableObject. Esta clase, que me la otorga el toolkit de MVVM, hace que todas las propiedades sean Observable y los comandos sean Observables. Permite a mi clase ser usada desde una vista. 
    {
        //Inyección de dependencias:
        private readonly ITeachers _teacherService;
        ///
        [ObservableProperty] //Acordate que la propiedad ObservableProperty, que me la proporciona el kit toolkit de MVVM, lo que hace es crearme, sin que la vea en la presente clase, un propiedad con el modificador de acceso público de la propiedad privada que se halla debajo. Y a esa propiedad pública le pone como primera letra una mayúscula. Es por ello que en los binding del archivo xmls de Login las propiedades a las que refieren inician con mayúscula. 
        private string name;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private int id;

        public LoginViewModel()
            => _teacherService = App.Current.Services.GetRequiredService<ITeachers>(); //Inyecto la dependencia.

        [RelayCommand] //Propiedad de toolkit que establece al método por debajo como comando, lo cual me permite usarlo en la o en las vistas asociadas a mi clase viewModel. O sea, me permite utilizar al método que está debo de la presente propiedad como un, en términos de JavaFx, MANEJADOR DE EVENTOS. En .NET esos métodos se llaman COMANDOS. De hecho, en el BINDING de la vista, la propiedad RelayCommand le agrega automáticamente la palabra Command al final del método al que corresponde dicha propiedad. 
        public async Task logueIn(TeachersModels teachers)
        {
            Id = _teacherService.ExistsTeacher(new TeachersModels { Name = Name, Password = Password});
            if (Id > 0)
            {
                await Shell.Current.GoToAsync($"MainTeacherMenu?Id={Id}");
            }
        }
        [RelayCommand]
        public async Task SignUp()
        {
            await Shell.Current.GoToAsync("SignUpForm"); //Me reedirecciona  a la ruta que le pase por parámetro.
        }
    }

    
}
