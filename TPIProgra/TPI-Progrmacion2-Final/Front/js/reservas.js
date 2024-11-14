import { limpiarMain, obtenerDatos } from './utils.js';
import { crearTabla, formatearFecha } from './funciones.js';

export function manejarClickNuevaReserva(entradas) {
  limpiarMain();
  renderizarFormReserva(entradas);
}

export async function renderizarFormReserva(entradas) {
  const main = document.querySelector("main");

  // Crear sección del formulario
  const section = document.createElement("section");
  section.classList.add("formulario");
  main.appendChild(section);

  // Título del formulario
  const h1 = document.createElement("h1");
  h1.textContent = "Reservar Función";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  // Llamar a crearCampos para generar los campos del formulario
  const filterContainer = await crearCampos();
  section.appendChild(filterContainer);

  const divMagico = document.createElement("div");
  divMagico.setAttribute("id", "detalles");
  divMagico.setAttribute("data-entradas", JSON.stringify(entradas))
  divMagico.classList.add("d-none");
  section.appendChild(divMagico);
}

export async function crearCampos() {
  // Contenedor de filtros
  const filterContainer = document.createElement("div");
  filterContainer.classList.add("filter-container", "mb-4");

  // Label y select para la forma de pago
  const labelFormaPago = document.createElement("label");
  labelFormaPago.textContent = "Forma de pago:";
  const inputFormaPago = document.createElement("select");
  inputFormaPago.classList.add("form-control", "mb-2");

  function limpiarCampos() {
    inputFormaPago.value = "";
    //inputIdCliente.value = "";
    inputFechaEmision.value = new Date().toLocaleDateString();
  }

  // Obtener las formas de pago desde el backend y agregar opciones
  try {
    const response = await fetch("https://localhost:7025/api/FormaPagos");
    const formasPago = await response.json();

    // Agregar opción predeterminada
    const defaultOption = document.createElement("option");
    defaultOption.value = "";
    defaultOption.textContent = "Seleccione una forma de pago";
    inputFormaPago.appendChild(defaultOption);

    // Agregar opciones dinámicamente
    formasPago.forEach((formaPago) => {
      const option = document.createElement("option");
      option.value = formaPago.idFormaPago;
      option.textContent = formaPago.formaPago;
      inputFormaPago.appendChild(option);
    });
  } catch (error) {
    console.error("Error al cargar formas de pago:", error);
    alert("No se pudieron cargar las formas de pago.");
  }

  // Añadir el select de forma de pago al contenedor
  filterContainer.appendChild(labelFormaPago);
  filterContainer.appendChild(inputFormaPago);

  // Campo para ID del cliente
  const labelFechaEmision = document.createElement("label");
  labelFechaEmision.textContent = "Fecha de Emisión:";
  // const inputIdCliente = document.createElement("input");
  // inputIdCliente.type = "number";
  // inputIdCliente.placeholder = "ID del cliente";
  // inputIdCliente.classList.add("form-control", "mb-2");


  // Crea el campo de selección para el cliente
  const labelCliente = document.createElement("label");
  labelCliente.textContent = "Cliente:";
  const selectCliente = document.createElement("select");
  selectCliente.classList.add("form-control", "mb-2");
  const defaultOption = document.createElement("option");
  defaultOption.textContent = "Elegir Cliente";
  defaultOption.value = ""; // Valor vacío para que no sea válido
  defaultOption.selected = true;
  defaultOption.disabled = true;
  selectCliente.appendChild(defaultOption);

  async function cargarClientes() {
    try {
      const response = await fetch('https://localhost:7025/api/Clientes');
      if (!response.ok) {
        if(respuesta.status === 401){
          alert("Credenciales no validas. Ingrese sesion.")
          const user = document.getElementById("user");
          user.textContent = "Usuario";
        } 
        if(respuesta.status === 403) alert("No autorizado.")
        throw new Error("Error al obtener la lista de clientes");
      }

      const clientes = await response.json();

      // Añade una opción por cada cliente
      clientes.forEach(cliente => {
        const option = document.createElement("option");
        option.value = cliente.idCliente; // Asigna el idCliente como valor
        option.textContent = `${cliente.nombre} ${cliente.apellido}`; // Muestra nombre y apellido
        selectCliente.appendChild(option);
      });
    } catch (error) {
      console.error("Error al cargar los clientes:", error);
      alert("No se pudo cargar la lista de clientes.");
    }
  }

  // Ejecuta la función para cargar clientes al cargar la página
  cargarClientes();

  filterContainer.appendChild(labelCliente);
  filterContainer.appendChild(selectCliente);

  //filterContainer.appendChild(inputIdCliente);
  filterContainer.appendChild(labelFechaEmision);

  // Campo para Fecha de Emisión
  const inputFechaEmision = document.createElement("input");
  inputFechaEmision.type = "text";
  inputFechaEmision.value = new Date().toLocaleDateString();
  inputFechaEmision.classList.add("form-control", "mb-2");
  inputFechaEmision.readOnly = true;
  filterContainer.appendChild(inputFechaEmision);

  // Botón de submit para reservar
  const submitButton = document.createElement("button");
  submitButton.type = "button";  // Cambiado a button para evitar envío automático
  submitButton.classList.add("btn", "btn-primary", "mt-3");
  submitButton.textContent = "Reservar";

  submitButton.addEventListener("click", async () => {
    const data = {
      idReserva: 0,
      idFormaPago: inputFormaPago.value,
      idCliente: selectCliente.value,
      //idCliente: inputIdCliente.value,
      fechaEmision: new Date().toISOString(),
      fechaPago: new Date().toISOString(),  // Fecha actual en formato ISO
      estadoPago: true,
      entrada: JSON.parse(document.getElementById("detalles").getAttribute("data-entradas"))
    };
    console.log(JSON.stringify(data));

    try {
      const response = await fetch('https://localhost:7025/api/Reservas', {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (!response.ok){
        if(respuesta.status === 401){
          alert("Credenciales no validas. Ingrese sesion.")
          const user = document.getElementById("user");
          user.textContent = "Usuario";
        } 
        if(respuesta.status === 403) alert("No autorizado.")
        throw new Error("Error en la reserva");

      } 
      alert("Reserva realizada con éxito");
      limpiarCampos();
      limpiarMain();
      renderReservas();
    } catch (error) {
      console.error("Error en la reserva:", error);
      alert("No se pudo realizar la reserva.");
    }
  });
  filterContainer.appendChild(submitButton);

  // Botón de submit para reservar más tarde
  const submitButton2 = document.createElement("button");
  submitButton2.type = "button";
  submitButton2.classList.add("btn", "btn-primary", "mt-3");
  submitButton2.textContent = "Reservar más tarde";

  submitButton2.addEventListener("click", async () => {
    const data = {
      idReserva: 0,
      idFormaPago: inputFormaPago.value,
      idCliente: selectCliente.value,
      //idCliente: inputIdCliente.value,
      fechaEmision: new Date().toISOString(),
      fechaPago: null,  // Fecha actual en formato ISO
      estadoPago: false,
      entrada: JSON.parse(document.getElementById("detalles").getAttribute("data-entradas"))
    };

    try {
      const response = await fetch("https://localhost:7025/api/Reservas", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });



      if (!response.ok) {
        if(respuesta.status === 401){
          alert("Credenciales no validas. Ingrese sesion.")
          const user = document.getElementById("user");
          user.textContent = "Usuario";
        } 
        if(respuesta.status === 403) alert("No autorizado.")
          throw new Error("Error en la reserva");
      }

      alert("Reserva programada con éxito");
      limpiarCampos();
    } catch (error) {
      console.error("Error en la reserva:", error);
      alert("No se pudo programar la reserva.");
    }
  });

  filterContainer.appendChild(submitButton2);

  return filterContainer;
}

// maestro detalle
export async function manejarClickConsultarReservas() {
  limpiarMain();
  await renderReservas();
}

export async function renderReservas() {
  const main = document.querySelector("main");

  const section = document.createElement("section");
  section.classList.add("funciones");
  main.appendChild(section);

  const h1 = document.createElement("h1");
  h1.textContent = "Reservas";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  const encabezados = [
    "ID",
    "Forma de Pago",
    "Cliente",
    "Fecha de reserva",
    "Fecha de pago",
    "Estado",
    "Acciones",
  ];

  const table = crearTabla(encabezados);
  section.appendChild(table);




  try {
    //const status = 0 || document.cookie["session"] ;
    //const data = await obtenerDatos(`https://localhost:7025/api/Reservas/cliente/${status}`);
    const data = await obtenerDatos(`https://localhost:7025/api/Reservas/cliente/0`);
    await cargarTabla(data, table);
  } catch (error) {
    console.error("Error fetching bookings:", error);
    alert("No se pudieron cargar las reservas.");
  }

}

export async function cargarTabla(data, table) {
  const tableBody = table.querySelector("tbody");

  data.forEach((reserva) => {
    const fila = document.createElement("tr");

    // crear celdas
    const celdas = [

      reserva.idReserva,
      reserva.idFormaPagoNavigation.formaPago,
      reserva.idClienteNavigation.nombre + " " + reserva.idClienteNavigation.apellido,
      formatearFecha(reserva.fechaEmision),
      formatearFecha(reserva.fechaPago),
      reserva.estadoPago ? "Pagada" : "Pendiente",
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

    const btnDetalles = document.createElement("button");
    btnDetalles.classList.add("btn", "btn-primary");
    btnDetalles.textContent = "Ver detalles";
    celdaAcciones.appendChild(btnDetalles);

    // evento editar
    btnDetalles.addEventListener("click", () => {

      mostrarDetalles(reserva.idReserva)
    });


    fila.appendChild(celdaAcciones);
    tableBody.appendChild(fila);
  });

}

export async function mostrarDetalles(idReserva) {
  const detalles = await obtenerDatos(`https://localhost:7025/api/Entradas/reserva/${idReserva}`);

  const modalBody = document.querySelector("#tabla-modal > tbody");
  while (modalBody.firstChild) modalBody.removeChild(modalBody.firstChild);
  let total = 0.0;
  detalles.forEach((entrada) => {
    const row = document.createElement("tr");


    const cells = [
      entrada.idButacaNavigation.fila + "-" + entrada.idButacaNavigation.columna,
      entrada.idFuncionNavigation.idPeliculaNavigation.pelicula1,
      entrada.idFuncionNavigation.horario,
      entrada.idFuncionNavigation.idSalaNavigation.idSala,
      `$${entrada.idFuncionNavigation.precioActual.toFixed(2)}`,
    ];
    total = total + entrada.idFuncionNavigation.precioActual;
    cells.forEach((cell) => {
      const td = document.createElement("td");
      td.textContent = cell;
      row.appendChild(td);
    });

    modalBody.appendChild(row);
  });
  document.querySelector("#total").textContent = `$${total}`;

  console.log(detalles);
  const modal = new bootstrap.Modal(
    document.getElementById("detalleModal")
  );
  modal.show();

}

export async function manejarClickAgregarReservas() {
  limpiarMain();
  await renderEntradasForm();
}

export async function renderEntradasForm() {
  const main = document.querySelector("main");
  const section = document.createElement("section");
  section.classList.add("funciones");
  main.appendChild(section);
  const h1 = document.createElement("h1");
  h1.textContent = "Entradas";
  section.appendChild(h1);

  const form = document.createElement("form");
  form.setAttribute("id", "form");
  section.appendChild(form);

  const lblPelicula = document.createElement("label");
  lblPelicula.setAttribute("for", "pelicula");
  lblPelicula.classList.add("form-label");
  lblPelicula.textContent = "Pelicula:";
  form.appendChild(lblPelicula);

  const selectPelicula = document.createElement("select");
  selectPelicula.setAttribute("id", "pelicula");
  selectPelicula.classList.add("form-select");
  form.appendChild(selectPelicula);

  const lblFuncion = document.createElement("label");
  lblFuncion.setAttribute("for", "funcion");
  lblFuncion.classList.add("form-label");
  lblFuncion.textContent = "Funcion:";
  form.appendChild(lblFuncion);

  const selectFuncion = document.createElement("select");
  selectFuncion.setAttribute("id", "funcion");
  selectFuncion.classList.add("form-select");
  form.appendChild(selectFuncion);

  const lblButacas = document.createElement("label");
  lblButacas.setAttribute("for", "butacas");
  lblButacas.classList.add("form-label");
  lblButacas.textContent = "Seleccione butacas:";
  form.appendChild(lblButacas);

  const butacaGrid = document.createElement("div");
  butacaGrid.setAttribute("id", "container");
  butacaGrid.classList.add("butacas-grid");
  butacaGrid.addEventListener("click", updateContador);
  section.appendChild(butacaGrid);

  const contador = document.createElement("h4");
  contador.setAttribute("id", "contador");
  contador.setAttribute("data-entradas", []);
  contador.textContent = "Entradas: xO ($0)";
  section.appendChild(contador)

  const btnReserva = document.createElement('button');
  btnReserva.addEventListener("click", () => {
    const detalles = captureEntradas();
    manejarClickNuevaReserva(detalles);
  })
  btnReserva.textContent = "Siguiente"
  btnReserva.classList.add("btn", "btn-primary", "mt-3");
  section.appendChild(btnReserva);

  await renderDropdownPeliculas();
  await renderDropdownFunciones();
  await renderButacasGrid();



  selectPelicula.addEventListener("change", renderDropdownFunciones)
  selectFuncion.addEventListener("change", renderButacasGrid)
}
export async function renderDropdownPeliculas() {
  const dropdown = document.querySelector("#pelicula");

  const data = await obtenerDatos(`https://localhost:7025/api/Peliculas`);

  data.forEach((item) => {
    const option = document.createElement("option");
    option.value = item["idPelicula"];
    option.textContent = item["pelicula1"];
    dropdown.appendChild(option);
  })

}

export function updateContador() {
  const contador = document.querySelector("#contador");
  const funcion = JSON.parse(document.querySelector("#funcion").value);
  const entradas = captureEntradas();
  contador.textContent = `Entradas: x${entradas.length} ($${entradas.length * funcion["precioActual"]})`;


}

export function captureEntradas() {
  const container = document.querySelector("#container");
  const funcion = JSON.parse(document.querySelector("#funcion").value);
  let entradas = [];
  document.querySelectorAll(".posicion").forEach(butaca => {
    if (butaca.classList.contains("reservada")) {
      entradas.push({
        idReserva: 0,
        idButaca: butaca.getAttribute("id"),
        idFuncion: funcion["idFuncion"]
      })
    }
  });
  return entradas;
}
export async function renderDropdownFunciones() {
  const dropdownPeliculas = document.querySelector("#pelicula");
  const dropdownFunciones = document.querySelector("#funcion");

  if (dropdownPeliculas.value) {
    const data = await obtenerDatos(`https://localhost:7025/api/Funciones/pelicula/${dropdownPeliculas.value}`);
    data.forEach((item) => {
      const option = document.createElement("option");
      option.value = JSON.stringify({
        idFuncion: item.idFuncion,
        precioActual: item.precioActual
      });
      option.textContent = `Sala ${item["idSala"]} - ${formatearFecha(item["horario"])}`;
      dropdownFunciones.appendChild(option);
    })
  }




}

export async function renderButacasGrid() {
  const funcion = JSON.parse(document.querySelector("#funcion").value);


  if (funcion["idFuncion"]) {
    const container = document.querySelector("#container");
    const butacas = await obtenerDatos(`https://localhost:7025/api/Butacas/ButacasByFuncion?idFuncion=${funcion["idFuncion"]}`)
    const butacasOcupadas = await obtenerDatos(`https://localhost:7025/api/Butacas/ButacasOcupadas?idFuncion=${funcion["idFuncion"]}`)

    while (container.firstChild) container.removeChild(container.firstChild);

    let rows = new Set();
    let columns = 1;
    let map = new Map();
    butacas.forEach(butaca => {
      if (!rows.has(butaca.fila)) rows.add(butaca.fila);
      if (butaca.columna > columns) columns = butaca.columna;
      map.set(butaca.fila + butaca.columna, butaca.idButaca);
    })


    const modeloSala = document.createElement("div");
    modeloSala.classList.add("sala");
    modeloSala.setAttribute("id", "sala");
    container.appendChild(modeloSala);

    rows.forEach(row => {
      const fila = document.createElement("div");
      fila.classList.add("fila", "flex-grow-0", "flex-shrink-0");
      modeloSala.appendChild(fila);
      for (let i = 1; i <= columns; i++) {
        const posicion = document.createElement("div");
        posicion.classList.add("posicion", "libre");
        posicion.setAttribute("id", `${map.get(row + i)}`)
        posicion.setAttribute('data', `${row}${i}`);
        posicion.innerText = `${row}${i}`;
        posicion.addEventListener("click", toggleButacas)

        butacasOcupadas.forEach(bOcu => {
          if (row + i == bOcu.fila + bOcu.columna) {
            posicion.classList.remove("libre");
            posicion.classList.add("ocupada");
            posicion.removeEventListener("click", toggleButacas)
            //butacasOcupadas.remove(bOcu);
          }
        })
        fila.appendChild(posicion);
      }
    })

  }


}

export function toggleButacas(event) {
  ocuparButaca(event);
}

export function ocuparButaca(e) {
  const butaca = e.target;
  if (butaca.classList.contains("reservada")) {
    butaca.classList.remove("reservada");
    butaca.classList.add("libre");
    console.log(butaca.getAttribute("id"));
  }
  else {
    butaca.classList.remove("libre");
    butaca.classList.add("reservada");
    console.log(butaca.getAttribute("id"));
  }


}


