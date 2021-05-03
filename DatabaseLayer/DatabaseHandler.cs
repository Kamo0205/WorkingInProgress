using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class DatabaseHandler
    {
        private SqlConnection conn;
        public DatabaseHandler(string name)
        {
            this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings[name].ConnectionString);
        }

        public int execute(string query)
        {
            int result = 0;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    Console.WriteLine("Successful connection");
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return result;
        }

        public string[] Read(string query)
        {
            List<string> output = new List<string>();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dreader = cmd.ExecuteReader();

                    while (dreader.Read())
                    {
                        string tmp = null;
                        for (int i = 0; i < dreader.FieldCount; i++)
                        {
                            if (i < dreader.FieldCount - 1)
                                tmp += dreader.GetValue(i) + ",";
                            else
                                tmp += dreader.GetValue(i);
                        }
                        output.Add(tmp);
                    }
                    Console.Write(output);
                    dreader.Close();
                    cmd.Dispose();
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return output.ToArray();
        }
    }
}
