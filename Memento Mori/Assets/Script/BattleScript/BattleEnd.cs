using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnd : MonoBehaviour
{
    public GameObject InventoryGameobject;

    private List<string> regimentsKilledEnd; 

    public Behaviour canvas;
    public OpinionManager opinionManager;
    
    public RecapitulatifScript recap;
    public void BattleProvinceEnd()
    {
        
        canvas.enabled = ! canvas.enabled;
        PlayerInventory Inventory = InventoryGameobject.GetComponent<PlayerInventory>();
        regimentsKilledEnd = RegimentSelectionManager.Instance.regimentsOwnedKilled;
        int indexRK = regimentsKilledEnd.Count-1;
        opinionManager.MilitaryOpinion -= regimentsKilledEnd.Count*5;
        recap.DeadRegimentOwner += regimentsKilledEnd.Count;


        while(regimentsKilledEnd.Count >0 || indexRK >= 0)
        {
            bool regimentremove = false;
            int indexInventory = Inventory.RegimentsOwned.Count-1;

            while(regimentremove == false && indexInventory >=0)
            {
                if(regimentsKilledEnd[indexRK]== Inventory.RegimentsOwned[indexInventory])
                {
                    Debug.Log($"Regiment {Inventory.RegimentsOwned[indexInventory]} est retiré");
                    regimentremove = true;
                    Inventory.RemoveRegimentInventory(indexInventory);
                    regimentsKilledEnd.RemoveAt(indexRK);
                }
                else
                {
                    indexInventory -=1;
                }
            }
            indexRK-=1;
        }

        RegimentSelectionManager.Instance.ClearRegiment();
        
    }

    
}

