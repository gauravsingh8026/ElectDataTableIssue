using Elect.Web.DataTable.Attributes;
using Microsoft.AspNetCore.Mvc;
using PFAutomation.IModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFAutomation.Models
{
    [ModelMetadataType(typeof(IEmployeeMetadata))]
    public partial class Employee :IEmployeeMetadata
    {
        [DataTable(DisplayName = "Name", Order =2)]
        public string FullName { get { return this.EmpFirstName + " " + this.EmpLastName; } }
    }

    public interface IEmployeeMetadata
    {
        [DataTable(DisplayName ="Id",IsVisible =false,Order =1)]
        long EmpId { get; set; }
        
        [DataTableIgnore]
        [DisplayName("First Name")]
        string EmpFirstName { get; set; }

        [DataTableIgnore]
        string EmpLastName { get; set; }

        [DataTableIgnore]
        string EmpStreet { get; set; }

        [DataTableIgnore]
        string EmpCity { get; set; }

        [DataTable(DisplayName ="Pin Code", Order =3)]
        string EmpPin { get; set; }

        [DataTableIgnore]
        string EmpState { get; set; }

        [DataTable(DisplayName ="Mobile", Order =4)]
        string EmpContact { get; set; }

        [DataTableIgnore]
        string EmpEmail { get; set; }

        [DataTableIgnore]
        DateTime? EmpDob { get; set; }

        [DataTableIgnore]
        string EmpImage { get; set; }

        [DataTableIgnore]
        int EmpGroupId { get; set; }

        [DataTableIgnore]
        DateTime EmpDoj { get; set; }

        [DataTableIgnore]
        int EmpServiceYear { get; set; }

        [DataTableIgnore]
        int CreatedBy { get; set; }

        [DataTableIgnore]
        DateTime CreatedOn { get; set; }

        [DataTableIgnore]
        int UpdatedBy { get; set; }

        [DataTableIgnore]
        DateTime UpdatedOn { get; set; }

        [DataTableIgnore]
        EmpGroup EmpGroup { get; set; }

        [DataTableIgnore]
        ICollection<EmpSalary> EmpSalary { get; set; }

        [DataTableIgnore]
        ICollection<Loan> Loan { get; set; }

        [DataTableIgnore]
        ICollection<PfContribution> PfContribution { get; set; }
    }
}
