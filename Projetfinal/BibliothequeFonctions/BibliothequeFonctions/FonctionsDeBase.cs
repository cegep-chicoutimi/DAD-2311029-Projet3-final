using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeFonctionsDeBase;

public class FonctionsDeBase
{
    #region Affichage de texte

    /// <summary>
    /// Affiche une ligne de texte lettre par lettre.
    /// </summary>
    /// <param name="texte">Le texte à afficher.</param>
    /// <param name="couleur">La couleur console du texte, par défaut White.</param>
    public static void AfficherLigne(string texte, ConsoleColor couleur = ConsoleColor.White)
    {
        Console.ForegroundColor = couleur;
        Console.WriteLine(texte);
        Console.ResetColor();
    }

    /// <summary>
    /// Affiche un texte lettre par lettre.
    /// </summary>
    /// <param name="texte">Le texte à afficher.</param>
    /// <param name="couleur">La couleur console du texte, par défaut White.</param>
    public static void AfficherTexteProgressif(string texte, ConsoleColor couleur = ConsoleColor.White)
    {
        Console.ForegroundColor = couleur;

        foreach (char lettre in texte)
        {
            Thread.Sleep(25);
            Console.Write(lettre);
        }

        Console.ResetColor();
    }

    /// <summary>
    /// Affiche un titre entre 2 lignes de n asterisques.
    /// </summary>
    /// <param name="titre">Le titre à afficher.</param>
    public static void AfficherTitre(string titre, int nbAsterisques = 30, ConsoleColor couleur = ConsoleColor.Cyan, bool centre = true)
    {
        // Déclaration des variables
        string asterisques = "".PadLeft(nbAsterisques, '*');

        // Centrage du titre
        if (centre)
        {
            int nbEspaces = (nbAsterisques - titre.Length) / 2;
            titre = titre.PadLeft(nbEspaces + titre.Length);
        }

        // Affichage de l'entête
        Console.ResetColor();
        Console.ForegroundColor = couleur;
        Console.WriteLine(asterisques);
        Console.WriteLine(titre.ToUpper());
        Console.WriteLine(asterisques);
        Console.ResetColor();
    }

    /// <summary>
    /// Lit un texte dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire le texte dans la console.</param>
    /// <param name="messageInvalide">Le message à afficher lorsque l'lue est invalide.</param>
    /// <param name="accepteVide">Accepte un texte vide. Par défaut VRAI.</param>
    /// <returns>Le texte lu dans la console.</returns>
    public static string LireTexte(string message, string messageInvalide = "", bool accepteVide = true)
    {
        string reponse;

        Console.Write(message);
        reponse = Console.ReadLine() ?? "";

        if (accepteVide == false)
        {
            while (reponse.Trim() == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(messageInvalide);
                Console.ResetColor();
                reponse = Console.ReadLine() ?? "";
            }
        }

        return reponse;
    }

    /// <summary>
    /// Lit un texte non vide dans la console.
    /// </summary>
    /// <returns>Le texte non vide lu dans la console.</returns>
    public static string LireTexteNonVide()
    {
        return LireTexteNonVide("");
    }

    /// <summary>
    /// Lit un texte non vide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire le texte non vide dans la console.</param>
    /// <returns>Le texte non vide lu dans la console.</returns>
    public static string LireTexteNonVide(string message)
    {
        string texte;

        Console.Write(message);
        texte = Console.ReadLine() ?? "";
        texte = texte.Trim();

        while (texte == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("lue obligatoire, recommencez : ");
            Console.ResetColor();
            texte = Console.ReadLine() ?? "";
        }

        return texte;
    }

    #endregion

    #region Lecture de texte

    /// <summary>
    /// Lit un caractère dans la console.
    /// </summary>
    /// <returns>Le caractère lu dans la console.</returns>
    public static char LireCaractere()
    {
        return LireCaractere("");
    }

    /// <summary>
    /// Lit un caractère dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire un caractère dans la console.</param>
    /// <returns>Le caractère lu dans la console.</returns>
    public static char LireCaractere(string message)
    {
        string texte;

        Console.Write(message);
        texte = Console.ReadLine() ?? "";

        while (texte.Length != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Nombre de caractères invalide, recommencez : ");
            Console.ResetColor();
            texte = Console.ReadLine() ?? "";
        }

        return texte[0];
    }

    #endregion

    #region Lecture de double

    /// <summary>
    /// Lit un nombre réel (double) valide dans la console.
    /// </summary>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDouble()
    {
        return LireDouble("");
    }

    /// <summary>
    /// Lit un nombre réel (double) valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire le nombre réel dans la console.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDouble(string message)
    {
        return LireDouble(message, "Nombre réel invalide, recommencez : ");
    }

