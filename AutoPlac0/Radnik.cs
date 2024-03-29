//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoPlac0
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Radnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Radnik()
        {
            this.Ugovors = new HashSet<Ugovor>();
        }
    
        public int IDRadnika { get; set; }
        [RegularExpression(@"[A-z]{2,20}$", ErrorMessage = "Imeradnika treba da ima minimum 2, a maksimum 20 slova.")]
        public string Ime { get; set; }
        [RegularExpression(@"[A-z]{2,20}$", ErrorMessage = "Prezime kupca treba da ima minimum 2, a maksimum 20 slova.")]
        public string Prezime { get; set; }
        [RegularExpression(@"[0-9]{13}$", ErrorMessage = "JMBG mora da ima 13 karaktera.")]
        public string JMBG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ugovor> Ugovors { get; set; }
    }
}
