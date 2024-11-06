namespace Wifi.TeilnehmerVerwaltungV4.DemoDataProvider.Entities
{
    public class Person
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public Dob dob { get; set; }
        public Registered registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public Id id { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }
    }
}