    /// <summary>
    /// Lit un nombre réel (double) valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire le nombre réel dans la console.</param>
    /// <param name="messageInvalide">Le message à afficher lorsque l'lue est invalide.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDouble(string message, string messageInvalide)
    {
        double reel;
        bool valide;

        Console.Write(message);
        valide = double.TryParse(Console.ReadLine(), out reel);

        while (valide == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(messageInvalide);
            Console.ResetColor();
            valide = double.TryParse(Console.ReadLine(), out reel);
        }

        return reel;
    }

    /// <summary>
    /// Lit un double valide dans la console.
    /// </summary>
    /// <param name="min">La valeur minimale valide.</param>
    /// <param name="max">La valeur maximale valide.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDoubleMinMax(double min, double max)
    {
        return LireDoubleMinMax("", min, max);
    }

    /// <summary>
    /// Lit un double valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="min">La valeur minimale valide.</param>
    /// <param name="max">La valeur maximale valide.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDoubleMinMax(string message, double min, double max)
    {
        return LireDoubleMinMax(message, $"Cette valeur est invalide ({min} à {max}), recommencez : ", min, max);
    }

    /// <summary>
    /// Lit un double valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="messageInvalide">Le message à afficher lorsque l'lue est invalide.</param>
    /// <param name="min">La valeur minimale valide.</param>
    /// <param name="max">La valeur maximale valide.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDoubleMinMax(string message, string messageInvalide, double min, double max)
    {
        double reel;
        bool valide;

        Console.Write(message);
        valide = double.TryParse(Console.ReadLine(), out reel);

        while (valide == false || reel < min || reel > max)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(messageInvalide);
            Console.ResetColor();
            valide = double.TryParse(Console.ReadLine(), out reel);
        }

