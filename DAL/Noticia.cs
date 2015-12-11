using System;

namespace DAL
{
    [Serializable]
    public class Noticia
    {
        #region Properties

        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Cuerpo { get; set; }
        public int? IdCategoria { get; set; }
        public string Autor { get; set; }

        #endregion

        #region Constructor

        public Noticia()
            : base()
        {
        }

        #endregion
    }
}