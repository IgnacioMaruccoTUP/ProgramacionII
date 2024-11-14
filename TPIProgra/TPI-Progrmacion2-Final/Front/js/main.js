import { manejarClickConsultarFunciones, manejarClickAgregarFuncion, renderizarFunciones } from './funciones.js';
import { manejarClickNuevaReserva, manejarClickConsultarReservas, manejarClickAgregarReservas } from './reservas.js';
import { limpiarMain } from './utils.js';
import { manejarClickIngresar, manejarClickRegistrar } from './login.js';

(() => {
  const btnInicio = document.querySelector("#inicio");
  const btnConsultarFunciones = document.querySelector("#consultar_funciones");
  const btnAgregarFuncion = document.querySelector("#agregar_funcion");
  const btmNuevaReserva = document.querySelector("#agregar_reserva");
  const btnConsultarReservas = document.querySelector("#consultar_reservas");
  const btnIngresar = document.querySelector("#ingresar");
  const btnRegistrar = document.querySelector("#registrar");
  const btnAcercaDe = document.querySelector("#acerca_de");

  btnInicio.addEventListener("click", manejarClickInicio);
  btnConsultarFunciones.addEventListener("click", manejarClickConsultarFunciones);
  btnAgregarFuncion.addEventListener("click", manejarClickAgregarFuncion);
  btmNuevaReserva.addEventListener("click", manejarClickAgregarReservas);
  btnConsultarReservas.addEventListener("click", manejarClickConsultarReservas);
  btnAcercaDe.addEventListener("click", manejarClickAcercaDe);

  btnIngresar.addEventListener("click", manejarClickIngresar);
  btnRegistrar.addEventListener("click", manejarClickRegistrar);


})();

function manejarClickInicio() {
  limpiarMain();
}

function manejarClickAcercaDe() {
  limpiarMain();
  renderAcercaDe();
}

function renderAcercaDe() {
  const main = document.querySelector("main");

  //Seccion
  const section = document.createElement("section");
  section.classList.add("acerca-de");
  main.appendChild(section);

  //Titulo
  const h1 = document.createElement("h1");
  h1.textContent = "UNIVERSIDAD TECNOLÓGICA NACIONAL";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  const img = document.createElement("img");
  img.src = "../images/logo.png";
  img.classList.add("img-logo", "img-fluid", "mx-auto", "d-block");
  section.appendChild(img);

  const h2 = document.createElement("h2");
  h2.textContent = "Facultad Regional Córdoba";
  h2.classList.add("text-center", "mb-4");
  section.appendChild(h2);

  const h3 = document.createElement("h3");
  h3.textContent = "Tecnicatura Universitaria en Programación";
  h3.classList.add("text-center", "mb-4");
  section.appendChild(h3);

  const h4 = document.createElement("h4");
  h4.textContent = "Base de Datos I";
  h4.classList.add("text-center", "mb-4");
  section.appendChild(h4);

  const comision = document.createElement("h6");
  comision.textContent = "Comisión – 1W1 – Grupo 5";
  comision.classList.add("text-center", "mb-4");
  section.appendChild(comision);

  const integrantes = document.createElement("h6");
  integrantes.textContent = "Integrantes";
  integrantes.classList.add("text-center", "mb-4");
  section.appendChild(integrantes);

  const p1 = document.createElement("p");
  p1.classList.add("text-left", "mb-2");
  p1.textContent = "412152 – Giorda, Brunella de Lourdes";
  section.appendChild(p1);

  const li2 = document.createElement("p");
  li2.classList.add("text-left", "mb-2");
  li2.textContent = "412304 – Guzmán Olariaga Facundo Nicolás";
  section.appendChild(li2);

  const p3 = document.createElement("p");
  p3.classList.add("text-left", "mb-2");
  p3.textContent = "412366 – Marucco, Ignacio";
  section.appendChild(p3);

  const p4 = document.createElement("p");
  p4.classList.add("text-left", "mb-2");
  p4.textContent = "412488 – Mendoza, Eduardo";
  section.appendChild(p4);

  const p5 = document.createElement("p");
  p5.classList.add("text-left", "mb-2");
  p5.textContent = "412092 – Murúa, Nicolás Agustín";
  section.appendChild(p5);

  const p6 = document.createElement("p");
  p6.classList.add("text-left", "mb-2");
  p6.textContent = "412012 – Rago, Tomás";
  section.appendChild(p6);
}