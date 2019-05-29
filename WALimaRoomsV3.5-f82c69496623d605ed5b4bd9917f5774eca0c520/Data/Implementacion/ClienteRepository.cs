using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacion
{
    public class ClienteRepository : IClienteRepository
    {
        public bool delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete Cliente where ClienteId = '" + id + "'", con);

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

        public List<Cliente> FindAll()
        {
            var clientes = new List<Cliente>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.ClienteId, c.NroDocumento, c.NombreCliente, c.apellPaterno, c.apellMaterno, c.Nacionalidad," +
                                    " c.Phone, c.email, t.TipoDocumentoId, t.NombreTipoDcumento from Cliente c, " +
                                    "TipoDocumento t where c.TipoDocumento_id = t.TipoDocumentoId", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new Cliente();
                            var tipoDocumento = new TipoDocumento();

                            tipoDocumento.TipoDocumentoId = Convert.ToInt32(dr["TipoDocumentoId"]);
                            tipoDocumento.NombreTipoDocumento = dr["NombreTipoDcumento"].ToString();

                            cliente.ClienteId = Convert.ToInt32(dr["ClienteId"]);
                            cliente.NombreCliente = dr["NombreCliente"].ToString();
                            cliente.apellPaterno = dr["apellPaterno"].ToString();
                            cliente.apellMaterno = dr["apellMaterno"].ToString();
                            cliente.Nacionalidad = dr["Nacionalidad"].ToString();
                            cliente.Telefono = dr["Phone"].ToString();
                            cliente.Correo = dr["email"].ToString();
                            cliente.NroDocumento = dr["NroDocumento"].ToString();

                            cliente.tipoDocumento = tipoDocumento;

                            clientes.Add(cliente);
                        }
                    }
                    
                }
            }
            catch(Exception )
            {
                throw;
            }
            return clientes;
        }

        public Cliente FindbyID(int? id)
        {
            Cliente cliente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.ClienteId, c.NombreCliente, c.apellPaterno, c.apellMaterno, c.Nacionalidad, c.Phone, c.email, c.NroDocumento, " +
                                    "t.TipoDocumentoId, t.NombreTipoDcumento  from Cliente c, TipoDocumento t where c.TipoDocumento_id=t.TipoDocumentoId and ClienteId='" + id+"'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente();
                            var tipoDocumento = new TipoDocumento();

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

                            return cliente;
                        }
                    }                    
                }
            }
            catch(Exception )
            {
                throw;
            }
            return null;
        }

        public bool insert(Cliente t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into Cliente values (@NombreCliente, @apellPaterno," +
                                    "@apellMaterno, @Nacionalidad, @Phone, @email, @TipoDocumento_id, @NroDocumento)", con);

                    query.Parameters.AddWithValue("@NombreCliente", t.NombreCliente);
                    query.Parameters.AddWithValue("@apellPaterno", t.apellPaterno);
                    query.Parameters.AddWithValue("@apellMaterno", t.apellMaterno);
                    query.Parameters.AddWithValue("@Nacionalidad", t.Nacionalidad);
                    query.Parameters.AddWithValue("Phone", t.Telefono);
                    query.Parameters.AddWithValue("@email", t.Correo);
                    query.Parameters.AddWithValue("@TipoDocumento_id", t.tipoDocumento.TipoDocumentoId);
                    query.Parameters.AddWithValue("@NroDocumento", t.NroDocumento);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch(Exception )
            {
                throw;
            }
            return rpta;
        }

        public bool update(Cliente t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Cliente set NombreCliente=@NombreCliente, " +
                                    "apellPaterno=@apellPaterno, apellMaterno=@apellMaterno, Nacionalidad=@Nacionalidad," +
                                    " Phone=@Phone, Telefono=@email, TipoDocumento_id=@TipoDocumento_id," +
                                    " NroDocumento=@NroDocumento where ClienteId=@ClienteId", con);

                    query.Parameters.AddWithValue("ClienteId", t.ClienteId);
                    query.Parameters.AddWithValue("@NombreCliente", t.NombreCliente);
                    query.Parameters.AddWithValue("@apellPaterno", t.apellPaterno);
                    query.Parameters.AddWithValue("@apellMaterno", t.apellMaterno);
                    query.Parameters.AddWithValue("@Nacionalidad", t.Nacionalidad);
                    query.Parameters.AddWithValue("Phone", t.Telefono);
                    query.Parameters.AddWithValue("@email", t.Correo);
                    query.Parameters.AddWithValue("@TipoDocumento_id", t.tipoDocumento.TipoDocumentoId);
                    query.Parameters.AddWithValue("@NroDocumento", t.NroDocumento);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }
    }
}
