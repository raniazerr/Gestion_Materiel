using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyonPalme.Modele;
using System.ComponentModel;
using System.IO;
using LyonPalme.Models;
namespace LyonPalme
{
    /// <summary>
    /// Gère l'interface entre la base de données et la couche présentation.
    /// </summary>
    public class DBInterface
    {

        public static List<MaterielModele> GetAllMaterielStock()
        {
            List<MaterielModele> stocks = new List<MaterielModele>();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spMaterielStock", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            MaterielModele materielModel = new MaterielModele();
                            materielModel.idMateriel = sqlDataReader.GetInt32(0);
                            materielModel.Marque = sqlDataReader.GetString(1);
                            materielModel.Libelle = sqlDataReader.GetString(2);
                            materielModel.Etat = sqlDataReader.GetString(3);
                            
                            stocks.Add(materielModel);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return stocks;
        }

        public static List<MaterielModele> GetAllMaterielPret()
        {
            List<MaterielModele> stocks = new List<MaterielModele>();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spMaterielPret", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            MaterielModele materielModel = new MaterielModele();
                            materielModel.idMateriel = sqlDataReader.GetInt32(0);
                            materielModel.Marque = sqlDataReader.GetString(1);
                            materielModel.Libelle = sqlDataReader.GetString(2);
                            stocks.Add(materielModel);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return stocks;
        }
        public static void AddMateriel(string marque, string libelle, string etat ,string taille, int? pointure)
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spAddMaterielStock", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@marque", marque);
                    sqlCommand.Parameters.AddWithValue("@libellé", libelle);
                    sqlCommand.Parameters.AddWithValue("@état", etat);

                    if (taille != null)
                    {
                        sqlCommand.Parameters.AddWithValue("@taille", taille);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@taille", DBNull.Value);
                    }

                    if (pointure.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@pointure", pointure.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@pointure", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
        }



        public static void RecupMateriel(int id)
        {
            List<MaterielModele> stocks = new List<MaterielModele>();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spRecupMateriel", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@codePret", id));
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
        } 

        public static void AddPretMateriel(int idNageur, int idMateriel, DateTime datedebut, DateTime datefin  )
        {
            SqlConnection connection = null;

            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spAddPretMateriel", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idNageur", idNageur);
                    sqlCommand.Parameters.AddWithValue("@idMateriel", idMateriel);
                    sqlCommand.Parameters.AddWithValue("@dateDebutPret", datedebut);
                    sqlCommand.Parameters.AddWithValue("@dateFinPret", datefin);

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
        }

        public static List<int> GetAllNageurByMateriel(int materialId)
        {
            List<int> nageurIds = new List<int>();

            try
            {
                using (SqlConnection connection = Connection.getInstance().GetConnection())
                using (SqlCommand sqlCommand = new SqlCommand("GM_spGetAllNageurByMateriel", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@idMateriel", materialId));

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            int idNageur = sqlDataReader.GetInt32(0);
                            nageurIds.Add(idNageur);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog($"DBInterface : erreur - {ex.Message}\nStackTrace: {ex.StackTrace}", w);
                }
            }

            return nageurIds;
        }

        public static List<PretModele> GetAllPrets()
        {
            List<PretModele> stocks = new List<PretModele>();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spGetAllPrets", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            PretModele pretModele = new PretModele();
                            pretModele.codePret = sqlDataReader.GetInt32(0);
                            pretModele.idNageur = sqlDataReader.GetInt32(1);
                            pretModele.idMateriel = sqlDataReader.GetInt32(2);
                            pretModele.dateDebutPret = sqlDataReader.GetDateTime(3);
                            pretModele.dateFinPret = sqlDataReader.GetDateTime(4);
                            stocks.Add(pretModele);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return stocks;
        }


        public static List<NageurModel> GetAllNageur()
        {
            List<NageurModel> stocks = new List<NageurModel>();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spGetAllNageur", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            NageurModel nageurModele = new NageurModel();
                            nageurModele.Id = sqlDataReader.GetInt32(0);
                            nageurModele.Nom = sqlDataReader.GetString(1);
                            nageurModele.Prenom = sqlDataReader.GetString(2);
                            nageurModele.Age = sqlDataReader.GetString(3);
                            nageurModele.Tel = sqlDataReader.GetString(4);
                            nageurModele.Mail = sqlDataReader.GetString(5);
                            stocks.Add(nageurModele);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return stocks;
        }

        public static List<MonopalmeModele> GetAllMonopalme()
        {
            List<MonopalmeModele> stocks = new List<MonopalmeModele>();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spGetAllMono", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            MonopalmeModele monopalmeModele = new MonopalmeModele();
                            monopalmeModele.idMateriel = sqlDataReader.GetInt32(0);
                            monopalmeModele.pointure = sqlDataReader.GetInt32(1);
                            stocks.Add(monopalmeModele);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return stocks;
        }

        public static List<CombinaisonModele> GetAllCombinaison()
        {
            List<CombinaisonModele> stocks = new List<CombinaisonModele>();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("GM_spGetAllCombi", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            CombinaisonModele combinaisonModele = new CombinaisonModele();
                            combinaisonModele.idMateriel = sqlDataReader.GetInt32(0);
                            combinaisonModele.taille = sqlDataReader.GetString(1);
                            stocks.Add(combinaisonModele);

                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection?.Close();
            }
            return stocks;
        }
    }
}