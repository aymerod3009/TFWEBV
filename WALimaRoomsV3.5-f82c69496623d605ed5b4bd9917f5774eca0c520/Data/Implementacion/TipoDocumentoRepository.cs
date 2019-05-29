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
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        public bool delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete TipoDocumento where TipoDocumentoId='" + id + "'", con);

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

        public List<TipoDocumento> FindAll()
        {
            var tipoDocumentos = new List<TipoDocumento>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from TipoDocumento", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tipodocumento = new TipoDocumento();

                            tipodocumento.TipoDocumentoId = Convert.ToInt32(dr["TipoDocumentoId"]);
                            tipodocumento.NombreTipoDocumento = dr["NombreTipoDcumento"].ToString();

                            tipoDocumentos.Add(tipodocumento);
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return tipoDocumentos;
        }

        public TipoDocumento FindbyID(int? id)
        {
            TipoDocumento tipoDocumento = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from TipoDocumento where TipoDocumentoId='" + id + "'", con);

                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tipoDocumento = new TipoDocumento();
                            tipoDocumento.TipoDocumentoId = Convert.ToInt32(dr["TipoDocumentoId"]);
                            tipoDocumento.NombreTipoDocumento = dr["NombreTipoDcumento"].ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return tipoDocumento;
        }

        public bool insert(TipoDocumento t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into TipoDocumento values (@NombreTipoDocumento)", con);

                    query.Parameters.AddWithValue("@NombreTipoDocumento", t.NombreTipoDocumento);

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

        public bool update(TipoDocumento t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update TipoDocumento set NombreTipoDocumento=@NombreTipoDocumento" +
                                    "where TipoDocumentoId=@TipoDocumentoId", con);

                    query.Parameters.AddWithValue("@TipoDocumentoId", t.TipoDocumentoId);
                    query.Parameters.AddWithValue("@NombreTipoDocumento", t.NombreTipoDocumento);

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
    }
}
