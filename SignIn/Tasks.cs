//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignIn
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            this.Activity = new HashSet<Activity>();
            this.Comments = new HashSet<Comments>();
            this.Task_Employee_Activity = new HashSet<Task_Employee_Activity>();
        }
    
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int ProjectID { get; set; }
        public int TaskType { get; set; }
        public string TaskDescription { get; set; }
        public System.DateTime InsertTaskDate { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public bool isDone { get; set; }
        public bool isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual Projects Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task_Employee_Activity> Task_Employee_Activity { get; set; }
        public virtual TaskType TaskType1 { get; set; }
        public int CustomerID { get; set; }
        public int EmployeePK { get; set; }
    }
}