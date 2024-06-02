//L'objectif de cet exercice est de trouver les K plus grands éléments dans un tableau de N entiers positifs.
//Les éléments doivent être affichés en ordre décroissant.
// Expected Time Complexity: O(K+(N-K)*logK)
// Expected Auxiliary Space: O(K + (N - K) * logK)

public class Solution
{
    public int[] kLargest(int[] arr, int n, int k)
    {

        SortedSet<KeyValuePair<int, int>> pq = new SortedSet<KeyValuePair<int, int>>(
            Comparer<KeyValuePair<int, int>>.Create((a, b) => {
                int result = a.Key.CompareTo(b.Key);
                return result == 0 ? a.Value.CompareTo(b.Value) : result;
            }));


        // dans cette boucle on a l'ajout et la supression de N-K elements alors la complexité est N-Klog(K)
        for (int i = 0; i < n; ++i)
        {
            pq.Add(new KeyValuePair<int, int>(arr[i], i));

            if (pq.Count > k)
            {
                pq.Remove(pq.Min);
            }
        }


        int[] ans = new int[k];
        int index = k - 1;
        // copmlexeté de cette boucle est O(K)
        foreach (var item in pq)
        {
            ans[index--] = item.Key;
        }

        return ans;
    }


    public static void Main(string[] args)
    {
        // Exemple 1
        int[] arr1 = { 12, 5, 787, 1, 23 };
        int n1 = arr1.Length;
        int k1 = 2;
        int[] result1 = new Solution().kLargest(arr1, n1, k1);
        Console.WriteLine(string.Join(" ", result1)); 

        // Exemple 2
        int[] arr2 = { 1, 23, 12, 9, 30, 2, 50 };
        int n2 = arr2.Length;
        int k2 = 3;
        int[] result2 = new Solution().kLargest(arr2, n2, k2);
        Console.WriteLine(string.Join(" ", result2)); 
    }

}







