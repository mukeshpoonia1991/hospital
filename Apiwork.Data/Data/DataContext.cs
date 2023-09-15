using Api.Domain.Hospitales;
using Api.Domain.OTPes;
using Apiwork.domain.Depatemants;
using Apiwork.domain.Docuement;
using Apiwork.domain.Documents;
using Apiwork.domain.Employees;
using Apiwork.domain.EmployesDepatements;
using Apiwork.domain.EmployesLogin;
using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;

using Apiwork.domain.OPDs;
using Apiwork.domain.PatientDocuments;
using Apiwork.domain.Patients;
using Apiwork.domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Apiwork.Data.Data
{
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }
        public DbSet<Hospital> hospitals { get; set; }

        public DbSet<HospitalAddress> hospitalAddresses { get; set; }

        public DbSet<Employee> employees { set; get; }

        public DbSet<EmployeeType> employeeTypes { get; set; }

        public DbSet<Department> departments { get; set; }

        public DbSet<EmployeeDepartment> employeeDepartments { get; set; }

        public DbSet<EmployeeLogin> employeeLogins { get; set; }

        public DbSet<Service> services { get; set; }

        public DbSet<ServiceType> serviceTypes { get; set; }

        public DbSet<OTP> OTPs { get; set; }

        public DbSet<DocumentType> documentTypes { get; set; }

        public DbSet<Document> documents { get; set; }
        public DbSet<PatientDocument> patientDocuments { get; set; }

        public DbSet<Patient> patients { get; set; }


 
        public DbSet<Opd> opds { get; set; }




    }
}
