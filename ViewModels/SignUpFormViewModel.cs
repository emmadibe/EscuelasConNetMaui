using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EscuelaConMaui.Enums;
using EscuelaConMaui.Interfaz.InterfazSignUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.ViewModels
{
    public partial class SignUpFormViewModel : ObservableValidator //La clase ObservableValidator extiende de ObservableObject. Por lo tanto, esta clase, que me la proporciona el toolkit de MVVM, va a tener los métodos y propiedades de su padre más otros que me permitirán realizar validaciones. 
    {
        private readonly SignUpIFunctions functions; //Mis dependencias.

        //PROPIEDADES:

        //Acordate que la propiedd ObservableProperty crea, aunque no la veamos, una propiedad oública de la propiedad privada de abajo y le cambia la inicial a mayúscula. En este caso, crea una propiedad Ramas, la cual usaré en el método cargarRamas. 
        [ObservableProperty]
        private ObservableCollection<RamaItem> ramas; //El primer atributo de mi ViewModel es una colección de RamaItem. Cada elemento de mi colección es una instancia de RamaItem. Por lo tanto, cada elemento de la colección tendrá tres propiedades: una Rama, que es el enum; un string, que indica el nombre; y un int, que indica el valor. 
        [Required(ErrorMessage = "El campo apellido es obligatorio, pal")] 
        [ObservableProperty]
        private RamaItem selectedRama = new RamaItem(); //Otra propiedad es una instancia de RamaItem. 
        [Required(ErrorMessage = "El campo apellido es obligatorio, pal")]
        private string name = string.Empty;
        [Required(ErrorMessage = "El campo apellido es obligatorio, pal")]
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value, true);
        } 

        private string lastName = string.Empty;

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value, true);
        }

        private int age = 0;
        public int Age
        {
            get => age;
            set => SetProperty<int>(ref age, value, true);
        }

        public SignUpFormViewModel() //Builder.
        {
            this.functions = App.Current.Services.GetRequiredService<SignUpIFunctions>(); //Le digo al software que quiero acceder al servicio de tipo SignUpIFunctions. Estoy inyectando la dependencia (SignUpIFunctions) por MÉTODO. 

            Ramas = functions.CargarRamas(); //En el constructor, estoy llamando al método CargarRamas(). Por lo tanto, ni bien comboco al método SignUpFormViewModel se carga la propiedad-colección Ramas.
                                             //Este método lo que hace es inicializar mi propiedad colección Ramas. 
        }

        [RelayCommand]
        private void RamaSeleccionada()
        {
            if (SelectedRama != null)
            {
                // Aquí puedes manejar la lógica de cuando una rama es seleccionada
                Console.WriteLine($"Rama seleccionada: {SelectedRama.Nombre} (Valor: {SelectedRama.Valor})");
            }
        }

        [RelayCommand]
        public void signUp()
        {
            this.functions.signUp();
        }
       
    }
}
