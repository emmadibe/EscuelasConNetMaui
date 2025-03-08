using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.ViewModels.CoursesViewModels
{
    public partial class ShowCourseViewModels : ObservableObject
    {
        //INYECCION DE DEPENDENCIAS
        private readonly ICourses _coursesFunctions;
        private readonly GeneralsIFunctions _generalsFunctions;
        private readonly ITraerTodos _traerTodosFunctions;
        private readonly ITraerTodoDefinitivo _traerTodoDefinitivo;
        //
        //PROPIEDADES
        private ObservableCollection<TraerTodoModels> _studentsList;
        public ObservableCollection<TraerTodoModels> StudentsList
        {
            get => _studentsList;
            set
            {
                _studentsList = value;
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        private int courseId;

        [ObservableProperty]
        private CoursesModels coursesModels = new();

        public string LabelCourseDescription
        {
            get => coursesModels != null ? $"Datos del curso: \n ID: {MyCurrentCourse.courseId}\n Nombre: {MyCurrentCourse.courseName}\n Escuela: {MyCurrentCourse.courseSchool}\n Materia: {MyCurrentCourse.courseSubject}" : "Cargando...";
            set => this._generalsFunctions.OnPropertyChanged(nameof(LabelCourseDescription)); //Para que se actualice. 
        }
        //

        //METODOS CONSTRUCTORES
        public ShowCourseViewModels(int courseID) //builder uno
        {
            this.courseId = courseID;
            _coursesFunctions = App.Current.Services.GetRequiredService<ICourses>();
            _generalsFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _traerTodosFunctions = App.Current.Services.GetRequiredService<ITraerTodos>();
            _traerTodoDefinitivo = App.Current.Services.GetRequiredService<ITraerTodoDefinitivo>();
            GetMyCourse(courseId);
            StudentsList = new ObservableCollection<TraerTodoModels>();
            Task.Run(async () => await ShowEverithing()); // Ejecutar asincrónicamente
        }

        public ShowCourseViewModels() //Builder dos
        {
            _coursesFunctions = App.Current.Services.GetRequiredService<ICourses>();
            _generalsFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _traerTodosFunctions = App.Current.Services.GetRequiredService<ITraerTodos>();
            _traerTodoDefinitivo = App.Current.Services.GetRequiredService<ITraerTodoDefinitivo>();
            StudentsList = new ObservableCollection<TraerTodoModels>();
            Task.Run(async () => await ShowEverithing()); // Ejecutar asincrónicamente
        } 

        //METODOS
        public async Task GetMyCourse(int courseID)
        {
            this.coursesModels = await _coursesFunctions.GetById(courseID);
            MyCurrentCourse.courseId = courseID;
            MyCurrentCourse.courseName = this.coursesModels.Name;
            MyCurrentCourse.courseSubject = this.coursesModels.Subject;
            MyCurrentCourse.courseSchool = this.coursesModels.School;
        }

        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("MainTeacherMenu");
        }

        [RelayCommand]
        public async Task AddStudents()
        {
            await Shell.Current.GoToAsync("AddStudent");        
        }

        [RelayCommand]
        public async Task AddTest()
        {
            await Shell.Current.GoToAsync("AddTest");
        }

        [RelayCommand]
        public async Task GoToAssistence()
        {

        }

        [RelayCommand]
        public async Task ShowEverithing()
        {
            
            List<TraerTodoModels> TraerTodoList = await _traerTodosFunctions.GetStudentExamsByCourse(MyCurrentCourse.courseId);

            Debug.WriteLine($"Usted tiene {TraerTodoList.Count} elementos en su lista");

            // Limpiar la colección antes de agregar nuevos elementos
            StudentsList.Clear();

            foreach (TraerTodoModels elemento in TraerTodoList)
            {
                Debug.WriteLine(elemento.ToString());
                StudentsList.Add(elemento); //Voy agregando, uno por uno, cada elemento (que es una instancia de TraerTodoModels) a la colección de tipo List TraerTodoList.
            }
        }
    }
}
