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
    public class PagoRepository : IPagoRepository
    {
        public bool delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete Pago where PagoId='" + id + "'", con);

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

        public List<Pago> FindAll()
        {
            var pagos = new List<Pago>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select p.PagoId, p.NroTransaccion, p.FechaTransaccion," +
                                                "c.ContratoId, c.FechaPago " +
                                                "from Pago p, Contrato c where p.Contrato_id=c.ContratoId", con);                    
                        using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var pago = new Pago();
                            var contrato = new Contrato();

                            pago.PagoId = Convert.ToInt32(dr["PagoId"]);
                            pago.NroTransaccion = dr["NroTransaccion"].ToString();
                            pago.FechaTransaccion = Convert.ToDateTime(dr["FechaTransaccion"]);

                            contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                            contrato.FechaPago = Convert.ToInt32(dr["FechaPago"]);

                            pago.Contrato = contrato;

                            pagos.Add(pago);
                        }
                    }                    
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return pagos;
        }

        public Pago FindbyID(int? id)
        {
            Pago pago;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select p.PagoId, p.NroTransaccion, p.FechaTransaccion," +
                                                "c.ContatoId, c.FechaPago" +
                                                "from Pago p, Contrato c where p.Contrato_id=c.ContratoId and PagoId='"+id+"'", con);

                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var contrato = new Contrato();
                            pago = new Pago();

                            pago.PagoId = Convert.ToInt32(dr["PagoId"]);
                            pago.NroTransaccion = dr["NroTransaccion"].ToString();
                            pago.FechaTransaccion = Convert.ToDateTime(dr["FechaTransaccion"]);

                            contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                            contrato.FechaPago = Convert.ToInt32(dr["FechaPago"]);

                            pago.Contrato = contrato;

                            return pago;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return null;
        }

        public bool insert(Pago t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into Pago values(@NroTransaccion, @FechaTransaccion, @Contrato_id)", con);

                    query.Parameters.AddWithValue("@NroTransaccion", t.NroTransaccion);
                    query.Parameters.AddWithValue("@FechaTransaccion", t.FechaTransaccion);
                    query.Parameters.AddWithValue("@Contrato_id", t.Contrato.ContratoId);

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

        public bool update(Pago t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Pago set NroTransaccion=@NroTransaccion, FechaTransaccion=@FechaTransaccion," +
                                    "Contrato_id=@Contrato_id where PagoId=@PagoId", con);

                    query.Parameters.AddWithValue("@PagoId", t.PagoId);
                    query.Parameters.AddWithValue("@NroTransaccion", t.NroTransaccion);
                    query.Parameters.AddWithValue("@FechaTransaccion", t.FechaTransaccion);
                    query.Parameters.AddWithValue("@Contrato_id", t.Contrato.ContratoId);

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
