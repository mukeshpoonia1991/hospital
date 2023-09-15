namespace ApiWeb.Webapi.Dto.Reports
{
    public class DashBoardReport
    {
        public int TotalService { get; set; }

        public int TotalDoctor { get; set; }
        public int TotalOtherStaff { get; set; }
        public int TotalPatient { get; set; }
        public int TodayOpd { get; set; }
        public int TotalOpd { get; set; }

        public int WeekOpd { get; set; }

        public int TodayOpdAmount { get; set; }

        public int TotalOpdAmount { get; set; }

        public int WeekOpdAmount { get; set; }

    }
}
