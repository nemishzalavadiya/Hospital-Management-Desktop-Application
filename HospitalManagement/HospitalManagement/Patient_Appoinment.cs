//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient_Appoinment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient_Appoinment()
        {
            this.Patient_record = new HashSet<Patient_record>();
        }
    
        public int Appoinment_Id { get; set; }
        public System.DateTime Start_date { get; set; }
        public string Patient_name { get; set; }
        public System.DateTime Appoinment_date { get; set; }
        public string Address { get; set; }
        public string Mobile_no { get; set; }
        public int Doctor_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_record> Patient_record { get; set; }
        public virtual User User { get; set; }
    }
}
