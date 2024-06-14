using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject errorPopup; // Référence à un pop-up d'erreur dans l'UI

    // Méthode pour créer une salle avec un nom unique
    public void CreateRoom()
    {
        string roomName = "Room" + Random.Range(1, 10000);
        RoomOptions options = new RoomOptions { MaxPlayers = 2 }; // Ajustez selon vos besoins
        PhotonNetwork.CreateRoom(roomName, options); // Crée une salle avec un nom unique
    }

    // Méthode pour rejoindre une salle de manière aléatoire
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    // Callback lorsque le joueur rejoint une salle
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("MultiScene"); // Remplacez par le nom de votre scène de jeu
    }

    // Callback lorsque la jonction aléatoire échoue
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join random room.");
        ShowErrorPopup("No rooms available. Please create a new room.");
    }

    // Méthode pour quitter le lobby
    public void ExitLobby()
    {
        PhotonNetwork.LeaveRoom();
        // Laisser la scène gérer la navigation
    }

    // Affiche le pop-up d'erreur
    private void ShowErrorPopup(string message)
    {
        if (errorPopup != null)
        {
            errorPopup.SetActive(true);
            errorPopup.GetComponentInChildren<Text>().text = message;
        }
    }

    // Ferme le pop-up d'erreur
    public void CloseErrorPopup()
    {
        if (errorPopup != null)
        {
            errorPopup.SetActive(false);
        }
    }

    // Callback lorsque le joueur quitte une salle
    public override void OnLeftRoom()
    {
        Debug.Log("Left room.");
        if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.PlayerCount == 0)
        {
            PhotonNetwork.CurrentRoom.RemovedFromList = true;
        }

        // Si le joueur est dans MultiScene, retourner à StartScene
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            PhotonNetwork.LoadLevel("StartScene");
        }
    }
}