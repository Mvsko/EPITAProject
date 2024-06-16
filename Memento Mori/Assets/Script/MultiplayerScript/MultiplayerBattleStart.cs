using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MultiplayerBattleStart : MonoBehaviourPun
{
    public SpawnRegiment spawnRegiment;
    public GameObject CameraController;

    private List<string> romanRegiments = new List<string>
    {
        "Hastati", "Triarii", "Frondeur", "Equites", "BalisteRomaine", "Legat"
    };

    private List<string> persianRegiments = new List<string>
    {
        "ArcherPerse", "BalistePerse", "Kardake", "Melophore", "MelophoreMede", "Sakas"
    };

    public void InitializePlayerRegiments(string team)
    {
        if (team == "Team1")
        {
            Debug.Log("Team1 - MultiplayerBattleStart");
            foreach (string regiment in romanRegiments)
            {
                spawnRegiment.SpawnRegimentMethod(regiment);
            }
        }
        else if (team == "Team2")
        {
            Debug.Log("Team2 - MultiplayerBattleStart");
            foreach (string regiment in persianRegiments)
            {
                spawnRegiment.SpawnRegimentMethod(regiment);
            }
        }
        spawnRegiment.ResetSpawnRegimentPlacement();
    }
}
