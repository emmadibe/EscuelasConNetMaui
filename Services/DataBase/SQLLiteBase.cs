using EscuelaConMaui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Services.DataBase
{
    public class SQLLiteBase //Clase encargada de conectarme y devolver la base de datos. Esta es la ùnica responsabilidad de la clase. 
    {
        private string _rutaDB;
        private readonly IDataBaseInitializer _initializer; //Inyecto la dependencia por método. 
        public SQLiteConnection _connection;

        public SQLLiteBase() //Builder. 
        {
            _rutaDB = FileAccesHelper.GetPathFile("EscuelasNetMaui.db");// El método GetPathFile, perteneciente a la clase-helper FileAccesHelper, accede directamente al archivo de la base de datos y me lo retorna. Ello me permite conectarme a la bdd.  
            if (_connection != null) return; //Es que si _connection no es null significa que ya estoy conectado a la base de datos.
            _connection = new SQLiteConnection(_rutaDB);

            //Crear tablas:
            _initializer = App.Current.Services.GetRequiredService<IDataBaseInitializer>(); //Estoy inyectando la dependencia vía método. Dado que en una clase A (SQLLiteBase) tengo que usar un método de una clase B (DataBaseInitializer), es una buena práctica de la programacion inyectar dependencias para que la clase A no dependa directamente de B, sino de una interfaz que define sus métodos. Entonces, si yo modifico a B no tengo que modificar A siempre y cuando permanezca la interfaz. 
            _initializer.Initialize();
        }
    }
}
