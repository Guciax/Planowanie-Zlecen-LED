using System.Collections.Generic;
using System.Data.SqlClient;

namespace Planowanie_Zlecen_LED
{
    public class SqlOperations
    {
        private static string SafeGetString(SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return "";
        }

        public static Dictionary<string, string> Nc12ToOracleSpec()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Connection.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=ConnectToMSTDB;User Id=mes;Password=mes;";
                    cmd.CommandText = @"SELECT NC12,Colective FROM ConnectToMSTDB.dbo.v_Item";
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string nc12 = SafeGetString(rdr, "NC12");

                            string collective = SafeGetString(rdr, "Colective");

                            if (result.ContainsKey(nc12))
                            {
                                if (result[nc12] == "")
                                {
                                    result[nc12] = collective;
                                }
                                continue;
                            }
                            result.Add(nc12, collective);
                        }
                    }
                }
            }
            return result;
        }
    }
}