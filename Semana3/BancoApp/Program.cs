using BancoApp.Domain;
using BancoApp.Services;

CuentaService manager = new CuentaService();

//List all product of store:
List<Cuenta> lst = manager.GetCuentas();
if (lst.Count == 0)
{
    Console.WriteLine("Sin cuentas en la base de datos");

}
else
{
    foreach (var oCuenta in lst)
    {
        Console.WriteLine(oCuenta);
    }
}
