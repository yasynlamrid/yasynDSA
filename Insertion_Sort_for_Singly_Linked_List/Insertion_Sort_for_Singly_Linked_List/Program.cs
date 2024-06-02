//Le but de cet exercice est de trier une liste chaînée simplement
//liée en utilisant l'algorithme de tri par insertion


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode InsertionSort(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        // Pointeur pour la liste triée
        ListNode sortedList = new ListNode(0); // Dummy head

        while (head != null)
        {
            ListNode current = head;
            head = head.next; // Avancer dans la liste originale

            // Trouver l'emplacement où insérer le nœud courant
            ListNode prev = sortedList;
            while (prev.next != null && prev.next.val < current.val)
            {
                prev = prev.next;
            }

            // Insérer le nœud courant dans la liste triée
            current.next = prev.next;
            prev.next = current;
        }

        return sortedList.next; // Retourner la liste triée sans le dummy head
    }

    public static void Main(string[] args)
    {
        // Exemple d'utilisation
        ListNode head = new ListNode(30, new ListNode(23, new ListNode(28, new ListNode(30, new ListNode(11, new ListNode(14, new ListNode(19, new ListNode(16, new ListNode(21, new ListNode(25))))))))));
        Solution solution = new Solution();
        ListNode sortedHead = solution.InsertionSort(head);

        // Afficher la liste triée
        while (sortedHead != null)
        {
            Console.Write(sortedHead.val + " ");
            sortedHead = sortedHead.next;
        }
    }
}
