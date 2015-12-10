using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NoticiaBusiness : IDisposable
    {
        public void InsertNoticia(Noticia oNoticia)
        {
            SqlConnection oConn = new SqlConnection(Constants.connectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();
            try
            {
                using (NoticiaDataAccess tDataAccess = new NoticiaDataAccess())
                {
                    tDataAccess.Insert(oConn, oTran, oNoticia);
                }
                oTran.Commit();
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                throw ex;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }
        }

        public void UpdateNoticia(Noticia oNoticia)
        {
            SqlConnection oConn = new SqlConnection(Constants.connectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();
            try
            {
                using (NoticiaDataAccess tDataAccess = new NoticiaDataAccess())
                {
                    tDataAccess.Update(oConn, oTran, oNoticia);
                }
                oTran.Commit();
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                throw ex;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }
        }

        public DataSet GetNoticiaById(Noticia oNoticia)
        {
            SqlConnection oConn = new SqlConnection(Constants.connectionString);
            oConn.Open();
            try
            {
                using (NoticiaDataAccess tDataAccess = new NoticiaDataAccess())
                {
                    return tDataAccess.GetById(oConn, null, oNoticia);
                }
            }
            finally
            {
                oConn.Close();
            }
        }

        public DataSet GetNoticias()
        {
            SqlConnection oConn = new SqlConnection(Constants.connectionString);
            oConn.Open();
            try
            {
                using (NoticiaDataAccess tDataAccess = new NoticiaDataAccess())
                {
                    return tDataAccess.GetAll(oConn, null);
                }
            }
            finally
            {
                oConn.Close();
            }
        }

        public void Dispose()
        {
            
        }
    }
}