using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Models
{
    public abstract class PersonAbstractModels
    {
        protected string? name { get; set; }
        protected string? lastName { get; set; }
        protected int? age { get; set; }
    }
}
