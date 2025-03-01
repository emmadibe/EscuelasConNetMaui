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

        public MainTeacherMenuViewModel() //Builder 1.
        {
            _teachersService = App.Current.Services.GetRequiredService<ITeachers>(); //Inyecto la dependencia. 
            _generalsIFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            GetAllProperty(); //Tengo que inicializar la instancia de teacherModels.
        }

        public MainTeacherMenuViewModel(int teacherId) //Builder 2.
        {
            _teachersService = App.Current.Services.GetRequiredService<ITeachers>(); //Inyecto la dependencia. 
            _generalsIFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            TeacherId = teacherId;
            GetAllProperty(); //Tengo que inicializar la instancia de teacherModels.
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
    }
}
