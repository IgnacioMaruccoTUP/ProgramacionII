const turnsArray = [
  {
    id: 1,
    date: "2025-01-01",
    hour: "10:00",
    client: "Santiago",
  },
  {
    id: 2,
    date: "2024-12-31",
    hour: "11:00",
    client: "Juan",
  },
  {
    id: 3,
    date: "2024-11-15",
    hour: "12:00",
    client: "Santiago",
  },
  {
    id: 4,
    date: "2024-10-31",
    hour: "13:00",
    client: "Paz",
  },
  {
    id: 5,
    date: "2025-01-01",
    hour: "14:00",
    client: "Julian",
  },
  {
    id: 6,
    date: "2025-01-01",
    hour: "15:00",
    client: "Maria",
  },
  {
    id: 7,
    date: "2025-01-01",
    hour: "16:00",
    client: "Paz",
  },
  {
    id: 8,
    date: "2025-01-02",
    hour: "16:00",
    client: "Santiago",
  },
];

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

homeBtn.addEventListener("click", handleHomeClick);
allTurnsBtn.addEventListener("click", handleAllTurnsClick);
newTurnBtn.addEventListener("click", handleNewTurnClick);

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

function clearMain() {
  const main = document.querySelector("main");
  while (main.firstChild) {
    main.removeChild(main.firstChild);
  }
}

function renderTurnsByClient() {
  const main = document.querySelector("main");

  // Section
  const section = document.createElement("section");
  section.classList.add("turns-by-client");
  main.appendChild(section);

  // Title
  const h1 = document.createElement("h1");
  h1.textContent = "Turnos por cliente";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Table
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

  // Mapa contando turnos por cliente
  const turnCountMap = turnsArray.reduce((acc, turn) => {
    acc[turn.client] = (acc[turn.client] || 0) + 1;
    return acc;
  }, {});

  // Llenar tabla
  for (const client in turnCountMap) {
    const tr = document.createElement("tr");
    tbody.appendChild(tr);

    const td1 = document.createElement("td");
    td1.textContent = client; // Nombre
    td1.classList.add("text-center", "p-3");
    tr.appendChild(td1);

    const td2 = document.createElement("td");
    td2.textContent = turnCountMap[client]; // CantTurnos
    td2.classList.add("text-center", "p-3");
    tr.appendChild(td2);
  }
}

function renderAllTurns() {
  const main = document.querySelector("main");

  // Section
  const section = document.createElement("section");
  section.classList.add("all-turns");
  main.appendChild(section);

  // Title
  const h1 = document.createElement("h1");
  h1.textContent = "Turnos Registrados";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Table
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

  // Llenar tabla
  turnsArray.forEach((turn) => {
    const tr = document.createElement("tr");
    tbody.appendChild(tr);

    const td1 = document.createElement("td");
    td1.textContent = turn.client;
    td1.classList.add("text-center");
    tr.appendChild(td1);

    const td2 = document.createElement("td");
    td2.textContent = turn.date;
    td2.classList.add("text-center");
    tr.appendChild(td2);

    const td3 = document.createElement("td");
    td3.textContent = turn.hour;
    td3.classList.add("text-center");
    tr.appendChild(td3);
  });
}

function renderNewTurnForm() {
  const main = document.querySelector("main");

  // Section
  const section = document.createElement("section");
  section.classList.add("new-turn-form");
  main.appendChild(section);

  // Title
  const h1 = document.createElement("h1");
  h1.textContent = "Registrar Turno";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Form
  const form = document.createElement("form");
  form.classList.add("d-flex", "flex-column", "align-items-center");
  section.appendChild(form);

  // Client select
  const clientSelect = document.createElement("select");
  clientSelect.name = "client";
  clientSelect.id = "client";
  clientSelect.classList.add("form-control", "mb-3", "w-50");

  // Placeholder
  const placeholderOption = document.createElement("option");
  placeholderOption.value = "";
  placeholderOption.textContent = "Seleccionar cliente";
  placeholderOption.disabled = true;
  placeholderOption.selected = true;
  clientSelect.appendChild(placeholderOption);

  // Llenar clientes
  clientsArray.forEach((client) => {
    const option = document.createElement("option");
    option.value = client;
    option.textContent = client;
    clientSelect.appendChild(option);
  });
  form.appendChild(clientSelect);

  // Date
  const dateInput = document.createElement("input");
  dateInput.type = "date";
  dateInput.name = "date";
  dateInput.id = "date";
  dateInput.placeholder = "Fecha";
  dateInput.classList.add("form-control", "mb-3", "w-50");
  form.appendChild(dateInput);

  // Hour
  const hourInput = document.createElement("input");
  hourInput.type = "time";
  hourInput.name = "hour";
  hourInput.id = "hour";
  hourInput.placeholder = "Hora";
  hourInput.classList.add("form-control", "mb-3", "w-50");
  form.appendChild(hourInput);

  // Button submit
  const button = document.createElement("button");
  button.type = "submit";
  button.textContent = "Registrar";
  button.classList.add("btn", "btn-primary");
  form.appendChild(button);

  // Submit event
  form.addEventListener("submit", (e) => {
    e.preventDefault();
    const client = document.querySelector("#client").value;
    const date = document.querySelector("#date").value;
    const hour = document.querySelector("#hour").value;

    if (!client) {
      alert("Por favor, selecciona un cliente.");
      return;
    }

    const newTurn = {
      client,
      date,
      hour,
    };
    turnsArray.push(newTurn);
    clearMain();
    renderTurnsByClient();
  });
}

document.addEventListener("DOMContentLoaded", () => {
  renderTurnsByClient();
});
