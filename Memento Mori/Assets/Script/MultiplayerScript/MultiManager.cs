using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MultiManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public MultiplayerBattleStart battleStart;

    private void Start()
    {
        if (battleStart == null)
        {
            Debug.LogError("MultiplayerBattleStart non assigné dans l'inspecteur.");
        }
    }

    public void OnPlayerJoinedRoom()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab is not assigned.");
            return;
        }

        if (battleStart == null)
        {
            Debug.LogError("BattleStart is not assigned.");
            return;
        }

        if (PhotonNetwork.LocalPlayer == null)
        {
            Debug.LogError("PhotonNetwork.LocalPlayer is not initialized.");
            return;
        }

        if (PhotonNetwork.LocalPlayer.TagObject == null)
        {
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
            string team = (PhotonNetwork.CurrentRoom.PlayerCount == 1) ? "Team1" : "Team2";
            MultiScenePlayer playerScript = player.GetComponent<MultiScenePlayer>();

            if (playerScript != null)
            {
                playerScript.team = team;
                PhotonNetwork.LocalPlayer.TagObject = player;
                battleStart.InitializePlayerRegiments(team);
            }
            else
            {
                Debug.LogError("MultiScenePlayer script is not found on the instantiated player prefab.");
            }
        }
    }
}
