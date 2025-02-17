using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EscuelaConMaui.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.ViewModels
{
    public partial class SignUpFormViewModel : ObservableValidator //La clase ObservableValidator extiende de ObservableObject. Por lo tanto, esta clase, que me la proporciona el toolkit de MVVM, va a tener los métodos y propiedades de su padre más otros que me permitirán realizar validaciones. Por ejemplo, posee las propiedades Required y MaxLength.
    {
        private readonly GeneralsIFunctions generals; //Mis otras dependencias.

        //PROPIEDADES:
        public ObservableCollection<string> Errors { get; set; } = new(); //Es una colección, de tipo ObservableCollection (colección que me la da el toolkit) que almacena strings. O sea, cada elemento de la colección es un string. Ese string representa un error. Como puede haber más de un error es que necesito que sea una colección. En efecto, un campo puede no pasar la validación Required ni tampoco la MaxLength. 

        private string? _name;
        [Required (ErrorMessage ="Campo obligatorio")]
        [MaxLength (50)]    
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, true);
        }

        private string? _lastName;
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50)]

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value, true);
        }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (_age != value) //Si el valor de _age es diferente al valor que recibe para setear...
                {
                    _age = value; //Cambio el valor de age por value.
                    this.generals.OnPropertyChanged(); //Actualizo la UI sin refresh. Como el parámetro del método OnPropertyChanged tiene el atributo CalledMembeName, no necesito aclarar que quiero actualizar la propiedad Age, sino que se pasa ese valor solito sin que lo aclare porque Age es la propiedad que está llamandolo.
                }
            }
        }
        [Required(ErrorMessage = "Campo obligatorio")]

        public List<int> Ages => Enumerable.Range(18, 120).ToList();

        private Rama _ramaSeleccionada;
        public Rama RamaSeleccionada
        {
            get => _ramaSeleccionada;
            set
            {
                if (_ramaSeleccionada != value)
                {
                    _ramaSeleccionada = value;
                    this.generals.OnPropertyChanged(nameof(RamaSeleccionada)); //Llamo al método On... vía inyección de dependencias. 
                }
            }
        }
        [Required(ErrorMessage = "Por favor, seleccione una rama")]


        public List<Rama> Ramas => Enum.GetValues(typeof(Rama)).Cast<Rama>().ToList(); //Colección, de tipo List, de Ramas. O sea, cada elemento de la colección es una Rama. 
        // Enum.GetValues(typeof(Rama)) es un método estático de la clase Enum que obtiene un array de objetos que representan los valores definidos en el enum Rama. typeof(Rama) pasa el tipo de enumeración para obtener sus valores.
        //.Cast<Rama>() convierte cada uno de los objetos en el array devuelto por GetValues al tipo específico Rama. Esto es necesario porque GetValues retorna un Array de objetos object, y necesitamos especificar que son del tipo Rama.
        // .ToList() convierte la secuencia de valores (ahora de tipo Rama) en una List<Rama> ((recordar que el método GetValue retrna un array). Esto convierte el IEnumerable<Rama> que resulta del Cast en una lista que puede ser usada como la propiedad.


        public SignUpFormViewModel() //Builder.
        { 
            this.generals = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            //Dado que voy a utiliar un método que está en la clase GeneralFunctions (OnPropertyChanged)es una buena práctica hacer inyección de dependencias para que la clase SignUpFormViewModel NO dependa directamente de GeneralFUnctions, sino de la interfaz que tiene la definición de su método (GeneralIFunctions). 
        }



        [RelayCommand]
        public async Task SignUp()
        {
            ValidateAllProperties(); //Valida todas las Data Annotations. 
            Errors.Clear(); //Si hay algún error anterior, lo quito. 
            GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add("Nombre: " + f.ErrorMessage)); //Traeme los errores del campo nombre. Como pueden ser más de uno, me los convierte a una lista. Luego, va recorriendo esa lista a partir del bucle forEach. Por cada elemento que hay en la lista, agrega (Add) el siguiente string a la colección Errors: "Nombre: el mensaje de error que haya".
            GetErrors(nameof(LastName)).ToList().ForEach(f => Errors.Add("Apellido: " + f.ErrorMessage));
            GetErrors(nameof(RamaSeleccionada)).ToList().ForEach(f => Errors.Add("Rama: " + f.ErrorMessage ));
            GetErrors(nameof(Age)).ToList().ForEach(f => Errors.Add("Edad: " + f.ErrorMessage));
        }

    }
}
