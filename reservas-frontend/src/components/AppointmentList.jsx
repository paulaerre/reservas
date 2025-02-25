import Appointment from './Appointment'
function AppointmentList({appointments, services}) {
  
  const renderedAppointments = appointments.map((appt) => {
    return <Appointment key={appt.id} appointment={appt} serviceName={services.find(x=> x.id === appt.serviceId).name} />
  })

  return (
      <div>
        <h1 className="text-3xl font-bold underline p-3">Reservas</h1>
        {renderedAppointments}
      </div>
  )
}

export default AppointmentList
