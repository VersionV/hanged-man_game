using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;
using TMPro;

public class PenduManager : MonoBehaviour
{
    // Liste des mots possibles pour le jeu
    [SerializeField] private List<string> motsPossibles = new List<string>() { "UNITY", "PENDU", "JEU", "PROGRAMMATION" };

    // Le mot que le joueur doit deviner
    private string motActuel;

    // Le mot affich� avec les lettres devin�es et les tirets
    private string motAffiche;

    // Nombre de parties de l'�pouvantail affich�es
    private int scarecrowPart = 0;

    // Nombre d'erreurs restantes avant la d�faite
    private int tentativesRestantes = 8;

    // Lettres d�j� essay�es par le joueur
    private string lettresDevinees = "";

    // G�re l'affichage de l'�pouvantail
    [SerializeField] private scarecrowManager scarecrowManager;

    // Contient tous les boutons des lettres
    [SerializeField] private GameObject buttonContainer;

    // S'affiche quand le joueur perd
    [SerializeField] private GameObject gameOver;

    // Affiche le mot � deviner (avec tirets)
    [SerializeField] private TextMeshProUGUI texteMotADeviner;

    // Gestionnaire de menu pour g�rer le bouton de red�marrage
    [SerializeField] private MenuManager menuManager;

    // R�f�rence au bouton de red�marrage
    [SerializeField] private GameObject restartButton;

    [SerializeField] private GameObject boutonPause;

    // Initialise le jeu
    void Start()
    {
        ChoisirMot();
        MettreAJourAffichageMot();
    }

    // Choisit un mot au hasard dans la liste
    private void ChoisirMot()
    {
        int index = Random.Range(0, motsPossibles.Count);
        motActuel = motsPossibles[index].ToUpper();
        GenererMotAffiche();
        Debug.Log(motActuel);
    }

    // Cr�e la version initiale du mot � afficher (avec tirets et une lettre visible)
    private void GenererMotAffiche()
    {
        StringBuilder sb = new StringBuilder(motActuel.Length);
        int indexLettreVisible = Random.Range(0, motActuel.Length);
        for (int i = 0; i < motActuel.Length; i++)
        {
            if (i == indexLettreVisible)
            {
                sb.Append(motActuel[i]);
            }
            else
            {
                sb.Append('_');
            }
        }
        motAffiche = sb.ToString();
    }

    // Met � jour l'affichage du mot � deviner
    private void MettreAJourAffichageMot()
    {
        texteMotADeviner.text = string.Join(" ", motAffiche.ToCharArray());
    }

    // V�rifie si la lettre est dans le mot et met � jour l'affichage
    public bool VerifierLettre(char lettre)
    {
        bool lettreCorrecte = false;
        StringBuilder nouveauMotAffiche = new StringBuilder(motAffiche);
        for (int i = 0; i < motActuel.Length; i++)
        {
            if (motActuel[i] == lettre && motAffiche[i] == '_')
            {
                nouveauMotAffiche[i] = lettre;
                lettreCorrecte = true;
            }
        }
        motAffiche = nouveauMotAffiche.ToString();
        MettreAJourAffichageMot();
        return lettreCorrecte;
    }

    // Appel� quand le joueur choisit une lettre
    public void lettreChoisies(string lettre)
    {
        JouerTour(lettre[0]);
    }

    // G�re un tour de jeu
    public bool JouerTour(char lettre)
    {
        lettre = char.ToUpper(lettre);
        if (lettresDevinees.Contains(lettre))
        {
            return false;
        }
        lettresDevinees += lettre;

        DesactiverBoutonLettre(lettre);

        if (VerifierLettre(lettre))
        {
            if (motAffiche == motActuel)
            {
                FinDePartieVictoire();
            }
            return true;
        }
        else
        {   
            scarecrowManager.afficherPartie(scarecrowPart);
            Debug.Log("afficherElement " + scarecrowPart);
            tentativesRestantes--;
            scarecrowPart++;

            if (tentativesRestantes > 0)
            {
                Debug.Log("il te reste " + tentativesRestantes + " tentatives");
            }
            else
            {
                FinDePartieDefaite();
            }
            return false;
        }
    }

    // D�sactive le bouton de la lettre choisie
    private void DesactiverBoutonLettre(char lettre)
    {
        Button[] boutons = buttonContainer.GetComponentsInChildren<Button>();
        foreach (Button bouton in boutons)
        {
            TextMeshProUGUI texteBouton = bouton.GetComponentInChildren<TextMeshProUGUI>();
            if (texteBouton != null && texteBouton.text.ToUpper() == lettre.ToString())
            {
                bouton.interactable = false;
                break;
            }
        }
    }

    // G�re la fin de partie en cas de victoire
    private void FinDePartieVictoire()
    {
        Debug.Log("F�licitations ! Vous avez gagn� !");
        buttonContainer.SetActive(false);
        // D�sactive le bouton pause
        boutonPause.SetActive(false);
        // Affiche le bouton restart
        menuManager.ShowRestartButton();
        restartButton.SetActive(true);
    }

    // G�re la fin de partie en cas de d�faite
    /// <summary>
    /// La m�thode de la fin
    /// </summary>
    private void FinDePartieDefaite()
    {
        buttonContainer.SetActive(false);
        Debug.Log("Vous avez Perdu");
        gameOver.SetActive(true);
        texteMotADeviner.text = motActuel; // Affiche le mot complet � la fin
        menuManager.ShowRestartButton();
        restartButton.SetActive(true);
        // D�sactive le bouton pause
        boutonPause.SetActive(false);
    }

    public void ResetGame()
    {
        // R�initialiser les variables
        scarecrowPart = 0;
        tentativesRestantes = 8;
        lettresDevinees = "";

        // Rechoisir un nouveau mot
        ChoisirMot();

        // Mettre � jour l'affichage
        MettreAJourAffichageMot();

        // R�activer les boutons des lettres
        ReactiverTousLesBoutons();

        // Cacher l'�cran de game over
        gameOver.SetActive(false);

        // R�activer le conteneur de boutons
        buttonContainer.SetActive(true);

        // R�initialiser l'�pouvantail 
        scarecrowManager.ResetScarecrow();

        // Cacher le bouton restart
        restartButton.SetActive(false);

        // R�active le bouton pause
        boutonPause.SetActive(true);
    }

    private void ReactiverTousLesBoutons()
    {
        Button[] boutons = buttonContainer.GetComponentsInChildren<Button>(true);
        foreach (Button bouton in boutons)
        {
            bouton.interactable = true;
        }
    }
}