        return reel;
    }

    /// <summary>
    /// Lit un double plus grand que zéro dans la console.
    /// </summary>
    /// <param name="message">Le message à afficher.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDoublePositif(string message)
    {
        return LireDoublePositif(message, "Cette valeur est invalide. Le nombre doit être plus grand que zéro. Recommencez :");
    }

    /// <summary>
    /// Lit un double plus grand que zéro dans la console.
    /// </summary>
    /// <param name="message">Le message à afficher.</param>
    /// <param name="messageInvalide">Le message à afficher lorsque l'lue est invalide.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static double LireDoublePositif(string message, string messageInvalide)
    {
        // Déclaration des variables
        double reel;
        bool valide;

        // Écriture du message à la console
        Console.Write(message);
        valide = double.TryParse(Console.ReadLine(), out reel);

        while (valide == false || reel <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(messageInvalide);
            Console.ResetColor();
            valide = double.TryParse(Console.ReadLine(), out reel);
        }

        return reel;
    }

    /// <summary>
    /// Lit un nombre de doubles valides dans la console.
    /// </summary>
    /// <param name="nbDoubles">Nombre de doubles à lire.</param>
    /// <returns>Le nombre réel (double) lu dans la console.</returns>
    public static List<double> LireDoubles(int nbDouble)
    {
        return LireDoubles(nbDouble);
    }

    /// <summary>
    /// Lit un nombre de doubles valides dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="nbDoubles">Nombre de doubles à lire.</param>
    /// <returns>Les nombres réels (double) lus dans la console.</returns>
    public static List<double> LireDoubles(string message, int nbDoubles)
    {
        List<double> doubles = new List<double>();

        Console.WriteLine(message);

        for (double index = 1; index <= nbDoubles; index++)
        {
            double reel = LireDouble($"Entier #{index} : ");
            doubles.Add(reel);
        }

        return doubles;
    }


    /// <summary>
    /// Lit un nombre de doubles valides dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="nbDoubles">Nombre de doubles à lire.</param>
    /// <returns>Les nombres réels (double) lus dans la console.</returns>
    public static List<double> LireDoublesMinMax(string message, int nbDoubles, double min, double max)
    {
        List<double> doubles = new List<double>();

        Console.WriteLine(message);

        for (double index = 1; index <= nbDoubles; index++)
        {
            double reel = LireDoubleMinMax($"Entier #{index} : ", min, max);
            doubles.Add(reel);
        }

        return doubles;
    }


    /// <summary>
    /// Lit un nombre de doubles valides dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="nbDoubles">Nombre de doubles à lire.</param>
    /// <returns>Les nombres réels (double) lus dans la console.</returns>
    public static List<double> LireDoublesPositifs(string message, int nbDoubles)
    {
        List<double> doubles = new List<double>();

        Console.WriteLine(message);

        for (double index = 1; index <= nbDoubles; index++)
        {
            double reel = LireDoublePositif($"Entier #{index} : ");
            doubles.Add(reel);
        }

        return doubles;
    }

    #endregion

    #region LireEntier

    /// <summary>
    /// Lit un entier valide dans la console.
    /// </summary>
    /// <returns>L'entier lu dans la console.</returns>
    public static int LireEntier()
    {
        return LireEntier("");
    }

    /// <summary>
    /// Lit un entier valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static int LireEntier(string message)
    {
        return LireEntier(message, "Nombre entier invalide, recommencez : ");
    }

    /// <summary>
    /// Lit un entier valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="messageInvalide">Le message à afficher lorsque l'lue est invalide.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static int LireEntier(string message, string messageInvalide)
    {
        int entier;
        bool valide;

        Console.Write(message);
        valide = int.TryParse(Console.ReadLine(), out entier);

        while (valide == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(messageInvalide);
            Console.ResetColor();
            valide = int.TryParse(Console.ReadLine(), out entier);
        }

        return entier;
    }

    /// <summary>
    /// Lit un entier valide dans la console.
    /// </summary>
    /// <param name="min">La valeur minimale valide.</param>
    /// <param name="max">La valeur maximale valide.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static int LireEntierMinMax(int min, int max)
    {
        return LireEntierMinMax("", min, max);
    }

    /// <summary>
    /// Lit un entier valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="min">La valeur minimale valide.</param>
    /// <param name="max">La valeur maximale valide.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static int LireEntierMinMax(string message, int min, int max)
    {
        return LireEntierMinMax(message, $"Nombre entier invalide ({min} à {max}), recommencez : ", min, max);
    }

    /// <summary>
    /// Lit un entier valide dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="messageInvalide">Le message à afficher lorsque l'lue est invalide.</param>
    /// <param name="min">La valeur minimale valide.</param>
    /// <param name="max">La valeur maximale valide.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static int LireEntierMinMax(string message, string messageInvalide, int min, int max)
    {
        int entier;
        bool valide;

        Console.Write(message);
        valide = int.TryParse(Console.ReadLine(), out entier);

        while (valide == false || entier < min || entier > max)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(messageInvalide);
            Console.ResetColor();
            valide = int.TryParse(Console.ReadLine(), out entier);
        }

        return entier;
    }

    /// <summary>
    /// Lit un nombre entier plus grand que zéro dans la console.
    /// </summary>
    /// <param name="message">Le message à afficher.</param>
    /// <returns>Le nombre entier lu dans la console.</returns>
    public static int LireEntierPositif(string message)
    {
        return LireEntierPositif(message, "Le nombre entier saisi est invalide. Il doit être plus grand que zéro. Recommencez :");
    }

    /// <summary>
    /// Lit un nombre entier plus grand que zéro dans la console.
    /// </summary>
    /// <param name="message">Le message à afficher.</param>
    /// <param name="messageInvalide">Le message à afficher lorsque l'lue est invalide.</param>
    /// <returns>Le nombre entier lu dans la console.</returns>
    public static int LireEntierPositif(string message, string messageInvalide)
    {
        // Déclaration des variables
        int entier;
        bool valide;

        // Écriture du message à la console
        Console.Write(message);
        valide = int.TryParse(Console.ReadLine(), out entier);

        while (valide == false || entier <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(messageInvalide);
            Console.ResetColor();
            valide = int.TryParse(Console.ReadLine(), out entier);
        }

        return entier;
    }

    /// <summary>
    /// Lit un entier valide dans la console.
    /// </summary>
    /// <param name="nbEntiers">Nombre d'entiers à lire.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static List<int> LireEntiers(int nbEntiers)
    {
        return LireEntiers(nbEntiers);
    }

    /// <summary>
    /// Lit un nombre d'entiers valides dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="nbEntiers">Nombre d'entiers à lire.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static List<int> LireEntiers(string message, int nbEntiers)
    {
        List<int> entiers = new List<int>();

        Console.WriteLine(message);

        for (int index = 1; index <= nbEntiers; index++)
        {
            int entier = LireEntier($"Entier #{index} : ");
            entiers.Add(entier);
        }

        return entiers;
    }

    /// <summary>
    /// Lit un nombre d'entiers valides dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="nbEntiers">Nombre d'entiers à lire.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static List<int> LireEntiersMinMax(string message, int nbEntiers, int min, int max)
    {
        List<int> entiers = new List<int>();

        Console.WriteLine(message);

        for (int index = 1; index <= nbEntiers; index++)
        {
            int entier = LireEntierMinMax($"Entier #{index} : ", min, max);
            entiers.Add(entier);
        }

        return entiers;
    }


    /// <summary>
    /// Lit un nombre d'entiers valides dans la console.
    /// </summary>
    /// <param name="message">Le message affiché avant de lire l'entier dans la console.</param>
    /// <param name="nbEntiers">Nombre d'entiers à lire.</param>
    /// <returns>L'entier lu dans la console.</returns>
    public static List<int> LireEntiersPositifs(string message, int nbEntiers)
    {
        List<int> entiers = new List<int>();

        Console.WriteLine(message);

        for (int index = 1; index <= nbEntiers; index++)
        {
            int entier = LireEntierPositif($"Entier #{index} : ");
            entiers.Add(entier);
        }

        return entiers;
    }


    #endregion

    /// <summary>
    /// Cammoule le texte affiché à la console à la fin de l'excéution.
    /// </summary>
    public static void MasquerTexte()
    {
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Black;
    }
}
