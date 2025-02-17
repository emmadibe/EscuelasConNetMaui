using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Models
{
    public abstract class PersonAbstractModels
    {
        protected string? Name { get; set; }
        protected string? LastName { get; set; }
        protected int? Age { get; set; }
        protected string? Email { get; set; }
    }
}
