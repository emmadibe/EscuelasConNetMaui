using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services.DataBase
{
    public class DataBaseInitializer : IDataBaseInitializer //Implemento la interfaz para aplicar inyección de dependencias.
    {
        private readonly SQLiteConnection _connection;

        public DataBaseInitializer()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "EscuelasNetMaui.db");
            _connection = new SQLiteConnection(dbPath); //Ni bien instancio la clase inicializo a _connection (instancia de SQLiteConnection). Necesito acceder a sus métodos en Initialize()
        }
         
        public void Initialize()
        {
            _connection.CreateTable<TeachersModels>();
            _connection.CreateTable<CoursesModels>();
            _connection.CreateTable<StudentsModels>();
            _connection.CreateTable<TestsModels>();
            _connection.CreateTable<TestsXStudentsModels>();
            _connection.Execute(
           "CREATE UNIQUE INDEX IF NOT EXISTS UX_StudentId_TestId ON testsXstudents (StudentId, TestId)"); //Para evitar que un estudiante pueda tener más de una nota en un mismo examen.
        }
    }
}
