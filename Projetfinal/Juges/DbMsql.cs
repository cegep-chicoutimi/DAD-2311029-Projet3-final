using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BibliothequeFonctionsDeBase;

namespace Juges
{
    public class DbMsql
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

        public string[] SelectionerJoueurs()
        {
            VerifierConnexionBD();
            

            MySqlDataReader resultatRequete = null;
            MySqlDataReader resultatRequete1 = null;
            try
            {
                LaConnexion.Open();
                
                

                
                
                //Écrire la requête SQL qu'on veut exécuter
               string requete = "SELECT * FROM h25_devapp_2311029.fide_joueurs;";

                MySqlCommand laCommande = new MySqlCommand(requete, LaConnexion);

                resultatRequete = laCommande.ExecuteReader();
                int compteur = 0;
                var listejoueurs = new List<string[]>();
                while (resultatRequete.Read())
                {
                    string id = resultatRequete.GetInt32("idJoueur").ToString();
                    string nom = resultatRequete.GetString("Nom");
                    string prenom = resultatRequete.GetString("Prenom");
                    compteur += 1;
                    string strCompteur = compteur.ToString();
                    listejoueurs.Add(new string[] { strCompteur, id, nom, prenom });

                }

                foreach(string[] listejoueur in listejoueurs)
                {
                    Console.WriteLine(listejoueur[0] + ".  " + listejoueur[1] + " " + listejoueur[2] + " " + listejoueur[3]);
                }

                int choixdeJoeur = FonctionsDeBase.LireEntierMinMax("Choix du joueur : ",1, listejoueurs.Count);

                return listejoueurs[choixdeJoeur];

            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine(sqlEx.ToString());
                
            }
            finally
            {
                if (resultatRequete != null)
                {
                    resultatRequete.Close();
                }
                if (LaConnexion != null)
                {
                    LaConnexion.Close();
                }
            }
            return new string[] { "Erreur", "0", "Aucun", "Aucun" };
        }
    }
}
