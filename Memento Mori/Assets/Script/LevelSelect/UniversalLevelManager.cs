using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UniversalLevelManager : MonoBehaviour {

 // Méthode pour retourner à la scène de sélection de niveau

    public void GoBackToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }
}