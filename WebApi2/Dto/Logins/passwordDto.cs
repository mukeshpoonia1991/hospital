namespace ApiWeb.Webapi.Dto.Logins
{
    public class passwordDto
    {



        public int Otp { get; set; }
        public string Password { get; set; }

        public string confirmPassword { get; set; }

        public int EmployessID { get; set; }
    }
}
