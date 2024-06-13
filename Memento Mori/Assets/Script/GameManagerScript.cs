using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public OpinionManager opinionManager;
    public GameObject GameOverMenu;
    private bool IsNotGameOver = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsNotGameOver && opinionManager.MilitaryOpinion <=0 || opinionManager.SenatOpinion <=0 || opinionManager.RegionOpinion <=0)
        {
            GameOverMenu.SetActive(true);
            IsNotGameOver = false;
        }
    }
}
