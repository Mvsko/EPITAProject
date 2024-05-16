using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconScript : MonoBehaviour
{
    
   
    public void IconManage(int id)
    {
        
        //Met le background de la card
        transform.GetChild(0).gameObject.SetActive(id!=0);
        transform.GetChild(1).gameObject.SetActive(id!=0);
        transform.GetChild(2).gameObject.SetActive(id!=0);
        //Active et Desactive les bons icons
        for (int i = 3; i < transform.childCount; i++)
        {   
            // Le "+2" est pour eviter d'interférer avec le background du visual
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
