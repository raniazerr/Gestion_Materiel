using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using LyonPalme;


namespace LyonPalme
{
    /// <summary>
    /// Auteur : N.Lefebvre
    /// Date de création : 18/01/24
    /// Date de modification : 
    /// Gère la connexion à la base de données, par un singleton.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Instance SqlConnection : persiste la connexion au serveur.
        /// </summary>
        private static SqlConnection sqlConnection = null;

        /// <summary>
        /// Singleton : instance unique de la classe Connexion.
        /// </summary>
        private static Connection instance;

        /// <summary>
        /// Constructeur privé, pour créer le singleton.
        /// </summary>
        private Connection() { }

        /// <summary>
        /// Connexion à SQL Server.
        /// </summary>
        /// <returns>Un SqlConnection non null si connexion réussie.</returns>
        public SqlConnection GetConnection()
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["sqlserver_lyonpalme"].ConnectionString;
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

            }
            catch (SqlException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("Connection : erreur de connexion au serveur", w);
                }
            }
            return sqlConnection;
        }

        /// <summary>
        /// Crée le singleton s'il n'existe pas.
        /// </summary>
        /// <returns>L'instance de Connection</returns>
        public static Connection getInstance()
        {
            if (Connection.instance == null)
                Connection.instance = new Connection();
            return Connection.instance;
        }
    }
}
