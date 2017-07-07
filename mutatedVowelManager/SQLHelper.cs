using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mutatedVowelManager
{
    class SQLHelper
    {
        //SingletonInstanceHandling
        private static SQLHelper _Instance;

        public static SQLHelper Instance
        {
            get
            {
                return _Instance;
            }
        }

        //Setzen der Instanz
        public static void SetInstance(SQLHelper Instance)
        {
            _Instance = Instance;
        }

        private string connectionString;

        //Konstruktor - Connectionstring wird gesetzt
        public SQLHelper(string Connectionstring)
        {
            connectionString = Connectionstring;
        }

        //Funktion die eine SqlConnection zurückgibt
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);

        }

     

        //Funktion für SelectCommands mit Parameter
        public virtual DataTable SelectTable(string Command, params SqlParameter[] CmdParameter)
        {
            DataTable Result = new DataTable();
            SqlCommand Cmd = new SqlCommand(Command, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(Cmd);

            if (CmdParameter != null)
                Cmd.Parameters.AddRange(CmdParameter);

            da.Fill(Result);

            return Result;

        }

        //Funktion für SelectCommands mit Abfrage von stringarrays
        public virtual DataTable SelectTableFromArrayParameter(string Command, List<string> lStringParameter)
        {
            DataTable Result = new DataTable();
            SqlCommand Cmd = new SqlCommand();
            string[] parameters = new string[lStringParameter.Count];
            SqlDataAdapter da = new SqlDataAdapter(Cmd);

            for (int i = 0; i < lStringParameter.Count; i++)
            {

                parameters[i] = string.Format("@Possibilities{0}", i);
                Cmd.Parameters.AddWithValue(parameters[i], lStringParameter[i]);
                
            }
            Cmd.CommandText = string.Format(Command, string.Join(", ", parameters));
            Cmd.Connection = GetConnection();
            da.Fill(Result);

            return Result;

        }

        //Überladung von SelectTable für Aufrufe ohne Parameter
        public virtual DataTable SelectTable(string Command)
        {
            return SelectTable(Command, null);
        }

        //Funktion um SqlCommands ohne Rückgabe von Datensätzen auszuführen
        public virtual void ExecuteNonQuery(string Command, params SqlParameter[] CmdParameter)
        {
            SqlConnection Con = GetConnection();
            SqlCommand Cmd = new SqlCommand(Command, Con);

            if (CmdParameter != null)
                Cmd.Parameters.AddRange(CmdParameter);

            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
        }

        //Überladung von Funktion ExecuteNonQuery damit man die Funktion ohne Parameter aufrufen kann.
        public virtual void ExecuteNonQuery(string Command)
        {
            ExecuteNonQuery(Command, null);
        }
    }
}

