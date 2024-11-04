const clientsArray = [
  "Gabriel",
  "Juan",
  "Paz",
  "Julian",
  "Maria",
  "Carlos",
  "Ana",
  "Lucia",
  "Roberto",
  "Marta",
];

const homeBtn = document.querySelector("#home");
const allTurnsBtn = document.querySelector("#all_turns");
const newTurnBtn = document.querySelector("#new_turn");
const allServicesBtn = document.querySelector("#all_services");
const newServiceBtn = document.querySelector("#new_service");

homeBtn.addEventListener("click", handleHomeClick);
allTurnsBtn.addEventListener("click", handleAllTurnsClick);
newTurnBtn.addEventListener("click", handleNewTurnClick);
allServicesBtn.addEventListener("click", handleAllServicesClick);
newServiceBtn.addEventListener("click", handleNewServiceClick);

function handleHomeClick() {
  clearMain();
  renderTurnsByClient();
}
function handleAllTurnsClick() {
  clearMain();
  renderAllTurns();
}
function handleNewTurnClick() {
  clearMain();
  renderNewTurnForm();
}

function handleAllServicesClick() {
  clearMain();
  renderAllServices();
}

function handleNewServiceClick() {
  clearMain();
  renderNewServiceForm();
}

function clearMain() {
  const main = document.querySelector("main");
  while (main.firstChild) {
    main.removeChild(main.firstChild);
  }
}

async function renderNewTurnForm() {
  const main = document.querySelector("main");

  // Crear sección principal
  const section = document.createElement("section");
  section.classList.add("new-turn-form");
  main.appendChild(section);

  // Título
  const h1 = document.createElement("h1");
  h1.textContent = "Registrar Turno";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Formulario
  const form = document.createElement("form");
  form.classList.add("d-flex", "flex-column", "align-items-center");
  section.appendChild(form);

  // Select de cliente
  const clientSelect = createSelectInput("client", "Seleccionar cliente", [
    "Gabriel",
    "Juan",
    "Paz",
    "Julian",
    "Maria",
    "Carlos",
    "Ana",
    "Lucia",
    "Roberto",
    "Marta",
  ]);
  form.appendChild(clientSelect);

  // Fecha y hora
  form.appendChild(createInput("date", "date", "Fecha"));
  form.appendChild(createInput("time", "hour", "Hora"));

  // Contenedor de servicios
  const servicesContainer = document.createElement("div");
  servicesContainer.classList.add("services-container", "mb-3", "w-50");
  form.appendChild(servicesContainer);

  // Botón para agregar servicios
  const addServiceButton = document.createElement("button");
  addServiceButton.type = "button";
  addServiceButton.textContent = "Agregar Servicio";
  addServiceButton.classList.add("btn", "btn-secondary", "mb-3");
  addServiceButton.addEventListener("click", async () => {
    const serviceContainer = await createServiceWithObservations();
    servicesContainer.appendChild(serviceContainer);
  });
  form.appendChild(addServiceButton);

  // Botón de enviar
  const button = document.createElement("button");
  button.type = "submit";
  button.textContent = "Registrar";
  button.classList.add("btn", "btn-primary");
  form.appendChild(button);

  // Manejo del envío del formulario
  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    // Recoger datos del formulario
    const client = document.querySelector("#client").value;
    const date = document.querySelector("#date").value;
    const hour = document.querySelector("#hour").value;

    const selectedServices = Array.from(
      servicesContainer.querySelectorAll(".service-observation-container")
    )
      .map((container) => {
        const serviceId = parseInt(container.querySelector("select").value);
        const observation =
          container.querySelector("input").value || "Sin observaciones";
        return {
          idTurno: 0,
          idServicio: serviceId,
          observaciones: observation,
        };
      })
      .filter((service) => service.idServicio);

    // Validación de campos obligatorios
    if (!client || !date || !hour || selectedServices.length === 0) {
      alert(
        "Por favor, completa todos los campos obligatorios y selecciona al menos un servicio."
      );
      return;
    }

    const fecha = new Date(`${date}T${hour}:00`).toISOString();
    const newTurn = {
      id: 0,
      fecha,
      cliente: client,
      fechaBaja: null,
      motivoBaja: null,
      tDetallesTurnos: selectedServices,
    };

    // Enviar la solicitud POST
    try {
      const response = await fetch("https://localhost:7224/api/Turno", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(newTurn),
      });

      if (!response.ok) throw new Error("Error al registrar el turno");

      alert("Turno registrado con éxito");
      clearMain();
      renderTurnsByClient();
    } catch (error) {
      console.error(error);
      alert("Hubo un problema al registrar el turno");
    }
  });
}

