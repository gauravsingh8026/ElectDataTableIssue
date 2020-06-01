using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFAutomation.Models
{
    [Table("emp_salary")]
    public partial class EmpSalary
    {
        public EmpSalary()
        {
            PfContributionNavigation = new HashSet<PfContribution>();
        }

        [Key]
        [Column("sal_id")]
        public long SalId { get; set; }
        [Column("emp_id")]
        public long EmpId { get; set; }
        [Column("salary", TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }
        [Column("pf_contribution", TypeName = "decimal(18, 2)")]
        public decimal PfContribution { get; set; }
        [Column("from_date", TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Column("to_date", TypeName = "date")]
        public DateTime ToDate { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("created_on", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("updated_by")]
        public int UpdatedBy { get; set; }
        [Column("updated_on", TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.EmpSalary))]
        public virtual Employee Emp { get; set; }
        [InverseProperty("Salary")]
        public virtual ICollection<PfContribution> PfContributionNavigation { get; set; }
    }
}
