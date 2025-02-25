function Appointment({ appointment, serviceName }) {
  return (
    <div className="border max-w-xs m-2 p-2">
      <p>
        Servicio: {serviceName} <br />
        Cliente: {appointment.client} <br />
        {appointment.date} - {appointment.time}hs
      </p>
    </div>
  );
}

export default Appointment;
