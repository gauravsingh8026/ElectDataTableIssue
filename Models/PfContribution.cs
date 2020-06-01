using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFAutomation.Models
{
    [Table("pf_contribution")]
    public partial class PfContribution
    {
        [Key]
        [Column("contribution_id")]
        public long ContributionId { get; set; }
        [Column("emp_id")]
        public long EmpId { get; set; }
        [Column("month")]
        public byte Month { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("amount", TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Column("salary_id")]
        public long? SalaryId { get; set; }
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
        [InverseProperty(nameof(Employee.PfContribution))]
        public virtual Employee Emp { get; set; }
        [ForeignKey(nameof(SalaryId))]
        [InverseProperty(nameof(EmpSalary.PfContributionNavigation))]
        public virtual EmpSalary Salary { get; set; }
    }
}
