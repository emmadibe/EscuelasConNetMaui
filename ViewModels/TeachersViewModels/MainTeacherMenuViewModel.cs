using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.ViewModels.TeachersViewModels
{
    public partial class MainTeacherMenuViewModel : ObservableObject, INotifyPropertyChanged//La interfaz INotifyPropertyChanged ya me la proporciona la plataforma .NET. Es una interfaz fundamental para implementar métodos y propiedades que NOTIFICAN algún cambio en una propiedad. Esa notificación permite actualizar la Interfaz de Usuairo (UI) automáticamente sin tener que hacer un refresh (refrezco) de página. Por ejemplo, cambio la propiedad Rama seleccionada bueno, se actualiza el valor automáticamente.
    {
        /// Inyección de dependencias.
        private readonly ITeachers _teachersService;
        private readonly ICourses _coursesService;
        private readonly GeneralsIFunctions _generalsIFunctions;

        /// Propiedades
        private int _teacherId;
        public int TeacherId //El valor de esta propiedad lo recibo de MainTeacherMenu, quien a su vez lo recibe de Login vía URL. 
        {
            get => _teacherId;
            set
            {
                //_teacherId = value;
                //this._generalsIFunctions.OnPropertyChanged(nameof(TeacherId)); // Este método, cuya firma está en INoifyPropertyChanged, es utilizado en aplicaciones con el patrón de diseño MVVM.  Lo que hace este método, básicamente, es notificarle a la Interfaz de Usuario (UI) que una propiedad ha cambiado su valor. Pues, las interfaces de usuario no se enteran de dichos cambios a menos que se lo comuniques. Entonces, el método OnPropertyChanged() lanza un evento de tipo PropertyChangedEvenHandler que le notifica a la UI de que una propiedad cambió su valor y, así, lo actualiza de forma automática. De esta manera, los cambios en los valores de las propiedades se verán reflejadas en la UI sin la necesidad de tener que estar refrescando (refresh) la página. 
                SetProperty(ref _teacherId, value);
                this._generalsIFunctions.OnPropertyChanged(nameof(TeacherId));
            }
        }
        //Propiedades de los cursos que me traigo:
        public int Id { get; set; }
    

        [ObservableProperty]
        private int idCourseSelected = 2;

        ///
        public string LabelTeacherDescription
        {
            get => SessionData.SessionName != null ? $"ID: {SessionData.SessionId}\n Name: {SessionData.SessionName} {SessionData.SessionLastName}\n Age: {SessionData.SessionAge}\n Email: {SessionData.SessionEmail}\n " : "Cargando";
            set
            {
                this._generalsIFunctions.OnPropertyChanged(nameof(LabelTeacherDescription)); //Para que se actualice. 
            }
        }

        [ObservableProperty]
        private TeachersModels teacher;

        [ObservableProperty]
        private ObservableCollection<CoursesModels> courses = new(); //La idea es que en esta colección ObservableCollection cada elemento es un COursesModels. O sea, cada elemento de mi colección es un curso. Yo me traigo todos mis cursos desde la base de datos y los guardo, uno por uno, en esta colección para mostrarlos en la vista. 

        //MÉTODOS.

        public MainTeacherMenuViewModel() //Builder 1.
        {
            _teachersService = App.Current.Services.GetRequiredService<ITeachers>(); //Inyecto la dependencia. 
            _generalsIFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _coursesService = App.Current.Services.GetRequiredService<ICourses>();
            GetAllProperty(); //Tengo que inicializar la instancia de teacherModels.
            GetMyCourses(); //Inicializo la colección courses.
        }

        public MainTeacherMenuViewModel(int teacherId) //Builder 2.
        {
            _teachersService = App.Current.Services.GetRequiredService<ITeachers>(); //Inyecto la dependencia. 
            _generalsIFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _coursesService = App.Current.Services.GetRequiredService<ICourses>();
            TeacherId = teacherId;
            GetAllProperty(); //Tengo que inicializar la instancia de teacherModels.
            GetMyCourses(); //Inicializo la colección courses.
        }

        public async Task GetAllProperty()
        {
            Teacher = await _teachersService.GetById(_teacherId);
            if (Teacher != null) //Guardo todas las variables de sesión en la clase estática SessionData. De esta manera, podré acceder a dichas propiedades desde cualquier parte del programa en todo momento. 
            {
                SessionData.SessionName = teacher.Name;
                SessionData.SessionLastName = teacher.LastName;
                SessionData.SessionEmail = teacher.Email;
                SessionData.SessionRama = teacher.Rama;
                SessionData.SessionId = teacher.Id;
                SessionData.SessionAge = teacher.Age;
            } 
        }

        public async Task GetMyCourses()
        {
            courses.Clear(); //limpio los elementos de la colección courses que ya haya por si hay que agregar algo nuevo. Además, para evitar sobreescritura de elementos en la UI.
            List<CoursesModels> listCourses = await _coursesService.GetAllCoursesByMyTeacher(SessionData.SessionId);  //EL método GetAllCoursesByMyteacher me devuelve una lista con todos los registros de la tabla courses (en este caso) en donde el valor del campo teacherId sea igual a id del teacher que inició sesión. Por ende, devuelve una lista en donde cada elemento de la lista es una instancia de CourseModels. 
            //Debo pasar los elementos (instancias de CourseModels) de la lista a la colección, de tipo ObservableCollection, llamada courses.
            foreach (var model in listCourses)
            { //Voy recorriendo la colección list. En cada ciclo del bucle me paro en un elemento de la colección. Ese elemento lo paso a la variable llamada model y la agrego (Add) a la colección de tipo ObservableCollection llamada courses. Y, así, paso cada elemento de mi colección List a mi colección ObservableCollection. 
                courses.Add(model);
            }
        }

        // MÉTODOS COMANDOS / MANEJADORES DE EVENTOS
        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("///Login");
        }

        [RelayCommand]
        public async Task CreateCourse()
        {
            Shell.Current.GoToAsync("CreateCourse");
        }

        [RelayCommand]
        public async Task InCourse(int id) //Cuando el usuario aprieta el botón entra al curso. Voy a la View con ese curso. 
        {
            IdCourseSelected = id;
            await Shell.Current.GoToAsync($"ShowCourse?courseId={id}"); //Envío el id del curso como parámetro vía url. 
        }
    }
}
