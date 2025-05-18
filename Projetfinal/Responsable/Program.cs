using System;
using System.IO;
using System.Linq;

namespace Responsable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Chemin relatif vers le dossier partagé contenant les fichiers de parties
            string dossier = @"..\..\..\..\Parties\";

            // Vérifie si le dossier existe
            if (!Directory.Exists(dossier))
            {
                Console.WriteLine("❌ Dossier de parties introuvable.");
                return;
            }

            // Récupère tous les fichiers dont le nom commence par "fichier_" et se termine par ".txt"
            string[] fichiers = Directory.GetFiles(dossier, "fichier_*.txt");

            // Vérifie s’il y a au moins un fichier
            if (fichiers.Length == 0)
            {
                Console.WriteLine("❌ Aucun fichier de partie trouvé.");
                return;
            }

            // Affiche la liste des fichiers trouvés avec des numéros
            Console.WriteLine("📂 Fichiers disponibles :");
            for (int i = 0; i < fichiers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(fichiers[i])}");
            }

            // Demande à l'utilisateur de choisir un fichier à afficher
            Console.Write("\nEntrez le numéro du fichier à lire : ");
            int choix = int.Parse(Console.ReadLine());

            // Sélection du fichier choisi
            string fichierChoisi = fichiers[choix - 1];

            // Lecture de toutes les lignes du fichier
            string[] lignes = File.ReadAllLines(fichierChoisi);

            // Vérifie que le fichier contient bien 10 lignes (2 joueurs + 8 lignes du plateau)
            if (lignes.Length < 10)
            {
                Console.WriteLine("❌ Fichier invalide.");
                return;
            }

            // Affichage des noms et identifiants des joueurs
            Console.WriteLine($"\n👑 Gagnant : {lignes[0]}");
            Console.WriteLine($"💔 Perdant : {lignes[1]}");

            Console.WriteLine("\n📦 Plateau :\n");

            // Extraction des 8 lignes représentant l’état final de l’échiquier
            string[] plateau = lignes.Skip(2).Take(8).ToArray();

            // Affichage du plateau avec couleurs
            AfficherPlateau(plateau);

            // Demande à l'utilisateur s’il veut enregistrer la partie dans la base de données
            Console.WriteLine("\nSouhaitez-vous consigner cette partie dans la base ? (o/n)");
            string reponse = Console.ReadLine();

            if (reponse.Trim().ToLower() == "o")
            {
                // Extraction des ID FIDE depuis les lignes des joueurs (dernier mot)
                string idGagnant = lignes[0].Split(' ').Last();
                string idPerdant = lignes[1].Split(' ').Last();

                // Connexion à la base de données et appel de la procédure stockée
                DbMsql db = new DbMsql();
                db.InitialiserConnexion();
                int nbVictoires = db.ConsignerPartie(int.Parse(idGagnant), int.Parse(idPerdant));

                // Affichage du résultat de l’enregistrement
                Console.WriteLine($"\n✅ Partie enregistrée. Nombre total de victoires du gagnant : {nbVictoires}");
            }
            else
            {
                Console.WriteLine("❎ Partie ignorée.");
            }
        }

        // Méthode d'affichage stylisé du plateau d’échecs dans la console
        static void AfficherPlateau(string[] plateau)
        {
            for (int i = 0; i < plateau.Length; i++)
            {
                for (int j = 0; j < plateau[i].Length; j++)
                {
                    char piece = plateau[i][j];

                    // Couleur du texte selon la pièce : majuscule = blanc, minuscule = vert, vide = gris
                    Console.ForegroundColor = char.IsUpper(piece) ? ConsoleColor.White :
                                              char.IsLower(piece) ? ConsoleColor.Green :
                                              ConsoleColor.DarkGray;

                    // Couleur du fond pour effet damier (alternance noir/gris)
                    Console.BackgroundColor = (i + j) % 2 == 0 ? ConsoleColor.Black : ConsoleColor.Gray;

                    // Affichage de la pièce
                    Console.Write($" {piece} ");
                }

                // Réinitialisation des couleurs après chaque ligne
                Console.ResetColor();
                Console.WriteLine();
            }

            // Réinitialisation globale
            Console.ResetColor();
        }
    }
}
