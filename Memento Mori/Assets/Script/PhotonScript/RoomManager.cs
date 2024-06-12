using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public void CreateRoom(string roomName)
    {
        RoomOptions options = new RoomOptions { MaxPlayers = 2 }; // Ajustez selon vos besoins
        PhotonNetwork.CreateRoom(roomName, options);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("MultiScene"); // Remplacez par le nom de votre scène de jeu
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room. Creating a new room.");
        CreateRoom("Room" + Random.Range(1, 10000));
    }
}