// Función para crear un input genérico
function createInput(type, id, placeholder) {
  const input = document.createElement("input");
  input.type = type;
  input.id = id;
  input.name = id;
  input.placeholder = placeholder;
  input.classList.add("form-control", "mb-3", "w-50");
  return input;
}

// Función para crear un select input con opciones
function createSelectInput(id, placeholder, options) {
  const select = document.createElement("select");
  select.id = id;
  select.name = id;
  select.classList.add("form-control", "mb-3", "w-50");

  const placeholderOption = document.createElement("option");
  placeholderOption.value = "";
  placeholderOption.textContent = placeholder;
  placeholderOption.disabled = true;
  placeholderOption.selected = true;
  select.appendChild(placeholderOption);

  options.forEach((optionText) => {
    const option = document.createElement("option");
    option.value = optionText;
    option.textContent = optionText;
    select.appendChild(option);
  });

  return select;
}

// Función para crear el select de servicios con campo de observación
async function createServiceWithObservations() {
  const container = document.createElement("div");
  container.classList.add(
    "service-observation-container",
    "d-flex",
    "mb-3",
    "align-items-center"
  );

  const serviceSelect = await createServiceSelect();
  container.appendChild(serviceSelect);

  const observationInput = document.createElement("input");
  observationInput.type = "text";
  observationInput.placeholder = "Observaciones del servicio";
  observationInput.classList.add("form-control", "ms-3");
  container.appendChild(observationInput);

  return container;
}

// Función para crear el select de servicios desde el endpoint
async function createServiceSelect() {
  const select = document.createElement("select");
  select.classList.add("form-control", "mb-2");

  const placeholderOption = document.createElement("option");
  placeholderOption.value = "";
  placeholderOption.textContent = "Seleccionar servicio";
  placeholderOption.disabled = true;
  placeholderOption.selected = true;
  select.appendChild(placeholderOption);

  try {
    const response = await fetch("https://localhost:7224/api/Servicio");
    if (!response.ok) throw new Error("Error al cargar los servicios");

    const services = await response.json();
    services.forEach((service) => {
      const option = document.createElement("option");
      option.value = service.id;
      option.textContent = service.nombre;
      select.appendChild(option);
    });
  } catch (error) {
    console.error("Error al cargar los servicios:", error);
    alert("No se pudieron cargar los servicios");
  }

  return select;
}

