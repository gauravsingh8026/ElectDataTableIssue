using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFAutomation.Models
{
    [Table("emp_group")]
    public partial class EmpGroup
    {
        public EmpGroup()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        [Column("emp_group_id")]
        public int EmpGroupId { get; set; }
        [Required]
        [Column("emp_group_name")]
        [StringLength(10)]
        public string EmpGroupName { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("created_on", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("updated_by")]
        public int UpdatedBy { get; set; }
        [Column("updated_on", TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [InverseProperty("EmpGroup")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
