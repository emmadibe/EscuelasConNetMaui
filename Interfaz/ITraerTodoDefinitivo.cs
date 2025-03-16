using EscuelaConMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Interfaz
{
    public interface ITraerTodoDefinitivo
    {
        public Task<List<TraerTodoDefinitivoModels>> pasarRegistrosDeUnaColeccionAOtra(List<TraerTodoModels> traerTodos);
        
    }
}
