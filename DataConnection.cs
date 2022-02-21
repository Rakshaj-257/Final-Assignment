using DataComponent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionData
{
    public class DataConnection
    {
        static string constr = @"Data Source=rilpt143;Initial Catalog=Shopping;User ID=sa;Password=sa123";
        public void AddNewCloth(Boutique boutique)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "insert into boutique values(@id,@Ctype,@Cbrand,Csize,CPrize)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", boutique.CId);
                cmd.Parameters.AddWithValue("@Ctype", boutique.CType);
                cmd.Parameters.AddWithValue("@Cbrand", boutique.CBrand);
                cmd.Parameters.AddWithValue("@Csize", boutique.CSize);
                cmd.Parameters.AddWithValue("@CPrize", boutique.CPrice);
                try
                {
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        throw new Exception("No deatails were Added");
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }
        public List<Boutique> GetCloths()
        {
            var list = new List<Boutique>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCmd = con.CreateCommand();
                    sqlCmd.CommandText = "SELECT * FROM boutique";
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var cloth = new Boutique();
                        cloth.CId = Convert.ToInt32(reader[0]);
                        cloth.CType = reader[1].ToString();
                        cloth.CBrand = reader[2].ToString();
                        cloth.CSize = reader[3].ToString();
                        cloth.CPrice = Convert.ToInt32(reader[4]);
                        list.Add(cloth);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }
        public void UpdateCloth(Boutique boutique)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                var query = $"UPDATE boutique set CType = '{ boutique.CType }', CBrand = '{boutique.CBrand}', CSize = '{boutique.CSize}',CPrice='{boutique.CPrice}' where CId = '{boutique.CId}'";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Details were updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        
        public void DeleteCloth(int id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM boutique WHERE CId = " + id;
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                        throw new Exception("Cannot Remove Cloth Item");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
