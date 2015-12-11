using System;
using DAL;

namespace TUDAI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var autor = Constants.autor_parametro;
            if (!IsPostBack)
            {
                if (Request.QueryString[autor] != null)
                {
                    var noti = new Noticia()
                    {
                        Autor = Request.QueryString[autor]
                    };
                    gvNoticias.DataSource = new NoticiaBusiness().GetNoticiasByAutor(noti);
                    gvNoticias.DataBind();
                }
                else
                {
                    gvNoticias.DataSource = new NoticiaBusiness().GetNoticias();
                    gvNoticias.DataBind();
                };
            }
        }

        protected void Filtrar(object sender, EventArgs e) {
            var url = "Default.aspx?Autor=" + txt_filtro.Text;
            Response.Redirect(url);
        }

    }
}