namespace Juges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbMsql dbMsql = new DbMsql();
            dbMsql.InitialiserConnexion();
            string[] joueurGagnant;
            string[] joueurPerdant;
            joueurGagnant = dbMsql.SelectionerJoueurs("Choix du joueur gagnant : ");
            Console.Clear();
            joueurPerdant = dbMsql.SelectionerJoueurs("Choix du joueur perdant : ");

            string cheminDuFichier = "fichier.txt";
            string[] lignes =
            {
                $"{joueurGagnant[2]} {joueurGagnant[3]} (W) {joueurGagnant[1]}",
                $"{joueurPerdant[2]} {joueurPerdant[3]}  {joueurPerdant[1]}",
            };

            File.WriteAllLines(cheminDuFichier, lignes);


            string codeDesPieces = "ptcfkqPTCFKQ-";


        }
    }
}
