using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetMVC
{
    public partial class Product : System.Web.UI.Page
    {
        string id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                switch (id)
                   {
                    case "1":
                        Label1.Text = "Карандаш";
                        break;

                    case "2":
                        Label1.Text = "Книга";
                        break;
                    case "3":
                        Label1.Text = "Телефон";
                        break;
                    case "4":
                        Label1.Text = "Машина";
                        break;
                    default:
                        Label1.Text = "Такой продукт не найден";
                        break;
                }
            }
            else
            {
                Label1.Text = "неверный id";
            }
        }
    }
}