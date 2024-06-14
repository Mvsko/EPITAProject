using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBattleScript : MonoBehaviour
{
    public RegimentSelectionManager regimentSelectionManager;
    public BattleManager battleManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (regimentSelectionManager.allEnemyRegimentsList.Count==0)
        {
            Debug.Log("AfterMatch");
            battleManager.AfterMatch(true);
        }
    }
}
