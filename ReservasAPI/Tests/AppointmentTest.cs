using ReservasAPI.Models;

namespace Tests
{
    public class AppointmentTest
    {
        [Fact]
        public void Create_Appointment_Result_Ok()
        {
            AppointmentRequest ar = new AppointmentRequest
            {
                Date = new DateTime(),
                Time = "12",
                Client = "Paula",
                ServiceId = 1,
            };

            Appointment a = new Appointment(ar);

            Assert.Equal(ar.Date.ToString("dd/MM/yyyy"), a.Date);
        }
    }
}