import { useEffect, useState } from "react";
import { getAvailableTimeslots } from "../api/api";
import DatePicker from "react-datepicker";
import Button from "./Button";

function NewAppointment({ services, onCreate }) {
  const timeslots = ["10", "11", "12", "13", "14", "15", "16", "17"];

  const [selectedDate, setSelectedDate] = useState(new Date());
  const [selectedService, setSelectedService] = useState(null);
  const [selectedTimeslot, setSelectedTimeslot] = useState(null);
  const [availableTimeslots, setAvailableTimeslots] = useState([]);
  const [clientName, setClientName] = useState("");

  const formatDate = () => {
    return selectedDate.toISOString().split("T")[0];
  }

  const [formattedDate, setFormattedDate] = useState(() => formatDate());

  const renderedServices = services.map((service) => {
    return (
      <Button
        selected={selectedService === service}
        onClick={() => setSelectedService(service)}
        primary
        active
        key={service.id}
      >
        {service.name}
      </Button>
    );
  });

  const renderedTimeslots = timeslots.map((time) => {
    return (
      <Button
        selected={selectedTimeslot === time}
        onClick={() => setSelectedTimeslot(time)}
        warning
        active={availableTimeslots.includes(time)}
        key={time}
      >
        {time}hs
      </Button>
    );
  });

  const fetchTimeslots = async (date) => {
      const result = await getAvailableTimeslots(date);
      setAvailableTimeslots(result);
  }
 
  useEffect(() => {
    const newFormattedDate = formatDate();
    setFormattedDate(newFormattedDate);
    setSelectedTimeslot(null);
  }, [selectedDate]);

  useEffect(() => {
    fetchTimeslots(formattedDate);
  },[formattedDate]);

  const appointmentComplete = () => {
    return selectedService && clientName && selectedTimeslot && formattedDate;
  };

  const createAppointment = () => {
    onCreate({
      serviceId: selectedService.id,
      time: selectedTimeslot,
      date: formattedDate,
      client: clientName,
    });
    setClientName('');
    setSelectedDate(new Date());
    setSelectedService(null);
    setSelectedTimeslot(null);
    setFormattedDate(formatDate());
  };

  return (
    <>
      <h1 className="text-3xl font-bold underline p-3">Nueva Reserva</h1>

      <div className="flex flex-col gap-4 max-w-4xl border m-2 p-2 ">
        <div>
          <h1 className="p-2">Seleccionar Servicio:</h1>
          <div className="flex space-x-1">{renderedServices}</div>
        </div>
        <div>
          <h1 className="p-2">Fecha:</h1>
          <DatePicker
            className="border border-grey p-2"
            selected={selectedDate}
            onChange={(date) => setSelectedDate(date)}
            dateFormat="dd/MM/yyyy"
          />
        </div>
        <div>
          <h1 className="p-2">Hora:</h1>
          <div className="flex space-x-1">{renderedTimeslots}</div>
        </div>
        <div>
          <input
            className="text-m border rounded-md px-3 py-2"
            placeholder="Nombre del cliente"
            value={clientName}
            onChange={(e) => setClientName(e.target.value)}
          />
        </div>
        {appointmentComplete() && (
          <h1 className="text-2xl font-bold p-2">
            Estás reservando: {selectedService && selectedService.name} el{" "}
            {formattedDate} a las {selectedTimeslot}hs para {clientName}
          </h1>
        )}
        <Button
          onClick={() => createAppointment()}
          success
          active={appointmentComplete()}
          className="w-30"
        >
          Crear Reserva
        </Button>
      </div>
    </>
  );
}

export default NewAppointment;
