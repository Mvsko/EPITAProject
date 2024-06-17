using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignEscapeScript : MonoBehaviour
{

    public GameObject menu;
   public Behaviour canvas;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)&&canvas.enabled )
        {
            menu.SetActive(true);
        }
    }
}
