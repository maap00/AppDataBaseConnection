using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseConnection.modelo
{
          public class User
        {
            private int _id;
            private string _name;
            private string _lastName;
            private string _userName;
            private string _password;
            private string _email;

            public User() {
       
             }

            public User( string name, string lastName, string userName, string password, string email)
            {            
                _name = name;
                _lastName = lastName;
                _userName = userName;
                _password = password;
                _email = email;
            }

            public User(int id, string name, string lastName, string userName, string password, string email)
            : this(name, lastName, userName, password, email) 
            { 
               this._id = id;
            }

            public void showDates()
            {
                Console.WriteLine(_id.ToString());
                Console.WriteLine(_name.ToString());
                Console.WriteLine(_lastName.ToString());
                Console.WriteLine(_userName.ToString());
                Console.WriteLine(_password.ToString());
                Console.WriteLine(_email.ToString());

            }

            public int id
            {
                get
                {
                    return _id;

                }
                set
                {
                    _id = value;
                }
            }


            public string name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            public string lastName
            {
                get
                {
                    return _lastName;
                }
                set
                {
                    _lastName = value;
                }
            }

            public string userName
            {
                get
                {
                    return _userName;

                }
                set
                {
                    _userName = value;
                }
            }

            public string password
            {
                get
                {
                    return _password;

                }
                set
                {
                    _password = value;
                }
            }
            public string email
            {
                get
                {
                    return _email;

                }
                set
                {
                    _email = value;
                }
            }
        }
    }
