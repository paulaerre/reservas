import axios from "axios";

const API_URL = "https://localhost:7121/";

export async function getServices() {
  const response =  await axios.get(`${API_URL}services`);
 
  return response.data;
}

export async function getAppointments() {
  const response = await axios.get(`${API_URL}appointments`);

  return response.data;
}

export async function getAvailableTimeslots(date) {
  console.log(date);
  const response = await axios.get(`${API_URL}appointments/timeslots?date=${date}`);

  return response.data;
}

export async function createAppointment(appointment) {
  try {
    const result = await axios.post(`${API_URL}appointment`, appointment);
    alert(`Turno creado para el cliente ${result.data.client} satisfactoriamente`)
    return result.data;
  } catch (e) {
    alert(e.response.data)
  }
}
