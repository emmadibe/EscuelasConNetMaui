using EscuelaConMaui.Models;
using Microsoft.Maui.Controls.Platform.Compatibility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace EscuelaConMaui.ViewModels.TestsViewModels
{
    public partial class AddTestViewModels : ObservableValidator
    {
        //INYECCION DE DEPENDENCIAS
        private readonly GeneralsIFunctions _generalFunctions;
        private readonly ITests _testFunctions;
        private readonly IstudentXtest _studentXtest;
        private readonly IStudents _studentsFunctions;
        //

        //PROPIEDADES
        public ObservableCollection<string> Errors { get; set; } = new();

        public string LabelCourseDescription
        {
            get => $"Datos del curso:\n ID: {MyCurrentCourse.courseId}\n Name: {MyCurrentCourse.courseName}\n School: {MyCurrentCourse.courseSchool}\n Subject: {MyCurrentCourse.courseSubject}\n";
            set => _generalFunctions.OnPropertyChanged(nameof(LabelCourseDescription));
        }

        private string? _name;

        [MaxLength(30)]
        [Required]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, true);
        }

        [Required]
        private int _testNoumber;
        public int TestNoumber
        {
            get => _testNoumber;
            set => SetProperty(ref _testNoumber, value, true);
        }

        public List<int> Noumbers => Enumerable.Range(1, 40).ToList();
        //

        //METODOS CONSTRUCTORES
        public AddTestViewModels()
        {
            _generalFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _testFunctions = App.Current.Services.GetRequiredService<ITests>();
            _studentXtest = App.Current.Services.GetRequiredService<IstudentXtest>();
            _studentsFunctions = App.Current.Services.GetRequiredService<IStudents>();
        }
        //

        //METODOS
        [RelayCommand]
        public async Task Back()
            => await Shell.Current.GoToAsync("ShowCourse");
        //

        [RelayCommand]
        public async Task AddTest(TestsModels testsModels) //Cuando se crea un examen, deben crearse también los registros de la tabla intermedia StudentsXTest
        {
            ValidateAllProperties(); //Valida todas las Data Annotations. 
            Errors.Clear(); //Si hay algún error anterior, lo quito. 
            GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add("Nombre: " + f.ErrorMessage)); //Traeme los errores del campo nombre. Como pueden ser más de uno, me los convierte a una lista. Luego, va recorriendo esa lista a partir del bucle forEach. Por cada elemento que hay en la lista, agrega (Add) el siguiente string a la colección Errors: "Nombre: el mensaje de error que haya".
            GetErrors(nameof(TestNoumber)).ToList().ForEach(f => Errors.Add("Apellido: " + f.ErrorMessage));

            if (Errors.Count > 0) return; //Pues, si hay un error debo terminar el método para que no se guarde a un nuevo docente. 

            int TestID = await _testFunctions.InsertTest(new TestsModels { Name = Name, TestNoumber = TestNoumber, CourseId = MyCurrentCourse.courseId, Date = DateTime.Now });


                                        ///
            ///Ya guardé mi nuevo examen en la tabla test de la base de datos. Ahora, debo crear los registros intermedios studentsXtests
            //Primero, debo traerme todos los estudiantes que pertenezcan a este cursoID.
            List<StudentsModels> students = await _studentsFunctions.GetAllByCourseId(MyCurrentCourse.courseId); //Listo, ya tengo, en una colección de tipo List, a todos mis estudiantes de mi curso. O sea, cada elemento de mi List es una instancia de StudentsModels.
            //Ahora, en un bucle foreach, voy creando los registros de la tabla intermedia entre el examen recién agregado y cada student del curso
            foreach (StudentsModels student in students)
            {
               await _studentXtest.InsertTestXStudent(new TestsXStudentsModels { Nota = 0, TestId = TestID, StudentId = student.Id });
            }

            //Me reedirijo a la view de mi curso:
            await Shell.Current.GoToAsync("ShowCourse"); //Con el método GoToAsync puedo navegar a otra vista cuya ruta haya codificado en la clase AppShell. Por eso es tan importante configurar la ruta. 
        }
    }
}
