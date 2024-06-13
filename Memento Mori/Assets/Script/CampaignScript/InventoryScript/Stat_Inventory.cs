using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class  PlayerInventory : MonoBehaviour
{

    //Variable Monaitaires
    public int money;      
    public int Income;
    public int Sales;

    //Référence Monaitaire Affichage
    public GameObject IncomePositive;
    public GameObject IncomeNegative;
    public Text moneyText;  
    
    
    // Variable de l'inventaire
    public GameObject Slots;
    public List<string> RegimentsOwned ;

    // Référence Monaitaire des régiments
    private List<string> RegimentType = new List<string>{"None","Hastati", "Triarii", "Frondeur","Equites","BalisteRomaine","Legat"};
    private int HastatiPrice = 1;
    private int TriariiPrice = 1;
    private int FrondeurPrice = 1;
    private int EquitesPrice = 1;
    private int BalistePrice = 1;
    private int LegatPrice= 1;


    void Start()
    {
        // Initialisation des statistiques
        money = 10;
        RegimentsOwned =  new List<string>{"None","None","None","None","None",
                                           "None","None","None","None","None",
                                           "None","None","None","None","None",
                                           "None","None","None","None","None",
                                           "None"
                                           };
        Sales = 0;
        Income = 5;
        AddRegimentInventory(0,1);
        

    }
   
    void Update()
    {   
        // Met à jour l'affichage de l'argent
        if (moneyText != null)              
        {
            moneyText.text = $"{money}";
            if( Income - Sales > 0 )
            {
                IncomePositive.SetActive(true);
                IncomeNegative.SetActive(false);
            }
            else
            {
                if(Income - Sales < 0)
                {
                    IncomePositive.SetActive(false);
                    IncomeNegative.SetActive(true);
                }
                else
                {
                    IncomeNegative.SetActive(false);
                    IncomePositive.SetActive(false);
                }   
            }
        }
     }
    private int RegimentTypePrice (string typeString)
    {
        if (typeString == "Hastati")
        {
            return HastatiPrice;
        }
        if (typeString == "Triarii")
        {
            return TriariiPrice;
        }
        if (typeString == "Frondeur")
        {
            return FrondeurPrice;
        }
        if (typeString == "Equites")
        {
            return EquitesPrice;
        }
        if (typeString == "Baliste")
        {
            return BalistePrice;
        }
        if (typeString == "Legat")
        {
            return LegatPrice;
        }
        return 0;
    }
   
    public bool AddRegimentInventory(int SlotID, int typeID)
    {
        SlotManager slot = Slots.transform.GetChild(SlotID).gameObject.transform.GetComponent<SlotManager>();
        int price = RegimentTypePrice(RegimentType[typeID]);
        
        if(money >= price && SlotID < RegimentsOwned.Count && RegimentsOwned[SlotID]=="None")
        {
            money = money - price;
            //Correspond à la solde du régiment
            Sales += 1;     
            RegimentsOwned[SlotID] = RegimentType[typeID];
            // Met à jour l'icône correspondante
            slot.IconManage(typeID);
            return true;
        }
        return false;
    }

     // Méthode pour enlever un régiment de l'inventaire
     public bool RemoveRegimentInventory(int SlotID)
     {
        if(RegimentsOwned[SlotID] != "None")
        {
            SlotManager slot = Slots.transform.GetChild(SlotID).gameObject.transform.GetComponent<SlotManager>();
            RegimentsOwned[SlotID] = "None";
            slot.IconManage(0);
            Sales -= 1;
            return true;
        }
        return false;
        
     }
}
