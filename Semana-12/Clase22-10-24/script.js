function procesar() {
  let n = parseInt(document.querySelector("#cantidad-numeros").value);

  const $btn = document.querySelector("button");

  $btn.disabled = true;

  const array = [];

  let cpos = 0,
    cneg = 0,
    spos = 0,
    sneg = 0;

  for (let i = 0; i < n; i++) {
    let valor = Math.floor(Math.random() * 100);
    if (Math.random() > 0.5) {
      array.push(valor);
    } else {
      valor = -valor;
      array.push(valor);
    }

    if (valor >= 0) {
      spos += valor;
      cpos++;
    } else {
      sneg += valor;
      cneg++;
    }
    console.log(`[${i}]:${valor}`);
  }

  const tableBody = document.querySelector("#table-body");
  // Limpiar tabla:
  tableBody.innerHTML = "";
  // Llenar la tabla
  for (let i = 0; i < array.length; i++) {
    const row = document.createElement("tr");
    const celdaPositiva = document.createElement("td");
    const celdaNegativa = document.createElement("td");
    celdaPositiva.classList.add("table-primary");
    celdaNegativa.classList.add("table-secondary");
    if (array[i] >= 0) {
      celdaPositiva.textContent = array[i];
      celdaNegativa.textContent = "";
    } else {
      celdaPositiva.textContent = "";
      celdaNegativa.textContent = array[i];
    }

    row.appendChild(celdaPositiva);
    row.appendChild(celdaNegativa);
    tableBody.appendChild(row);
  }

  document.querySelector(
    "#media-positivos"
  ).textContent = `Media de valores positivos: ${spos / cpos}.`;

  document.querySelector(
    "#media-negativos"
  ).textContent = `Media de valores negativos: ${sneg / cneg}.`;

  $btn.disabled = false;
}
