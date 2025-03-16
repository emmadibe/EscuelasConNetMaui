using EscuelaConMaui.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace EscuelaConMaui.ViewModels.StudentsViewModels
{
    public partial class AddStudentViewModels : ObservableValidator
    {
        //INYECCON DE DEPENDENCIAS
        private readonly GeneralsIFunctions _generalsIFunctions;
        private readonly IStudents _studentsFunctions;
        private readonly ITests _testsFunctions;
        private readonly IstudentXtest _studentXtestFunctions;
        //

        //PROPIEDADES
        public ObservableCollection<string> Errors { get; set; } = new(); //Colección de errores. Cada elemento de la colección es un string que me indica un error.
        public string LabelCourseDescription
        {
            get => $"Datos del curso:\n ID: {MyCurrentCourse.courseId}\n Nombre del curso: {MyCurrentCourse.courseName}\n Escuela: {MyCurrentCourse.courseSchool}\n Materia: {MyCurrentCourse.courseSubject}";
            set => this._generalsIFunctions.OnPropertyChanged(nameof(LabelCourseDescription)); //Para que se actualice. 
        }

        [ObservableProperty]
        private string? resultado = "";

        //Propiedades de students:
        [ObservableProperty]
        private int id;

        private string? _name;
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(20)]
        public string Name
        {
            get => this._name;
            set => SetProperty(ref this._name, value, true);
        }

        private string? _lastName;
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(20)]
        public string LastName
        {
            get => this._lastName;
            set => SetProperty(ref this._lastName, value, true);
        }


        //

        //CONSTRUCTORES

        public AddStudentViewModels() //Builder dos
        {
            _generalsIFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _studentsFunctions = App.Current.Services.GetRequiredService<IStudents>();
            _testsFunctions = App.Current.Services.GetRequiredService<ITests>();
            _studentXtestFunctions = App.Current.Services.GetRequiredService<IstudentXtest>();
        }

        //

        //METODOS
        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("ShowCourse");
        }

        [RelayCommand]
        public async Task AddStudent(StudentsModels students)
        {
            ValidateAllProperties(); //Valida todas las Data Annotations. 
            Errors.Clear(); //Si hay algún error anterior, lo quito. 
            GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add("Nombre del alumno: " + f.ErrorMessage)); //Traeme los errores del campo nombre. Como pueden ser más de uno, me los convierte a una lista. Luego, va recorriendo esa lista a partir del bucle forEach. Por cada elemento que hay en la lista, agrega (Add) el siguiente string a la colección Errors: "Nombre: el mensaje de error que haya".
            GetErrors(nameof(LastName)).ToList().ForEach(f => Errors.Add("Apellido del alumno: " + f.ErrorMessage));

            if (Errors.Count > 0) return; //Pues, si hay un error debo terminar el método para que no se guarde a un nuevo docente. 
            //Agrgeo el nuevo estudiante a la base de datos
            Id = await _studentsFunctions.InsertStudent(new StudentsModels {CourseId = MyCurrentCourse.courseId, Name = Name, LastName = LastName});

            Resultado = $" Registro id:{Id}";

            //Ahora, debería crear todos los registros intyermedios de la tabal intermedia studentsXtest.
            //Primero, debo traerme todos los tests de mi course ID que tengo en la bdd a una colección de tipo list. 
            List<TestsModels> Tests = await _testsFunctions.GetAllByCourseId(MyCurrentCourse.courseId); //Listo, ya tengo a todos los tests de mi presente curso en la colección de tipo List. 
            //Ahora, a partir de un bucle for each, debo recorrer todos mis tests e ir creando registros intermedios 
            foreach (TestsModels test in Tests)
            {
                await _studentXtestFunctions.InsertTestXStudent(new TestsXStudentsModels { Nota = 0, StudentId = Id, TestId = test.Id });   
            }
        }
    }
}
