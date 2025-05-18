using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Juges
{
    internal class Program
    {
        // Constante des codes valides pour les pièces d’échec et cases vides
        const string CodeDesPieces = "ptcfkqPTCFKQ-";

        static void Main(string[] args)
        {
            DbMsql dbMsql = new DbMsql();
            dbMsql.InitialiserConnexion();

            // Sélection des joueurs
            string[] joueurGagnant = SelectionnerJoueur(dbMsql, "Choix du joueur gagnant : ");
            Console.Clear();

            string[] joueurPerdant = SelectionnerJoueur(dbMsql, "Choix du joueur perdant : ");
            Console.Clear();

            

            // Génération des deux premières lignes du fichier
            List<string> lignes = GenererEntete(joueurGagnant, joueurPerdant);

            // Saisie et encodage de l’état final de la partie
            List<string> etatFinal = SaisirEtatFinal();
            lignes.AddRange(etatFinal);

            // Écriture dans le fichier texte
            // Dossier partagé Parties
            string dossierParties = @"..\..\..\..\Parties\";
            Directory.CreateDirectory(dossierParties);

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string cheminDuFichier = Path.Combine(dossierParties, $"fichier_{timestamp}.txt");

            File.WriteAllLines(cheminDuFichier, lignes);

            Console.WriteLine($"\n✅ Fichier enregistré avec succès dans : {cheminDuFichier}");
        }

        static string[] SelectionnerJoueur(DbMsql db, string message)
        {
            return db.SelectionerJoueurs(message);
        }

        

        static List<string> GenererEntete(string[] gagnant, string[] perdant)
        {
            return new List<string>
            {
                $"{gagnant[2]} {gagnant[3]} (W) {gagnant[1]}",
                $"{perdant[2]} {perdant[3]} {perdant[1]}"
            };
        }

        static List<string> SaisirEtatFinal()
        {
            List<string> etatFinal = new List<string>();
            Console.WriteLine("\nEntrez l’état final de l’échiquier (8 lignes, de haut en bas, 8 caractères chacune) :");

            for (int i = 0; i < 8; i++)
            {
                string ligne;
                do
                {
                    Console.Write($"Ligne {i + 1} : ");
                    ligne = Console.ReadLine();

                    // Vérifie que tous les caractères sont valides
                    if (ligne.Length != 8 || !ligne.All(c => CodeDesPieces.Contains(char.ToLower(c)) || CodeDesPieces.Contains(char.ToUpper(c))))
                    {
                        Console.WriteLine("❌ Erreur : la ligne doit contenir exactement 8 caractères valides (p, t, c, f, k, q, -).");
                    }

                } while (ligne.Length != 8 || !ligne.All(c => CodeDesPieces.Contains(char.ToLower(c)) || CodeDesPieces.Contains(char.ToUpper(c))));

                // Mise en majuscule ou minuscule selon qui est blanc
                
                etatFinal.Add(ligne);
            }

            return etatFinal;
        }
    }
}
