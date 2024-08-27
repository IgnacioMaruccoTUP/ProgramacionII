// See https://aka.ms/new-console-template for more information
using PilasColasApp.Clases;

var pila = new Pila(2);

pila.Aniadir(1);
pila.Aniadir(2);
pila.Aniadir(3);

Console.WriteLine(pila.Primero());
Console.WriteLine(pila.EstaVacia());


Console.WriteLine(pila.Extraer());
Console.WriteLine(pila.EstaVacia());
Console.WriteLine(pila.Extraer());
Console.WriteLine(pila.EstaVacia());
Console.WriteLine(pila.Extraer());
Console.WriteLine(pila.EstaVacia());


var cola = new Cola();

cola.Aniadir(1);
cola.Aniadir(2);


Console.WriteLine(cola.Primero());
Console.WriteLine(cola.EstaVacia());
Console.WriteLine(cola.Extraer());
Console.WriteLine(cola.EstaVacia());
Console.WriteLine(cola.Extraer());
Console.WriteLine(cola.EstaVacia());
Console.WriteLine(cola.Extraer());
Console.WriteLine(cola.EstaVacia());

