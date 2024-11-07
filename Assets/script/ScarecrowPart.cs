using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cette classe représente une partie de l'épouvantail (comme la tête, les bras, etc.)
public class ScarecrowPart
{
    // La partie visuelle (le GameObject dans Unity)
    public GameObject partObject;

    // Pour savoir si la partie est visible ou non
    public bool estVisible;

    // Le nom de la partie (pour mieux s'y retrouver)
    public string nomPartie;

    // Le constructeur - c'est comme une recette pour créer une nouvelle partie
    public ScarecrowPart(GameObject objet, string nom)
    {
        partObject = objet;       // On assigne l'objet
        nomPartie = nom;          // On lui donne un nom
        estVisible = false;       // Au début, la partie est cachée
    }
}