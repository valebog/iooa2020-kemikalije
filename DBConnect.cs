using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPEK2.DB
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "ucka.veleri.hr";
            database = "vbognolo";
            uid = "vbognolo";
            password = "11";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private string OpenConnection()
        {
            try
            {
                connection.Open();
                return "";
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        return "Cannot connect to server.  Contact administrator";

                    case 1045:
                        return "Invalid username/password, please try again";
                }
                return "Error";
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close(); 
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        //Insert statement
        public void Insert( string Sql)
        {
            if (this.OpenConnection() == "")
            {
                MySqlCommand mySql = new MySqlCommand(Sql, connection);

                mySql.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string sql)
        {
            if (this.OpenConnection() == "")
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string sql)
        {
            if (this.OpenConnection() == "")
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public MySqlDataReader Select(string sql)
        {
            if(this.OpenConnection() == "")
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader data = cmd.ExecuteReader();
                return data;
            }


            return null;
        }

    }
}