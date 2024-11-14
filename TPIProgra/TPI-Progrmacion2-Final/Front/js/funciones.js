import { limpiarMain, obtenerDatos } from './utils.js';

export function manejarClickConsultarFunciones() {
  limpiarMain();
  renderizarFunciones();
}

export function manejarClickAgregarFuncion() {
  limpiarMain();
  renderizarFormFuncion();
}

export async function renderizarFunciones() {
  const main = document.querySelector("main");

  const section = document.createElement("section");
  section.classList.add("funciones");
  main.appendChild(section);

  const h1 = document.createElement("h1");
  h1.textContent = "Funciones";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  const filterContainer = await crearFiltros();
  section.appendChild(filterContainer);

  const encabezados = [
    "ID",
    "Pelicula",
    "Subtitulos",
    "Sala",
    "Horario",
    "Precio",
    "Acciones",
  ];

  // crear tabla
  const table = crearTabla(encabezados);
  section.appendChild(table);

  try {
    const data = await obtenerDatos("https://localhost:7025/api/funciones");
    renderizarTabla(data, table);
  } catch (error) {
    console.error("Error fetching functions:", error);
    alert("No se pudieron cargar las funciones.");
  }
}

export async function crearFiltros() {
  // div para filtros
  const filterContainer = document.createElement("div");
  filterContainer.classList.add("filter-container", "mb-4");

  // input nombre pelicula
  const labelPelicula = document.createElement("label");
  labelPelicula.textContent = "Filtrar por nombre de película:";
  const inputPelicula = document.createElement("input");
  inputPelicula.classList.add("form-control", "mb-2");
  inputPelicula.type = "text";
  inputPelicula.id = "input-pelicula";
  inputPelicula.placeholder = "Nombre de la película";
  filterContainer.appendChild(labelPelicula);
  filterContainer.appendChild(inputPelicula);

  // input sala
  const labelSala = document.createElement("label");
  labelSala.textContent = "Filtrar por sala:";
  const inputSala = document.createElement("input");
  inputSala.classList.add("form-control", "mb-2");
  inputSala.type = "number";
  inputSala.id = "input-sala";
  inputSala.placeholder = "Sala";
  filterContainer.appendChild(labelSala);
  filterContainer.appendChild(inputSala);

  // input fecha desde
  const labelFechaDesde = document.createElement("label");
  labelFechaDesde.textContent = "Filtrar por fecha desde:";
  const inputFechaDesde = document.createElement("input");
  inputFechaDesde.classList.add("form-control", "mb-2");
  inputFechaDesde.type = "date";
  inputFechaDesde.id = "input-fecha-desde";
  filterContainer.appendChild(labelFechaDesde);
  filterContainer.appendChild(inputFechaDesde);

  // input fecha hasta
  const labelFechaHasta = document.createElement("label");
  labelFechaHasta.textContent = "Filtrar por fecha hasta:";
  const inputFechaHasta = document.createElement("input");
  inputFechaHasta.classList.add("form-control", "mb-2");
  inputFechaHasta.type = "date";
  inputFechaHasta.id = "input-fecha-hasta";
  filterContainer.appendChild(labelFechaHasta);
  filterContainer.appendChild(inputFechaHasta);

  // input precio desde
  const labelPrecioDesde = document.createElement("label");
  labelPrecioDesde.textContent = "Filtrar por precio desde:";
  const inputPrecioDesde = document.createElement("input");
  inputPrecioDesde.classList.add("form-control", "mb-2");
  inputPrecioDesde.type = "number";
  inputPrecioDesde.id = "input-precio-desde";
  filterContainer.appendChild(labelPrecioDesde);
  filterContainer.appendChild(inputPrecioDesde);

  // input precio hasta
  const labelPrecioHasta = document.createElement("label");
  labelPrecioHasta.textContent = "Filtrar por precio hasta:";
  const inputPrecioHasta = document.createElement("input");
  inputPrecioHasta.classList.add("form-control", "mb-2");
  inputPrecioHasta.type = "number";
  inputPrecioHasta.id = "input-precio-hasta";
  filterContainer.appendChild(labelPrecioHasta);
  filterContainer.appendChild(inputPrecioHasta);

  // btn consultar
  const btnConsultar = document.createElement("button");
  btnConsultar.classList.add("btn", "btn-secondary");
  btnConsultar.textContent = "Consultar";
  filterContainer.appendChild(btnConsultar);

  // btn limpiar filtros
  const btnLimpiar = document.createElement("button");
  btnLimpiar.classList.add("btn", "btn-secondary", "ml-2");
  btnLimpiar.textContent = "Limpiar filtros";
  filterContainer.appendChild(btnLimpiar);

  // event listener consultar por filtros
  btnConsultar.addEventListener("click", consultarFuncionesConFiltros);
  // event listener limpiar filtros
  btnLimpiar.addEventListener("click", limpiarFiltros);

  return filterContainer;
}

