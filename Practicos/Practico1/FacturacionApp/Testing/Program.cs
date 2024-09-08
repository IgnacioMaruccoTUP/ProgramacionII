using FacturacionApp.Domain;
using FacturacionApp.Services;

BillManager billManager = new BillManager();

bool aux = true;
int userChoice;
bool idExists;

while (aux)
{
    do
    {
        Console.WriteLine("Elegir opción: \n1->Mostrar todas las Facturas \n2->Mostrar una factura específica \n3->Registrar transacción \n4->Salir");
        if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice >= 1 && userChoice <= 4)
        {
            Console.Clear();
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("\n");
                    Console.WriteLine("Facturas:");
                    var billList = billManager.GetAllBills();
                    foreach (var bill in billList)
                    {
                        Console.WriteLine(bill.ToString());
                    }
                    break;

                case 2:
                    idExists = false;
                    while (!idExists)
                    {
                        Console.WriteLine("Ingrese el número de factura: ");
                        try
                        {
                            int billCode = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (billManager.GetBillById(billCode) != null)
                                Console.WriteLine(billManager.GetBillById(billCode).ToString());
                            else
                                Console.WriteLine("No hay ninguna factura con ese número!");
                            idExists = true;
                        }
                        catch
                        {
                            Console.WriteLine("Ingrese un número de factura válido!");
                            idExists = false;
                        }
                    }
                    break;

                case 3:
                    Bill oNewBill = new Bill();
                    List<BillDetail> detailList = new List<BillDetail>();

                    //Bill Date
                    oNewBill.Date = DateTime.Now;

                    //Bill Client
                    Console.WriteLine("Ingresar cliente:");
                    oNewBill.Client = Console.ReadLine();
                    Console.Clear();

                    //Bill PaymentType
                    var paymentTypeList = billManager.GetAllPaymentTypes();
                    Console.WriteLine("Ingresar forma de pago (código):");
                    for (int i = 0; i < paymentTypeList.Count; i++)
                    {
                        Console.WriteLine((i + 1) + "->" + paymentTypeList[i].ToString());
                    }
                    int paymentTypeCode;
                    bool isValidPaymentType = false;
                    while (!isValidPaymentType)
                    {
                        if (int.TryParse(Console.ReadLine(), out paymentTypeCode) && paymentTypeCode > 0 && paymentTypeCode <= paymentTypeList.Count)
                        {
                            oNewBill.PaymentType = paymentTypeList[paymentTypeCode - 1];
                            isValidPaymentType = true;
                        }
                        else
                        {
                            Console.WriteLine("Forma de pago no válida. Intente nuevamente.");
                        }
                    }
                    Console.Clear();

                    //Bill Articles
                    bool repeat = true;
                    var articleList = billManager.GetAllArticles();
                    do
                    {
                        int articleCode;
                        bool isValidArticle = false;

                        Console.WriteLine("Ingresar artículo (código):");
                        for (int j = 0; j < articleList.Count; j++)
                        {
                            Console.WriteLine((j + 1) + "->" + articleList[j].ToString());
                        }

                        while (!isValidArticle)
                        {
                            if (int.TryParse(Console.ReadLine(), out articleCode) && articleCode > 0 && articleCode <= articleList.Count)
                            {
                                BillDetail oDetail = new BillDetail();
                                oDetail.Article = articleList[articleCode - 1];
                                Console.WriteLine("Ingresar cantidad:");
                                oDetail.Count = Convert.ToInt32(Console.ReadLine());

                                //Evitar detalles repetidos
                                bool isRepeated = false;
                                foreach (BillDetail detail in detailList)
                                {
                                    if (detail.Article.Code == articleCode)
                                    {
                                        detail.Count += oDetail.Count;
                                        isRepeated = true;
                                    }
                                }

                                if (!isRepeated)
                                {
                                    detailList.Add(oDetail);
                                }

                                isValidArticle = true;
                            }
                            else
                            {
                                Console.WriteLine("Artículo no válido. Intente nuevamente.");
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("Desea ingresar más artículos? \n1->Si\n2->No");
                        string end = Console.ReadLine();
                        Console.Clear();
                        if (end != "1")
                        {
                            oNewBill.DetailList = detailList;
                            repeat = false;
                        }

                    } while (repeat);

                    Console.WriteLine(oNewBill);
                    var savedBill = billManager.SaveBill(oNewBill);
                    break;

                case 4:
                    aux = false;
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Selecciona una opción válida!");
        }
    } while (aux);
}
