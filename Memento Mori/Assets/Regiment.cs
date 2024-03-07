using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regiment : MonoBehaviour
{
    public List<Unit> listUnite {get;set;}
    public bool dead = false;
    void Start()
    {
        listUnite = new List<Unit>();
        for (int i = 0; i < 100; i++)
        {
            listUnite.Add(new Unit("legionnaire"));
        }
    }

    
    void Update()
    {
        if(dead)
        {
            listUnite.Clear();
        }
        if(listUnite.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
