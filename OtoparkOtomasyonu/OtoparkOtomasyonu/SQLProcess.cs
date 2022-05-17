using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtoparkOtomasyonu
{
    
    
    internal class SQLProcess
    {
        private String sqlAddress = "Data Source=DESKTOP-NLRIGP6;Initial Catalog=otoparkVeritabani;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-NLRIGP6;Initial Catalog=otoparkVeritabani;Integrated Security=True");

        /// <summary>
        /// Insert, Update, Delete işlemlerinde kullanılmalı
        /// </summary>
        public void executeQuery(String query)
        {
            
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            
            catch(Exception ex)
            {
                sqlConnection.Close();
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Veri tabanı işlemlerinde bir hata meydana geldi");
            }
            
        }
        /// <summary>
        /// Select işlemlerinde veriyi alırken kullanılmalı
        /// Geriye Liste içinde liste döner. İlk liste rowları ikinci liste rowların fieldlarını içerir
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Object>? selectQuery(String query)
        {

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                List<Object> rows = new List<object>();
                while (reader.Read())
                {
                    List<Object> rowValues = new List<object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowValues.Add(reader.GetValue(i));
                    }
                    rows.Add(rowValues);
                }
                reader.Close();
                sqlConnection.Close();
                return rows;
            }
            else
            {
                Console.WriteLine("No rows found.");
                reader.Close();
                return null;
            }
           
        }
        
    }
}
