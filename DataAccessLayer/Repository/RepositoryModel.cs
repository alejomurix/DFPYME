using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using Npgsql;
using DTO;
//using DTO.Clases;
using DataAccessLayer.DataSets;
using DataAccessLayer.DataSets.DataBaseDSTableAdapters;
using DataAccessLayer.Models;
using DataAccessLayer.Generator;


namespace DataAccessLayer.Repository
{
    public class RepositoryModel
    {
        private bool RedondearPrecio2;

        private bool aprox_precio;


        private const int IdPaisColombia = 49;

        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa una sentencia adapter en posgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        private clienteTableAdapter adCliente;

        private empresaTableAdapter adCompany;

        private details_tributary_empresaTableAdapter adTributaryCp;

        private details_rut_empresaTableAdapter adRUTCp;

        private empresa_ciiuTableAdapter adCIIUCp;

        

        //private details_tributary_clientTableAdapter adTributary;

        //private details_rut_clientTableAdapter adRUT;


        private DaoInventario daoInventario;

        public RepositoryModel()
        {
            try
            {
                RedondearPrecio2 = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
                aprox_precio = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("tipo_aprox_precio"));

                this.miConexion = new Conexion();

                this.adCliente = new clienteTableAdapter();
                this.adCompany = new empresaTableAdapter();
                this.adTributaryCp = new details_tributary_empresaTableAdapter();
                this.adRUTCp = new details_rut_empresaTableAdapter();
                this.adCIIUCp = new empresa_ciiuTableAdapter();
                //this.adTributary = new details_tributary_clientTableAdapter();
                //this.adRUT = new details_rut_clientTableAdapter();

                this.daoInventario = new DaoInventario();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable Departamentos()
        {
            try
            {
                DataTable dtDeptos = new DataTable();
                string sql =
                    "select iddepartamento AS id, nombredepartamento || '-' || code AS nombre " + 
                    "from departamento where idpais = @id order by nombredepartamento;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", IdPaisColombia);
                miAdapter.Fill(dtDeptos);
                return dtDeptos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los departamentos.\n" + ex.Message);
            }
        }

        public DataTable Cities(string codeDepto)
        {
            try
            {
                DataTable dtCities = new DataTable();
                string sql =
                    "select code, code || ' - ' || nombre as nombre from municipio where code_depto = @codigo order by nombre;";
                    ///"select code, nombre from municipio where code_depto = @codigo order by nombre;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codeDepto);
                miAdapter.Fill(dtCities);
                return dtCities;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las ciudades.\n" + ex.Message);
            }
        }

        public DataTable CodePostales()
        {
            try
            {
                DataTable dtCodes = new DataTable();
                string sql =
                    "select c_postal, ciudad || ' - ' || departamento || ' - ' || c_postal  as nombre from code_postal order by departamento, ciudad;";
                    ///"select c_postal, ciudad || ' - ' || departamento as nombre from code_postal order by departamento, ciudad;";
                CargarAdapter(sql);
                miAdapter.Fill(dtCodes);
                return dtCodes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los codigos postales.\n" + ex.Message);
            }
        }



        /*
        public DataTable Cities(int idDepartamento)
        {
            try
            {
                DataTable dtCities = new DataTable();
                string sql =
                    "select iddepartamento AS id, nombredepartamento || '-' || code AS nombre " +
                    "from departamento where idpais = @id order by nombredepartamento;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", idDepartamento);
                miAdapter.Fill(dtCities);
                return dtCities;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los departamentos.\n" + ex.Message);
            }
        }
        */



