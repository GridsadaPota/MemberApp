namespace Member_App.Models
{
    public class MemberModel
    {
        public int Member_ID { get; set; }
        public string Member_Code { get; set;}
        public string Member_Name { get; set;}
        public string Member_Tel { get; set;}
        public string Member_Email { get; set;}
        public DateTime Member_Regis_Date { get; set;}
        public int Member_LT { get; set; }
        public DateTime Create_Date { get; set;}
        public DateTime Modifire_Date { get; set;}
    }
}
