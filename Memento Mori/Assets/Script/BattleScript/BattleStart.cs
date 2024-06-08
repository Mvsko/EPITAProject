using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleStart : MonoBehaviour
{
    public SpawnRegiment spawnRegiment;
    public GameObject CameraController;

    public PlayerInventory Inventory;

    public GameObject Maps;

    public void BattleProvinceStart(int mapID)
    {
       for (int i = 0; i <  Maps.transform.childCount; i++)
       {
            Maps.transform.GetChild(i).gameObject.SetActive(mapID == i);
            
       }

       foreach (string regiment in Inventory.RegimentsOwned)
       {
        if (regiment != "None")
        {
            spawnRegiment.SpawnRegimentMethod(regiment);
        }
       }
       
        
    }
}
