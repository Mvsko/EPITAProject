using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class LevelManager : MonoBehaviour {
 
 // Méthode pour retourner à la scène de sélection de niveau
	public void GoBackToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }
}