export function limpiarFiltros() {
  const inputPelicula = document.querySelector("#input-pelicula");
  const inputSala = document.querySelector("#input-sala");
  const inputFechaDesde = document.querySelector("#input-fecha-desde");
  const inputFechaHasta = document.querySelector("#input-fecha-hasta");
  const inputPrecioDesde = document.querySelector("#input-precio-desde");
  const inputPrecioHasta = document.querySelector("#input-precio-hasta");

  inputPelicula.value = "";
  inputSala.value = "";
  inputFechaDesde.value = "";
  inputFechaHasta.value = "";
  inputPrecioDesde.value = "";
  inputPrecioHasta.value = "";
}

export async function consultarFuncionesConFiltros() {
  // Obtener los valores de los inputs
  const inputPelicula = document.querySelector("#input-pelicula");
  const inputSala = document.querySelector("#input-sala");
  const inputFechaDesde = document.querySelector("#input-fecha-desde");
  const inputFechaHasta = document.querySelector("#input-fecha-hasta");
  const inputPrecioDesde = document.querySelector("#input-precio-desde");
  const inputPrecioHasta = document.querySelector("#input-precio-hasta");

  const pelicula = inputPelicula.value;
  const sala = inputSala.value;
  const fechaDesde = inputFechaDesde.value;
  const fechaHasta = inputFechaHasta.value;
  const precioDesde = inputPrecioDesde.value;
  const precioHasta = inputPrecioHasta.value;

  try {
    const data = await obtenerDatos(`https://localhost:7025/api/funciones/GetByFilters?pelicula=${pelicula}&sala=${sala}&fechaDesde=${fechaDesde}&fechaHasta=${fechaHasta}&precioDesde=${precioDesde}&precioHasta=${precioHasta}`);



    const section = document.querySelector("main").querySelector(".funciones");

    section.removeChild(section.querySelector("table"));


    const encabezados = [
      "ID",
      "Pelicula",
      "Subtitulos",
      "Sala",
      "Horario",
      "Precio",
      "Acciones",
    ];

    const table = crearTabla(encabezados);
    section.appendChild(table);

    renderizarTabla(data, table);
  } catch (error) {
    console.error("Error fetching filtered functions:", error);
    alert("No se pudieron cargar las funciones con los filtros.");
  }
}

export function crearTabla(encabezados) {
  const table = document.createElement("table");
  table.classList.add(
    "table",
    "table-striped",
    "table-hover",
    "align-middle",
    "table-bordered"
  );

  const tableHead = document.createElement("thead");
  const headerRow = document.createElement("tr");

  // encabezados
  encabezados.forEach((headerText) => {
    const th = document.createElement("th");
    th.scope = "col";
    th.textContent = headerText;

    // Ocultar id
    if (headerText === "ID") {
      th.classList.add("hidden-column");
    }

    headerRow.appendChild(th);
  });

  tableHead.appendChild(headerRow);
  table.appendChild(tableHead);

  const tableBody = document.createElement("tbody");
  table.appendChild(tableBody);

  return table;
}

export function renderizarTabla(data, tabla) {
  const tableBody = tabla.querySelector("tbody");

  data.forEach((funcion) => {
    const fila = document.createElement("tr");

    // crear celdas
    const celdas = [
      funcion.idFuncion,
      funcion.idPeliculaNavigation.pelicula1,
      funcion.subtitulada ? "Sí" : "No",
      funcion.idSalaNavigation.idSala,
      formatearFecha(funcion.horario),
      `$${funcion.precioActual}`,
    ];

    celdas.forEach((celda, indice) => {
      const td = document.createElement("td");
      td.textContent = celda;

      // ocultar id
      if (indice === 0) {
        td.classList.add("hidden-column");
      }

      fila.appendChild(td);
    });

    // acciones
    const celdaAcciones = document.createElement("td");

    const btnEditar = document.createElement("button");
    btnEditar.classList.add("btn", "btn-primary");
    btnEditar.textContent = "Editar";
    celdaAcciones.appendChild(btnEditar);

    // evento editar
    btnEditar.addEventListener("click", () => editarFuncion(funcion.idFuncion));

    const btnEliminar = document.createElement("button");
    btnEliminar.classList.add("btn", "btn-danger");
    btnEliminar.textContent = "Eliminar";

    // evento eliminar
    btnEliminar.addEventListener("click", () =>
      eliminarFuncion(funcion.idFuncion)
    );

    celdaAcciones.appendChild(btnEliminar);

    fila.appendChild(celdaAcciones);
    tableBody.appendChild(fila);
  });
}

