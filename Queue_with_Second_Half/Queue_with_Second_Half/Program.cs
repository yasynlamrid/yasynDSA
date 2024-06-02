//réarranger une file d'attente 𝑄 entrelaçant la première moitié de la file avec la seconde moitié

using System.Net;

class Solution
{
    public List<int> rearrangeQueue(Queue<int> q)
    {

        // initailisation 
        Stack<int> s = new Stack<int>();
        int half = q.Count / 2;

        // Transférer la première moitié des éléments dans la pile
        for (int i = 0; i < half; i++)
        {
            s.Push(q.Peek());
            q.Dequeue();
        }

        //Remettre les éléments de la pile dans la file
        while (s.Count != 0)
        {
            q.Enqueue(s.Peek());
            s.Pop();
        }

        // Déplacer les premiers half éléments à la fin de la file
        for (int i = 0; i < half; i++)
        {
            q.Enqueue(q.Peek());
            q.Dequeue();
        }

        //Transférer de nouveau la première moitié des éléments dans la pile
        for (int i = 0; i < half; i++)
        {
            s.Push(q.Peek());
            q.Dequeue();
        }

        // Entrelacer les éléments
        while (s.Count != 0)
        {
            q.Enqueue(s.Peek());
            s.Pop();
            q.Enqueue(q.Peek());
            q.Dequeue();
        }

        // Transférer les éléments de la file dans une liste
        List<int> ans = new List<int>();
        while (q.Count > 0)
        {
            ans.Add(q.Peek());
            q.Dequeue();
        }
        return ans;
    }
}
class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        // Exemple 1
        Queue<int> Q1 = new Queue<int>(new int[] { 2, 4, 3, 1 });
        List<int> result1 = solution.rearrangeQueue(Q1);
        Console.WriteLine("Exemple 1 - Sortie : " + string.Join(", ", result1));

        // Exemple 2
        Queue<int> Q2 = new Queue<int>(new int[] { 3, 5 });
        List<int> result2 = solution.rearrangeQueue(Q2);
        Console.WriteLine("Exemple 2 - Sortie : " + string.Join(", ", result2));
    }
}
