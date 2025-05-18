using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Responsable
{
    internal class DbMsql
    {
        public MySqlConnection LaConnexion { get; set; } = null;

        public DbMsql()
        {

        }

        public void InitialiserConnexion()
        {
            //Remplacer les éléments par les bonnes valeurs pour l'adresse du serveur, l'utilisateur, le mot de passe et la base de données ciblée
            string connectionString = "server=sql.decinfo-cchic.ca;port=33306;uid=dev-2311029;pwd=Balde622@@;database=h25_devapp_2311029";

            LaConnexion = new MySqlConnection(connectionString);

        }
        private void VerifierConnexionBD()
        {
            if (LaConnexion == null)
            {
                throw new Exception("La connexion est nulle, veuillez Initialiser la Connexion avant.");
            }
        }
        public int ConsignerPartie(int idGagnant, int idPerdant)
        {
            VerifierConnexionBD(); // Vérifie si LaConnexion est bien initialisée

            int nbVictoires = 0;

            LaConnexion.Open();

            MySqlCommand cmd = new MySqlCommand("setVictoires", LaConnexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idw", idGagnant);
            cmd.Parameters["@idw"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@idl", idPerdant);
            cmd.Parameters["@idl"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new MySqlParameter("@nbVictoires", MySqlDbType.Int32));
            cmd.Parameters["@nbVictoires"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            nbVictoires = Convert.ToInt32(cmd.Parameters["@nbVictoires"].Value);

            LaConnexion.Close(); // Toujours fermer la connexion

            return nbVictoires;
        }



    }
}
