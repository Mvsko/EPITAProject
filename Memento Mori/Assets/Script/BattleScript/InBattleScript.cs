using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBattleScript : MonoBehaviour
{
    public RegimentSelectionManager regimentSelectionManager;
    public BattleManager battleManager;
    public GameObject GameVictoryMenu;
    public GameObject GameDMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameVictoryMenu.SetActive(false);
        GameDMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (regimentSelectionManager.allEnemyRegimentsList.Count==0)
        {
            
            GameVictoryMenu.SetActive(true);
            //battleManager.AfterMatch(true);
        }
        else
        {
            if(regimentSelectionManager.allRegimentsList.Count==0)
            {
                
                GameDMenu.SetActive(true);
                //battleManager.AfterMatch(true);
            }
            else
            {
                int i = 0;
                bool res = true;
                while(res && i<regimentSelectionManager.allEnemyRegimentsList.Count)
                {
                    if(regimentSelectionManager.allEnemyRegimentsList[i].GetComponent<Regiment>().moral > 5)
                    {
                        res = false;
                    }
                    i+=1;
                }
                if(res)
                {
                     
                    GameVictoryMenu.SetActive(true);
                    //battleManager.AfterMatch(true); 
                }   
            }
            
        }
        
    }
}
