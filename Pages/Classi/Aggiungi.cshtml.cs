using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Alievi_IAL.Pages.Classi.Commons;

namespace Alievi_IAL.Pages.Classi
{
    public class AggiungiModel : PageModel
    {
        public Alievi alievo = new Alievi();
        public void OnGet()
        {

        }

        public void OnPost()
        {
            
            alievo.Nome = Request.Form["Nome"];
            alievo.Cognome = Request.Form["Cognome"];
            alievo.DataNascita = DateTime.Parse(Request.Form["DataNascita"]);
            alievo.Classe = int.Parse(Request.Form["Classe"]);
            
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Open();
                string query = "INSERT INTO Allievi (Nome,Cognome,DataNascita,Classe)" +
                                "VALUES (@Nome,@Cognome,@DataNascita,@Classe)";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
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
