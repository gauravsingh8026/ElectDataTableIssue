using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFAutomation.Models
{
    [Table("loan")]
    public partial class Loan
    {
        [Key]
        [Column("loan_id")]
        public long LoanId { get; set; }
        [Column("emp_id")]
        public long EmpId { get; set; }
        [Column("application_date", TypeName = "datetime")]
        public DateTime ApplicationDate { get; set; }
        [Column("approval_date", TypeName = "datetime")]
        public DateTime? ApprovalDate { get; set; }
        [Column("loan_amount", TypeName = "decimal(18, 2)")]
        public decimal LoanAmount { get; set; }
        [Column("loan_emi", TypeName = "decimal(18, 2)")]
        public decimal? LoanEmi { get; set; }
        [Column("emi_period")]
        public int? EmiPeriod { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("created_on", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("updated_by")]
        public int UpdatedBy { get; set; }
        [Column("updated_on", TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.Loan))]
        public virtual Employee Emp { get; set; }
    }
}
