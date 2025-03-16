using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Interfaz
{
    public interface ITraerTodos
    {
        public Task<List<TraerTodoModels>> GetStudentExamsByCourse(int courseId);
    }
}
