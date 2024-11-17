using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Alievi_IAL.Pages.Classi.Commons;
namespace Alievi_IAL.Pages.Classi
{
    public class VisualizzaModel : PageModel
    {
        public List<Alievi> Alievo = new List<Alievi>();
        public void OnGet()
        {
            //Lettura
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Allievi ORDER BY Classe";
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Alievi alievo = new Alievi();
                            alievo.Id = reader.GetInt32(0);
                            alievo.Nome = reader.GetString(1);
                            alievo.Cognome = reader.GetString(2);
                            alievo.DataNascita = reader.GetDateTime(3);
                            alievo.Classe = reader.GetInt32(4);
                            Alievo.Add(alievo);
                        }
                    }
                }
            }
            //Elimina
        }
    }
}
