using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarGLPI
{
    class Crm
    {
        public static void UpdateTbCrm(string numCrm, string nomMedico)
        {

            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["NOSSADROGARIA"].ToString()))
            {
                sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand();
                sqlComm.CommandTimeout = 0;
                SqlTransaction transaction;
                transaction = sqlConn.BeginTransaction(IsolationLevel.ReadCommitted);
                sqlComm.Connection = sqlConn;
                sqlComm.Transaction = transaction;

                try
                {
                    sqlComm.CommandText = SQL.UpdateCrm;
                    sqlComm.Parameters.AddWithValue("@NUM_CRM", numCrm);
                    sqlComm.Parameters.AddWithValue("@NOM_MEDICO", nomMedico);
                    sqlComm.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                    sqlComm.Dispose();
                }
            }
        }

        public static DataTable SelectCrm(string numCrm)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["NOSSADROGARIA"].ToString());
            sqlConn.Open();

            SqlCommand sqlComm = new SqlCommand();
            sqlComm.CommandTimeout = 0;
            sqlComm.Connection = sqlConn;
            DataTable dtResultado = new DataTable();

            try
            {
                sqlComm.CommandText = SQL.SelectCrm;
                sqlComm.Parameters.AddWithValue("@NUM_CRM", numCrm);
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlComm);
                sqlDA.Fill(dtResultado);

                return dtResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                dtResultado = null;
                sqlConn.Close();
                sqlConn.Dispose();
                sqlComm.Dispose();
            }
        }

        public static void InsertCrm(string numCrm, string nomMedico)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["NOSSADROGARIA"].ToString()))
            {
                sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand();
                sqlComm.Connection = sqlConn;
                try
                {
                    sqlComm.CommandText = SQL.InsertCrm;
                    sqlComm.Parameters.AddWithValue("@NUM_CRM", numCrm);
                    sqlComm.Parameters.AddWithValue("@NOM_MEDICO", nomMedico);
                    sqlComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    throw new Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                    sqlComm.Dispose();
                }
            }
        }

        public static DataTable SelectXmlNcr()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["NOSSADROGARIA_VENDA"].ToString());
            sqlConn.Open();

            SqlCommand sqlComm = new SqlCommand();
            sqlComm.CommandTimeout = 0;
            sqlComm.Connection = sqlConn;
            DataTable dtResultado = new DataTable();

            try
            {
                sqlComm.CommandText = SQL.SelectXmlNcr;
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlComm);
                sqlDA.Fill(dtResultado);

                return dtResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                dtResultado = null;
                sqlConn.Close();
                sqlConn.Dispose();
                sqlComm.Dispose();
            }
        }

        public static void UpdateXml(string codChaveAcesso, string xml, string xmlCa)
        {

            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["NOSSADROGARIA_VENDA"].ToString()))
            {
                sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand();
                sqlComm.CommandTimeout = 0;
                SqlTransaction transaction;
                transaction = sqlConn.BeginTransaction(IsolationLevel.ReadCommitted);
                sqlComm.Connection = sqlConn;
                sqlComm.Transaction = transaction;

                try
                {
                    sqlComm.CommandText = SQL.UpdateXmlAnd;
                    sqlComm.Parameters.AddWithValue("@TXT_VENDA_XML", xml);
                    sqlComm.Parameters.AddWithValue("@TXT_CANCELAMENTO_XML", xmlCa);
                    sqlComm.Parameters.AddWithValue("@COD_CHAVE_ACESSO", codChaveAcesso);
                    sqlComm.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                    sqlComm.Dispose();
                }
            }
        }
    }
}
