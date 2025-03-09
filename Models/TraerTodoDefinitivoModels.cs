using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Models
{
    public class TraerTodoDefinitivoModels
    {
        public string NameAndLastName { get; set; }
        public Dictionary<string, int> TestAndNote { get; set; }

        public TraerTodoDefinitivoModels(string NameAndLast, Dictionary<string, int> Note)
        {
            NameAndLastName = NameAndLast;
            TestAndNote = Note;
        }

        public override string ToString()
        {
            return $"Nombre: {NameAndLastName}, Examen: {TestAndNote}";
        }
    }
}
