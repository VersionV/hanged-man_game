using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // R�f�rence au bouton Restart
    [SerializeField] private Button restartButton;

    // R�f�rence au PenduManager
    [SerializeField] private PenduManager penduManager;

    void Start()
    {
        // S'assurer que le bouton est cach� au d�but
        restartButton.gameObject.SetActive(false);

        // Ajouter un listener pour le clic sur le bouton
        restartButton.onClick.AddListener(RestartGame);
    }

    // M�thode pour afficher le bouton Restart
    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    // M�thode appel�e quand on clique sur Restart
    private void RestartGame()
    {
        // Cacher le bouton Restart
        restartButton.gameObject.SetActive(false);

        // Appeler la m�thode de red�marrage du PenduManager
        penduManager.ResetGame();
    }
}