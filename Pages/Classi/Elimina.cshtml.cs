using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Alievi_IAL.Pages.Classi.Commons;
using System.Data.SqlClient;

namespace Alievi_IAL.Pages.Classi
{
    public class EliminaModel : PageModel
    {
        public void OnGet()
        {
            string id = Request.Query["id"];
            int Id = Convert.ToInt32(id);

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "DELETE FROM Allievi WHERE Id = @Id";
                using (SqlCommand CmD = new SqlCommand(query, con))
                {
                    CmD.Parameters.AddWithValue("@Id", Id);
                    CmD.ExecuteNonQuery();
                }
            }
            Response.Redirect("Visualizza");
        }
    }
}
