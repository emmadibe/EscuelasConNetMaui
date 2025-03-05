using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;
using EscuelaConMaui.Services;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace EscuelaConMaui.ViewModels.CoursesViewModels
{
    public partial class CreateCourseViewModels : ObservableValidator //Como tengo que validar que los datos ingresados por el usuario sean válidos (que respeten un min o max de chars, por ejempplo), la clase debe ser hija de ObservableValidator. Esta clase, recordemos, posee propiedades y métodos (como setProperty()) que me permiten a mi hacer validaciones sobre los datos ingresados por el usuario. 
    {
        //INYECCIÓN DE DEPENDENCIAS
        private readonly GeneralsIFunctions _generalsIFunctions;
        private readonly ICourses _coursesFunctions;
        //PROPIEDADES

        public ObservableCollection<string> Errors { get; set; } = new(); //Es una colección, de tipo ObservableCollection (colección que me la da el toolkit, muy similar a una colección List) que almacena strings. O sea, cada elemento de la colección es un string. Ese string representa un error. Como puede haber más de un error es que necesito que sea una colección. En efecto, un campo puede no pasar la validación Required ni tampoco la MaxLength o MinLength. 

        [ObservableProperty]
        private string? resultado;

        [ObservableProperty]
        private int courseId;

        private string? _name;

        [Required(ErrorMessage ="Campo obligatorio")]
        [MaxLength(20)]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, true); //Método que me otorga ObservableValidator. Primer parámetro, la propiedad a la cual le voy a setear el valor; el segundo, el valor que le seteo; el tercero, un bool, que indica si activo o no las validaciones. Al poner true, el software va a comprobar que se cumplan las validaciones como MaxLength y Required. 
        }

        private string? _school;
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(20)]
        public string School
        {
            get => _school;
            set => SetProperty(ref _school, value, true);
        }

        private string? _subject;
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(20)]
        public string? Subject
        {
            get => _subject;
            set => SetProperty(ref _subject, value, true);
        }

        private string? _description;
        
        [MinLength(5)]
        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value, true);
        }
        public string LabelCreateCourseDescription  //Pongo los datos del docente. 
        {
            get => SessionData.SessionName != null ? $"ID: {SessionData.SessionId}\n Name: {SessionData.SessionName} {SessionData.SessionLastName}\n Age: {SessionData.SessionAge}\n Email: {SessionData.SessionEmail}\n " : "Cargando";
            set
            {
                this._generalsIFunctions.OnPropertyChanged(nameof(LabelCreateCourseDescription)); //Para que se actualice. 
            }
        }

        //MÉTODOS:
        public CreateCourseViewModels() //Builder. 
        {
            _generalsIFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>(); //Inyecto mi dependencia por método. 
            _coursesFunctions = App.Current.Services.GetRequiredService<ICourses>(); //Inyecto la dependendencia relacionado a CRUD.
        }

        [RelayCommand]
        public async Task CreateCourse(CoursesModels course)
        {
            ValidateAllProperties(); //Valida todas las Data Annotations. 
            Errors.Clear(); //Si hay algún error anterior, lo quito. 
            GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add("Nombre: " + f.ErrorMessage)); //Traeme los errores del campo nombre. Como pueden ser más de uno, me los convierte a una lista. Luego, va recorriendo esa lista a partir del bucle forEach. Por cada elemento que hay en la lista, agrega (Add) el siguiente string a la colección Errors: "Nombre: el mensaje de error que haya".
            GetErrors(nameof(School)).ToList().ForEach(f => Errors.Add("Escuela: " + f.ErrorMessage));
            GetErrors(nameof(Subject)).ToList().ForEach(f => Errors.Add("Materia: " + f.ErrorMessage));
            GetErrors(nameof(Description)).ToList().ForEach(f => Errors.Add("Descripción: " + f.ErrorMessage));

            if (Errors.Count > 0) return; //Pues, si hay un error debo terminar el método para que no se guarde a un nuevo curso. 

            courseId = await _coursesFunctions.InsertCourse(new CoursesModels { Name = Name, School = School, Subject = Subject, Description = Description, TeacherId = SessionData.SessionId });
            Resultado = $" Registro id:{courseId}";

         //   await Shell.Current.GoToAsync("Login"); //reedirigirme a la view del curso recién creado. 
        }

        [RelayCommand] //Propiedad, del toolkit de MVVM, que permite que el método debajo pueda ser llamado en la vista asociada.
        public async Task Back()
        {
            await Shell.Current.GoToAsync("MainTeacherMenu");
        }
    }
}
