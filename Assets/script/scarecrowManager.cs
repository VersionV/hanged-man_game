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
        // On cr�e notre liste
        partiesEpouvantail = new List<ScarecrowPart>();

        // Pour chaque partie dans Unity, on cr�e un nouvel objet ScarecrowPart
        for (int i = 0; i < partieDuPendu.Count; i++)
        {
            string nom = "Partie" + (i + 1); // On donne un nom � chaque partie
            partiesEpouvantail.Add(new ScarecrowPart(partieDuPendu[i], nom));
        }

        // On cache toutes les parties au d�but
        CacherToutesLesParties();
    }

    // Affiche la partie demand�e
    public void afficherPartie(int indexPartie)
    {
        if (indexPartie >= 0 && indexPartie < partiesEpouvantail.Count)
        {
            ScarecrowPart partie = partiesEpouvantail[indexPartie];
            partie.partObject.SetActive(true);
            partie.estVisible = true;
        }
    }

    // Nouvelle m�thode pour cacher toutes les parties
    public void CacherToutesLesParties()
    {
        foreach (ScarecrowPart partie in partiesEpouvantail)
        {
            partie.partObject.SetActive(false);
            partie.estVisible = false;
        }
    }

    // M�thode pour r�initialiser l'�pouvantail
    public void ResetScarecrow()
    {
        CacherToutesLesParties();
    }
}

