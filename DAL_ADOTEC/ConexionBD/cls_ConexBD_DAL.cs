using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL_ADOTEC.ConexionBD
{
    public class cls_ConexBD_DAL
    {
        //METODO DE CONEXION A LA BASE DE DATOS SQL SERVER
        public void CrearConx(ref cls_VariablesConexBD_DAL Obj_DB_DAL)
        {
            try
            {
                Obj_DB_DAL.sCxCadena = ConfigurationManager.ConnectionStrings[1].ConnectionString;
                Obj_DB_DAL.Obj_Connec_DB = new SqlConnection(Obj_DB_DAL.sCxCadena);
                Obj_DB_DAL.Obj_Connec_DB.Open();
                Obj_DB_DAL.sMsjError = string.Empty;
            }
            catch (Exception ex)
            {
                Obj_DB_DAL.sMsjError = ex.Message.ToString();
                Obj_DB_DAL.Obj_Connec_DB = null;
                Obj_DB_DAL.sCxCadena = string.Empty; ;
            }
        }

        //METODO DE CREACION DE PARAMETROS, QUE RELACIONAN LAS VARIABLES
        //DE LA BASE DE DATOS CON LA DE LA PLATAFORMA DE VISUAL
        public void CrearParametros(ref cls_VariablesConexBD_DAL Obj_DB_DAL)
        {
            try
            {
                Obj_DB_DAL.DT_Parametros = new DataTable("Parametros");
                Obj_DB_DAL.DT_Parametros.Columns.Add("Nombre");
                Obj_DB_DAL.DT_Parametros.Columns.Add("Tipo");
                Obj_DB_DAL.DT_Parametros.Columns.Add("Valor");

                Obj_DB_DAL.sMsjError = string.Empty;
            }
            catch (Exception ex)
            {
                Obj_DB_DAL.sMsjError = ex.Message.ToString();
                Obj_DB_DAL.DT_Parametros = null;
            }
        }

        //METODO EJECUTABLE DE LAS ACCIONES DE LISTAR Y FILTRAR
        public void Execute_DataAdapter(ref cls_VariablesConexBD_DAL Obj_DB_DAL)
        {
            try
            {
                //SE CREA LA CONECXION A LA BD SQL
                CrearConx(ref Obj_DB_DAL);

                //COMPROBAR SI HAY CONECXION A LA BD SQL
                if ((Obj_DB_DAL.Obj_Connec_DB != null) && (Obj_DB_DAL.sMsjError == string.Empty))
                {
                    //ABRIR LA ENTRADA DE DATOS
                    if (Obj_DB_DAL.Obj_Connec_DB.State == ConnectionState.Closed)
                    {
                        Obj_DB_DAL.Obj_Connec_DB.Open();
                    }

                    //INSTANCIAR EL DATA ADAPTER CON LOS PARAMETROS QUE RECIBE SP
                    Obj_DB_DAL.Obj_DAdapter = new SqlDataAdapter(Obj_DB_DAL.sSP_Name, Obj_DB_DAL.Obj_Connec_DB);

                    //Ejecutar Stored Procedure
                    Obj_DB_DAL.Obj_DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //DEFINICION DEL VALOR DEL PARAMETRO (VARIABLES)
                    if (Obj_DB_DAL.DT_Parametros != null)
                    {
                        foreach (DataRow DR in Obj_DB_DAL.DT_Parametros.Rows)
                        {
                            SqlDbType DBType = SqlDbType.VarChar;

                            switch (DR[1].ToString())
                            {
                                case "1":
                                    {
                                        DBType = SqlDbType.TinyInt;
                                        break;
                                    }
                                case "2":
                                    {
                                        DBType = SqlDbType.Int;
                                        break;
                                    }
                                case "3":
                                    {
                                        DBType = SqlDbType.VarChar;
                                        break;
                                    }
                                case "4":
                                    {
                                        DBType = SqlDbType.NVarChar;
                                        break;
                                    }
                                case "5":
                                    {
                                        DBType = SqlDbType.SmallInt;
                                        break;
                                    }
                                case "6":
                                    {
                                        DBType = SqlDbType.Char;
                                        break;
                                    }
                                case "7":
                                    {
                                        DBType = SqlDbType.DateTime;
                                        break;
                                    }
                            }

                            Obj_DB_DAL.Obj_DAdapter.SelectCommand.Parameters.Add(DR["Nombre"].ToString(), DBType).Value = DR["Valor"].ToString();
                        }
                    }
                    Obj_DB_DAL.Obj_DSet = new DataSet();
                    Obj_DB_DAL.Obj_DAdapter.Fill(Obj_DB_DAL.Obj_DSet, Obj_DB_DAL.sTableName);

                    Obj_DB_DAL.sMsjError = string.Empty;
                }

            }
            catch (Exception error)
            {
                Obj_DB_DAL.sMsjError = error.Message.ToString();
            }
            finally
            {
                //CIERRE DE LA ENTRADA DE DATOS
                if (Obj_DB_DAL.Obj_Connec_DB != null)
                {
                    if (Obj_DB_DAL.Obj_Connec_DB.State == ConnectionState.Open)
                    {
                        Obj_DB_DAL.Obj_Connec_DB.Close();
                    }

                    //DESTRUCCION DE LA CONECXION PARA NO CONSUMIR
                    Obj_DB_DAL.Obj_Connec_DB.Dispose();
                }
            }
        }

        //METODO EJECUTABLE DE LAS ACCIONES DE ELIMINAR Y MODIFICAR
        public void Execute_NonQuery(ref cls_VariablesConexBD_DAL Obj_DB_DAL)
        {
            try
            {
                CrearConx(ref Obj_DB_DAL);

                if ((Obj_DB_DAL.Obj_Connec_DB != null) && (Obj_DB_DAL.sMsjError == string.Empty)) { }
                {
                    if (Obj_DB_DAL.Obj_Connec_DB.State == ConnectionState.Closed)
                    {
                        Obj_DB_DAL.Obj_Connec_DB.Open();
                    }

                    Obj_DB_DAL.Obj_Command = new SqlCommand(Obj_DB_DAL.sSP_Name, Obj_DB_DAL.Obj_Connec_DB);

                    Obj_DB_DAL.Obj_Command.CommandType = CommandType.StoredProcedure;

                    if (Obj_DB_DAL.DT_Parametros.Rows.Count >= 1)
                    {
                        foreach (DataRow DR in Obj_DB_DAL.DT_Parametros.Rows)
                        {
                            SqlDbType DBType = SqlDbType.VarChar;

                            switch (DR[1].ToString())
                            {
                                case "1":
                                    {
                                        DBType = SqlDbType.TinyInt;
                                        break;
                                    }
                                case "2":
                                    {
                                        DBType = SqlDbType.Int;
                                        break;
                                    }
                                case "3":
                                    {
                                        DBType = SqlDbType.VarChar;
                                        break;
                                    }
                                case "4":
                                    {
                                        DBType = SqlDbType.NVarChar;
                                        break;
                                    }
                                case "5":
                                    {
                                        DBType = SqlDbType.SmallInt;
                                        break;
                                    }
                                case "6":
                                    {
                                        DBType = SqlDbType.Char;
                                        break;
                                    }
                                case "7":
                                    {
                                        DBType = SqlDbType.DateTime;
                                        break;
                                    }

                            }

                            Obj_DB_DAL.Obj_Command.Parameters.Add(DR["Nombre"].ToString(), DBType).Value = DR["Valor"].ToString();

                        }
                    }

                    Obj_DB_DAL.Obj_Command.ExecuteNonQuery();

                    Obj_DB_DAL.sMsjError = string.Empty;
                }

                Obj_DB_DAL.sMsjError = string.Empty;
            }
            catch (Exception error)
            {
                Obj_DB_DAL.sMsjError = error.Message.ToString();
            }
            finally
            {
                if (Obj_DB_DAL.Obj_Connec_DB != null)
                {
                    if (Obj_DB_DAL.Obj_Connec_DB.State == ConnectionState.Open)
                    {
                        Obj_DB_DAL.Obj_Connec_DB.Close();
                    }

                    Obj_DB_DAL.Obj_Connec_DB.Dispose();
                }
            }
        }

        //Metodo para modificar tablas con variables identity
        public void Ejec_Scalar(ref cls_VariablesConexBD_DAL Obj_DB_DAL)
        {
            try
            {
                CrearConx(ref Obj_DB_DAL);

                if ((Obj_DB_DAL.Obj_Connec_DB != null) && (Obj_DB_DAL.sMsjError == string.Empty)) { }
                {
                    if (Obj_DB_DAL.Obj_Connec_DB.State == ConnectionState.Closed)
                    {
                        Obj_DB_DAL.Obj_Connec_DB.Open();
                    }

                    Obj_DB_DAL.Obj_Command = new SqlCommand(Obj_DB_DAL.sSP_Name, Obj_DB_DAL.Obj_Connec_DB);

                    Obj_DB_DAL.Obj_Command.CommandType = CommandType.StoredProcedure;

                    if (Obj_DB_DAL.DT_Parametros.Rows.Count >= 1)
                    {
                        foreach (DataRow DR in Obj_DB_DAL.DT_Parametros.Rows)
                        {
                            SqlDbType DBType = SqlDbType.VarChar;

                            switch (DR[1].ToString())
                            {
                                case "1":
                                    {
                                        DBType = SqlDbType.TinyInt;
                                        break;
                                    }
                                case "2":
                                    {
                                        DBType = SqlDbType.Int;
                                        break;
                                    }
                                case "3":
                                    {
                                        DBType = SqlDbType.VarChar;
                                        break;
                                    }
                                case "4":
                                    {
                                        DBType = SqlDbType.NVarChar;
                                        break;
                                    }
                                case "5":
                                    {
                                        DBType = SqlDbType.SmallInt;
                                        break;
                                    }
                                case "6":
                                    {
                                        DBType = SqlDbType.Char;
                                        break;
                                    }
                                case "7":
                                    {
                                        DBType = SqlDbType.DateTime;
                                        break;
                                    }
                            }
                            Obj_DB_DAL.Obj_Command.Parameters.Add(DR["Nombre"].ToString(), DBType).Value = DR["Valor"].ToString();

                        }
                    }

                    Obj_DB_DAL.iValorScalar = Convert.ToInt32(Obj_DB_DAL.Obj_Command.ExecuteScalar());

                    Obj_DB_DAL.sMsjError = string.Empty;
                }

                Obj_DB_DAL.sMsjError = string.Empty;
            }
            catch (Exception error)
            {
                Obj_DB_DAL.sMsjError = error.Message.ToString();
            }
            finally
            {
                if (Obj_DB_DAL.Obj_Connec_DB != null)
                {
                    if (Obj_DB_DAL.Obj_Connec_DB.State == ConnectionState.Open)
                    {
                        Obj_DB_DAL.Obj_Connec_DB.Close();
                    }

                    Obj_DB_DAL.Obj_Connec_DB.Dispose();
                }
            }
        }
    }
}
