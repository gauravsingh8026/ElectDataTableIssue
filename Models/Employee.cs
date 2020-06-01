using Elect.Web.DataTable.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFAutomation.Models
{
    [Table("employee")]
    public partial class Employee
    {
        public Employee()
        {
            EmpSalary = new HashSet<EmpSalary>();
            Loan = new HashSet<Loan>();
            PfContribution = new HashSet<PfContribution>();
        }

        [Key]
        [Column("emp_id")]
        public long EmpId { get; set; }

        [DataTableIgnore]
        [Required]
        [Column("emp_first_name")]
        [StringLength(50)]
        public string EmpFirstName { get; set; }
        [Column("emp_last_name")]
        [StringLength(50)]
        public string EmpLastName { get; set; }
        [Column("emp_street")]
        [StringLength(500)]
        public string EmpStreet { get; set; }
        [Column("emp_city")]
        [StringLength(20)]
        public string EmpCity { get; set; }
        [Column("emp_pin")]
        [StringLength(10)]
        public string EmpPin { get; set; }
        [Column("emp_state")]
        [StringLength(20)]
        public string EmpState { get; set; }
        [Required]
        [Column("emp_contact")]
        [StringLength(15)]
        public string EmpContact { get; set; }
        [Column("emp_email")]
        [StringLength(30)]
        public string EmpEmail { get; set; }
        [Column("emp_dob", TypeName = "date")]
        public DateTime? EmpDob { get; set; }
        [Column("emp_image")]
        [StringLength(500)]
        public string EmpImage { get; set; }
        [Column("emp_group_id")]
        public int EmpGroupId { get; set; }
        [Column("emp_doj", TypeName = "date")]
        public DateTime EmpDoj { get; set; }
        [Column("emp_service_year")]
        public int EmpServiceYear { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("created_on", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("updated_by")]
        public int UpdatedBy { get; set; }
        [Column("updated_on", TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [ForeignKey(nameof(EmpGroupId))]
        [InverseProperty("Employee")]
        public virtual EmpGroup EmpGroup { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<EmpSalary> EmpSalary { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<Loan> Loan { get; set; }
        [InverseProperty("Emp")]
        public virtual ICollection<PfContribution> PfContribution { get; set; }
    }
}
