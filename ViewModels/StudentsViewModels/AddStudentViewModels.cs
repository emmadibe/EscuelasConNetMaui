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
        //

        //PROPIEDADES
        public ObservableCollection<string> Errors { get; set; } = new(); //Colección de errores. Cada elemento de la colección es un string que me indica un error.
        public string LabelCourseDescription
        {
            get => $"Datos del curso:\n ID: {MyCurrentCourse.courseId}\n Nombre del curso: {MyCurrentCourse.courseName}\n Escuela: {MyCurrentCourse.courseSchool}\n Materia: {MyCurrentCourse.courseSubject}";
            set => this._generalsIFunctions.OnPropertyChanged(nameof(LabelCourseDescription)); //Para que se actualice. 
        }

        //Propiedades de students:
        private string _name;
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(20)]
        public string Name
        {
            get => this._name;
            set => SetProperty(ref this._name, value, true);
        }

        private string _lastName;
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
        }

        //

        //METODOS
        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("ShowCourse");
        }

        [RelayCommand]
        public async Task AddStudent()
        {

        }
    }
}
