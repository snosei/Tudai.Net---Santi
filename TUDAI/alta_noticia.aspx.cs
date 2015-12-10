using System;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace TUDAI
{
    public partial class AltaNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDdls();
            }
            var id = Constants.id_parametro;
            if (Request.QueryString[id] != null) {
                var Noti = new Noticia()
                {
                    Id = Convert.ToInt32(Request.QueryString[id])
                };

                var noti = new NoticiaBusiness().GetNoticiaById(Noti);
                txt_titulo.Text = noti.Tables[0].Rows[0].ItemArray[1].ToString();
                txt_cuerpo.Text = noti.Tables[0].Rows[0].ItemArray[3].ToString();
                date_fecha.SelectedDate = Convert.ToDateTime(noti.Tables[0].Rows[0].ItemArray[2].ToString());
                                           
                if (noti.Tables[0].Rows[0].ItemArray[4].ToString() != "$nbsp") {
                    ddl_categorias.SelectedValue = noti.Tables[0].Rows[0].ItemArray[4].ToString();
                }
                                
            }
        }

        private void CargarDdls()
        {
            ddl_categorias.DataSource = new CategoriaBusiness().GetCategorias();
            ddl_categorias.DataBind();   
        }

        protected void Publicar_Noticia(object sender, EventArgs e)
        {
            var oNoticia = new Noticia()
            {
                Titulo = txt_titulo.Text,
                Cuerpo = txt_cuerpo.Text,
                Fecha = date_fecha.SelectedDate,
                IdCategoria = int.Parse(ddl_categorias.SelectedValue)
            };
            using (NoticiaBusiness n = new NoticiaBusiness())
            {
                n.InsertNoticia(oNoticia);
            }
            lbl_resultado.Text = "Noticia publicada correctamente";            
            
        }
    }
}