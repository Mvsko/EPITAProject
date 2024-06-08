using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    
    // Référence à l'inventaire du joueur
    public PlayerInventory playerInventory;

    public GameObject IconVisaul;
    public int SlotID;

    // Méthode pour gérer l'icône en fonction de l'ID
    public void IconManage(int id)
    {   
        // Active ou désactive le fond de la carte sur le slot
        IconVisaul.transform.GetChild(0).gameObject.SetActive(id!=0);
        IconVisaul.transform.GetChild(1).gameObject.SetActive(id!=0);
        IconVisaul.transform.GetChild(2).gameObject.SetActive(id!=0);


        // Active ou désactive les éléments enfants en fonction de l'ID
        for (int i = 3; i <  IconVisaul.transform.childCount; i++)
        {   
             // L'indice "+2" évite d'interférer avec les éléments d'arrière-plan du visuel
            if(id+2 == i)
            {
                
                IconVisaul.transform.GetChild(i).gameObject.SetActive(true);
                
            }
            else
            {
                IconVisaul.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
       
    } 

    

    
    public void RemoveChoiceButton()
    {
        
        playerInventory.RemoveRegimentInventory(SlotID);
    }
    
    // Méthode pour gérer la sélection d'un type de régiment
    public void HandleInputData(int Typeid)
    {
        
        playerInventory.AddRegimentInventory(SlotID,Typeid);
    }
}
