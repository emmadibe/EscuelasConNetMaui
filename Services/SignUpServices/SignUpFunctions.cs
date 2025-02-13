using EscuelaConMaui.Interfaz.InterfazSignUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Services.SignUpServices
{
    public class SignUpFunctions : SignUpFormViewModel, SignUpIFunctions //Implementa la interfaz.
    {
        public ObservableCollection<RamaItem> CargarRamas()
        {
            Ramas = new ObservableCollection<RamaItem>(
                 Enum.GetValues(typeof(Rama)).Cast<Rama>().Select
                                                             (
                                                                 rama =>
                                                                 {
                                                                     var (nombre, valor) = rama.GetInfo();
                                                                     return new RamaItem { Rama = rama, Nombre = nombre, Valor = valor };
                                                                 }
                                                             )
                                 );
            return Ramas;
            //Inicializo mi propiedad pública Ramas. Acordate que al poner la propiedad, proporcionada por el toolkit, ObservableProperty, por encima de ramas, se crea una propiedad con el mismo nombre,pero con la inicial en mayúscula, con el modificador de acceso public. 
            //Ramas es una colección, de tipo ObservableCollection (muy similar a una vista) de elementos de tipo RamaItem. Es decir, cada elemento de mi colección es una instancia de RamaItem. Por lo tanto, cada elemento de mi colección tiene un dato de tipo Rama, otro string y otro int. Es que una instancia de RamaInto tiene tres propiedades.
            //Enum.GetValues devuelve un array que contiene todos los valores de la enumeración Rama. 
            //typeof(Rama) infica que estoy trabajando con la enumeración Rama. 
            //Cast<Rama>() convierte el array de objetos devuelto por GetValues en un IEnumerable<Rama>, permitiendo que cada valor de la enumeración se trate como un Rama.
            //Select es un método de extensión de LINQ (Language Integrated Query) que transforma cada elemento de una secuencia según la función proporcionada.
            //La lambda (rama => { ... }) toma cada valor de la enumeración Rama y realiza las siguientes acciones:
            //var (nombre, valor) = rama.GetInfo();: Aquí se asume que Rama tiene un método GetInfo que devuelve una tupla con dos elementos, nombre y valor.
            //return new RamaItem { Rama = rama, Nombre = nombre, Valor = valor };: Crea una nueva instancia de RamaItem con los datos obtenidos de GetInfo.
            //RamaItem es una clase con tres propiedades: una, de tipo Rama; otra, string; y otra, int.  
        }

        public void signUp()
        {
            throw new NotImplementedException();
        }
    }
}
