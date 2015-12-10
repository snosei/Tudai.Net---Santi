using System;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class NoticiaDataAccess : IDisposable
    {
        public void Insert(SqlConnection oConn, SqlTransaction oTran, Noticia oNoticia)
        {
            using (SqlCommand oComm = new SqlCommand())
            {
                oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                oComm.Transaction = oTran;

                oComm.CommandType = CommandType.Text;
                oComm.CommandText = string.Format("INSERT INTO {0}.{1}(titulo,fecha,cuerpo,id_categoria) VALUES (@titulo, @fecha, @cuerpo, @id_categoria)", Constants.esquema, Constants.tablaNoticias);

                oComm.Parameters.AddWithValue("@titulo", oNoticia.Titulo);
                oComm.Parameters.AddWithValue("@fecha", oNoticia.Fecha);
                oComm.Parameters.AddWithValue("@cuerpo", oNoticia.Cuerpo);                
                oComm.Parameters.AddWithValue("@id_categoria", oNoticia.IdCategoria == null ? DBNull.Value : (object)oNoticia.IdCategoria);

                oComm.ExecuteNonQuery();
            }
        }

        public void Update(SqlConnection oConn, SqlTransaction oTran, Noticia oNoticia)
        {
            using (SqlCommand oComm = new SqlCommand())
            {
                oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                oComm.Transaction = oTran;

                oComm.CommandType = CommandType.Text;
                oComm.CommandText = string.Format("UPDATE {0}.{1} SET titulo=@titulo,fecha=@fecha,cuerpo=@cuerpo,id_categoria=@id_categoria WHERE id=@Id", Constants.esquema, Constants.tablaNoticias);
                oComm.Parameters.AddWithValue("@titulo", oNoticia.Titulo);
                oComm.Parameters.AddWithValue("@fecha", oNoticia.Fecha);
                oComm.Parameters.AddWithValue("@cuerpo", oNoticia.Cuerpo);
                oComm.Parameters.AddWithValue("@id_categoria", oNoticia.IdCategoria == null ? DBNull.Value : (object)oNoticia.IdCategoria);
                oComm.Parameters.AddWithValue("@id", oNoticia.Id);

                oComm.ExecuteNonQuery();
            }
        }

        public DataSet GetById(SqlConnection oConn, SqlTransaction oTran, Noticia oNoticia)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using (SqlCommand oComm = new SqlCommand())
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        oComm.Connection = oTran != null ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.Text;
                        oComm.CommandText = string.Format("SELECT [id],[titulo],[fecha],[cuerpo],[id_categoria] FROM {0}.{1} WHERE id=@id", Constants.esquema, Constants.tablaNoticias);

                        oComm.Parameters.AddWithValue("id",oNoticia.Id);

                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);

                        return ds;
                    }
                    finally
                    {
                    }
                }
            }
        }

        public DataSet GetAll(SqlConnection oConn, SqlTransaction oTran)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using (SqlCommand oComm = new SqlCommand())
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        oComm.Connection = oTran != null ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.Text;
                        oComm.CommandText = string.Format("SELECT [id],[titulo],[fecha],[cuerpo],[id_categoria] FROM {0}.{1}", Constants.esquema, Constants.tablaNoticias);
                        
                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);

                        return ds;
                    }
                    finally
                    {
                    }
                }
            }
        }

        public void Dispose() { }
    }
}