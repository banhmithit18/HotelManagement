//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Model.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            this.BOOKINGs = new HashSet<BOOKING>();
            this.ORDERDETAILs = new HashSet<ORDERDETAIL>();
            this.SHIFTS = new HashSet<SHIFT>();
        }
    
        public int ID { get; set; }
        public string IDCARD { get; set; }
        public string NAME { get; set; }
        public Nullable<int> AGE { get; set; }
        public string PHONENUMBER { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string ACCOUNTTYPE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOKING> BOOKINGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFT> SHIFTS { get; set; }
    }
}
