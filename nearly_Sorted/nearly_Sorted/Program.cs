// le but de cet exercice est de trier un tableau à N élements, avec K represente la distance maximale
// à laquelle chaque élément peut se trouver de sa position finale

// à respecter  :

// la complexité temporelle  : nlogK
// la complexité spatiale auxiliaire : O(n)





public class Solution
{
    public List<int> NearlySorted(int[] arr, int num, int K)
    {
        List<int> result = new List<int>();
        var sortedSet = new SortedSet<int>();

        // Ajouter les premiers K+1 éléments au set trié
        for (int i = 0; i <= K; i++)
        {
            sortedSet.Add(arr[i]);
        }

        // Parcourir le reste des éléments du tableau
        for (int i = K + 1; i < num; i++)
        {
            result.Add(sortedSet.Min);
            sortedSet.Remove(sortedSet.Min);
            sortedSet.Add(arr[i]);
        }

        // Ajouter les éléments restants du set trié au résultat
        while (sortedSet.Count > 0)
        {
            result.Add(sortedSet.Min);
            sortedSet.Remove(sortedSet.Min);
        }

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        // Exemple 1
        int[] arr1 = { 6, 5, 3, 2, 8, 10, 9 };
        int n1 = 7;
        int k1 = 2;
        List<int> sortedArr1 = solution.NearlySorted(arr1, n1, k1);
        Console.WriteLine("Exemple 1: " + string.Join(" ", sortedArr1));

        // Exemple 2
        int[] arr2 = { 3, 1, 4, 2, 5 };
        int n2 = 5;
        int k2 = 2;
        List<int> sortedArr2 = solution.NearlySorted(arr2, n2, k2);
        Console.WriteLine("Exemple 2: " + string.Join(" ", sortedArr2));
    }
}
