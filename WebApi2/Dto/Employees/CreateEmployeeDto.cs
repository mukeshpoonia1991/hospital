namespace ApiWeb.Webapi.Dto.Employees
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string MeddleName { get; set; }
        public string LastName { get; set; }

        public Int64 MobileNo { get; set; }
        public Int64 AlterNetMobileNo { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        public DateTime DataOfJoin { get; set; }

        public DateTime DataOfBirth { get; set; }

        public DateTime Createddate { get; set; }

        public int Creatorid { get; set; }

        public int EmployeeTypeId { get; set; }

        public string Code { get; set; }

        public string Password { get; set; }

     

    

    }
}
