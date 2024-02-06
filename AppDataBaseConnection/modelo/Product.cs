using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseConnection.modelo
{
    public class Product
    {
        private int _idProduct;
        private string _decriptionProduct;
        private double _priceProduct;
        private double _priceSale;
        private double _stock;
        private int _idUser;

        public Product(){}

        public Product(string decriptionProduct, double priceProduct, double priceSale, double stock, int idUser)
        {
           
            this._decriptionProduct = decriptionProduct;
            this._priceProduct = priceProduct;
            this._priceSale = priceSale;
            this._stock = stock;
            this._idUser = idUser;  
        }
        public Product(int idProduct, string decriptionProduct, double priceProduct, double priceSale, double stock, int idUser)
            :this(decriptionProduct, priceProduct, priceSale,stock, idUser)
        {
           
            this._idProduct = idProduct;
        }

        public int idProduct { get => _idProduct; set => _idProduct = value; }
        public string decriptionProduct { get => _decriptionProduct; set => _decriptionProduct = value; }
        public double priceProduct { get => _priceProduct; set => _priceProduct = value; }
        public double priceSale { get => _priceSale; set => _priceSale = value; }
        public double stock { get => _stock; set => _stock = value; }
        public int idUser { get => _idUser; set => _idUser = value; }
    }
}
