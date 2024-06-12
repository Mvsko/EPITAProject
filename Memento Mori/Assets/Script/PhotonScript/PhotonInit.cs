using Photon.Pun;
using UnityEngine;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        // Connect to Photon using the settings specified in the PhotonServerSettings file
        PhotonNetwork.ConnectUsingSettings();
    }

    // Called when the client is connected to the Master Server
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        // Join the default lobby
        PhotonNetwork.JoinLobby();
    }

    // Called when the client has joined a lobby
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }
}