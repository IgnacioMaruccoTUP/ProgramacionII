// See https://aka.ms/new-console-template for more information
using FacturacionApp.Data.Implementations;
using FacturacionApp.Domain;
using FacturacionApp.Services;
using System.Collections.Immutable;
using System.Data;

using (UnitOfWork oUoW = new UnitOfWork())
{
    BillManager service = new BillManager(oUoW);

    //Recuperar Articulos
    Console.WriteLine("Artículos:");
    var articleList = service.GetAllArticles();

    foreach (var article in articleList)
    {
        Console.WriteLine($"Codigo: {article.Code} | Nombre: {article.Name} | Precio Unitario: ${article.UnitPrice}");
    }

    //Recuperar Formas Pago
    Console.WriteLine("Formas de Pago:");
    var paymentTypesList = service.GetAllPaymentTypes();

    foreach (var paymentType in paymentTypesList)
    {
        Console.WriteLine($"Codigo: {paymentType.Code} | Nombre: {paymentType.Name}");
    }

    //Recuperar Facturas
    Console.WriteLine("Facturas:");
    var billList = service.GetAllBills();
    foreach (var bill in billList)
    {
        Console.WriteLine($"Factura Nro: {bill.Code}, Fecha: {bill.Date}, Forma de Pago: {bill.PaymentType.Name}, Cliente: {bill.Client}");
        foreach (var detail in bill.DetailList)
            Console.WriteLine($"Detalle: {detail.Code}, Articulo: {detail.Article.Name}, Cantidad: {detail.Count}, Precio Unitario: ${detail.Article.UnitPrice}");
    }

    //Agregar Factura Nueva
    var oBill = new Bill
    {
        Date = DateTime.Now,
        Client = "Eren Yeager",
        PaymentType = paymentTypesList[1],
        DetailList = new List<BillDetail>
        {
            new BillDetail {Article = new Article {Code = 1 }, Count=2 },
            new BillDetail {Article = new Article {Code = 2 }, Count=3 }
        }
    };
    bool newBill = service.AddBill(oBill);
    Console.WriteLine("Nueva Factura: " + newBill);

}


//creo un unit of work, hago todo (get articles, get types, insertar maestro detalle) y
//al final meto un oUow.savechanges 
