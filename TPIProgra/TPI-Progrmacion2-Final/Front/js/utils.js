export function limpiarMain() {
  const main = document.querySelector("main");
  while (main.firstChild) {
    main.removeChild(main.firstChild);
  }
}

export async function obtenerDatos(url) {
  console.log(url)
  try {
    const respuesta = await fetch(url, {
      headers: {
        "Content-Type": "application/json",
        //"set-cookie":document.cookie
  
      },
      credentials: "include",
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

    return await respuesta.json();
  } catch (error) {
    console.error("Error al obtener los datos:", error);
  }
}
