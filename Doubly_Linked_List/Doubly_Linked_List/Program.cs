// le but de l'exercice est de trier de façon croissant et decroissant 
// en utilisant marge sort 



public class Node
{
    public int data;
    public Node prev, next;
    public Node(int d) { data = d; prev = next = null; }
}

public class DoublyLinkedList
{
    public Node head;


    // cette fonction sert à diviser la liste en deux parties 
    public Node Split(Node head)
    {
        Node fast = head, slow = head;
        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        Node temp = slow.next;
        slow.next = null;
        return temp;
    }

    // Cette fontion permet de fusinner les deux listes 
    public Node Merge(Node first, Node second)
    {
        if (first == null) return second;
        if (second == null) return first;

        if (first.data < second.data)
        {
            first.next = Merge(first.next, second);
            first.next.prev = first;
            first.prev = null;
            return first;
        }
        else
        {
            second.next = Merge(first, second.next);
            second.next.prev = second;
            second.prev = null;
            return second;
        }
    }

   // cet fonction permet de diviser et fusionner la liste
    public Node MergeSort(Node node)
    {
        if (node == null || node.next == null)
            return node;

        Node second = Split(node);

        node = MergeSort(node);
        second = MergeSort(second);

        return Merge(node, second);
    }

    // Function to reverse the doubly linked list
    public void Reverse()
    {
        Node temp = null;
        Node current = head;

        while (current != null)
        {
            temp = current.prev;
            current.prev = current.next;
            current.next = temp;
            current = current.prev;
        }

        if (temp != null)
        {
            head = temp.prev;
        }
    }

    // Function to print nodes in a given doubly linked list
    public void PrintList(Node node)
    {
        while (node != null)
        {
            Console.Write(node.data + " ");
            node = node.next;
        }
        Console.WriteLine();
    }


    // trier dans les deux ordres et les afficher 
    public void SortDoubly()
    {
        head = MergeSort(head);
        PrintList(head);
        Reverse();
        PrintList(head);
    }

    // permet d'inserer les données 
    public void Push(int new_data)
    {
        Node new_Node = new Node(new_data);

        new_Node.next = head;
        new_Node.prev = null;

        if (head != null)
            head.prev = new_Node;

        head = new_Node;
    }
}

class Program
{
    static void Main()
    {
        DoublyLinkedList dll = new DoublyLinkedList();
        int[] values = { 7, 3, 5, 2, 6, 4, 1, 8 };

        foreach (int value in values)
        {
            dll.Push(value);
        }

        dll.SortDoubly();
    }
}
