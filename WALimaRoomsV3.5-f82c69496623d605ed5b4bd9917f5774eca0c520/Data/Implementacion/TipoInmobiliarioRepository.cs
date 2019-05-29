using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Implementacion
{
    public class TipoInmobiliarioRepository : ITipoInmobiliarioRepository
    {
        public bool delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete from TipoInmobiliario where TipoInmobiliarioId ='" + id + "'", con);

                    query.ExecuteNonQuery();

                    rpta = true;
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return rpta;
        }

        public List<TipoInmobiliario> FindAll()
        {
            var tipoInmobiliarios = new List<TipoInmobiliario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from TipoInmobiliario", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tipoInmobiliario = new TipoInmobiliario();

                            tipoInmobiliario.TipoInmobiliarioId = Convert.ToInt32(dr["TipoInmobiliarioId"]);
                            tipoInmobiliario.NombreTipoInmobiliario = dr["NombreTipoInmobiliario"].ToString();

                            tipoInmobiliarios.Add(tipoInmobiliario);
                        }
                    }
                    con.Close();
                }                
            }
            catch(Exception ex)
            {
                
            }
            return tipoInmobiliarios;
        }

        public TipoInmobiliario FindbyID(int? id)
        {
            TipoInmobiliario tipoInmobiliario = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from TipoInmobiliario where TipoInmobiliarioId='" + id + "'", con);

                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tipoInmobiliario = new TipoInmobiliario();
                            tipoInmobiliario.TipoInmobiliarioId = Convert.ToInt32(dr["TipoInmobiliarioId"]);
                            tipoInmobiliario.NombreTipoInmobiliario = dr["NombreTipoInmobiliario"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                
            }
            return tipoInmobiliario;
        }

        public bool insert(TipoInmobiliario t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into TipoInmobiliario values (@NombreTipoInmobiliario)", con);

                    query.Parameters.AddWithValue("@NombreTipoInmobiliario", t.NombreTipoInmobiliario);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rpta;
        }

        public bool update(TipoInmobiliario t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update TipoInmobilario set NombreTipoInmobiliario = @NombreTipoInmobiliario" +
                                                " where TipoInmobiliarioId = @TipoInmobiliarioId", con);

                    query.Parameters.AddWithValue("@TipoInmobiliarioId", t.TipoInmobiliarioId);
                    query.Parameters.AddWithValue("@NombreTipoInmobiliario", t.NombreTipoInmobiliario);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch(Exception ex)
            {
                
            }
            return rpta;
        }
    }
}
