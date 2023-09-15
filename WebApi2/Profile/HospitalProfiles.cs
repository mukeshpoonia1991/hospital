

using Api.Domain.Hospitales;
using ApiWeb.Webapi.Dto.Departments;
using ApiWeb.Webapi.Dto.Documents;
using ApiWeb.Webapi.Dto.Documents.Types;
using ApiWeb.Webapi.Dto.Employees;
using ApiWeb.Webapi.Dto.Employees.Types;
using ApiWeb.Webapi.Dto.Hospitals;
using ApiWeb.Webapi.Dto.OPDs;
using ApiWeb.Webapi.Dto.Services;
using ApiWeb.Webapi.Dto.Services.Types;
using Apiwork.domain.Depatemants;
using Apiwork.domain.Docuement;
using Apiwork.domain.Documents;
using Apiwork.domain.Employees;
using Apiwork.domain.EmployesLogin;
using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;
using Apiwork.domain.OPDs;
using Apiwork.domain.Patients;
using Apiwork.domain.Services;
using AutoMapper;

namespace ApiWeb.Webapi
{
    public class HospitalProfiles :Profile
    {
        public HospitalProfiles() 
        {
            CreateMap<ServiceType, ServiceTypeDto>();
            CreateMap<CreateServiceTypeDto, ServiceType>();
            CreateMap<UpdateServiceTypeDto, ServiceType>();

            CreateMap<DocumentType, DocumenttypeDto>();
            CreateMap<CreateUpdateDocumentTypeDto, DocumentType>();


            CreateMap<Department, DepartmentDto>();
            CreateMap<CreateUpdateDepartmentDto, Department>();


            CreateMap<EmployeeType, EmployeeTypeDto>();
            CreateMap<CreateUpdateEmployeeTypeDto, EmployeeType>();

            CreateMap<Document, DocumentDto>();
            CreateMap<CreateUpdateDocumentDto, Document>();



            CreateMap<Hospital, HospitalDto>();
            CreateMap<HospitalAddress,HospitalDto>();
            CreateMap<CreateUpdateHospitalDto, Hospital>();
            CreateMap<CreateUpdateHospitalDto, HospitalAddress>();
            CreateMap<UpdateHospitalDto, Hospital>();
            CreateMap<UpdateHospitalAddressDto, HospitalAddress>();


            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeLogin, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<CreateEmployeeDto, EmployeeLogin>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeLogInDto, EmployeeLogin>();


            CreateMap<Opd, OPDDTO>();
            CreateMap<Patient,OPDDTO>();
            CreateMap<CreateOpdDto, Opd>();
            CreateMap<CreateOpdDto,Patient>();
            CreateMap<UpdateOpdDto, Opd>();
            CreateMap<UpdatePatientDto, Patient>();

            CreateMap<Service, ServiceDto>();
            CreateMap<CreateUpdateServiceDto, Service>();


            CreateMap<Service, ServiceDto>();
            CreateMap<CreateServiceTypeDto, Service>();



        }

    }
}
