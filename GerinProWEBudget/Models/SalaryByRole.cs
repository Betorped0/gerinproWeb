//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GerinProWEBudget.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalaryByRole
    {
        public string rolid { get; set; }
        public decimal sueldo { get; set; }
    
        public virtual AspNetRole AspNetRole { get; set; }
    }
}
