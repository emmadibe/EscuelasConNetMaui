using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Services.ServicesLogIn
{
    public class GeneralsFunctions : GeneralsIFunctions, INotifyPropertyChanged
    {
        //La interfaz INotifyPropertyChanged ya me la proporciona la plataforma .NET. Es una interfaz fundamental para implementar métodos y propiedades que NOTIFICAN algún cambio en una propiedad. Esa notificación permite actualizar la Interfaz de Usuairo (UI) automáticamente sin tener que hacer un refresh (refrezco) de página. Por ejemplo, cambio la propiedad Rama seleccionada bueno, se actualiza el valor automáticamente.

        public event PropertyChangedEventHandler PropertyChanged; //Evento que se dispara cuando una propiedad cambia de valor. El método OnPropertyChanged captura este evento y se lo lanza a la UI para avisarle que una propiedad cambió de valor y así actualiza los datos a mostrar en pantalla sin refrezcar (refresh) la página

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //Este método tiene el modificador de acceso public y no retorna nada (void)
            // El identificador del método es OnPropertyChanged. Es un identificador muy usado, por convención, para aquellos métodos que tratan el cambio de valor de una propiedad y su notificación a servidores para que el UI se actualice automáticamente. 
            //Como parámetro el método recibe un string llamado propertyName, el cual posee, por defecto, el valor null. También este parámetro tiene el atributo CallerMemberName.
            //Ahora bien, el parámetro tiene un atributo llamado CallerMemberName. Este atributo lo que hace es tomar como parámetro la propiedad (en este caso) o método que llama a este método. Entonces, en el ViewModel, se pasa como parámetro la propiedad RamaSeleccionada de forma automática, aunque no la ponga entre paréntesis. Si no estuviera este atributo, debería aclararlo. Igual lo aclaro en RamaSeleccionada, aunque no en Age. 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke. Lanza el evento cuyo identificador es PropertyChanged. Al tener el ? indica que puede ser null. Por lo tanto, si nadie está escuchando no te tira una excepción. 
            //this es el objeto que envía la notificación 8esta clase). 
            //PropertyChangedEventArgs es la propiedad que cambió.
            //nameOf() el nombre de la propiedad que cambió.
        }

    }
}
