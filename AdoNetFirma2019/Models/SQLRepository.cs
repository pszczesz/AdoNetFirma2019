using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetFirma2019.Models {
    public class SQLRepository :IRepository{
        private string _connString;

        public SQLRepository(string connString) {
            _connString = connString;
        }
        public List<Worker> GetWorkers(){
            List<Worker> workers = new List<Worker>();
            SqlDataReader rd;
            using (var conn = new SqlConnection(_connString)) {
                string sql = "SELECT * FROM Pracownicy";
                SqlCommand command =new SqlCommand(sql,conn);
                conn.Open();
                rd = command.ExecuteReader();
                if (rd.HasRows) {
                    while (rd.Read()) {
                                        workers.Add(new Worker() {
                                            Id = rd.GetInt32(0),
                                            Imie = rd.GetString(1),
                                            Nazwisko = rd.GetString(2),
                                            Pensja = rd.GetDecimal(3),
                                            Stanowisko = new Stanowisko() 
                                        });
                }
                
                }
            }
            rd.Close();
            return workers;
        }
        public Worker GetWorker(int id) {
            throw new System.NotImplementedException();
        }

        public void InsertWorker(Worker worker) {
            using (var conn = new SqlConnection(_connString))
            {
                string sql =
                    "INSERT INTO Pracownicy(Imie,Nazwisko,Pensja) values(@Imie,@Nazwisko,@Pensja)";

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add("@Imie", SqlDbType.NVarChar);
                command.Parameters["@Imie"].Value = worker.Imie;
                command.Parameters.Add("@Nazwisko", SqlDbType.NVarChar);
                command.Parameters["@Nazwisko"].Value = worker.Nazwisko;
                command.Parameters.AddWithValue("@Pensja", worker.Pensja);
                conn.Open();
                command.ExecuteNonQuery();
            }
            
        }
    }
}