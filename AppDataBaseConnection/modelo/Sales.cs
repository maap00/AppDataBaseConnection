using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseConnection.modelo
{
    public class Sales
    {
        private int _idSales;
        private string _comments;
        private int _idUsuario;

        public Sales()
        {
            this._idSales = 0;
            this._comments = string.Empty;
            this._idUsuario = 0;
        }

        public Sales( string comments, int idUsuario)
        {
            this._comments = comments;
            this._idUsuario = idUsuario;
        }

        public Sales(int idSales, string comments, int idUsuario)
            :this(comments,idUsuario)
        {
            this._idSales = idSales;
         
        }

        public int idSales { get { return this._idSales; } set { this._idSales = value; } }
        public string Comments { get { return this._comments; } set { this._comments = value; } }
        public int IdUsuario { get { return this._idUsuario; } set { this._idUsuario = value; } }
    }
}
