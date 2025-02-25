using EscuelaConMaui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Helpers
{
    public class SQLLiteBase //Clase encargada de devolver la base de datos.
    {
        private string _rutaDB;
        public SQLiteConnection _connection;

        public SQLLiteBase() //Builder. 
        {
            _rutaDB = FileAccesHelper.GetPathFile("EscuelasNetMaui.db");// El método GetPathFile, perteneciente a la clase-helper FileAccesHelper, accede directamente al archivo de la base de datos y me lo retorna. Ello me permite conectarme a la bdd.  
            if (_connection != null) return;
            _connection = new SQLiteConnection(_rutaDB);
            _connection.CreateTable<TeachersModels>();
        }
    }
}
