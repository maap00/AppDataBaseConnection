using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class SoldProduct
    {
        private int _id;
        private int _stock;
        private int _idProduct;
        private int _idSale;
        public SoldProduct()
        {
            this._id = 0;
            this._idProduct = 0;
            this._stock = 0;
            this._idSale = 0;
        }

        public SoldProduct( int stock, int idProduct, int idSale)
        {
            this._stock = stock;
            this._idProduct = idProduct;
            this._idSale = idSale;
        }
        public SoldProduct(int Id, int stock, int idProduct, int idSale)
            :this( stock,  idProduct,  idSale)
        {
            this._id = Id;
         
        }

        public void showDates()
        {
            Console.WriteLine(this._id.ToString());
            Console.WriteLine(this._stock.ToString());
            Console.WriteLine(this._idProduct.ToString());
            Console.WriteLine(this._idSale.ToString());

        }

        public int Id { get { return this._id; } set { this._id = value; } }

        public int stock { get { return this._stock; } set { this._stock = value; } }
        public int idProduct { get { return this._idProduct; } set { this._idProduct = value; } }

        public int idSale { get { return this._idSale; } set { this._idSale = value; } }

    }
}