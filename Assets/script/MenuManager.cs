using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Référence au bouton Restart
    [SerializeField] private Button restartButton;

    // Référence au PenduManager
    [SerializeField] private PenduManager penduManager;

    void Start()
    {
        // S'assurer que le bouton est caché au début
        restartButton.gameObject.SetActive(false);

        // Ajouter un listener pour le clic sur le bouton
        restartButton.onClick.AddListener(RestartGame);
    }

    // Méthode pour afficher le bouton Restart
    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    // Méthode appelée quand on clique sur Restart
    private void RestartGame()
    {
        // Cacher le bouton Restart
        restartButton.gameObject.SetActive(false);

        // Appeler la méthode de redémarrage du PenduManager
        penduManager.ResetGame();
    }
}