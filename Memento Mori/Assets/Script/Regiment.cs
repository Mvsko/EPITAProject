using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Regiment : MonoBehaviour
{
     public List<Unit> listUnite {get;set;}
    public bool dead = false;
    void Start()
    {
        // Ajoute le régiment dans la liste pour pouvoir etre utilisé
        RegimentSelectionManager.Instance.allRegimentsList.Add(gameObject);
         listUnite = new List<Unit>();
        for (int i = 0; i < 100; i++)
        {
            listUnite.Add(new Unit("legionnaire"));
        }
    }

    void Update ()
    {
        if(dead)
        {
            listUnite.Clear();
        }
        if(listUnite.Count == 0)
        {
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        RegimentSelectionManager.Instance.allRegimentsList.Remove(gameObject);
        Destroy(gameObject);
        
    }

}
