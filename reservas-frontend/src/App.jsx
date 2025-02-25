import "react-datepicker/dist/react-datepicker.css";
import "./App.css";
import { useEffect, useState } from "react";
import { getServices, getAppointments, createAppointment } from "./api/api";
import AppointmentList from "./components/AppointmentList";
import NewAppointment from "./components/NewAppointment";
import Button from "./components/Button";

function App() {
  const [appointments, setAppointments] = useState([]);
  const [services, setServices] = useState([]);
  const [serviceError, setServiceError] = useState(false);
  const [appointmentError, setAppointmentError] = useState(false);
  const [activeTab, setActiveTab] = useState("appointments");

  const fetchData = async () => {
    try {
      const result = await getServices();
      setServices(result);
    } catch (e) {
      setServiceError(true);
      console.log(e);
    }
    try {
      const result = await getAppointments();
      setAppointments(result);
    } catch (e) {
      setAppointmentError(true);
      console.log(e);
    }
  };

  const handleCreateAppointment = async (appt) => {
    await createAppointment(appt);
    await fetchData();
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <>
      <div className="flex gap-4 mb-4">
        <Button
          primary
          active
          selected={activeTab === "appointments"}
          onClick={() => setActiveTab("appointments")}
        >
          Ver Reservas
        </Button>
        <Button
          primary
          active
          selected={activeTab === "newAppointment"}
          onClick={() => setActiveTab("newAppointment")}
        >
          Nueva Reserva
        </Button>
      </div>
      {activeTab === "appointments" && (
        <div>
          {!appointmentError ? (
            <AppointmentList appointments={appointments} services={services} />
          ) : (
            <h1>Error buscando reservas...</h1>
          )}
        </div>
      )}
      {activeTab === "newAppointment" && (
        <div>
          {!serviceError ?
          <NewAppointment
            services={services}
            onCreate={handleCreateAppointment}
          />: 
          <h1>Error buscando servicios... </h1>
          }
        </div>
      )}
    </>
  );
}

export default App;
