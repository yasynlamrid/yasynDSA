//L'exercice consiste à trier une pile (stack) de manière 
//à ce que l'élément le plus grand se trouve en haut de la pile


class Program
{
    // Fonction pour insérer un élément de manière triée dans la pile
    static void SortedInsert(Stack<int> stack, int element)
    {
        // Si la pile est vide ou l'élément actuel est plus grand que l'élément au sommet
        if (stack.Count == 0 || element > stack.Peek())
        {
            stack.Push(element);
        }
        else
        {
            // Sinon, retirez l'élément au sommet et insérez l'élément actuel récursivement
            int temp = stack.Pop();
            SortedInsert(stack, element);
            stack.Push(temp);
        }
    }

    // Fonction principale pour trier la pile
    static void SortStack(Stack<int> stack)
    {
        // Si la pile n'est pas vide
        if (stack.Count > 0)
        {
            // Retirez l'élément au sommet
            int temp = stack.Pop();
            // Triez récursivement la pile restante
            SortStack(stack);
            // Insérez l'élément retiré à sa place correcte
            SortedInsert(stack, temp);
        }
    }

    // Fonction pour afficher les éléments de la pile
    static void PrintStack(Stack<int> stack)
    {
        foreach (var item in stack)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(11);
        stack.Push(2);
        stack.Push(32);
        stack.Push(3);
        stack.Push(41);

        Console.WriteLine("Stack avant tri:");
        PrintStack(stack);

        SortStack(stack);

        Console.WriteLine("Stack après tri:");
        PrintStack(stack);
    }
}
