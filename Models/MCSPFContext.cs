using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PFAutomation.Models
{
    public partial class MCSPFContext : DbContext
    {
        public MCSPFContext()
        {
        }

        public MCSPFContext(DbContextOptions<MCSPFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpGroup> EmpGroup { get; set; }
        public virtual DbSet<EmpSalary> EmpSalary { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<PfContribution> PfContribution { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=MCSPF;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpGroup>(entity =>
            {
                entity.Property(e => e.EmpGroupName).IsUnicode(false);
            });

            modelBuilder.Entity<EmpSalary>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpSalary)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_emp_salary_employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_employee_1");

                entity.HasIndex(e => e.EmpContact)
                    .HasName("unq_contact_employee")
                    .IsUnique();

                entity.Property(e => e.EmpCity).IsUnicode(false);

                entity.Property(e => e.EmpContact).IsUnicode(false);

                entity.Property(e => e.EmpDoj).HasComment("Date of joining");

                entity.Property(e => e.EmpEmail).IsUnicode(false);

                entity.Property(e => e.EmpFirstName).IsUnicode(false);

                entity.Property(e => e.EmpImage).IsUnicode(false);

                entity.Property(e => e.EmpLastName).IsUnicode(false);

                entity.Property(e => e.EmpPin).IsUnicode(false);

                entity.Property(e => e.EmpState).IsUnicode(false);

                entity.Property(e => e.EmpStreet).IsUnicode(false);

                entity.HasOne(d => d.EmpGroup)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmpGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_emp_group");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loan_employee");
            });

            modelBuilder.Entity<PfContribution>(entity =>
            {
                entity.HasKey(e => e.ContributionId)
                    .HasName("PK__pf_contr__018774BE9AA236B1");

                entity.HasIndex(e => e.EmpId)
                    .HasName("IX_pf_contribution");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.PfContribution)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pf_contribution_employee");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.PfContributionNavigation)
                    .HasForeignKey(d => d.SalaryId)
                    .HasConstraintName("FK_pf_contribution_emp_salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
