using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Models
{
    public abstract class AbstractBaseClass
    {
        [PrimaryKey, AutoIncrement] //propiedades que me las otorga el kit de sqllite. 
        public int Id { get; set; }
    }
}