        public City GetCityById(int id)
        {
            try
            {
                var city = new City();
                string sql =
                    "SELECT ciudad.idciudad, ciudad.nombreciudad, ciudad.code, ciudad.code_postal, departamento.iddepartamento, " +
                    "departamento.code, departamento.nombredepartamento FROM ciudad, departamento WHERE " +
                    "ciudad.iddepartamento = departamento.iddepartamento AND ciudad.idciudad = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    city.ID = reader.GetInt32(0);
                    city.Name = reader.GetString(1);
                    city.Code = reader.GetString(2);
                    city.CodePostal = reader.GetString(3);
                    city.Departament = new Departament
                    {
                        ID = reader.GetInt32(4),
                        Code = reader.GetString(5),
                        Name = reader.GetString(6)
                    };
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return city;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la ciudad del cliente." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public City GetCityByCustomer(string nit)
        {
            try
            {
                var city = new City();
                string sql = 
                    "SELECT ciudad.idciudad, ciudad.nombreciudad, ciudad.code, ciudad.code_postal, departamento.iddepartamento, " +
                    "departamento.code, departamento.nombredepartamento FROM cliente, ciudad, departamento WHERE cliente.idciudad = ciudad.idciudad AND " +
                    "ciudad.iddepartamento = departamento.iddepartamento AND cliente.nitcliente = @nit;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    city.ID = reader.GetInt32(0);
                    city.Name = reader.GetString(1);
                    city.Code = reader.GetString(2);
                    city.CodePostal = reader.GetString(3);
                    city.Departament = new Departament
                    {
                        ID = reader.GetInt32(4),
                        Code = reader.GetString(5),
                        Name = reader.GetString(6)
                    };
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return city;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la ciudad del cliente." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateCodePostal(City city)
        {
            try
            {
                string sql = "UPDATE ciudad SET code = @code, code_postal = @code_postal WHERE idciudad = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", city.ID);
                miComando.Parameters.AddWithValue("code", city.Code);
                miComando.Parameters.AddWithValue("code_postal", city.CodePostal);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el codigo postal.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public bool ExistsCustomer(string nit)
        {
            try
            {
                string sql = "SELECT nitcliente FROM cliente WHERE nitcliente = @nit;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                var result = miComando.ExecuteScalar();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                CargarComandoSP("insertar_cliente");
                miComando.Parameters.AddWithValue("", customer.NIT);
                miComando.Parameters.AddWithValue("", customer.Regimen);
                miComando.Parameters.AddWithValue("", customer.RazonSocial);
                miComando.Parameters.AddWithValue("", customer.Contact.Phone);
                miComando.Parameters.AddWithValue("", customer.Contact.Phone);
                miComando.Parameters.AddWithValue("", customer.Contact.Email);
                miComando.Parameters.AddWithValue("", customer.City.ID);
                miComando.Parameters.AddWithValue("", customer.Direccion);
                miComando.Parameters.AddWithValue("", true);
                miComando.Parameters.AddWithValue("", customer.TypeSales);
                miComando.Parameters.AddWithValue("", customer.ComercialClasification);
                miComando.Parameters.AddWithValue("", customer.DV);
                miComando.Parameters.AddWithValue("", customer.TypePerson);
                miComando.Parameters.AddWithValue("", customer.TypeIdentify);
                miComando.Parameters.AddWithValue("", true);
                miComando.Parameters.AddWithValue("", customer.Comercial);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (var tax in customer.IdentifyTaxes)
                {
                    AddDetailsTributary(customer.NIT, tax);
                }
                foreach (var tax in customer.ResponsabilitiesRUT)
                {
                    AddDetailsRUT(customer.NIT, tax);
                }
                if (GetCityById(customer.City.ID).CodePostal.Equals(""))
                {
                    UpdateCodePostal(customer.City);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el cliente.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AddDetailsTributary(string nit, IdentifyTax tax)
        {
            try
            {
                string sql =
                    "INSERT INTO details_tributary_client(nit_cliente, codigo, nombre, descripcion) " +
                    "VALUES (@nit_cliente, @codigo, @nombre, @descripcion);";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit_cliente", nit);
                miComando.Parameters.AddWithValue("codigo", tax.Code);
                miComando.Parameters.AddWithValue("nombre", tax.Name);
                miComando.Parameters.AddWithValue("descripcion", tax.Descripcion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar los detalles tributarios del cliente.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AddDetailsRUT(string nit, ResponsabilityFiscal fiscalRUT)
        {
            try
            {
                string sql =
                    "INSERT INTO details_rut_client(nit_cliente, codigo, descripcion) " +
                    "VALUES (@nit_cliente, @codigo, @descripcion);";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit_cliente", nit);
                miComando.Parameters.AddWithValue("codigo", fiscalRUT.Code);
                miComando.Parameters.AddWithValue("descripcion", fiscalRUT.Descripcion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar los detalles del RUT del cliente.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public void AddCustomer(CustomerModel customer)
        {
            try
            {
                var cRow = customer.Customer.AsEnumerable().FirstOrDefault();
                adCliente.Insert(
                    cRow.nitcliente,
                    cRow.idregimen,
                    cRow.nombrescliente,
                    cRow.telefonocliente,
                    cRow.celularcliente,
                    cRow.emailcliente,
                    cRow.idciudad,
                    cRow.direccioncliente,
                    cRow.estadocliente,
                    cRow.idtipo_cliente,
                    0,
                    cRow.id_clasificacion,
                    0,
                    cRow.name,
                    cRow.last_name,
                    cRow.dv,
                    cRow.type_person,
                    cRow.type_document,
                    cRow.name_comercial,
                    cRow.is_customer);
                foreach (var tax in customer.DetailsTributary)
                {
                    AddDetailsTributary(cRow.nitcliente, new IdentifyTax
                    {
                        Code = tax.codigo,
                        Name = tax.nombre,
                        Descripcion = tax.descripcion
                    });
                }
                foreach (var tax in customer.DetailsRUT)
                {
                    AddDetailsRUT(cRow.nitcliente, new ResponsabilityFiscal
                    {
                        Code = tax.codigo,
                        Descripcion = tax.descripcion
                    });
                }
                if (GetCityById(customer.City.ID).CodePostal.Equals(""))
                {
                    UpdateCodePostal(customer.City);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el cliente.\n" + ex.Message);
            }
        }



        public CustomerModel GetCustomerByNit(string nit)
        {
            try
            {
                CustomerModel c = new CustomerModel();

                string sql = "SELECT * FROM cliente WHERE nitcliente = @nit;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(c.Customer);

                c.Cliente = c.Customer.FirstOrDefault();

                c.City = GetCityByCustomer(nit);

                sql = "SELECT * FROM details_tributary_client WHERE nit_cliente = @nit;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(c.DetailsTributary);

                sql = "SELECT * FROM details_rut_client WHERE nit_cliente = @nit;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(c.DetailsRUT);

                return c;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cliente.\n" + ex.Message);
            }
        }

        public CustomerModel GetCustomerByNitDE(string nit)
        {
            try
            {
                CustomerModel c = new CustomerModel();

                //string sql = "SELECT * FROM cliente WHERE nitcliente = @nit;";
                string sql =
                    @"SELECT 
                          cliente.nitcliente, 
                          regimen.code as idregimen, 
                          cliente.nombrescliente, 
                          cliente.telefonocliente, 
                          cliente.celularcliente, 
                          cliente.emailcliente, 
                          cliente.idciudad, 
                          cliente.direccioncliente, 
                          cliente.estadocliente, 
                          cliente.idtipo_cliente, 
                          cliente.punto, 
                          cliente.id_clasificacion, 
                          cliente.id,
                          cliente.name,
                          cliente.last_name,
                          cliente.dv, 
                          cliente.type_person, 
                          cliente.type_document, 
                          cliente.name_comercial, 
                          cliente.is_customer
                        FROM 
                          cliente, 
                          regimen
                        WHERE 
                          regimen.idregimen = cliente.idregimen AND
                          cliente.nitcliente = @nit;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(c.Customer);

                c.Cliente = c.Customer.FirstOrDefault();

                c.City = GetCityByCustomer(nit);

                sql = "SELECT * FROM details_tributary_client WHERE nit_cliente = @nit;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(c.DetailsTributary);

                sql = "SELECT * FROM details_rut_client WHERE nit_cliente = @nit;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(c.DetailsRUT);

                return c;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cliente.\n" + ex.Message);
            }
        }

        public DataTable Customers()
        {
            try
            {
                var tCustomers = new DataTable();
                string sql =
                 @"SELECT 
                    cliente.nitcliente, 
                    cliente.nombrescliente, 
                    cliente.name_comercial, 
                    cliente.celularcliente, 
                    cliente.direccioncliente, 
                    ciudad.nombreciudad, 
                    cliente.emailcliente 
                 FROM cliente, ciudad 
                 WHERE ciudad.idciudad = cliente.idciudad AND 
                 cliente.is_customer = true ORDER BY cliente.nombrescliente ASC;";
                CargarAdapter(sql);
                miAdapter.Fill(tCustomers);
                return tCustomers;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los clientes.\n" + ex.Message);
            }
        }

        public DataTable CustomerByDocument(string document)
        {
            try
            {
                var tCustomers = new DataTable();
                string sql =
                 "SELECT cliente.nitcliente, cliente.nombrescliente, cliente.name_comercial, cliente.celularcliente, cliente.direccioncliente, ciudad.nombreciudad, " +
                 "cliente.emailcliente FROM cliente, ciudad WHERE ciudad.idciudad = cliente.idciudad AND cliente.is_customer = true AND " +
                 "cliente.nitcliente = @document " +
                 "ORDER BY cliente.nombrescliente ASC;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("document", document);
                miAdapter.Fill(tCustomers);
                return tCustomers;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los clientes.\n" + ex.Message);
            }
        }

        public DataTable CustomerByName(string name)
        {
            try
            {
                var tCustomers = new DataTable();
                string sql =
                 "SELECT cliente.nitcliente, cliente.nombrescliente, cliente.name_comercial, cliente.celularcliente, cliente.direccioncliente, ciudad.nombreciudad, " +
                 "cliente.emailcliente FROM cliente, ciudad WHERE ciudad.idciudad = cliente.idciudad AND cliente.is_customer = true AND " +
                 "(cliente.nombrescliente ILIKE '%" + name + "%' OR cliente.name_comercial ILIKE '%" + name + "%') " +
                 "ORDER BY cliente.nombrescliente ASC;";
                CargarAdapter(sql);
                //miAdapter.SelectCommand.Parameters.AddWithValue("name", name);
                miAdapter.Fill(tCustomers);
                return tCustomers;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los clientes.\n" + ex.Message);
            }
        }



        /**
        public DataBaseDS.clienteDataTable GetCustomerByNit(string nit)
        {
            try
            {
                var tcliente = new DataBaseDS.clienteDataTable();
                string sql = "SELECT * FROM cliente WHERE nitcliente = @nit;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tcliente);
                return tcliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cliente.\n" + ex.Message);
            }
        }
        */

        /*public void UpdateCustomer(DataBaseDS.clienteRow cRow, City city)
        {
            try
            {
                adCliente.Update(cRow);
                if (GetCityById(city.ID).CodePostal.Equals(""))
                {
                    UpdateCodePostal(city);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el cliente.\n" + ex.Message);
            }
        }*/

        public void UpdateCustomer(CustomerModel customer, DataBaseDS.clienteRow cRow)
        {
            try
            {
                //adCliente.Update(
                ///adCliente.Update(cRow);

                string sql = @"UPDATE cliente SET 
	                            idregimen = @idregimen, 
	                            nombrescliente = @nombrescliente, 
	                            telefonocliente = @telefonocliente, 
	                            celularcliente = @celularcliente, 
	                            emailcliente = @emailcliente, 
	                            idciudad = @idciudad, 
	                            direccioncliente = @direccioncliente, 
	                            idtipo_cliente = @idtipo_cliente, 
	                            id_clasificacion = @id_clasificacion, 
	                            name = @name, 
	                            last_name = @last_name, 
	                            dv = @dv, 
	                            type_person = @type_person, 
	                            type_document = @type_document, 
	                            name_comercial = @name_comercial 
                            WHERE nitcliente = @nitcliente;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("idregimen", cRow.idregimen);
                miComando.Parameters.AddWithValue("nombrescliente", cRow.nombrescliente);
                miComando.Parameters.AddWithValue("telefonocliente", cRow.celularcliente);
                miComando.Parameters.AddWithValue("celularcliente", cRow.celularcliente);
                miComando.Parameters.AddWithValue("emailcliente", cRow.emailcliente);
                miComando.Parameters.AddWithValue("idciudad", cRow.idciudad);
                miComando.Parameters.AddWithValue("direccioncliente", cRow.direccioncliente);
                miComando.Parameters.AddWithValue("idtipo_cliente", cRow.idtipo_cliente);
                miComando.Parameters.AddWithValue("id_clasificacion", cRow.id_clasificacion);
                miComando.Parameters.AddWithValue("name", cRow.name);
                miComando.Parameters.AddWithValue("last_name", cRow.last_name);
                miComando.Parameters.AddWithValue("dv", cRow.dv);
                miComando.Parameters.AddWithValue("type_person", cRow.type_person);
                miComando.Parameters.AddWithValue("type_document", cRow.type_document);
                miComando.Parameters.AddWithValue("name_comercial", cRow.name_comercial);
                miComando.Parameters.AddWithValue("nitcliente", cRow.nitcliente);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                DeleteDetailsTributary(cRow.nitcliente);
                DeleteDetailsRUT(cRow.nitcliente);

                foreach (var tax in customer.DetailsTributary)
                {
                    AddDetailsTributary(cRow.nitcliente, new IdentifyTax
                    {
                        Code = tax.codigo,
                        Name = tax.nombre,
                        Descripcion = tax.descripcion
                    });
                }
                foreach (var tax in customer.DetailsRUT)
                {
                    AddDetailsRUT(cRow.nitcliente, new ResponsabilityFiscal
                    {
                        Code = tax.codigo,
                        Descripcion = tax.descripcion
                    });
                }

                UpdateDocumentCustomer(cRow.nitcliente, customer.Document);
                UpdateCodePostal(customer.City);

                /*if (GetCityById(customer.City.ID).CodePostal.Equals(""))
                {
                    UpdateCodePostal(customer.City);
                }*/

                /*
                adCliente.Update(cRow);
                */
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el cliente.\n" + ex.Message);
            }
        }

        private void UpdateDocumentCustomer(string document, string documentEdit)
        {
            try
            {
                string sql =
                    "update cliente set nitcliente = @nitedit where nitcliente = @nit;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit", document);
                miComando.Parameters.AddWithValue("nitedit", documentEdit);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el documento del cliente.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteDetailsTributary(string nit)
        {
            try
            {
                string sql = 
                    "DELETE FROM details_tributary_client WHERE nit_cliente = @nit;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los detalles tributarios.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteDetailsRUT(string nit)
        {
            try
            {
                string sql =
                    "DELETE FROM details_rut_client WHERE nit_cliente = @nit;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los detalles tributarios.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        //public DataBaseDS.empresaDataTable Company()
        public CompanyModel Company()
        {
            try
            {
                CompanyModel c = new CompanyModel();

                DataBaseDS.empresaDataTable tCompany = new DataBaseDS.empresaDataTable();
                string sql = "SELECT * FROM empresa WHERE estadoempresa = TRUE;";
                CargarAdapter(sql);
                miAdapter.Fill(tCompany);
                c.Company = tCompany.FirstOrDefault();

                c.City = GetCityById(c.Company.idciudad);

                sql = "SELECT * FROM details_tributary_empresa;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsTributary);

                sql = "SELECT * FROM details_rut_empresa;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsRUT);

                sql = "select * from empresa_ciiu;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsCIIU);

                return c;
                //return tCompany;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los datos de la empresa.\n" + ex.Message);
            }
        }

        public CompanyModel CompanyDE()
        {
            try
            {
                CompanyModel c = new CompanyModel();

                DataBaseDS.empresaDataTable tCompany = new DataBaseDS.empresaDataTable();
                //string sql = "SELECT * FROM empresa WHERE estadoempresa = TRUE;";
                string sql =
                    @"SELECT 
                          empresa.nitempresa, 
                          regimen.code as idregimen, 
                          empresa.nombrecomercialempresa, 
                          empresa.nombrejuridicoempresa, 
                          empresa.telefonoempresa, 
                          empresa.celularempresa, 
                          empresa.faxempresa, 
                          empresa.emailempresa, 
                          empresa.pagwebempresa, 
                          empresa.representantelegalempresa, 
                          empresa.iddepartamento, 
                          empresa.idciudad, 
                          empresa.direccionempresa, 
                          empresa.estadoempresa, 
                          empresa.descripcion, 
                          empresa.recauda_iva, 
                          empresa.dv, 
                          empresa.type_person, 
                          empresa.type_document
                        FROM 
                          empresa, 
                          regimen
                        WHERE 
                          regimen.idregimen = empresa.idregimen AND
                          empresa.estadoempresa = true;";
                CargarAdapter(sql);
                miAdapter.Fill(tCompany);
                c.Company = tCompany.FirstOrDefault();

                c.City = GetCityById(c.Company.idciudad);

                sql = "SELECT * FROM details_tributary_empresa;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsTributary);

                sql = "SELECT * FROM details_rut_empresa;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsRUT);

                sql = "select * from empresa_ciiu;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsCIIU);

                return c;
                //return tCompany;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los datos de la empresa.\n" + ex.Message);
            }
        }

        public CompanyModel CompanyDE(bool productive)
        {
            try
            {
                CompanyModel c = new CompanyModel();

                DataBaseDS.empresaDataTable tCompany = new DataBaseDS.empresaDataTable();
                //string sql = "SELECT * FROM empresa WHERE estadoempresa = TRUE;";
                string sql =
                    @"SELECT 
                          empresa.nitempresa, 
                          regimen.code as idregimen, 
                          empresa.nombrecomercialempresa, 
                          empresa.nombrejuridicoempresa, 
                          empresa.telefonoempresa, 
                          empresa.celularempresa, 
                          empresa.faxempresa, 
                          empresa.emailempresa, 
                          empresa.pagwebempresa, 
                          empresa.representantelegalempresa, 
                          empresa.iddepartamento, 
                          empresa.idciudad, 
                          empresa.direccionempresa, 
                          empresa.estadoempresa, 
                          regimen.nombreregimen as descripcion, 
                          empresa.recauda_iva, 
                          empresa.dv, 
                          empresa.type_person, 
                          empresa.type_document
                        FROM 
                          empresa, 
                          regimen
                        WHERE 
                          regimen.idregimen = empresa.idregimen AND
                          empresa.estadoempresa = @product;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("product", productive);
                miAdapter.Fill(tCompany);
                c.Company = tCompany.FirstOrDefault();

                c.City = GetCityById(c.Company.idciudad);

                sql = "SELECT * FROM details_tributary_empresa;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsTributary);

                sql = "SELECT * FROM details_rut_empresa;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsRUT);

                sql = "select * from empresa_ciiu;";
                CargarAdapter(sql);
                miAdapter.Fill(c.DetailsCIIU);

                return c;
                //return tCompany;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los datos de la empresa.\n" + ex.Message);
            }
        }

        public Boolean ExisteCIIU(string ciiu)
        {
            try
            {
                string sql = "select codigo from ciiu where codigo = @codigo;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("codigo", ciiu);
                miConexion.MiConexion.Open();
                var result = miComando.ExecuteScalar();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al validar el CIIU." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateCompany(DataBaseDS.empresaRow company)
        {
            try
            {
                adCompany.Update(company);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos de la empresa.\n" + ex.Message);
            }
        }

        public void UpdateCompany(CompanyModel company)
        {
            try
            {
                ///adCompany.Update(company.Company);
                
                string sql = "UPDATE empresa SET nitempresa = @nit, idregimen = @idregimen, nombrecomercialempresa = @nombrecomercialempresa, " +
                             "nombrejuridicoempresa = @nombrejuridicoempresa, telefonoempresa = @telefonoempresa, celularempresa = @celularempresa, " + 
                             "emailempresa = @emailempresa, iddepartamento = @iddepartamento, idciudad = @idciudad, direccionempresa = @direccionempresa, " +
                             "dv = @dv, type_person = @type_person, type_document = @type_document WHERE nitempresa = @nitempresa;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("nit", company.NoIdentify);
                miComando.Parameters.AddWithValue("idregimen", company.Company.idregimen);
                miComando.Parameters.AddWithValue("nombrecomercialempresa", company.Company.nombrecomercialempresa);
                miComando.Parameters.AddWithValue("nombrejuridicoempresa", company.Company.nombrejuridicoempresa);
                miComando.Parameters.AddWithValue("telefonoempresa", company.Company.celularempresa);
                miComando.Parameters.AddWithValue("celularempresa", company.Company.celularempresa);
                miComando.Parameters.AddWithValue("emailempresa", company.Company.emailempresa);
                miComando.Parameters.AddWithValue("iddepartamento", company.Company.iddepartamento);
                miComando.Parameters.AddWithValue("idciudad", company.Company.idciudad);
                miComando.Parameters.AddWithValue("direccionempresa", company.Company.direccionempresa);
                miComando.Parameters.AddWithValue("dv", company.Company.dv);
                miComando.Parameters.AddWithValue("type_person", company.Company.type_person);
                miComando.Parameters.AddWithValue("type_document", company.Company.type_document);
                miComando.Parameters.AddWithValue("nitempresa", company.Company.nitempresa);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                UpdateCodePostal(company.City);

                DeleteTributaryCompany();
                foreach (DataBaseDS.details_tributary_empresaRow row in company.DetailsTributary.Rows)
                {
                    adTributaryCp.Insert(row.id, row.codigo, row.nombre, row.descripcion);
                }

                DeleteRUTCompany();
                foreach (DataBaseDS.details_rut_empresaRow rutRow in company.DetailsRUT.Rows)
                {
                    AddDetailsRUTCompany(rutRow);
                }

                DeleteCIIUCompany();
                foreach (DataBaseDS.empresa_ciiuRow ciiuRow in company.DetailsCIIU.Rows)
                {
                    adCIIUCp.Insert(ciiuRow.id, ciiuRow.codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos de la empresa.\n" + ex.Message);
            }
        }

        public void DeleteTributaryCompany()
        {
            try
            {
                string sql = "DELETE FROM details_tributary_empresa;";
                CargarComando(sql);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos tributarios de la empresa.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteRUTCompany()
        {
            try
            {
                string sql = "DELETE FROM details_rut_empresa;";
                CargarComando(sql);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos tributarios/RUT de la empresa.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteCIIUCompany()
        {
            try
            {
                string sql = "DELETE FROM empresa_ciiu;";
                CargarComando(sql);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos CIIU de la empresa.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public void AddDetailsRUTCompany(DataBaseDS.details_rut_empresaRow rutRow)
        {
            try
            {
                string sql =
                    "INSERT INTO details_rut_empresa(codigo, descripcion) " +
                    "VALUES (@codigo, @descripcion);";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("codigo", rutRow.codigo);
                miComando.Parameters.AddWithValue("descripcion", rutRow.descripcion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar los detalles del RUT de la empresa.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CIIUList()
        {
            try
            {
                var tCIIU = new DataTable();
                string sql = "SELECT * FROM ciiu ORDER BY codigo ASC;";
                CargarAdapter(sql);
                miAdapter.Fill(tCIIU);
                return tCIIU;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el listado de códigos CIIU.\n" + ex.Message);
            }
        }


        /// Section item
        private double IvaExc = 0.0000001;

        public Item GetItem(string code)
        {
            try
            {
                Item item = new Item();
                //
                CargarComandoSP("items");
                miComando.Parameters.AddWithValue("", code);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    item.Code = reader.GetString(0);
                    item.Description = reader.GetString(8);
                    item.UnitMedida = reader.GetString(9);
                    item.TypeStandar = new TypeStandar
                    {
                        CodeItem = reader.GetString(11), //0
                        CodeStandard = reader.GetString(12) //999
                    };
                    item.Costo = reader.GetDouble(13);
                    item.IVA = reader.GetDouble(14);
                    item.IC = reader.GetDouble(15);
                    item.INC = reader.GetDouble(17);
                    item.Neto = Convert.ToDouble(reader.GetInt32(18));
                    item.Price2 = reader.GetDouble(19);
                    item.Price3 = reader.GetDouble(20);
                    item.Price4 = reader.GetDouble(21);
                    if (RedondearPrecio2)
                    {
                        item.Price2 = Utilities.UseObject.Aproximar(Convert.ToInt32(item.Price2), aprox_precio);
                        item.Price3 = Utilities.UseObject.Aproximar(Convert.ToInt32(item.Price3), aprox_precio);
                        item.Price4 = Utilities.UseObject.Aproximar(Convert.ToInt32(item.Price4), aprox_precio);
                    }
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (item.IVA.Equals(this.IvaExc))
                {
                    item.IVA = 0;
                }
                /**item.Neto = item.UnitPrice;
                item.UnitPrice -= item.IC;
                item.UnitPrice = Math.Round(item.UnitPrice / (1 + (item.IVA / 100)), 2);*/
                //item.Taxes = Taxes(item);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar el item\n." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private List<Tax> Taxes(Item item)
        {
            try
            {
                //var items = new List<Item>();
                var taxes = new List<Tax>();
                if (item.IVA > 0)
                {
                    taxes.Add(new Tax
                    {
                        State = false,
                        ID = "01",
                        Base = Math.Round(item.UnitPrice * item.Quantity, 2),
                        Tarifa = item.IVA,
                        Value = Math.Round(Math.Round(item.UnitPrice * item.Quantity, 2) * item.IVA / 100, 2)
                    });
                }
                if (item.IC > 0)
                {
                    taxes.Add(new Tax
                    {
                        State = false,
                        ID = "02",
                        Nominal = true,
                        Base = item.IC,
                        Quantity = item.Quantity,
                        UnitMedida = item.UnitMedida,
                        Value = Math.Round(item.IC * item.Quantity, 2)
                    });
                }
                return taxes;



               // Item item = new Item();
                //
                /*CargarComando("items");
                miComando.Parameters.AddWithValue("", code);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    item.Code = reader.GetString(0);
                    item.Description = reader.GetString(8);
                    item.UnitMedida = reader.GetString(9);
                    item.TypeStandar = new TypeStandar
                    {
                        CodeItem = reader.GetString(11),
                        CodeStandard = reader.GetString(12)
                    };
                    item.Costo = reader.GetDouble(13);
                    item.IVA = reader.GetDouble(14);
                    item.IC = reader.GetDouble(15);
                    item.INC = reader.GetDouble(17);
                    item.UnitPrice = Convert.ToDecimal(reader.GetInt32(18));
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();*/
                //return item;
            }
            catch (Exception ex)
            {
                throw new Exception("\n." + ex.Message);
            }
        }


        public List<DTO.Clases.Producto> Productos(string[] filtros)
        {
            try
            {
                string sql =
                    @"SELECT 
                          codigointernoproducto, 
                          codigobarrasproducto, 
                          nombre, 
                          referenciaproducto, 
                          descripcionproducto, 
                          nombremarca, 
                          nombrecategoria, 
                          valorventaproducto, 
                          descto_mayor, 

                          mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_mayor / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS mayorista,  

                          cantidad_inventario, 
                          precio_costo, 
                          mi_round(precio_costo + (precio_costo * valoriva / 100), 0) AS costo_iva,
                          valoriva, 
                          utilidadporcentualproducto, 
                          estadoproducto , 

                            mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_distribuidor / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS precio3,  
	 
                          mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_3 / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS precio4 
                         FROM  
                           view_producto_completo_  
                         WHERE 
                         estadoproducto = true AND ";

                string strFiltro_Code = "(",
                       strFiltroName = "(";
                foreach (var f in filtros)
                {
                    strFiltro_Code += "codigobarrasproducto || ' ' || descripcionproducto ILIKE '%" + f + "%' ";
                    strFiltroName += "nombre ILIKE '%" + f + "%' ";
                    //strFiltroRef += "view_producto_completo.referenciaproducto ILIKE '%" + f + "%' ";
                    if (!(f.Equals(filtros.Last())))
                    {
                        strFiltro_Code += " AND ";
                        strFiltroName += " AND ";
                        //strFiltroRef += " OR ";
                    }
                }
                strFiltro_Code += ")";
                strFiltroName += ")";
                //strFiltroRef += ")";
                sql += strFiltro_Code + " OR " + strFiltroName +
                       " ORDER BY nombre ASC;";
                var productos = new List<DTO.Clases.Producto>();
                DTO.Clases.Producto p;
                CargarComando(sql);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    p = new DTO.Clases.Producto();
                    p.CodigoInternoProducto = reader.GetString(0);
                    p.CodigoBarrasProducto = reader.GetString(1);
                    p.NombreProducto = reader.GetString(2);
                    p.ReferenciaProducto = reader.GetString(3);
                    p.DescripcionProducto = reader.GetString(4);
                    p.NombreMarca = reader.GetString(5);
                    p.NombreCategoria = reader.GetString(6);
                    p.ValorVentaProducto = reader.GetInt32(7);
                    p.Utilidad2 = reader.GetDouble(8);
                    p.DescuentoMayor = reader.GetDouble(9);
                    p.Price3 = reader.GetDouble(16);
                    p.Price4 = reader.GetDouble(17);
                    if (RedondearPrecio2)
                    {
                        p.DescuentoMayor = Utilities.UseObject.Aproximar(Convert.ToInt32(p.DescuentoMayor), aprox_precio);
                        p.Price3 = Utilities.UseObject.Aproximar(Convert.ToInt32(p.Price3), aprox_precio);
                        p.Price4 = Utilities.UseObject.Aproximar(Convert.ToInt32(p.Price4), aprox_precio);
                    }
                    p.Cantidad = reader.GetDouble(10);
                    p.ValorCosto = Convert.ToDouble(reader.GetDecimal(12)); // Costo + iva
                    p.ValorIva = reader.GetDouble(13);
                    p.UtilidadPorcentualProducto = reader.GetDouble(14);
                    p.EstadoProducto = reader.GetBoolean(15);

                    productos.Add(p);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al consultar los productos\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<DTO.Clases.Producto> Productos(string code)
        {
            try
            {
                string sql =
                    @"SELECT 
                          codigointernoproducto, 
                          codigobarrasproducto, 
                          nombre, 
                          referenciaproducto, 
                          descripcionproducto, 
                          nombremarca, 
                          nombrecategoria, 
                          valorventaproducto, 
                          descto_mayor, 

                          mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_mayor / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS mayorista,  

                          cantidad_inventario, 
                          precio_costo, 
                          mi_round(precio_costo + (precio_costo * valoriva / 100), 0) AS costo_iva,
                          valoriva, 
                          utilidadporcentualproducto, 
                          estadoproducto , 

                            mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_distribuidor / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS precio3,  

                          mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_3 / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS precio4 
                         FROM  
                           view_producto_completo_  
                         WHERE 
                           codigointernoproducto = @codigo OR 
                           codigobarrasproducto = @codigo OR 
                           codigo_2 = @codigo OR 
                           codigo_3 = @codigo OR 
                           codigo_4 = @codigo OR 
                           codigo_5 = @codigo OR 
                           codigo_6 = @codigo OR 
                           codigo_7 = @codigo OR 
                           descto_3 = @codigo;";
                var productos = new List<DTO.Clases.Producto>();
                DTO.Clases.Producto p;
                CargarComando(sql);
                miComando.Parameters.AddWithValue("codigo", code);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    p = new DTO.Clases.Producto();
                    p.CodigoInternoProducto = reader.GetString(0);
                    p.CodigoBarrasProducto = reader.GetString(1);
                    p.NombreProducto = reader.GetString(2);
                    p.ReferenciaProducto = reader.GetString(3);
                    p.DescripcionProducto = reader.GetString(4);
                    p.NombreMarca = reader.GetString(5);
                    p.NombreCategoria = reader.GetString(6);
                    p.ValorVentaProducto = reader.GetInt32(7);
                    p.Utilidad2 = reader.GetDouble(8);
                    p.DescuentoMayor = reader.GetDouble(9);
                    p.Price3 = reader.GetDouble(16);
                    p.Price4 = reader.GetDouble(17);
                    if (RedondearPrecio2)
                    {
                        p.DescuentoMayor = Utilities.UseObject.Aproximar(Convert.ToInt32(p.DescuentoMayor), aprox_precio);
                        p.Price3 = Utilities.UseObject.Aproximar(Convert.ToInt32(p.Price3), aprox_precio);
                        p.Price4 = Utilities.UseObject.Aproximar(Convert.ToInt32(p.Price4), aprox_precio);
                    }
                    p.Cantidad = reader.GetDouble(10);
                    p.ValorCosto = Convert.ToDouble(reader.GetDecimal(12)); // Costo + iva
                    p.ValorIva = reader.GetDouble(13);
                    p.UtilidadPorcentualProducto = reader.GetDouble(14);
                    p.EstadoProducto = reader.GetBoolean(15);

                    productos.Add(p);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al consultar los productos\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




/*
        public DataBaseDS.item_documento_electronicoRow GetItem_(string code)
        {
            try
            {
                string sql =
                    "SELECT " +
                      "0 AS id, " +
                      "0 AS id_de," +
                      "0 AS numero, " +
                      "producto.codigointernoproducto AS codigo, " +
                      "producto.nombreproducto AS descripcion, " +
                      "valor_unidad_medida.codigo AS unidad_medida, " +
                      "0.0::double precision AS cantidad, " +
                      "producto.precio_costo AS costo, " +
                      "iva.valoriva AS iva, " +
                      "producto.impoconsumo AS ic, " +
                      "ico_consumo.valor_ico AS icn, " +
                      "0.0::double precision AS precio_unitario," + 
                      "producto.valorventaproducto AS neto, " +
                      "0.0::double precision AS total, " +
                      "product_standar.scheme_agency_id AS code_standar, " +
                      "product_standar.scheme_id AS item_standar " +
                    "FROM " +
                      "producto, " +
                      "producto_medida, " +
                      "valor_unidad_medida, " +
                      "iva, " +
                      "ico_consumo, " +
                      "product_standar " +
                    "WHERE " +
                      "producto.codigointernoproducto = producto_medida.codigointernoproducto AND " +
                      "producto.idiva = iva.idiva AND " +
                      "producto_medida.idvalor_unidad_medida = valor_unidad_medida.idvalor_unidad_medida AND " +
                      "ico_consumo.id_ico = producto.id_ico_producto AND " +
                      "product_standar.scheme_id = producto.scheme_id AND " +
                      "producto.codigointernoproducto = @code;";

                DocumentEModel d = new DocumentEModel();
                
               // DataBaseDS.item_documento_electronicoDataTable dtItem = new DataBaseDS.item_documento_electronicoDataTable();
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("code", code);
                miAdapter.Fill(d.ItemDocument);
                return d.ItemDocument.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */


        /// section electronic document

        public ElectronicDocument AddElectronicDocument(ElectronicDocument ed)
        {
            try
            {
                CargarComandoSP("insert_documento_electronico");
                miComando.Parameters.AddWithValue("", ed.NitCliente);
                miComando.Parameters.AddWithValue("", ed.Estado);
                miComando.Parameters.AddWithValue("", ed.Tipo);
                miComando.Parameters.AddWithValue("", ed.TipoFactura);
                miComando.Parameters.AddWithValue("", ed.TipoOperacion);
                miComando.Parameters.AddWithValue("", ed.TipoAmbiente);
                miComando.Parameters.AddWithValue("", ed.IdStatus);
                //miComando.Parameters.AddWithValue("", ed.Numero);
                miComando.Parameters.AddWithValue("", ed.Fecha);
                miComando.Parameters.AddWithValue("", ed.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("", ed.FechaLimite);
                miComando.Parameters.AddWithValue("", ed.NoItems);
                miComando.Parameters.AddWithValue("", ed.Total);
                miComando.Parameters.AddWithValue("", ed.Neto);
                miComando.Parameters.AddWithValue("", ed.Moneda);
                miComando.Parameters.AddWithValue("", ed.IdResolucion);
                miComando.Parameters.AddWithValue("", ed.MetodoPago);
                miComando.Parameters.AddWithValue("", ed.MedioPago);
                miComando.Parameters.AddWithValue("", ed.FechaPago);
                miComando.Parameters.AddWithValue("", ed.VUBL);
                miComando.Parameters.AddWithValue("", ed.VDIAN);
                miComando.Parameters.AddWithValue("", ed.IdCaja);
                miConexion.MiConexion.Open();
                ed.ID = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();

                string sql = "select numero from documento_electronico where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", ed.ID);
                miConexion.MiConexion.Open();
                ed.Numero = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return ed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int AddItem(Item item)
        {
            try
            {
                CargarComandoSP("insert_item_documento_electronico");
                miComando.Parameters.AddWithValue("", item.IDDE);
                miComando.Parameters.AddWithValue("", item.Numero);
                miComando.Parameters.AddWithValue("", item.Code);
                miComando.Parameters.AddWithValue("", item.Description);
                miComando.Parameters.AddWithValue("", item.UnitMedida);
                miComando.Parameters.AddWithValue("", item.Quantity);
                miComando.Parameters.AddWithValue("", item.Costo);
                miComando.Parameters.AddWithValue("", item.IVA);
                miComando.Parameters.AddWithValue("", item.IC);
                miComando.Parameters.AddWithValue("", item.INC);
                miComando.Parameters.AddWithValue("", item.UnitPrice);
                miComando.Parameters.AddWithValue("", item.Neto);
                miComando.Parameters.AddWithValue("", item.Total);
                miComando.Parameters.AddWithValue("", item.TypeStandar.CodeItem);
                miComando.Parameters.AddWithValue("", item.TypeStandar.CodeStandard);
                miConexion.MiConexion.Open();
                item.ID = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return item.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateQuantityOrPrice(Item item)
        {
            try
            {
                string sql = 
                    "update item_documento_electronico set cantidad = @cant, precio_unitario = @price, neto = @neto, total = @total where id = @id; ";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("cant", item.Quantity);
                miComando.Parameters.AddWithValue("price", item.UnitPrice);
                miComando.Parameters.AddWithValue("neto", item.Neto);
                miComando.Parameters.AddWithValue("total", item.Total);
                miComando.Parameters.AddWithValue("id", item.ID);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteItemDE(int id)
        {
            try
            {
                string sql = "delete from item_documento_electronico where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                sql = "delete from item_impuesto where id_item = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditElectronicDocument(ElectronicDocument ed)
        {
            try
            {
                CargarComandoSP("edit_documento_electronico");
                miComando.Parameters.AddWithValue("", ed.NitCliente);
                miComando.Parameters.AddWithValue("", ed.Tipo);
                miComando.Parameters.AddWithValue("", ed.TipoFactura);
                miComando.Parameters.AddWithValue("", ed.TipoOperacion);
                miComando.Parameters.AddWithValue("", ed.Total);
                miComando.Parameters.AddWithValue("", ed.Neto);
                miComando.Parameters.AddWithValue("", ed.Fecha);
                miComando.Parameters.AddWithValue("", ed.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("", ed.FechaLimite);
                miComando.Parameters.AddWithValue("", ed.MetodoPago);
                miComando.Parameters.AddWithValue("", ed.MedioPago);
                miComando.Parameters.AddWithValue("", ed.FechaPago);
                miComando.Parameters.AddWithValue("", ed.ID);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                this.UpdateNumberItemDE(ed.ID);
                this.UpdateTaxes(ed.ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditElectronicDocumentAll(ElectronicDocument ed)
        {
            try
            {
                CargarComandoSP("edit_documento_electronico");
                miComando.Parameters.AddWithValue("", ed.NitCliente);
                miComando.Parameters.AddWithValue("", ed.Estado);
                miComando.Parameters.AddWithValue("", ed.Tipo);
                miComando.Parameters.AddWithValue("", ed.TipoFactura);
                miComando.Parameters.AddWithValue("", ed.TipoOperacion);
                miComando.Parameters.AddWithValue("", ed.IdStatus);
                miComando.Parameters.AddWithValue("", ed.Numero);
                miComando.Parameters.AddWithValue("", ed.Fecha);
                miComando.Parameters.AddWithValue("", ed.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("", ed.FechaLimite);
                miComando.Parameters.AddWithValue("", ed.NoItems);
                miComando.Parameters.AddWithValue("", ed.Total);
                miComando.Parameters.AddWithValue("", ed.Neto);
                miComando.Parameters.AddWithValue("", ed.IdResolucion);
                miComando.Parameters.AddWithValue("", ed.MetodoPago);
                miComando.Parameters.AddWithValue("", ed.MedioPago);
                miComando.Parameters.AddWithValue("", ed.FechaPago);
                miComando.Parameters.AddWithValue("", ed.TransaccionID);
                miComando.Parameters.AddWithValue("", ed.ID);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void GenXML(ElectronicDocument de)
        {
            try
            {
                //de = GetDocument(de.ID);
                /*
                de.Company = Company();
                de.Customer = GetCustomerByNit(de.NitCliente);
                de.Resolution = ResolutionEnd();
                */
                de.Estado = true;
                de.Numero = de.Resolution.prefijo + de.Resolution.consecutive;
                de.Fecha = de.FechaLimite = de.FechaPago = DateTime.Now;
                de.IdResolucion = de.Resolution.id;
                de.NoItems = de.Items.Count;
                de.Total = de.Items.Sum(s => s.Total);

                // generar XML
                DocumentElectronicLoad deLoad = new DocumentElectronicLoad();
                deLoad.Document = de;
                //string xmlBase64 = deLoad.CreateXML();

                // load WS
                /**
                string user = "intredete";
                string password = "5b1b3e2caaab51bb89cbb0d4bbccf385e9d7e6a748c85f6c102de0a4166645da";

                WSFTechSoap wsFTech = new WSFTechSoap();
                WSFTechSoapDemo.Response.UploadFileResponse response = wsFTech.UploadInvoiceFile(user, password, xmlBase64);
                Console.WriteLine(response.Code);
                Console.WriteLine(response.Success);
                Console.WriteLine(response.TransaccionID);
                Console.WriteLine(response.MsgError);
                Console.WriteLine();
                WSFTechSoapDemo.Response.DocumentStatusFileResponse responseDoc = wsFTech.DocumentStatusFile(user, password, response.TransaccionID);
                Console.WriteLine(responseDoc.Code);
                Console.WriteLine(responseDoc.Success);
                Console.WriteLine(responseDoc.Status);
                Console.WriteLine(responseDoc.MsgError);
                Console.WriteLine();
                //Console.WriteLine("Documento electronico generado exitosamente...");

                EditElectronicDocumentAll(de);
                UpdateConsecutiveResolution(de.IdResolucion);
                */

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Item> UpdateTaxes(int idDocument)
        {
            try
            {
                var items = GetItems(idDocument);
                foreach (Item item in items)
                {
                    this.DeleteTax(item.ID);
                    foreach (Tax tax in Taxes(item))
                    {
                        tax.IDItem = item.ID;
                        item.Taxes.Add(tax);

                        AddTax(tax);
                    }
                }
                return items;
                /*return new ElectronicDocument 
                { 
                    NoItems = items.Count, 
                    Total = items.Sum(s => s.Total),
                    Items = items
                };*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddTax(Tax tax)
        {
            try
            {
                CargarComandoSP("insert_item_impuesto");
                miComando.Parameters.AddWithValue("", tax.IDItem);
                miComando.Parameters.AddWithValue("", tax.State);
                miComando.Parameters.AddWithValue("", tax.ID);
                miComando.Parameters.AddWithValue("", tax.Nominal);
                miComando.Parameters.AddWithValue("", tax.Base);
                miComando.Parameters.AddWithValue("", tax.Tarifa);
                miComando.Parameters.AddWithValue("", tax.Value);
                
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteTax(int idItem)
        {
            try
            {
                string sql = "DELETE FROM item_impuesto WHERE id_item = @id_item;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id_item", idItem);

                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }





        public void UpdateNumberItemDE(int idDE)
        {
            try
            {
                CargarComandoSP("update_numero_item_de");
                miComando.Parameters.AddWithValue("", idDE);

                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public bool GetDocumentEstate(string numero)
        {
            try
            {
                string sql = "select estado from documento_electronico where numero = @numero;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var result = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public ElectronicDocument GetDocument(int id)
        {
            try
            {
                ElectronicDocument ed = new ElectronicDocument();
                string sql = "select * from documento_electronico where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    ed.ID = reader.GetInt32(0);
                    ed.NitCliente = reader.GetString(1);
                    ed.Estado = reader.GetBoolean(2);
                    ed.Tipo = reader.GetString(3);
                    ed.TipoFactura = reader.GetString(4);
                    ed.TipoOperacion = reader.GetString(5);
                    ed.TipoAmbiente = reader.GetString(6);
                    ed.IdStatus = reader.GetInt32(7);
                    ed.Numero = reader.GetString(8);
                    ed.Fecha = reader.GetDateTime(9);
                    ed.Fecha = Utilities.UseDate.UnionFechaYHora(ed.Fecha, reader.GetDateTime(10));
                    
                    ed.NoItems = reader.GetInt32(12);
                    ed.Total = reader.GetDouble(13);
                    ed.Neto = reader.GetDouble(14);

                    ed.Moneda = reader.GetString(15);
                    ed.IdResolucion = reader.GetInt32(16);
                    ed.MetodoPago = reader.GetInt32(17);
                    ed.MedioPago = reader.GetString(18);
                    ed.FechaPago = reader.GetDateTime(19);
                    ed.VUBL = reader.GetString(20);
                    ed.VDIAN = reader.GetString(21);
                    ed.TransaccionID = reader.GetString(22);
                    ed.IdCaja = reader.GetInt32(23);
                    ed.Cancelled = reader.GetBoolean(24);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                ed.Items = this.GetItems(ed.ID);
                foreach (Item item in ed.Items)
                {
                    item.Taxes = Taxes(item);
                }
                ed.Retentions = this.TaxesElectronicDocument(ed.ID);
                //ed.Items = this.UpdateTaxes(ed.ID);
                this.UpdateNumberItemDE(ed.ID);
                return ed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public ElectronicDocument GetDocument(string numero)
        {
            try
            {
                ElectronicDocument ed = new ElectronicDocument();
                string sql = "select * from documento_electronico where numero = @numero;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while(reader.Read())
                {
                    ed.ID = reader.GetInt32(0);
                    ed.NitCliente = reader.GetString(1);
                    ed.Estado = reader.GetBoolean(2);
                    ed.Tipo = reader.GetString(3);
                    ed.TipoFactura = reader.GetString(4);
                    ed.TipoOperacion = reader.GetString(5);
                    ed.Numero = reader.GetString(8);
                    ed.MetodoPago = reader.GetInt32(17);
                    ed.MedioPago = reader.GetString(18);
                    ed.FechaPago = reader.GetDateTime(19);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                ed.Items = this.GetItems(ed.ID);
                ed.Retentions = this.TaxesElectronicDocument(ed.ID);
                return ed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public ElectronicDocument GetDocumentData(ElectronicDocument ed, bool productive)
        {
            try
            {
                ed = GetDocument(ed.ID);
                ed.Credential = CredentialWS(productive);
                ed.Company = CompanyDE(productive);
                ed.Customer = GetCustomerByNitDE(ed.NitCliente);
                ed.Resolution = ResolutionEnd();
                return ed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ElectronicDocument GetDocumentCompany(ElectronicDocument ed, bool productive)
        {
            try
            {
                ed = GetDocument(ed.ID);
                ed.Company = CompanyDE(productive);
                return ed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Item> GetItems(int idDocument)
        {
            try
            {
                List<Item> items = new List<Item>();

                string sql = "select * from item_documento_electronico where id_de = @id_de order by numero;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id_de", idDocument);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    item.ID = reader.GetInt32(0);
                    item.IDDE = reader.GetInt32(1);
                    item.Numero = reader.GetInt32(2);
                    item.Code = reader.GetString(3);
                    item.Description = reader.GetString(4);
                    item.UnitMedida = reader.GetString(5);
                    item.Quantity = reader.GetDouble(6);
                    item.Costo = reader.GetDouble(7);
                    item.IVA = reader.GetDouble(8);
                    item.IC = reader.GetDouble(9);
                    item.INC = reader.GetDouble(10);
                    item.UnitPrice = reader.GetDouble(11);
                    item.Neto = reader.GetDouble(12);
                    item.SubTotal = Math.Round(item.UnitPrice * item.Quantity, 2);
                    item.Total = reader.GetDouble(13);
                    item.TypeStandar = new TypeStandar
                    {
                        CodeItem = reader.GetString(14),
                        CodeStandard = reader.GetString(15)
                    };
                    items.Add(item);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public string UpdateNumberConsecutiveED(ElectronicDocument document)
        {
            try
            {
                document.Resolution = ResolutionEnd();
                document.Numero = document.Resolution.prefijo + document.Resolution.consecutive;
                this.UpdateConsecutiveResolution();
                this.EditElectronicDocumentAll(document);

                this.UpdateStock(document.Items);

                return document.Numero;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al obtener el número del Documento Elecronico." + ex.Message);
            }
        }


        public List<ElectronicDocument> Documents_()
        {
            try
            {
                List<ElectronicDocument> documents = new List<ElectronicDocument>();
                string sql=
                        "SELECT " +
                          "documento_electronico.id, " +
                          "documento_electronico.numero, " +
                          "documento_electronico.nit_cliente, " +
                          "CASE WHEN cliente.nombrescliente IS NULL THEN '' " +
                            "ELSE cliente.nombrescliente " +
                          "END AS cliente, " +
                          "documento_electronico.fecha, " +
                          "documento_electronico.total, " +
                          "documento_electronico.estado, " +
                          "estatus_de.id, " +
                          "estatus_de.name " +
                        "FROM " +
                          "documento_electronico " +
                        "INNER JOIN estatus_de " +
                          "ON documento_electronico.id_status = estatus_de.id " + 
                        "LEFT JOIN cliente " + 
                          "ON documento_electronico.nit_cliente = cliente.nitcliente " + 
                        "ORDER BY " +
                          "documento_electronico.fecha DESC, " +
                          "documento_electronico.hora DESC;";
                CargarComando(sql);
                miConexion.MiConexion.Open();
                LoadReader(miComando.ExecuteReader(), documents);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return documents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<ElectronicDocument> Documents()
        {
            try
            {
                List<ElectronicDocument> documents = new List<ElectronicDocument>();
                CargarComandoSP("electronic_document");
                miConexion.MiConexion.Open();
                LoadReader(miComando.ExecuteReader(), documents);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return documents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<ElectronicDocument> Documents(string cliente)
        {
            try
            {
                List<ElectronicDocument> documents = new List<ElectronicDocument>();
                CargarComandoSP("electronic_document");
                miComando.Parameters.AddWithValue("", cliente);
                miConexion.MiConexion.Open();
                LoadReader(miComando.ExecuteReader(), documents);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return documents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*
        public List<ElectronicDocument> Documents(string cliente)
        {
            try
            {
                List<ElectronicDocument> documents = new List<ElectronicDocument>();
                string sql =
                        "SELECT " +
                          "documento_electronico.id, " +
                          "documento_electronico.numero, " +
                          "documento_electronico.nit_cliente, " +
                          "CASE WHEN cliente.nombrescliente IS NULL THEN '' " +
                            "ELSE cliente.nombrescliente " +
                          "END AS cliente, " +
                          "documento_electronico.fecha, " +
                          "documento_electronico.total, " +
                          "documento_electronico.estado, " +
                          "estatus_de.id, " +
                          "estatus_de.name " +
                        "FROM " +
                          "documento_electronico " +
                        "INNER JOIN estatus_de " +
                          "ON documento_electronico.id_status = estatus_de.id " +
                        "LEFT JOIN cliente " +
                          "ON documento_electronico.nit_cliente = cliente.nitcliente " + 
                        "WHERE " +
                          "cliente.nombrescliente ilike '%" + cliente + "%' " +
                        "ORDER BY " +
                          "documento_electronico.fecha DESC, " +
                          "documento_electronico.hora DESC;";
                CargarComando(sql);
                ///miComando.Parameters.AddWithValue("cliente", cliente);
                miConexion.MiConexion.Open();
                LoadReader(miComando.ExecuteReader(), documents);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return documents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }
        */

        private void LoadReader(NpgsqlDataReader reader, List<ElectronicDocument> documents)
        {
            while (reader.Read())
            {
                documents.Add(new ElectronicDocument
                {
                    ID = reader.GetInt32(0),
                    Tipo = reader.GetString(1),
                    Numero = reader.GetString(2),
                    NitCliente = reader.GetString(3),
                    NameCustomer = reader.GetString(4),
                    MetodoPago = reader.GetInt32(5),
                    MetPago = reader.GetString(6),

                    MedioPago = reader.GetString(7),

                    //Fecha = reader.GetDateTime(7),
                    Fecha = Convert.ToDateTime(reader.GetString(9)),
                    FechaPago = reader.GetDateTime(10),
                    Total = reader.GetDouble(11),
                    Neto = reader.GetDouble(12),

                    Payment = reader.GetDouble(13),
                    Estado = reader.GetBoolean(14),
                    IdStatus = reader.GetInt32(15),
                    Status = reader.GetString(16),
                    Cancelled = reader.GetBoolean(17),
                    TransaccionID = reader.GetString(18)
                });
            }
        }


        public void DeleteElectronicDocument(int id)
        {
            try
            {
                string sql =
                    @"delete from documento_electronico where id = @id;
                      delete from item_documento_electronico where id_de = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateEstadoTrueDocument(int id)
        {
            try
            {
                string sql = "update documento_electronico set estado = true where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateNumberDocument(ElectronicDocument ed)
        {
            try
            {
                string sql = "update documento_electronico set numero = @num, id_resolucion = @id_resolution where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", ed.ID);
                miComando.Parameters.AddWithValue("num", ed.Numero);
                miComando.Parameters.AddWithValue("id_resolution", ed.IdResolucion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateTransaccionIDDE(ElectronicDocument de)
        {
            try
            {
                string sql = "update documento_electronico set transaccion_id = @t_id where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", de.ID);
                miComando.Parameters.AddWithValue("t_id", de.TransaccionID);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateStatusSigned(int id)
        {
            try
            {
                string sql = "update documento_electronico set id_status = 2 where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateCancelledDocument(int id)
        {
            try
            {
                string sql = "update documento_electronico set cancelled = true where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateStock(List<Item> items)
        {
            try
            {
                foreach (Item item in items)
                {
                    // consulto inventario
                    this.daoInventario.ActualizarCantidad(item.Code,
                        (this.daoInventario.CantidadInventario(item.Code) - item.Quantity));

                    // update inventario (inv.cant - item.cant)
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el inventario.\n" + ex.Message);
            }
        }


        public CredentialWebService CredentialWS(bool productive)
        {
            try
            {
                CredentialWebService c = new CredentialWebService();
                string sql = "select * from credencials_web_service where productive = @product;";
                CargarComando(sql);
                miConexion.MiConexion.Open();
                miComando.Parameters.AddWithValue("product", productive);
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    c.User = reader.GetString(2);
                    c.Password = reader.GetString(3);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        ///  Resolucion númeracion facturacion electronica
        
        // insert

        public DataBaseDS.resolucion_electronicaRow ResolutionEnd()
        {
            try
            {
                var tResolution = new DataBaseDS.resolucion_electronicaDataTable();
                string sql = "select * from resolucion_electronica where id = " +
                             "(select max(id) from resolucion_electronica);";
                CargarAdapter(sql);
                miAdapter.Fill(tResolution);
                return tResolution.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataBaseDS.resolucion_electronicaRow Resolution(int id)
        {
            try
            {
                var tResolution = new DataBaseDS.resolucion_electronicaDataTable();
                string sql = "select * from resolucion_electronica where id = @id";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tResolution);
                return tResolution.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateConsecutiveResolution(int id)
        {
            try
            {
                var resolution = Resolution(id);
                resolution.consecutive++;
                string sql = "update resolucion_electronica set consecutive = @num where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("num", resolution.consecutive);
                miComando.Parameters.AddWithValue("id", resolution.id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateConsecutiveResolution()
        {
            try
            {
                CargarComandoSP("update_resolution_consecutive");
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        


        /*public NumberResolution ResolutionEnd()
        {
            try
            {
                string sql = "select * from resolucion_electronica where id = " +
                             "(select max(id) from resolucion_electronica);";
                CargarComando(sql);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return documents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }*/

        

        ///  Section global tax (retencion) electronic invoice

        public Tax AddTaxElectronicInvoice(Tax tax)
        {
            try
            {
                CargarComandoSP("insert_tax_electronic_document");
                miComando.Parameters.AddWithValue("", tax.IDItem);
                miComando.Parameters.AddWithValue("", tax.State);
                miComando.Parameters.AddWithValue("", tax.ID);
                miComando.Parameters.AddWithValue("", tax.Base);
                miComando.Parameters.AddWithValue("", tax.Tarifa);
                miComando.Parameters.AddWithValue("", tax.Value);

                miConexion.MiConexion.Open();
                tax.IDI = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();

                return tax;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<Tax> TaxesElectronicDocument(int idDE)
        {
            try
            {
                List<Tax> taxes = new List<Tax>();

                string sql =
                @"SELECT 
                      tax_electronic_document.id, 
                      tax_electronic_document.id_de, 
                      tax_electronic_document.estate, 
                      tax_electronic_document.codigo, 
                      impuestos.nombre, 
                      tax_electronic_document.valor_base, 
                      tax_electronic_document.tarifa, 
                      tax_electronic_document.valor
                    FROM 
                      public.tax_electronic_document, 
                      public.impuestos
                    WHERE 
                      tax_electronic_document.codigo = impuestos.codigo AND
                      tax_electronic_document.id_de = @id_de 
                    ORDER BY
                      tax_electronic_document.codigo ASC;";
                    //"select * from tax_electronic_document where id_de = @id_de order by codigo;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id_de", idDE);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    taxes.Add(new Tax
                    {
                        IDI = reader.GetInt32(0),
                        IDItem = reader.GetInt32(1),
                        State = reader.GetBoolean(2),
                        ID = reader.GetString(3),
                        Description = reader.GetString(4),
                        Base = reader.GetDouble(5),
                        Tarifa = reader.GetDouble(6),
                        Value = reader.GetDouble(7)
                    });
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return taxes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteTaxElectronicDocument(int idTax)
        {
            try
            {
                string sql = "delete from tax_electronic_document where id = @id;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("id", idTax);

                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// END Section global tax (retencion) electronic invoice


        ///  Section electronic invoice payment

        public void AddPayment(ElectronicPayment payment)
        {
            try
            {
                foreach (Payment pay in payment.Payments)
                {
                    CargarComandoSP("insert_documento_electronico_payment");
                    miComando.Parameters.AddWithValue("", payment.IdDE);
                    miComando.Parameters.AddWithValue("", payment.IdUser);
                    miComando.Parameters.AddWithValue("", payment.IdCaja);
                    miComando.Parameters.AddWithValue("", pay.Code);
                    miComando.Parameters.AddWithValue("", payment.Date);
                    miComando.Parameters.AddWithValue("", payment.Date.TimeOfDay);
                    miComando.Parameters.AddWithValue("", pay.Valor);
                    miComando.Parameters.AddWithValue("", pay.Pago);

                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
                if (payment.Payments.Sum(s => s.Valor) >= payment.Total)
                {
                    this.UpdateCancelledDocument(payment.IdDE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*
        public double TotalPayment(int idCaja, DateTime beginDate, DateTime endDate)
        {
            try
            {
                string sql = @"select sum(valor) from documento_electronico_payment where 
                                id_caja = @caja AND 
                                fecha + hora BETWEEN @beginDate AND @endDate;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("caja", idCaja);
                miComando.Parameters.AddWithValue("beginDate", beginDate);
                miComando.Parameters.AddWithValue("endDate", endDate);
                miConexion.MiConexion.Open();
                double total = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }
        */

        public DataTable Payments(int idCaja, DateTime beginDate, DateTime endDate)
        {
            try
            {
                var tPayments = new DataTable();
                string sql =
                 @"SELECT 
                      documento_electronico_payment.fecha, 
                      documento_electronico_payment.hora, 
                      documento_electronico.numero,
                      usuario_sistema.nombresusuario_sistema, 
                      medio_pago.nombre, 
                      documento_electronico_payment.valor
                    FROM 
                      documento_electronico_payment, 
                      documento_electronico, 
                      usuario_sistema, 
                      medio_pago
                    WHERE 
                      documento_electronico_payment.id_de = documento_electronico.id AND 
                      documento_electronico_payment.id_user = usuario_sistema.idusuario_sistema AND
                      medio_pago.codigo = documento_electronico_payment.code_payment AND 
                      documento_electronico_payment.id_caja = @caja AND 
                      documento_electronico_payment.fecha + documento_electronico_payment.hora 
                    BETWEEN @beginDate AND @endDate 
                    ORDER BY  documento_electronico_payment.fecha, 
                     documento_electronico_payment.hora;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("beginDate", beginDate);
                miAdapter.SelectCommand.Parameters.AddWithValue("endDate", endDate);
                miAdapter.Fill(tPayments);
                return tPayments;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los pagos.\n" + ex.Message);
            }
        }


        //public void 

        ///  END Section electronic invoice payment


        /// Section fiscal electronic invoice
        
        public List<DTO.Clases.Impuesto> ElectronicFiscal(DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<DTO.Clases.Impuesto> taxes = new List<DTO.Clases.Impuesto>();
                string sql =
                @"SELECT 
                      de.id,
                      de.numero,
                      de.metodo_pago, 
                      it.iva, 
                      mi_round(SUM(it.precio_unitario * it.cantidad), 2) AS sub_total, 
                      mi_round(SUM((it.precio_unitario * it.cantidad) * it.iva / 100), 2) AS v_iva, 
                      mi_round(SUM(it.ic * it.cantidad), 2) AS ic 
                    FROM 
                      documento_electronico de 
                    INNER JOIN  
                      item_documento_electronico it 
                    ON  
                      de.id = it.id_de 
                    WHERE   
                      de.tipo = 'INVOIC' 
                      AND de.estado 
                      AND de.fecha BETWEEN @fecha AND @fecha2 
                    GROUP BY 
                      de.id, de.numero, de.metodo_pago, it.iva 
                    ORDER BY 
                      de.id, it.iva;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    taxes.Add(new DTO.Clases.Impuesto
                    {
                        Id = reader.GetInt32(0),
                        Numero = reader.GetString(1),
                        PayMethod = reader.GetInt32(2),
                        Tax = reader.GetDouble(3),
                        BaseGravable = Convert.ToDouble(reader.GetDecimal(4)),
                        ValorIva = Convert.ToDouble(reader.GetDecimal(5)),
                        Impoconsumo = Convert.ToDouble(reader.GetDecimal(6))
                    });
                }
                //var neto = taxes.Sum(s => s.GetNeto);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return taxes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int AcumuladoDE(DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<DTO.Clases.Impuesto> taxes = new List<DTO.Clases.Impuesto>();
                string sql =
                @"SELECT 
                      SUM(de.total) as total  
                    FROM 
                      documento_electronico de 
                    WHERE   
                      de.tipo = 'INVOIC' 
                      AND de.estado 
                      AND de.fecha BETWEEN @fecha AND @fecha2;";
                CargarComando(sql);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public EnvironmentDE GetEnvironment()
        {
            try
            {
                var enviroment = new EnvironmentDE();
                string sql = "select * from header_data;";
                CargarComando(sql);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    enviroment.UBL = reader.GetString(1);
                    enviroment.DIAN = reader.GetString(2);
                    enviroment.Target = reader.GetString(3);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return enviroment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComando(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
            miComando.CommandText = cmd;
        }

        private void CargarComandoSP(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.Text;
        }
    }
}