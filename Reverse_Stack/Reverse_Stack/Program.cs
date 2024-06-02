// L'objectif de cet exercice est de renverser une pile (stack) donnée en utilisant la récursivité.

class Solution
{
    // Fonction pour insérer un élément au bas de la pile.
    void InsertAtBottom(Stack<int> stack, int x)
    {
        // Si la pile est vide, insérer l'élément dans la pile.
        if (stack.Count == 0)
        {
            stack.Push(x);
        }
        else
        {
            // Sinon, si la pile n'est pas vide, enlever l'élément du dessus
            // et appeler récursivement la fonction pour insérer l'élément au bas.
            int y = stack.Pop();
            InsertAtBottom(stack, x);
            // Remettre l'élément retiré dans la pile.
            stack.Push(y);
        }
    }

    // Fonction pour inverser la pile en utilisant la récursion.
    void Fun(Stack<int> stack)
    {
        // Si la pile n'est pas vide,
        if (stack.Count > 0)
        {
            // Enlever l'élément du dessus,
            int x = stack.Pop();
            // Appeler récursivement la fonction pour inverser le reste de la pile.
            Fun(stack);
            // Insérer l'élément retiré au bas de la pile inversée.
            InsertAtBottom(stack, x);
        }
    }

    // Fonction pour inverser la pile donnée.
    public void Reverse(Stack<int> stack)
    {
        // Appeler la fonction récursive pour inverser la pile.
        Fun(stack);
    }

    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);
        stack.Push(7);
        stack.Push(6);

        Solution solution = new Solution();

        Console.WriteLine("Pile avant inversion :");
        PrintStack(stack);

        solution.Reverse(stack);

        Console.WriteLine("Pile après inversion :");
        PrintStack(stack);
    }

    static void PrintStack(Stack<int> stack)
    {
        foreach (var item in stack)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
