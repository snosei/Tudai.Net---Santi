using System.Web.Configuration;

namespace DAL
{
   public static class Constants
    {
        public const string esquema = "dbo";
        public const string id_parametro = "Id";
        public const string tablaNoticias = "Noticia";
        public const string tablaCategorias = "Categoria";
        public readonly static string connectionString = WebConfigurationManager.ConnectionStrings["tudaiConnectionString"].ConnectionString;
    }
}
