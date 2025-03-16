using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Interfaz
{
    public interface ITeachers //DEfino los métodos del CRUD.
    {
        public Task<List<TeachersModels>> GetAll(); //Me traigo una lista en donde cada item de la Lista es una instancia de TeachersModels. Con este método me traigo todos los docentes, todos los registros de mi tabla teachers de mi base de datos. 
        public Task<TeachersModels> GetById(int id); //Me traigo un solo teacher, el cual lo encuentro en mi bdd por el id. 
        public Task<int> InsertTeacher(TeachersModels teacher);
        public Task<int> DeleteTeacher(TeachersModels teacher);
        public Task<int> UpdateTeacher(TeachersModels teacher);

        public int ExistsTeacher(TeachersModels instance);

    }
}
