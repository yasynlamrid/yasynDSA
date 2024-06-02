// le but de l'exercice est de Le problème consiste à associer
// des écrous (nuts) et des boulons (bolts) de tailles différentes de manière efficace

public class NutsAndBoltsMatcher
{
    public static void MatchPairs(char[] nuts, char[] bolts, int n)
    {
        // Définir l'ordre spécifique
        char[] order = new char[] { '!', '#', '$', '%', '&', '*', '@', '^', '?' };

        // Créer un dictionnaire pour l'ordre des éléments
        Dictionary<char, int> orderMap = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++)
        {
            orderMap[order[i]] = i;
        }

        // Comparer les éléments en utilisant l'ordre spécifié dans le dictionnaire
        Array.Sort(nuts, (a, b) => orderMap[a].CompareTo(orderMap[b]));
        Array.Sort(bolts, (a, b) => orderMap[a].CompareTo(orderMap[b]));
    }

    public static void Main(string[] args)
    {
        // Exemple 1
        char[] nuts1 = new char[] { '@', '%', '$', '#', '^' };
        char[] bolts1 = new char[] { '%', '@', '#', '$', '^' };
        MatchPairs(nuts1, bolts1, nuts1.Length);
        Console.WriteLine(string.Join(" ", nuts1)); // Output: # $ % @ ^
        Console.WriteLine(string.Join(" ", bolts1)); // Output: # $ % @ ^

        // Exemple 2
        char[] nuts2 = new char[] { '^', '&', '%', '@', '#', '*', '$', '?', '!' };
        char[] bolts2 = new char[] { '?', '#', '@', '%', '&', '*', '$', '^', '!' };
        MatchPairs(nuts2, bolts2, nuts2.Length);
        Console.WriteLine(string.Join(" ", nuts2)); // Output: ! # $ % & * @ ^ ?
        Console.WriteLine(string.Join(" ", bolts2)); // Output: ! # $ % & * @ ^ ?
    }
}
