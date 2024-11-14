import { limpiarMain } from "./utils.js";



/*
document.addEventListener("DOMContentLoaded", async () => {
  renderRegister();
  //renderLogin();
  //setFormEvent();
  setNavEvents();
});
*/

export function setFormEvent() {
  const form = document.querySelector("#login-form");
  form.addEventListener("submit", (e) => {
    e.preventDefault();
    const loginRequest = {
      email: document.getElementById("email").value,
      password: document.getElementById("password").value
    };
    login(loginRequest);
  });
  
}
/*
export function setNavEvents() {
  const registerLink = document.getElementById("register-link");
  registerLink.addEventListener("click", (e) => {
    e.preventDefault();
    limpiarMain();
    renderRegister();
  });
  
  const loginLink = document.getElementById("login-link");
  loginLink.addEventListener("click", (e) => {
    e.preventDefault();
    limpiarMain();
    renderLogin();
  });
  const clientesLink = document.getElementById("clientes-link");
  clientesLink.addEventListener("click", (e) => {
    e.preventDefault();
    callClientes();
  });
}
  */

export function manejarClickIngresar() {
  limpiarMain();
  renderLogin();
}

export function manejarClickRegistrar() {
  limpiarMain();
  renderRegister();
}
/*
function limpiarMain() {
  const main = document.querySelector("main");
  while (main.firstChild) {
    main.removeChild(main.firstChild);
  }
}
*/

export function renderRegister() {
  const main = document.querySelector("main");
  const section = document.createElement("section");
  section.classList.add("register", "container", "justify-content-center", "align-items-center", "mt-5");

  const title = document.createElement("h3");
  title.textContent = "Registrarse";
  title.classList.add( "text-center");
  section.appendChild(title);

  const form = document.createElement("form");
  form.setAttribute("id", "register-form");
  form.classList.add("form");
  section.appendChild(form);

  const lblName = document.createElement("label");
  lblName.setAttribute("for", "name");
  lblName.classList.add("form-label");
  lblName.textContent = "Nombre";
  form.appendChild(lblName);

  const inputName = document.createElement("input");
  inputName.setAttribute("type", "text");
  inputName.setAttribute("id", "name");
  inputName.required = true;
  inputName.classList.add("form-control", "mb-3");
  form.appendChild(inputName);

  const lblLastName = document.createElement("label");
  lblLastName.setAttribute("for", "lastName");
  lblLastName.textContent = "Apellido";
  lblLastName.classList.add("form-label");
  form.appendChild(lblLastName);

  const inputLastName = document.createElement("input");
  inputLastName.setAttribute("type", "text");
  inputLastName.setAttribute("id", "lastName");
  inputLastName.classList.add("form-control", "mb-3");
  inputLastName.required = true;
  form.appendChild(inputLastName);

  const lblDNI = document.createElement("label");
  lblDNI.setAttribute("for", "DNI");
  lblDNI.textContent = "DNI";
  lblDNI.classList.add("form-label");
  form.appendChild(lblDNI);

  const inputDNI = document.createElement("input");
  inputDNI.setAttribute("type", "number");
  inputDNI.setAttribute("id", "DNI");
  inputDNI.classList.add("form-control", "mb-3");
  inputDNI.required = true;
  form.appendChild(inputDNI);

  const lblAdmin = document.createElement("label");
  lblAdmin.setAttribute("for", "admin");
  lblAdmin.textContent = "¿Es administrador?";
  lblAdmin.classList.add("form-label");
  form.appendChild(lblAdmin);

  const inputAdmin = document.createElement("input");
  inputAdmin.setAttribute("type", "checkbox");
  inputAdmin.setAttribute("id", "admin");
  inputAdmin.classList.add("form-check");
  form.appendChild(inputAdmin);

  const lblEmail = document.createElement("label");
  lblEmail.setAttribute("for", "email");
  lblEmail.textContent = "Email";
  lblEmail.classList.add("form-label");
  form.appendChild(lblEmail);

  const inputEmail = document.createElement("input");
  inputEmail.setAttribute("type", "email");
  inputEmail.setAttribute("id", "email");
  inputEmail.setAttribute("name", "email");
  inputEmail.classList.add("form-control", "mb-3");
  inputEmail.required = true;
  form.appendChild(inputEmail);

  const lblPassword = document.createElement("label");
  lblPassword.setAttribute("for", "password");
  lblPassword.textContent = "Contraseña";
  lblPassword.classList.add("form-label");
  form.appendChild(lblPassword);

  const inputPassword = document.createElement('input');
  inputPassword.setAttribute("type", "password");
  inputPassword.setAttribute("id", "password");
  inputPassword.setAttribute("name", "password");
  inputPassword.classList.add("form-control", "mb-3");
  inputPassword.required = true;
  form.appendChild(inputPassword);

  const button = document.createElement("button");
  button.setAttribute("type", "submit");
  button.setAttribute("id", "register-button");
  button.classList.add("btn", "btn-primary");
  button.textContent = "Registrarse";
  form.appendChild(button);

  const loginRedirect = document.createElement("p");
  loginRedirect.classList.add("text-center");
  const loginLink = document.createElement("a");
  loginLink.href = "#";
  loginLink.textContent = "¿Ya tienes una cuenta?";
  loginLink.addEventListener("click", (e) => {
    e.preventDefault();
    limpiarMain();
    renderLogin();
  });
  loginRedirect.appendChild(loginLink);
  form.appendChild(loginRedirect);

  form.addEventListener("submit", (e) => {
    e.preventDefault();
    const registerRequest = {
      idCliente: 0,
      nombre: document.getElementById("name").value,
      apellido: document.getElementById("lastName").value,
      numeroDoc: document.getElementById("DNI").value,
      fecAfiliacion: new Date().toISOString(),
      email: document.getElementById("email").value,
      admin: document.getElementById("admin").checked,
      pass: document.getElementById("password").value
    };
    register(registerRequest);
  });

  main.appendChild(section);
}

