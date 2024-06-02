// le but de cet exercice est de trouver le nombre d'occurrence d'un nombre dans un tableau 
// complexité :
// O(log(n))
// O(1)

public class Solution
{
    
    public int Count(int[] arr, int n, int x)
    {
      
        int low = Array.IndexOf(arr, x);

       
        if (low == -1)
            return 0;


        int high = Array.LastIndexOf(arr, x);

 
        return high - low + 1;
    }

    public static void Main()
    {
        int[] arr1 = { 1, 1, 2, 2, 2, 2, 3 };
        int n1 = 7;
        int x1 = 2;
        Solution sol = new Solution();
        Console.WriteLine(sol.Count(arr1, n1, x1)); 

        int[] arr2 = { 1, 1, 2, 2, 2, 2, 3 };
        int n2 = 7;
        int x2 = 4;
        Console.WriteLine(sol.Count(arr2, n2, x2));
    }
}
