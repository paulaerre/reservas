namespace ReservasAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Client { get; set; }
        public int ServiceId { get; set; }

        public Appointment () { }

        public Appointment(AppointmentRequest appt)
        {
            this.Date = appt.Date.Date.ToString("dd/MM/yyyy");
            this.Time = appt.Time;
            this.Client = appt.Client;
            this.ServiceId = appt.ServiceId;
        }
    }
}
