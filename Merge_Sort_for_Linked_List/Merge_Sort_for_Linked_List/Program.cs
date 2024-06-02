
public class Node
{
    public int data;
    public Node next;

    public Node(int d)
    {
        data = d;
        next = null;
    }
}

class Solution
{
    // fonction pour diviser la liste en deux 
    static void SplitList(Node source, out Node frontRef, out Node backRef)
    {
        frontRef = null;
        backRef = null;

        // deux pointeurs pour trouver la moitié de la liste 
        Node fast = source;
        Node slow = source;
        if (source == null || source.next == null)
        {
            frontRef = source;
            backRef = null;
        }
        else
        {
            //first pointer, slow moves 1 node and second pointer, fast moves
            //2 nodes in one iteration.
            slow = source;
            fast = source.next;
            while (fast != null)
            {
                fast = fast.next;
                if (fast != null)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
            }

            //slow is before the midpoint in the list, so we split the 
            //list in two halves from that point.
            frontRef = source;
            backRef = slow.next;
            slow.next = null;
        }
    }

    // pour trier une liste chaînée.
    static Node MergeList(Node a, Node b)
    {
        Node result = null;

        // Cas de base lorsque l'une des deux moitiés est null.
        if (a == null)
            return b;
        else if (b == null)
            return a;
        // Comparer les données dans les deux moitiés et stocker le plus petit dans result,
        // puis appeler récursivement la fonction MergeList pour le nœud suivant dans result.
        if (a.data <= b.data)
        {
            result = a;
            result.next = MergeList(a.next, b);
        }
        else
        {
            result = b;
            result.next = MergeList(a, b.next);
        }
        // Retourner la liste résultante.
        return result;
    }

    //Cette fonction va diviser , trier et apres fusionner 
    public Node mergeSort(Node head)
    {
        if (head == null || head.next == null)
            return head;

        SplitList(head, out Node a, out Node b);

        a = mergeSort(a);
        b = mergeSort(b);

        //calling the function to merge both halves.
        return MergeList(a, b);
    }

}