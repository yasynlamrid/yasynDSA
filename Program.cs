using System;

public class Solution
{
    public static int Tour(int[] petrol, int[] distance, int N)
    {
        int start = 0; // le point de depart 
        int deficit = 0; // Utilisée pour cumuler le manque de carburant 
        int surplus = 0; //La quantité de carburant disponible 

        for (int i = 0; i < N; i++)
        {
            // Mise à jour du surplus de carburant
            surplus += petrol[i] - distance[i];

            // Si le surplus est négatif, on ne peut pas continuer à partir de l'actuel point de départ
            if (surplus < 0)
            {
                // Mettre à jour le point de départ
                start = i + 1;
                // Ajouter le surplus au déficit total
                deficit += surplus;
                // Réinitialiser le surplus
                surplus = 0;
            }
        }

        // Vérifier si le total du surplus et du déficit est suffisant pour compléter le tour
        return (surplus + deficit >= 0) ? start : -1;
    }

    public static void Main(string[] args)
    {
        int N = 4;
        int[] petrol = { 4, 6, 7, 4 };
        int[] distance = { 6, 5, 3, 5 };

        int startPoint = Tour(petrol, distance, N);
        Console.WriteLine(startPoint); // Affiche 1
    }
}