export function renderLogin() {
  const main = document.querySelector("main");
  const section = document.createElement("section");
  section.classList.add("login", "container", "justify-content-center", "align-items-center", "mt-5");
  
  const title = document.createElement("h3");
  title.textContent = "Login";
  title.classList.add( "text-center");
  section.appendChild(title);

  const form = document.createElement("form");
  form.setAttribute("id", "login-form");
  form.classList.add();
  section.appendChild(form);

  const label = document.createElement("label");
  label.setAttribute("for", "email");
  label.textContent = "Email";
  form.appendChild(label);

  const input = document.createElement("input");
  input.setAttribute("type", "email");
  input.setAttribute("id", "email");
  input.setAttribute("name", "email");
  input.required = true;
  input.classList.add("form-control", "mb-3");
  form.appendChild(input);

  const label2 = document.createElement("label");
  label2.setAttribute("for", "password");
  label2.textContent = "Password";
  form.appendChild(label2);

  const input2 = document.createElement('input');
  input2.setAttribute("type", "password");
  input2.setAttribute("id", "password");
  input2.setAttribute("name", "password");
  input2.required = true;
  input2.classList.add("form-control", "mb-3");
  form.appendChild(input2);

  const button = document.createElement("button");
  button.setAttribute("type", "submit");
  button.setAttribute("id", "login-button");
  button.classList.add("btn", "btn-primary");
  button.textContent = "Login";
  form.appendChild(button);

  form.addEventListener("submit", (e) => {
    e.preventDefault();
    const loginRequest = {
      email: document.getElementById("email").value,
      password: document.getElementById("password").value
    };
    login(loginRequest);
  });

  main.appendChild(section);
}


export async function login(loginRequest) {
  fetch("https://localhost:7025/api/Autenticacion", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"

    },
    credentials: "include",
    body: JSON.stringify(loginRequest)
  }).then(response => {
    if (response.ok) {
      var hola = response.headers.getSetCookie();
      alert("Ha ingresado exitosamente!");
      const user = document.getElementById("user");
      user.textContent = loginRequest.email;
    }
  })
}
export async function register(registerRequest) {

  const response = await fetch("https://localhost:7025/api/Clientes", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(registerRequest)
  });
  
  if (response.ok) {
    alert("Se ha registrado exitosamente!");
  }
  else {
    throw new Error(`HTTP error! Status: ${respuesta.status}`);
  }
}



/*
async function callClientes() {
  const response = await fetch("https://localhost:7088/api/Clientes",{
    headers: {
      "Content-Type": "application/json",
      "set-cookie": document.cookie
    },
    method: 'GET',
    credentials: "include"
  });
  if (!response.ok) {
    alert("No autorizado");
  }
  else{
    const data = await response.json();
    console.log(data);

  }

}
*/