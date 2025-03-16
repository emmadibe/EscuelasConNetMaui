using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Models
{
    public class TraerTodoDefinitivoModels : ObservableObject, IEquatable<TraerTodoDefinitivoModels>
    {
        public string NameAndLastName { get; set; }
        private Dictionary<string, int> _testAndNote;
        public Dictionary<string, int> TestAndNote 
        {
            get => _testAndNote;
            set => SetProperty(ref _testAndNote, value);
        }
        // Método para actualizar una nota y notificar el cambio
        public void UpdateNota(string examen, int nota)
        {
            if (_testAndNote == null)
                _testAndNote = new Dictionary<string, int>();

            _testAndNote[examen] = nota;
            OnPropertyChanged(nameof(TestAndNote)); // Notifica que TestAndNote cambió
        }
        public TraerTodoDefinitivoModels(string NameAndLast, Dictionary<string, int> Note)
        {
            NameAndLastName = NameAndLast;
            TestAndNote = Note;
        }
        public TraerTodoDefinitivoModels() { }

        public void print()
        {
            Debug.WriteLine($"Nombre alumno: {this.NameAndLastName}");
           foreach( var item in TestAndNote )
            {
                Debug.WriteLine($"Examen {item.Key}, nota: {item.Value}" );
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is TraerTodoDefinitivoModels models &&
                   NameAndLastName == models.NameAndLastName;
        }

        public bool Equals(TraerTodoDefinitivoModels? other)
        {
            return other is not null &&
                   NameAndLastName == other.NameAndLastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NameAndLastName);
        }
    }
}
