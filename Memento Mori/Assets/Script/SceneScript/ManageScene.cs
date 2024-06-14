using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public GameObject globalLobby;
    public GameObject multiLobby;


    public void MoveToScene(int sceneID)
    {
       SceneManager.LoadScene(sceneID);
    }

    public void ShowMultiplayerLobby()
    {
        globalLobby.SetActive(false);
        multiLobby.SetActive(true);
    }

    public void ShowGlobalLobby()
    {
        globalLobby.SetActive(true);
        multiLobby.SetActive(false);
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