export async function eliminarFuncion(id) {
  const confirmarEliminar = window.confirm(
    "¿Estás seguro de que quieres eliminar esta función?"
  );

  if (confirmarEliminar) {
    try {
      const respuesta = await fetch(
        `https://localhost:7025/api/funciones/${id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
            //"set-cookie":document.cookie
      
          },
          credentials: "include"
        }
      );

      if (!respuesta.ok) {
        if(respuesta.status === 401){
          alert("Credenciales no validas. Ingrese sesion.")
          const user = document.getElementById("user");
          user.textContent = "Usuario";
        } 
        if(respuesta.status === 403) alert("No autorizado.")
        throw new Error(`HTTP error! Status: ${respuesta.status}`);
      }

      const message = await respuesta.json();
      console.log(message);
      alert("Se dio de baja la funcion correctamente.");
      manejarClickConsultarFunciones();
    } catch (error) {
      console.error("Error al dar de baja la funcion:", error);
      alert("Error al dar de baja la funcion.");
    }
  } else {
    console.log("Baja logica cancelada.");
  }
}

export function editarFuncion(id) {
  limpiarMain();
  renderizarFormFuncion(id);
}

export async function renderizarFormFuncion(idFuncion = null) {
  const main = document.querySelector("main");

  const section = document.createElement("section");
  section.classList.add("formulario");
  main.appendChild(section);

  const h1 = document.createElement("h1");
  h1.textContent = idFuncion ? "Editar Función" : "Registrar Nueva Función";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  try {
    const peliculas = await obtenerDatos("https://localhost:7025/api/Peliculas");
    const salas = await obtenerDatos("https://localhost:7025/api/Salas");

    const form = await crearFormFuncion(peliculas, salas, idFuncion);
    section.appendChild(form);
  } catch (error) {
    console.error("Error fetching data:", error);
    alert("No se pudieron cargar las películas o salas.");
  }
}

export async function crearFormFuncion(peliculas, salas, idFuncion) {
  const form = document.createElement("form");
  form.classList.add("form-group");

  // labels e inputs
  const horarioLabel = document.createElement("label");
  horarioLabel.textContent = "Horario de la Función:";
  const horarioInput = document.createElement("input");
  horarioInput.type = "datetime-local";
  horarioInput.classList.add("form-control");
  horarioInput.required = true;

  const precioLabel = document.createElement("label");
  precioLabel.textContent = "Precio de la Función:";
  const precioInput = document.createElement("input");
  precioInput.type = "number";
  precioInput.step = ".01";
  precioInput.classList.add("form-control");
  precioInput.required = true;

  const subtituladaLabel = document.createElement("label");
  subtituladaLabel.textContent = "¿Está Subtitulada?";
  const subtituladaSelect = document.createElement("select");
  subtituladaSelect.classList.add("form-control");
  subtituladaSelect.required = true;

  const opcionSi = document.createElement("option");
  opcionSi.value = "true";
  opcionSi.textContent = "Sí";
  const opcionNo = document.createElement("option");
  opcionNo.value = "false";
  opcionNo.textContent = "No";
  subtituladaSelect.appendChild(opcionSi);
  subtituladaSelect.appendChild(opcionNo);

  // dropdown peliculas
  const peliculaLabel = document.createElement("label");
  peliculaLabel.textContent = "Seleccione una Película:";
  const peliculaSelect = document.createElement("select");
  peliculaSelect.classList.add("form-control");
  peliculaSelect.required = true;

  const opcionDefaultPelicula = document.createElement("option");
  opcionDefaultPelicula.value = "";
  opcionDefaultPelicula.textContent = "Seleccione una película";
  peliculaSelect.appendChild(opcionDefaultPelicula);

  peliculas.forEach((pelicula) => {
    const peliculaOpcion = document.createElement("option");
    peliculaOpcion.value = pelicula.idPelicula;
    peliculaOpcion.textContent = pelicula.pelicula1;
    peliculaSelect.appendChild(peliculaOpcion);
  });

  // dropdown salas
  const salaLabel = document.createElement("label");
  salaLabel.textContent = "Seleccione una Sala:";
  const salaSelect = document.createElement("select");
  salaSelect.classList.add("form-control");
  salaSelect.required = true;

  const opcionDefaultSala = document.createElement("option");
  opcionDefaultSala.value = "";
  opcionDefaultSala.textContent = "Seleccione una sala";
  salaSelect.appendChild(opcionDefaultSala);

  salas.forEach((sala) => {
    if (sala.activa) {
      const salaOpcion = document.createElement("option");
      salaOpcion.value = sala.idSala;
      salaOpcion.textContent = `Sala ${sala.idSala}`;
      salaSelect.appendChild(salaOpcion);
    }
  });

  // cargar los datos de la funcion solo si se pasa un id
  if (idFuncion) {
    try {
      const respuesta = await fetch(`https://localhost:7025/api/funciones/${idFuncion}`,{
        headers: {
          "Content-Type": "application/json",
          //"set-cookie":document.cookie
    
        },
        credentials: "include"
      });
      if (!respuesta.ok) {
        if(respuesta.status === 401){
          alert("Credenciales no validas. Ingrese sesion.")
          const user = document.getElementById("user");
          user.textContent = "Usuario";
        } 
        if(respuesta.status === 403) alert("No autorizado.")
        throw new Error(`HTTP error! Status: ${respuesta.status}`);
      }
      const data = await respuesta.json();

      horarioInput.value = formatearFechaParaInput(data.horario);

      // llenar campos
      //horarioInput.value = data.horario;
      precioInput.value = data.precioActual;
      subtituladaSelect.value = data.subtitulada ? "true" : "false";
      peliculaSelect.value = data.idPelicula;
      salaSelect.value = data.idSala;
    } catch (error) {
      console.error("Error al cargar datos de la función:", error);
      alert("No se pudieron cargar los datos de la función.");
    }
  }

  // submit
  const submitButton = document.createElement("button");
  submitButton.type = "submit";
  submitButton.classList.add("btn", "btn-primary", "mt-3");
  submitButton.textContent = idFuncion
    ? "Actualizar Función"
    : "Registrar Función";

  form.appendChild(horarioLabel);
  form.appendChild(horarioInput);
  form.appendChild(precioLabel);
  form.appendChild(precioInput);
  form.appendChild(subtituladaLabel);
  form.appendChild(subtituladaSelect);
  form.appendChild(peliculaLabel);
  form.appendChild(peliculaSelect);
  form.appendChild(salaLabel);
  form.appendChild(salaSelect);
  form.appendChild(submitButton);

  // evento submit
  form.addEventListener("submit", async (event) => {
    event.preventDefault();

    // mapear valores
    const horario = horarioInput.value;
    const precio = parseFloat(precioInput.value);
    const subtitulada = subtituladaSelect.value === "true";
    const peliculaId = peliculaSelect.value;
    const salaId = salaSelect.value;

    if (!peliculaId || !salaId) {
      alert("Por favor, seleccione una película y una sala.");
      return;
    }

    const funcionData = {
      idFuncion: idFuncion || 0, // 0 para nuevos para q no se enoje entity, el id de la funcion para edit
      idPelicula: peliculaId,
      idSala: salaId,
      horario: horario,
      subtitulada: subtitulada,
      precioActual: precio,
      fechaAlta: new Date().toISOString(),
      fechaBaja: null,
    };

    const method = idFuncion ? "PUT" : "POST";
    const url = idFuncion
      ? `https://localhost:7025/api/funciones/${idFuncion}`
      : "https://localhost:7025/api/funciones";

    try {
      const respuesta = await fetch(url, {
        method: method,
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify(funcionData),
      });

      if (!respuesta.ok) {
        if(respuesta.status === 401){
          alert("Credenciales no validas. Ingrese sesion.")
          const user = document.getElementById("user");
          user.textContent = "Usuario";
        } 
        if(respuesta.status === 403) alert("No autorizado.")
        const errorData = await respuesta.json();
        throw new Error(errorData.message || "Error desconocido");
      }

      const data = await respuesta.json();
      alert(data.message);
      manejarClickConsultarFunciones();
    } catch (error) {
      console.error("Error al guardar o actualizar la función:", error);
      const form = document.querySelector('.formulario');
      const divMensajeError = document.createElement("div");
      divMensajeError.classList.add("alert", "alert-danger");
      divMensajeError.textContent = error.message;
      form.appendChild(divMensajeError);
    }
  });

  return form;
}

export function formatearFecha(dateString) {
  const date = new Date(dateString); // Convertir a objeto Date

  // Obtenemos los componentes de la fecha
  const day = date.getDate().toString().padStart(2, "0"); // Día con 2 dígitos
  const month = date.toLocaleString("default", { month: "short" }); // Mes abreviado (Ej. Nov)
  const year = date.getFullYear(); // Año completo
  const hours = date.getHours().toString().padStart(2, "0"); // Hora con 2 dígitos
  const minutes = date.getMinutes().toString().padStart(2, "0"); // Minutos con 2 dígitos

  // Devolvemos el formato requerido
  return `${day}-${month}-${year} | ${hours}:${minutes}`;
}

export function formatearFechaParaInput(dateString) {
  const date = new Date(dateString);

  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, "0"); // Mes con 2 dígitos
  const day = date.getDate().toString().padStart(2, "0"); // Día con 2 dígitos
  const hours = date.getHours().toString().padStart(2, "0"); // Hora con 2 dígitos
  const minutes = date.getMinutes().toString().padStart(2, "0"); // Minutos con 2 dígitos

  return `${year}-${month}-${day}T${hours}:${minutes}`;
}
