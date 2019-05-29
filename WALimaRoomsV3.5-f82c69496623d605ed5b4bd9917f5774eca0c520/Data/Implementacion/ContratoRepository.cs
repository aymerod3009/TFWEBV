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
    public class ContratoRepository : IContratoRepository
    {
        public bool delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete Contrato where ContratoId='" + id + "'", con);

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

        public List<Contrato> FindAll()
        {
            var contratos = new List<Contrato>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.ContratoId, c.fechaInicio, c.fechaFin, c.FechaPago," +
                        "p.ClienteId, p.NombreCliente, p.apellPaterno, p.apellMaterno, p.Nacionalidad, p.Phone, p.email, p.TipoDocumento_id, p.NroDocumento, " +
                        "t.TipoDocumentoId, t.NombreTipoDcumento," +
                        "i.InmobiliarioId, i.NombreInmobiliario, i.DireccionInmobiliario, i.Precio, i.TipoInmobiliario_id," +
                        "ti.TipoInmobiliarioId, ti.NombreTipoInmobiliario " +
                        "from Contrato c, Cliente p, TipoDocumento t, Inmobiliario i, TipoInmobiliario ti " +
                        "where c.Cliente_id=p.ClienteId and p.TipoDocumento_id=t.TipoDocumentoId and c.Inmobiliario_id=i.InmobiliarioId and i.TipoInmobiliario_id=ti.TipoInmobiliarioId", con);


                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var contrato = new Contrato();
                            var cliente = new Cliente();
                            var tipoDocumento = new TipoDocumento();
                            var inmobiliario = new Inmobiliario();
                            var tipoInmobiliario = new TipoInmobiliario();

                            contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                            contrato.fechaInicio = Convert.ToDateTime(dr["fechaInicio"]);
                            contrato.fechaFin = Convert.ToDateTime(dr["fechaFin"]);
                            contrato.FechaPago = Convert.ToInt32(dr["FechaPago"]);

                            tipoDocumento.TipoDocumentoId = Convert.ToInt32(dr["TipoDocumentoId"]);
                            tipoDocumento.NombreTipoDocumento = dr["NombreTipoDcumento"].ToString();

                            cliente.ClienteId = Convert.ToInt32(dr["ClienteId"]);
                            cliente.NombreCliente = dr["NombreCliente"].ToString();
                            cliente.apellPaterno = dr["apellPaterno"].ToString();
                            cliente.apellMaterno = dr["apellMaterno"].ToString();
                            cliente.Nacionalidad = dr["Nacionalidad"].ToString();
                            cliente.Telefono = dr["Phone"].ToString();
                            cliente.NroDocumento = dr["NroDocumento"].ToString();

                            cliente.tipoDocumento = tipoDocumento;

                            tipoInmobiliario.TipoInmobiliarioId = Convert.ToInt32(dr["TipoInmobiliarioId"]);
                            tipoInmobiliario.NombreTipoInmobiliario = dr["NombreTipoInmobiliario"].ToString();

                            inmobiliario.InmobiliarioId = Convert.ToInt32(dr["InmobiliarioId"]);
                            inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            inmobiliario.DireccionInmobiliario = dr["DireccionInmobiliario"].ToString();
                            inmobiliario.Precio = Convert.ToInt32(dr["Precio"]);

                            inmobiliario.tipoInmobiliario = tipoInmobiliario;

                            contrato.cliente = cliente;
                            contrato.inmobiliario = inmobiliario;

                            contratos.Add(contrato);
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return contratos;
        }

        public Contrato FindbyID(int? id)
        {
            Contrato contrato = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.ContratoId, c.fechaInicio, c.fechaFin, c.FechaPago," +
                        "p.ClienteId, p.NombreCliente, p.apellPaterno, p.apellMaterno, p.Nacionalidad, p.Phone, p.email, p.TipoDocumento_id, p.NroDocumento, " +
                        "t.TipoDocumentoId, t.NombreTipoDcumento, " +
                        "i.InmobiliarioId, i.NombreInmobiliario, i.DireccionInmobiliario, i.Precio, i.TipoInmobiliario_id," +
                        "ti.TipoInmobiliarioId, ti.NombreTipoInmobiliario " +
                        "from Contrato c, Cliente p, TipoDocumento t, Inmobiliario i, TipoInmobiliario ti " +
                        "where c.Cliente_id=p.ClienteId and p.TipoDocumento_id=t.TipoDocumentoId and c.Inmobiliario_id=i.InmobiliarioId and " +
                        "i.TipoInmobiliario_id=ti.TipoInmobiliarioId and ContratoId='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contrato = new Contrato();
                            var cliente = new Cliente();
                            var tipoDocumento = new TipoDocumento();
                            var inmobiliario = new Inmobiliario();
                            var tipoInmobiliario = new TipoInmobiliario();

                            contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                            contrato.fechaInicio = Convert.ToDateTime(dr["fechaInicio"]);
                            contrato.fechaFin = Convert.ToDateTime(dr["fechaFin"]);
                            contrato.FechaPago = Convert.ToInt32(dr["FechaPago"]);

                            tipoDocumento.TipoDocumentoId = Convert.ToInt32(dr["TipoDocumentoId"]);
                            tipoDocumento.NombreTipoDocumento = dr["NombreTipoDcumento"].ToString();

                            cliente.ClienteId = Convert.ToInt32(dr["ClienteId"]);
                            cliente.NombreCliente = dr["NombreCliente"].ToString();
                            cliente.apellPaterno = dr["apellPaterno"].ToString();
                            cliente.apellMaterno = dr["apellMaterno"].ToString();
                            cliente.Nacionalidad = dr["Nacionalidad"].ToString();
                            cliente.Telefono = dr["Phone"].ToString();
                            cliente.NroDocumento = dr["NroDocumento"].ToString();

                            cliente.tipoDocumento = tipoDocumento;

                            tipoInmobiliario.TipoInmobiliarioId = Convert.ToInt32(dr["TipoInmobiliarioId"]);
                            tipoInmobiliario.NombreTipoInmobiliario = dr["NombreTipoInmobilario"].ToString();

                            inmobiliario.InmobiliarioId = Convert.ToInt32(dr["InmobiliarioId"]);
                            inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            inmobiliario.DireccionInmobiliario = dr["DireccionInmobiliario"].ToString();
                            inmobiliario.Precio = Convert.ToInt32(dr["Precio"]);

                            inmobiliario.tipoInmobiliario = tipoInmobiliario;

                            contrato.cliente = cliente;
                            contrato.inmobiliario = inmobiliario;

                            return contrato;
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

        public bool insert(Contrato t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into Contrato values (@fechaInicio, @fechaFin, @FechaPago, @Cliente_id, @Inmobiliario_id)", con);

                    query.Parameters.AddWithValue("@fechaInicio", t.fechaInicio);
                    query.Parameters.AddWithValue("@fechaFin", t.fechaFin);
                    query.Parameters.AddWithValue("@FechaPago", t.FechaPago);
                    query.Parameters.AddWithValue("@Cliente_id", t.cliente.ClienteId);
                    query.Parameters.AddWithValue("@Inmobiliario_id", t.inmobiliario.InmobiliarioId);

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

        public bool update(Contrato t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Contrato set fechaInicio=@fechaInicio, fechaFin=@fechaFin, FechaPago=@FechaPago," +
                                    "Cliente_id=@Cliente_id, Inmobiliario_id@Inmobiliario_id where ContratoId=@ContratoId", con);

                    query.Parameters.AddWithValue("@ContratId", t.ContratoId);
                    query.Parameters.AddWithValue("@fechaInicio", t.fechaInicio);
                    query.Parameters.AddWithValue("@fechaFin", t.fechaFin);
                    query.Parameters.AddWithValue("@FechaPago", t.FechaPago);
                    query.Parameters.AddWithValue("@Cliente_id", t.cliente.ClienteId);
                    query.Parameters.AddWithValue("@Inmobiliario_id", t.inmobiliario.InmobiliarioId);

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
