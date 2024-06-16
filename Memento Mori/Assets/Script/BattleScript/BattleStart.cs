using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class BattleStart : MonoBehaviour
{
    public SpawnRegiment spawnRegiment;
    public GameObject CameraController;

    public PlayerInventory Inventory;

    public GameObject Maps;

    

    public (string,Vector3)[,] EnemyTable = new (string,Vector3)[10,6]
    {

        {("Bretteur",new Vector3(297f,7f,290f)),("Chasseur",new Vector3(303f,7f,290f)),("Chasseur",new Vector3(363f,7f,246f)),("GuerrierNu",new Vector3(359f,7f,241f)),("GuerrierNu",new Vector3(368f,7f,242f)),("GuerrierNu",new Vector3(304f,7f,284f))},


        {("GuerrierNu",new Vector3(416f,4.50f,232f)),("Chasseur",new Vector3(422f,4.5f,233f)),("Chasseur",new Vector3(433f,4f,233f)),("Bretteur",new Vector3(429f,3.5f,230f)),("Bretteur",new Vector3(438f,4f,230f)),("GuerrierNu",new Vector3(429f,4.5f,226f))},


        {("GuerrierNu",new Vector3(422.12f,2.9f,437.56f)),("Chasseur",new Vector3(429.75f,2f,447f)),("Onagre",new Vector3(444f,2f,447f)),("Bretteur",new Vector3(438,3f,437f)),("Bretteur",new Vector3(448f,3.5f,436f)),("Bretteur",new Vector3(429f,3.8f,437f))},

        {("Chasseur",new Vector3(508f,3f,507f)),("GuerrierNu",new Vector3(514f,4.5f,501f)),("Bretteur",new Vector3(474f,2f,465f)),("Bretteur",new Vector3(505f,3.5f,502f)),("Trimarcisia",new Vector3(499f,3.5f,505f)),("Bretteur",new Vector3(481f,2.5f,461f))},

        {("Chasseur",new Vector3(624.2f,3.03f,350f)),("GuerrierNu",new Vector3(629f,4.5f,344f)),("Trimarcisia",new Vector3(652f,2f,340f)),("Bretteur",new Vector3(621f,3.5f,345f)),("GuerrierNu",new Vector3(615f,3.5f,348f)),("Trimarcisia",new Vector3(659f,2.5f,335f))},

        {("Chasseur",new Vector3(478f,8.5f,281f)),("GuerrierNu",new Vector3(483f,10f,281f)),("Trimarcisia",new Vector3(496.5f,7f,278f)),("Bretteur",new Vector3(461.7f,9f,271f)),("GuerrierNu",new Vector3(455.5f,8.9f,275f)),("Bretteur",new Vector3(500f,8f,273.5f))},

        {("Chasseur",new Vector3(588f,7f,331f)),("Onagre",new Vector3(607f,8f,332f)),("GuerrierNu",new Vector3(602f,7.5f,329f)),("Chasseur",new Vector3(598f,7.5f,333f)),("Bretteur",new Vector3(596f,7.5f,327f)),("Bretteur",new Vector3(612f,6.5f,329.5f))},

        {("Bretteur",new Vector3(521f,7f,426f)),("Onagre",new Vector3(551f,8f,417f)),("Bretteur",new Vector3(547f,7.5f,415f)),("Chasseur",new Vector3(530f,8f,428f)),("Bretteur",new Vector3(528f,7.5f,422f)),("Bretteur",new Vector3(555f,6.5f,415f))} , 
    
        {("Bretteur",new Vector3(453f,11f,530f)),("Onagre",new Vector3(473f,9.5f,540f)),("Bretteur",new Vector3(470f,8.5f,532f)),("GuerrierNu",new Vector3(463f,8.5f,531f)),("Chasseur",new Vector3(456f,10.5f,536f)),("Bretteur",new Vector3(478f,8.5f,533f))},

        {("Bretteur",new Vector3(468f,7f,425f)),("Chasseur",new Vector3(492f,9.5f,445f)),("Bretteur",new Vector3(492f,8.5f,442f)),("GuerrierNu",new Vector3(485f,8.5f,441f)),("Trimarcisia",new Vector3(471f,6.5f,432f)),("Bretteur",new Vector3(500f,8.5f,443f))}  
    };


    

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
        Debug.Log(EnemyTable.GetLength(1));
       for (int i = 0; i < EnemyTable.GetLength(1); i++)
       {
        
        spawnRegiment.SpawnEnemyRegimentMethod(EnemyTable[mapID,i].Item1,EnemyTable[mapID,i].Item2);
       }
       
       spawnRegiment.ResetSpawnRegimentPlacement();

       
       
        
    }
}
