using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;

namespace McSoftware
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string publicado = "";
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["UserSession"]))
            {
                Response.Redirect(ResolveUrl(publicado + "/CerrarSession.aspx"), false);
                return;
            }
            string JS = HttpContext.Current.Session["UserSession"].ToString();
            Cls_Usuario_X_Empleado_BE objUser = JsonConvert.DeserializeObject<Cls_Usuario_X_Empleado_BE>(JS);
            
            string CodigoMaspol = objUser.CARNE;
            GeneraMenu(CodigoMaspol);
        }

        void GeneraMenu(string Codigo)
        {
            //xMenux.Items.Clear();
            Cls_Menu_BN objBN = new Cls_Menu_BN();
            Cls_Menu_BE obj_Menu = new Cls_Menu_BE();
            obj_Menu.Tipo = "1";
            string str = "";
            obj_Menu.xIdPerfil = "1";
            obj_Menu.MASPE_CARNE = Codigo;

            List<Cls_Menu_BE> ListaPersonal = objBN.Obt_Lista_Menu_BL(obj_Menu, "29", ref str);
            if (ListaPersonal.Count > 0)
            {
                //int Max = (from xp in ListaPersonal select xp.IdPadre).Max();

                List<Cls_Menu_BE> Lista = new List<Cls_Menu_BE>();

                MenuPrincipal.Attributes.Add("class", "sidebar-menu");
                foreach (Cls_Menu_BE cuenta1 in ListaPersonal)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    if (cuenta1.IdPadre == cuenta1.IdMenu)
                    {
                        HtmlGenericControl Icono = new HtmlGenericControl("i");
                        HtmlGenericControl divspan = new HtmlGenericControl("span");

                        List<Cls_Menu_BE> list = ListaPersonal.Where(x => x.IdNiveles == cuenta1.IdMenu).ToList();
                        if (list.Count == 0)
                        {
                            Icono.Attributes.Add("class", "fa fa-user-md");
                            divspan.InnerHtml = cuenta1.Descripcion;

                            li.Attributes.Add("class", "");
                            anchor.Attributes.Add("href", cuenta1.Aplicacion + ".aspx");
                            anchor.Controls.Add(Icono);
                            anchor.Controls.Add(divspan);
                            li.Controls.Add(anchor);
                            MenuPrincipal.Controls.Add(li);
                        }
                        else
                        {
                            Icono.Attributes.Add("class", "fa fa-user-md");
                            divspan.InnerHtml = cuenta1.Descripcion;

                            HtmlGenericControl liDetalle = new HtmlGenericControl("li");
                            HtmlGenericControl anchorDetalle = new HtmlGenericControl("a");
                            liDetalle.Attributes.Add("class", "treeview");
                            anchorDetalle.Attributes.Add("href", "#");
                            anchorDetalle.Controls.Add(Icono);
                            anchorDetalle.Controls.Add(divspan);
                            liDetalle.Controls.Add(anchorDetalle);
                            HtmlGenericControl ulDetalle = new HtmlGenericControl("ul");
                            ulDetalle.Attributes.Add("class", "treeview-menu");
                            foreach (Cls_Menu_BE ctaDetalle in list)
                            {
                                HtmlGenericControl liDetalle2 = new HtmlGenericControl("li");
                                HtmlGenericControl anchorDetalle2 = new HtmlGenericControl("a");
                                anchorDetalle2.Attributes.Add("href", ctaDetalle.Aplicacion + ".aspx");
                                anchorDetalle2.InnerText = ctaDetalle.Descripcion;
                                liDetalle2.Controls.Add(anchorDetalle2);
                                ulDetalle.Controls.Add(liDetalle2);
                                liDetalle.Controls.Add(ulDetalle);
                            }
                            MenuPrincipal.Controls.Add(liDetalle);
                        }
                    }

                }

            }
            else
            {
                //Session.Abandon();
                //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                //RemoveRedirCookie();
                //Response.Redirect("~/Presentacion/PagNotDefault.aspx", false);
            }
        }

        void Creacion(MenuItem xHijo, List<Cls_Menu_BE> objBE, List<Cls_Menu_BE> Personal)
        {
            foreach (Cls_Menu_BE cuenta1 in objBE)
            {
                List<Cls_Menu_BE> list = Personal.Where(x => x.IdPadre == cuenta1.IdMenu).ToList();
                MenuItem xMenu = new MenuItem();
                xMenu.Text = cuenta1.Descripcion;
                xMenu.Value = cuenta1.IdMenu.ToString();
                xMenu.NavigateUrl = cuenta1.Aplicacion;
                xHijo.ChildItems.Add(xMenu);
                if (list.Count > 0)
                {
                    Creacion(xMenu, list, Personal);
                }
            }
        }

    }

}