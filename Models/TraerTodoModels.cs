using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Models
{
    public class TraerTodoModels : AbstractBaseClass
    {
        public string NameAndLastName { get; set; }
        public string NoumberAndNameTest { get; set; }
        public double Nota { get; set; } // O int, según el tipo en la base de datos
        public int TestNoumber { get; set; }

        public override string ToString()
        {
            return $"Nombre: {NameAndLastName}, Examen: {NoumberAndNameTest}, Nota: {Nota}, Número Examen: {TestNoumber}";
        }
    }
}
