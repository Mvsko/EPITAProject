using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class ChoiceButtonScript : MonoBehaviour
{

    public ItemIconScript IconVisaul;

    
    void Start()
    {        
        
    }
    void Update()
    {
        //Active le bouton delete
        transform.GetChild(3).gameObject.SetActive(true);
        
    }
    
    public void HandleInputData(int id)
    {

        
        //Met le bon icon
        IconVisaul.IconManage(id);
        
    }

    
    
}
