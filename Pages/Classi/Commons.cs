namespace Alievi_IAL.Pages.Classi
{
    public class Commons
    {
        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Thomas Bravin\\Desktop\\Alievi_IAL\\Alievi_IAL\\DB\\Allievi.mdf\";Integrated Security=True;Connect Timeout=30";
        
        public class Alievi
        {
            public int Id;
            public string Nome;
            public string Cognome;
            public DateTime DataNascita;
            public int Classe;

        }
    }
}
