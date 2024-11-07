using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cette classe repr�sente une partie de l'�pouvantail (comme la t�te, les bras, etc.)
public class ScarecrowPart
{
    // La partie visuelle (le GameObject dans Unity)
    public GameObject partObject;

    // Pour savoir si la partie est visible ou non
    public bool estVisible;

    // Le nom de la partie (pour mieux s'y retrouver)
    public string nomPartie;

    // Le constructeur - c'est comme une recette pour cr�er une nouvelle partie
    public ScarecrowPart(GameObject objet, string nom)
    {
        partObject = objet;       // On assigne l'objet
        nomPartie = nom;          // On lui donne un nom
        estVisible = false;       // Au d�but, la partie est cach�e
    }
}