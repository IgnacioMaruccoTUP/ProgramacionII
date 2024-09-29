using BancoApp.Domain;
using BancoApp.Services;

AccountManager manager = new AccountManager();

//Create new account:
//var oAccountType = new AccountType()
//{
//    Id = 1,
//    Nombre = "Cuenta Corriente"
//};

//var oClient = new Client()
//{
//    Id = 1,
//    Nombre = "Julian",
//    Apellido = "Lencina",
//    Dni = 37785934
//};

//var oProduct = new Account()
//{
//    Cbu = 2222,
//    AccountType = oAccountType,
//    Saldo = 934234,
//    Cliente = oClient
//};
//if (manager.SaveAccount(oProduct))
//    Console.WriteLine("Cuenta registrada exitosamente!");

//Listar todas las cuentas:
List<Account> accountList = manager.GetAccounts();
if (accountList.Count == 0)
{
    Console.WriteLine("Sin cuentas en la base de datos");
}
else
{
    foreach (var oAccount in accountList)
    {
        Console.WriteLine(oAccount);
    }
}