async function renderTurnsByClient() {
  const main = document.querySelector("main");

  // Seccion
  const section = document.createElement("section");
  section.classList.add("turns-by-client");
  main.appendChild(section);

  // Titulo
  const h1 = document.createElement("h1");
  h1.textContent = "Turnos por cliente";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Tabla
  const tableWrapper = document.createElement("div");
  tableWrapper.classList.add("table-responsive");
  section.appendChild(tableWrapper);

  const table = document.createElement("table");
  table.classList.add(
    "table",
    "table-striped",
    "table-hover",
    "table-bordered"
  );
  tableWrapper.appendChild(table);

  const thead = document.createElement("thead");
  table.appendChild(thead);

  const tr = document.createElement("tr");
  thead.appendChild(tr);

  const th1 = document.createElement("th");
  th1.textContent = "Cliente";
  th1.classList.add("text-center", "fw-bold");
  tr.appendChild(th1);

  const th2 = document.createElement("th");
  th2.textContent = "Cantidad de Turnos";
  th2.classList.add("text-center", "fw-bold");
  tr.appendChild(th2);

  const tbody = document.createElement("tbody");
  table.appendChild(tbody);

  try {
    // Traer turnos
    const response = await fetch("https://localhost:7224/api/Turno", {
      method: "GET",
      headers: {
        Accept: "application/json",
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const turnsArray = await response.json();

    // Magia para contar turnos por cliente, TODO hacer un endpoint Map counting turns per client
    const turnCountMap = turnsArray.reduce((acc, turn) => {
      acc[turn.cliente] = (acc[turn.cliente] || 0) + 1;
      return acc;
    }, {});

    // Fill the table
    for (const client in turnCountMap) {
      const tr = document.createElement("tr");
      tbody.appendChild(tr);

      const td1 = document.createElement("td");
      td1.textContent = client; // Nombre cliente
      td1.classList.add("text-center", "p-3");
      tr.appendChild(td1);

      const td2 = document.createElement("td");
      td2.textContent = turnCountMap[client]; // Cantidad Turnos
      td2.classList.add("text-center", "p-3");
      tr.appendChild(td2);
    }
  } catch (error) {
    console.error("Error fetching turns:", error);
  }
}

async function renderAllTurns() {
  const main = document.querySelector("main");

  // Seccion
  const section = document.createElement("section");
  section.classList.add("all-turns");
  main.appendChild(section);

  // Titulo
  const h1 = document.createElement("h1");
  h1.textContent = "Turnos Registrados";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Tabla
  const tableWrapper = document.createElement("div");
  tableWrapper.classList.add("table-responsive");
  section.appendChild(tableWrapper);

  const table = document.createElement("table");
  table.classList.add(
    "table",
    "table-striped",
    "table-hover",
    "table-bordered"
  );
  tableWrapper.appendChild(table);

  const thead = document.createElement("thead");
  table.appendChild(thead);

  const tr = document.createElement("tr");
  thead.appendChild(tr);

  const th1 = document.createElement("th");
  th1.textContent = "Cliente";
  th1.classList.add("text-center", "fw-bold");
  tr.appendChild(th1);

  const th2 = document.createElement("th");
  th2.textContent = "Fecha";
  th2.classList.add("text-center", "fw-bold");
  tr.appendChild(th2);

  const th3 = document.createElement("th");
  th3.textContent = "Hora";
  th3.classList.add("text-center", "fw-bold");
  tr.appendChild(th3);

  const tbody = document.createElement("tbody");
  table.appendChild(tbody);

  try {
    const response = await fetch("https://localhost:7224/api/Turno", {
      method: "GET",
      headers: {
        Accept: "application/json",
      },
    });
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const turnsArray = await response.json();

    // Llenar tabla
    turnsArray.forEach((turn) => {
      const tr = document.createElement("tr");
      tbody.appendChild(tr);

      const td1 = document.createElement("td");
      td1.textContent = turn.cliente;
      td1.classList.add("text-center");
      tr.appendChild(td1);

      const td2 = document.createElement("td");
      td2.textContent = new Date(turn.fecha).toLocaleDateString(); // Formatear fecha
      td2.classList.add("text-center");
      tr.appendChild(td2);

      const td3 = document.createElement("td");
      td3.textContent = new Date(turn.fecha).toLocaleTimeString(); // Formatear horas
      td3.classList.add("text-center");
      tr.appendChild(td3);
    });
  } catch (error) {
    console.error("Error fetching turns:", error);
    const errorRow = document.createElement("tr");
    const errorMessage = document.createElement("td");
    errorMessage.colSpan = 3; // Ancho mensaje
    errorMessage.textContent = `Error fetching turns: ${error.message}`;
    errorMessage.classList.add("text-center", "text-danger");
    errorRow.appendChild(errorMessage);
    tbody.appendChild(errorRow);
  }
}

async function renderAllServices() {
  const main = document.querySelector("main");

  // Seccion
  const section = document.createElement("section");
  section.classList.add("all-services");
  main.appendChild(section);

  // Titulo
  const h1 = document.createElement("h1");
  h1.textContent = "Servicios Registrados";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Tabla
  const table = document.createElement("table");
  table.classList.add(
    "table",
    "table-striped",
    "table-hover",
    "align-middle",
    "table-bordered"
  );
  section.appendChild(table);

  // Encabezado
  const thead = document.createElement("thead");
  const headerRow = document.createElement("tr");
  const headers = ["Servicio", "Precio", "En Promoción"];
  headers.forEach((headerText) => {
    const th = document.createElement("th");
    th.textContent = headerText;
    headerRow.appendChild(th);
  });
  thead.appendChild(headerRow);
  table.appendChild(thead);

  // Tabla Body
  const tbody = document.createElement("tbody");
  table.appendChild(tbody);

  // Llenar tabla
  try {
    const response = await fetch("https://localhost:7224/api/Servicio");
    if (!response.ok) throw new Error("Error en la solicitud");

    const services = await response.json();
    console.log(services);
    services.forEach((service) => {
      const row = document.createElement("tr");

      // Servicio
      const cellNombre = document.createElement("td");
      cellNombre.textContent = service.nombre;
      row.appendChild(cellNombre);

      // Precio
      const cellPrecio = document.createElement("td");
      cellPrecio.textContent = `$${service.costo.toFixed(2)}`;
      row.appendChild(cellPrecio);

      // Promocion
      const cellEnPromocion = document.createElement("td");
      cellEnPromocion.textContent = service.enPromocion === "S" ? "Sí" : "No";
      row.appendChild(cellEnPromocion);

      tbody.appendChild(row);
    });
  } catch (error) {
    console.error("Error al obtener los servicios:", error);
  }
}

async function renderNewServiceForm() {
  const main = document.querySelector("main");

  // Seccion
  const section = document.createElement("section");
  section.classList.add("new-service-form");
  main.appendChild(section);

  // Titulo
  const h1 = document.createElement("h1");
  h1.textContent = "Registrar Servicio";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Form
  const form = document.createElement("form");
  form.classList.add("w-50", "mx-auto");
  section.appendChild(form);

  // Nombre
  const nombreInput = document.createElement("input");
  nombreInput.type = "text";
  nombreInput.name = "nombre";
  nombreInput.id = "nombre";
  nombreInput.placeholder = "Nombre";
  nombreInput.classList.add("form-control", "mb-3");
  form.appendChild(nombreInput);

  // Precio
  const precioInput = document.createElement("input");
  precioInput.type = "number";
  precioInput.name = "precio";
  precioInput.id = "precio";
  precioInput.placeholder = "Precio";
  precioInput.classList.add("form-control", "mb-3");
  form.appendChild(precioInput);

  // En Promocion
  const enPromocionLabel = document.createElement("label");
  enPromocionLabel.textContent =
    "En Promoción (marque si el servicio está en promoción)";
  enPromocionLabel.classList.add("form-check-label", "mb-2");
  form.appendChild(enPromocionLabel);

  const enPromocionInput = document.createElement("input");
  enPromocionInput.type = "checkbox";
  enPromocionInput.name = "enPromocion";
  enPromocionInput.id = "enPromocion";
  enPromocionInput.classList.add("form-check-input", "mb-3");
  form.appendChild(enPromocionInput);

  // Submit
  const submitButton = document.createElement("button");
  submitButton.type = "submit";
  submitButton.textContent = "Registrar Servicio";
  submitButton.classList.add("btn", "btn-primary");
  form.appendChild(submitButton);

  form.addEventListener("submit", async (event) => {
    event.preventDefault();
    const formData = new FormData(form);
    const nombre = formData.get("nombre");
    const precio = formData.get("precio");
    const enPromocion = enPromocionInput.checked ? "S" : "N";

    try {
      const response = await fetch("https://localhost:7224/api/Servicio", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          nombre,
          costo: precio,
          enPromocion,
          fechaCancelacion: null,
          motivoCancelacion: null,
        }),
      });
      if (!response.ok) throw new Error("Error en la solicitud");
      const service = await response.json();
      console.log(service);
      clearMain();
      renderAllServices();
    } catch (error) {
      console.error("Error al registrar el servicio:", error);
    }
  });
}

document.addEventListener("DOMContentLoaded", () => {
  renderTurnsByClient();
});
