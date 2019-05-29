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
    public class InmobiliarioRepository : IInmobiliarioRepository
    {
        public bool delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete Inmobiliario where InmobiliarioId='" + id + "'", con);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return rpta;
        }

        public List<Inmobiliario> FindAll()
        {
            var inmobiliarios = new List<Inmobiliario>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.TipoInmobiliarioId, c.NombreTipoInmobiliario, m.InmobiliarioId," +
                                    "m.NombreInmobiliario, m.DireccionInmobiliario, m.Precio " +
                                    "from TipoInmobiliario c, Inmobiliario m " +
                                    "where m.TipoInmobiliario_id=c.TipoInmobiliarioId", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var inmobiliario = new Inmobiliario();
                            var tipoInmobilairio = new TipoInmobiliario();                          

                            inmobiliario.InmobiliarioId = Convert.ToInt32(dr["InmobiliarioId"]);
                            inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            inmobiliario.DireccionInmobiliario = dr["DireccionInmobiliario"].ToString();
                            tipoInmobilairio.TipoInmobiliarioId = Convert.ToInt32(dr["TipoInmobiliarioId"]);
                            tipoInmobilairio.NombreTipoInmobiliario = dr["NombreTipoInmobiliario"].ToString();
                            inmobiliario.tipoInmobiliario = tipoInmobilairio;
                            inmobiliario.Precio = Convert.ToInt32(dr["Precio"]);

                            inmobiliarios.Add(inmobiliario);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return inmobiliarios;
        }

        public Inmobiliario FindbyID(int? id)
        {
            Inmobiliario inmobiliario = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.TipoInmobiliarioId, c.NombreTipoInmobiliario, m.InmobiliarioId," +
                                    "m.NombreInmobiliario, m.DireccionInmobiliario, m.Precio " +
                                    "from Inmobiliario m, TipoInmobiliario c " +
                                    "where c.TipoInmobiliarioId = m.TipoInmobiliario_id and InmobiliarioId = '"+id+"'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            inmobiliario = new Inmobiliario();
                            var tipoInmobilirio = new TipoInmobiliario();

                            inmobiliario.InmobiliarioId = Convert.ToInt32(dr["InmobiliarioId"]);
                            inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            inmobiliario.DireccionInmobiliario = dr["DireccionInmobiliario"].ToString();
                            inmobiliario.Precio = Convert.ToInt32(dr["Precio"]);
                            inmobiliario.tipoInmobiliario = tipoInmobilirio;

                            tipoInmobilirio.TipoInmobiliarioId = Convert.ToInt32(dr["TipoInmobiliarioId"]);
                            tipoInmobilirio.NombreTipoInmobiliario = dr["NombreTipoInmobiliario"].ToString();                            

                            return inmobiliario;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            return null;
        }

        public bool insert(Inmobiliario t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("insert into Inmobiliario values (@NombreInmobiliario, " +
                                    "@DireccionInmobiliario,  @TipoInmobiliario_id, @Precio)", con);

                    query.Parameters.AddWithValue("@NombreInmobiliario", t.NombreInmobiliario);
                    query.Parameters.AddWithValue("@DireccionInmobiliario", t.DireccionInmobiliario);
                    query.Parameters.AddWithValue("@TipoInmobiliario_id", t.tipoInmobiliario.TipoInmobiliarioId);
                    query.Parameters.AddWithValue("@Precio", t.Precio);                   

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch(Exception ex)
            {
                
            }
            return rpta;
        }

        public bool update(Inmobiliario t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["veterinaria"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Inmobiliario set NombreInmobiliario=@NombreInmobiliario, " +
                                    "DireccionInmobiliario=@DireccionInmobiliario, Precio=@Precio, " +
                                    "TipoInmobiliario_id=@TipoInmobiliario_id where InmobiliarioId=@InmobiliarioId", con);

                    query.Parameters.AddWithValue("@InmobiliarioId", t.InmobiliarioId);
                    query.Parameters.AddWithValue("@NombreInmobiliario", t.NombreInmobiliario);
                    query.Parameters.AddWithValue("@DireccionInmobiliario", t.DireccionInmobiliario);
                    query.Parameters.AddWithValue("@Precio", t.Precio);
                    query.Parameters.AddWithValue("@TipoInmobiliario_id", t.tipoInmobiliario.TipoInmobiliarioId);

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
