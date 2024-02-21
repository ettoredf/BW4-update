using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BW4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "SELECT * FROM Prodotto";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Prodotto> listaProdotti = new List<Prodotto>();

                while (reader.Read())
                {
                    Prodotto prodotto = new Prodotto();
                    prodotto.Id = Convert.ToInt32(reader["IDProdotto"]);
                    prodotto.NomeProdotto = reader.GetString(1);
                    prodotto.Descrizione = reader.GetString(2);
                    prodotto.Prezzo = reader.GetDecimal(3);
                    prodotto.Immagine = reader.GetString(4);

                    listaProdotti.Add(prodotto);
                }

                Repeater1.DataSource = listaProdotti;
                Repeater1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
        }


        protected void addToCart_Click(object sender, EventArgs e)
        {
            string idString = ((Button)sender).CommandArgument;
            int id = int.Parse(idString);

            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "SELECT * FROM Prodotto WHERE IDProdotto = " + id;

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (Session["cart"] == null)
                {
                    Session["cart"] = new List<Prodotto>();
                }

                if (reader.Read())
                {
                    List<Prodotto> cart = (List<Prodotto>)Session["cart"];
                    Prodotto prodotto = new Prodotto();
                    prodotto.Id = Convert.ToInt32(reader["IDProdotto"]);
                    prodotto.NomeProdotto = reader.GetString(1);
                    prodotto.Descrizione = reader.GetString(2);
                    prodotto.Prezzo = reader.GetDecimal(3);
                    prodotto.Immagine = reader.GetString(4);

                    cart.Add(prodotto);
                    Session["cart"] = cart;
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}