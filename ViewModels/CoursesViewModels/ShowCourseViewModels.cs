using System;
using System.Collections.Generic;
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
        //
        //PROPIEDADES
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
            GetMyCourse(courseId);
        }

        public ShowCourseViewModels() //Builder dos
        {
            _coursesFunctions = App.Current.Services.GetRequiredService<ICourses>();
            _generalsFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
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
    }
}
