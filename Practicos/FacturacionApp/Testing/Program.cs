using FacturacionApp.Domain;
using FacturacionApp.Services;

BillManager billManager = new BillManager();

//RECUPERAR FORMAS DE PAGO
Console.WriteLine("Formas de Pago Disponibles:");
var formasPago = billManager.GetAllPaymentTypes();
foreach (var formaPago in formasPago)
{
    Console.WriteLine($"ID: {formaPago.Code} | Nombre: {formaPago.Name}");
}

//RECUPERAR ARTICULOS
Console.WriteLine("\n");
Console.WriteLine("Articulos:");
var articles = billManager.GetAllArticles();
foreach (var article in articles)
{
    Console.WriteLine($"ID: {article.Code} | Nombre: {article.Name} | Precio Unitario: {article.UnitPrice}");
}


//INSERTAR TRANSACCION
//Nueva Factura:
var newBill = new Bill
{
    Client = "Julian",
    PaymentType = formasPago[0],
    DetailList = new List<BillDetail>()
    {
        new BillDetail { Article = articles[0],Count = 2 },
        new BillDetail { Article = articles[3],Count = 4 },
    }
};
Console.WriteLine("\n");
Console.WriteLine($"Factura Guardada? : {billManager.SaveBill(newBill)}");


//ELIMINAR UNA FACTURA
//var deletedBill = billManager.DeleteBill(9);
//Console.WriteLine("\n");
//Console.WriteLine($"Factura eliminada? : {deletedBill}");


//MOSTRAR TODAS LAS FACTURAS CON DETALLES
Console.WriteLine("\n");
Console.WriteLine("Facturas:");
var billList = billManager.GetAllBills();
foreach (var bill in billList)
{
    Console.WriteLine(bill.ToString());
}

//MOSTRAR UNA SOLA FACTURA
Console.WriteLine("\n");
Console.WriteLine("Recuperar una sola factura, ID 8:");
var specificBill = billManager.GetBillById(8);
Console.WriteLine(specificBill.ToString());