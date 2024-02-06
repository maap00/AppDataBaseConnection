using AppDataBaseConnection.database;
using AppDataBaseConnection.modelo;
using FinalProject;
using System.DirectoryServices.ActiveDirectory;

namespace AppDataBaseConnection
{
    internal static class Program
    {
   
     
        static void Main(string[] args)
        {
            //ADOUser db = new ADOUser();
            try
            {

                //TESTING METHODS ADOUsers

                //ADOUser.GetUserForId(1);
                //ADOUser.GetAllUserList();
                //User newUser = new User("Marco", "Astudillo", "maap00", "maapDev", "maapDevl@mail.com");
                //if (ADOUser.InsertUser(newUser))
                //{
                //    Console.WriteLine("Se agrego");
                //}
                //if (ADOUser.DeleteUser(1))
                //{
                //    Console.WriteLine("Se elimino");
                //}
                //User userUpdated = new User("PiKachu2", "Charmander1", "Bagre1", "papel1", "margara@mail1.com");
                //if (ADOUser.UpdateUser(3, userUpdated))
                //{
                //    MessageBox.Show("Updated");
                //}

                //TESTING METHODS ADOUproducts

                //ADOproduct.GetProductforId(1);
                //ADOproduct.getProductList();
                //Product newProduct = new Product("Creatina", 1500, 1800, 55, 2);
                //if (ADOproduct.InsertProduct(newProduct))
                //{
                //    Console.WriteLine("Se agrego");

                //}
                //if (ADOproduct.DeleteProduct(7))
                //{
                //    Console.WriteLine("Se elimino");
                //}
                ////Product productUpdated = new Product("Remera1", 1500, 1100, 24, 2);
                ////if (ADOproduct.UpdateProduct(1, productUpdated))
                ////{
                ////    MessageBox.Show("Updated");
                ////}

                //TESTING METHODS ADOSoldProd

                //ADOSoldProd.GetSoldProduct(1);
                //ADOSoldProd.getProductSoldList();
                //SoldProduct newSoldProduct = new SoldProduct(5,15,16,17);
                //if (ADOSoldProd.InsertSoldProduct(newSoldProduct))
                //{
                //    MessageBox.Show("Se agrego");
                //}
                //if (ADOSoldProd.DeleteSoldProduct(4))
                //{
                //    MessageBox.Show("Se elimino");
                //}
                //SoldProduct soldProductUpdate = new SoldProduct(2,2,2);
                //if(ADOSoldProd.UpdateSoldProduct(3,soldProductUpdate))
                //{
                //    MessageBox.Show("Actualizado");
                //}


                //TESTING METHODS ADOSoldProd

                //ADOSales.GetSalesforId(1);
                //ADOSales.getSalesList();
                //Sales newSales = new Sales("Nueva Venta", 3);
                //if (ADOSales.InsertSale(newSales))
                //{
                //    MessageBox.Show("Venta agregada");
                //}
                //if (ADOSales.DeleteSale(6))
                //{
                //    MessageBox.Show("Venta eliminada");
                //}

                Sales sales = new Sales("ultimoComentario", 2);

                if (ADOSales.UpdateSale(2,sales))
                {
                    MessageBox.Show("Regustro de venta actualizada");
                }




                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

       
        }
    }
}