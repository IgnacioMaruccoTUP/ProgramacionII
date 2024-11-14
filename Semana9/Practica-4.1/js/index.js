function clearInputs() {
  document.getElementById('nombre').value = '';
  document.getElementById('email').value = '';
  document.getElementById('consulta').value = '';
}

function validateForm() {
  const $inputNombre = document.querySelector("#nombre");
  const $inputEmail = document.querySelector("#email");
  const $inputConsulta = document.querySelector("#consulta");

  if ($inputNombre.value.length === 0){
    alert("Ingresar Nombre")
    return
  }

  if ($inputEmail.value.length === 0){
    alert("Ingresar Email")
    return
  }

  if (!$inputEmail.value.includes('@') || !$inputEmail.value.endsWith('.com')) {
  alert("El email debe contener un '@' y terminar en '.com'")
  return
}
    
  if ($inputConsulta.value.length === 0){
    alert("Ingreasr Consulta")
    return
  }

  alert(`Se envio el formulario con los siguientes datos:
Nombre: ${inputNombre.value} -
Email: ${inputEmail.value} -
Consulta: ${inputConsulta.value}
`);

}
