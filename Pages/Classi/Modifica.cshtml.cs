using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Alievi_IAL.Pages.Classi.Commons;

namespace Alievi_IAL.Pages.Classi
{
    public class ModificaModel : PageModel
    {
        public Alievi alievo = new Alievi();
        public void OnGet()
        {
            string Id = Request.Query["id"];

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Open();
                string query = "SELECT * FROM Allievi WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", int.Parse(Id));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            alievo.Id = reader.GetInt32(0);
                            alievo.Nome = reader.GetString(1);
                            alievo.Cognome = reader.GetString(2);
                            alievo.DataNascita = reader.GetDateTime(3);
                            alievo.Classe = reader.GetInt32(4);
                        }
                        else
                        {
                            throw new Exception("Nessun record trovato");
                        }
                    }
                }
            }
        }

        public void OnPost()
        {
            alievo.Id = int.Parse(Request.Form["Id"]);
            alievo.Nome = Request.Form["Nome"];
            alievo.Cognome = Request.Form["Cognome"];
            alievo.DataNascita = DateTime.Parse(Request.Form["DataNascita"]);
            alievo.Classe = int.Parse(Request.Form["Classe"]);

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Open();
                string query = "UPDATE Allievi SET Nome = @Nome, Cognome = @Cognome, DataNascita = @DataNascita, Classe = @Classe WHERE Id = @Id";

                using SqlCommand cmd = new SqlCommand(query, cnn);
                {
                    cmd.Parameters.AddWithValue("@Id", alievo.Id);
                    cmd.Parameters.AddWithValue("@Nome", alievo.Nome);
                    cmd.Parameters.AddWithValue("@Cognome", alievo.Cognome);
                    cmd.Parameters.AddWithValue("@DataNascita", alievo.DataNascita);
                    cmd.Parameters.AddWithValue("@Classe", alievo.Classe);
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect("Visualizza");
        }
    }
}
