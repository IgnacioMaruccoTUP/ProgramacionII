// See https://aka.ms/new-console-template for more information

using ProductosApp.Clases;

var suelto = new Suelto();
var pack = new Pack();

suelto.Precio = 1000;
suelto.Medida = 2;

pack.Precio = 3000;
pack.Cantidad = 6;

Producto[] array = { suelto, pack };

float total = 0;

foreach (Producto x in array)
{
    total += x.CalcularPrecio();
}

Console.WriteLine("TOTAL: $" + total);
