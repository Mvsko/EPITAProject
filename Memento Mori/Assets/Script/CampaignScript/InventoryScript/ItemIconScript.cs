using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconScript : MonoBehaviour
{
    // Référence à l'inventaire du joueur
    public PlayerInventory playerInventory;

    // Type de régiment actuellement sélectionné
    public string type = null;

    // Méthode pour déterminer le type de régiment en fonction de l'ID
    public void regimenttypeInfo (int id)
    {
        // Associe chaque ID à un type de régiment spécifique
         if (id ==1)
        {
            type = "Hastati";
        }
        if (id ==2)
        {
            type = "Triarii";
        }
        if (id ==3)
        {
            type = "Frondeur";
        }
        if(id ==4)
        {
            type = "Equites";
        }
        if(id ==5)
        {
            type = "Baliste";
        }
        if(id ==6)
        {
            type = "Legat";
        }
    }

    // Méthode pour gérer l'icône en fonction de l'ID
    public void IconManage(int id)
    {
        // Si l'ID est 0 et qu'un type est actuellement sélectionné, supprime le régiment de l'inventaire
        if(id == 0 && type != null)
        {
            playerInventory.RemoveRegimentInventory(type);
            type = null;
        }

         // Détermine le type de régiment en fonction de l'ID
         regimenttypeInfo(id);

        // Active ou désactive le fond de la carte sur le slot
        transform.GetChild(0).gameObject.SetActive(id!=0);
        transform.GetChild(1).gameObject.SetActive(id!=0);
        transform.GetChild(2).gameObject.SetActive(id!=0);


        // Active ou désactive les éléments enfants en fonction de l'ID
        for (int i = 3; i < transform.childCount; i++)
        {   
             // L'indice "+2" évite d'interférer avec les éléments d'arrière-plan du visuel
            if(id+2 == i)
            {
                
                transform.GetChild(i).gameObject.SetActive(true);
                
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
       
    }
}
