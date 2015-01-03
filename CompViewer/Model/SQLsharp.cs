using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class permettant la connexion à une base de données MySQL
/// </summary>
/// <typeparam name="T"></typeparam>
class SQLsharp<T>
{
    /// <summary>
    /// Singleton 
    /// </summary>
    private static SQLsharp<T> instance = null;

    private SQLsharp() { }

    /// <summary>
    /// Singleton Instance
    /// </summary>
    public static SQLsharp<T> Instance
    {
        get 
        {
            if (instance == null)
                instance = new SQLsharp<T>();

            return instance;
        }
    }

    MySqlConnection connection;

    /// <summary>
    /// Fonction qui permet d'ouvrire une connexion à une base de données local!
    /// </summary>
    /// <param name="server"></param>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <param name="dbName"></param>
    /// <returns> retourne true en cas de succés </returns>
    public bool connectToDB(string server, string userId, string password, string dbName)
    {
        try
        {
            string connStr = "server=" + server + ";uid=" + userId + ";pwd=" + password + ";database=" + dbName;
            connection = new MySqlConnection(connStr);
            connection.Open();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Execute une requete avec des parametres prédifinies par des valeurs @ dans dict
    /// </summary>
    /// <param name="request"></param>
    /// <param name="dict"></param>
    /// <returns></returns>
    public bool requestExec(string request, Dictionary<string, T> dict)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(request, connection);
            foreach (KeyValuePair<string, T> dTvaluePair in dict)
                cmd.Parameters.AddWithValue(dTvaluePair.Key, dTvaluePair.Value);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }
        
    /// <summary>
    /// Execute une requete avec des parametres prédifinies par des valeurs @ dans dict et vérifie
    /// si l'élement passé existe ou non : sert à l'identifiaction 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="dict"></param>
    /// <returns></returns>
    public bool ExecDataReader(string request, Dictionary<string, T> dict)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(request, connection);
            foreach (KeyValuePair<string, T> dTvaluePair in dict)
                cmd.Parameters.AddWithValue(dTvaluePair.Key, dTvaluePair.Value);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            bool check = false;
            if (dataReader.HasRows)
            {
                Console.WriteLine("row found");
                check = true;
            }
            else
            {
                Console.WriteLine("No rows found.");
                check = false;
            }
            dataReader.Close();
            return check;
        }
        catch
        {
            return false;
        }
    }


    /// <summary>
    /// Fonction qui permet de charger et executer une requete SQL 
    /// </summary>
    /// <param name="request"></param>
    /// <returns>  retourne true en cas de succés </returns>
    public bool requestExec(string request, byte[] pic, DateTime date)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(request, connection);
            cmd.Parameters.AddWithValue("@Pic", pic);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// lancement d'une requete encapsulé de plusieurs byte[] ou DateTime
    /// </summary>
    /// <param name="request"></param>
    /// <param name="dataTables"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool requestExec(string request, Dictionary<string, byte[]> dataTables, Dictionary<string, DateTime> data)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(request, connection);

            foreach (KeyValuePair<string, byte[]> dTvaluePair in dataTables)
                cmd.Parameters.AddWithValue(dTvaluePair.Key, dTvaluePair.Value);

            foreach (KeyValuePair<string, DateTime> dvaluePair in data)
                cmd.Parameters.AddWithValue(dvaluePair.Key, dvaluePair.Value);

            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Fonction qui permet de charger et executer un requete SQL
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public bool requestExec(string request)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(request, connection);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Fermeture de la connexion SQL
    /// </summary>
    public void closeConnection()
    {
        connection.Close();
    }
}

