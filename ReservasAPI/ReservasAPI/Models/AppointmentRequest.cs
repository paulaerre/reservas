namespace ReservasAPI.Models
{
    public class AppointmentRequest
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Client { get; set; }
        public int ServiceId { get; set; }
    }

}
