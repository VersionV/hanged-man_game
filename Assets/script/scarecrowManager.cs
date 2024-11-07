using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarecrowManager : MonoBehaviour
{
    // La liste des parties dans Unity
    [SerializeField] List<GameObject> partieDuPendu;

    // Notre nouvelle liste qui utilisera le constructeur
    private List<ScarecrowPart> partiesEpouvantail;

    void Start()
    {
        // On crée notre liste
        partiesEpouvantail = new List<ScarecrowPart>();

        // Pour chaque partie dans Unity, on crée un nouvel objet ScarecrowPart
        for (int i = 0; i < partieDuPendu.Count; i++)
        {
            string nom = "Partie" + (i + 1); // On donne un nom à chaque partie
            partiesEpouvantail.Add(new ScarecrowPart(partieDuPendu[i], nom));
        }

        // On cache toutes les parties au début
        CacherToutesLesParties();
    }

    // Affiche la partie demandée
    public void afficherPartie(int indexPartie)
    {
        if (indexPartie >= 0 && indexPartie < partiesEpouvantail.Count)
        {
            ScarecrowPart partie = partiesEpouvantail[indexPartie];
            partie.partObject.SetActive(true);
            partie.estVisible = true;
        }
    }

    // Nouvelle méthode pour cacher toutes les parties
    public void CacherToutesLesParties()
    {
        foreach (ScarecrowPart partie in partiesEpouvantail)
        {
            partie.partObject.SetActive(false);
            partie.estVisible = false;
        }
    }

    // Méthode pour réinitialiser l'épouvantail
    public void ResetScarecrow()
    {
        CacherToutesLesParties();
    }
}

