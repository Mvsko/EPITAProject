using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Regiment : MonoBehaviour
{
    public string typeRegiment;
    public List<Unit> listUnite {get;set;}
    public bool dead = false;
    public Material blason;
    void Start()
    {
        // Ajoute le régiment dans la liste pour pouvoir etre utilisé
        RegimentSelectionManager.Instance.allRegimentsList.Add(gameObject);
        listUnite = new List<Unit>();
        for (int i = 0; i < 100; i++)
        {
            listUnite.Add(new Unit(typeRegiment));
        }
        blason = Resources.Load($"Materials/Blason/BlasonMaterial/{typeRegiment}Blason",typeof(Material)) as Material;
        
        

        gameObject.transform.GetChild(8).gameObject.GetComponent<Renderer>().material = blason;
        
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
        RegimentSelectionManager.Instance.regimentsSelected.Remove(gameObject);
        RegimentSelectionManager.Instance.allRegimentsList.Remove(gameObject);
        Destroy(gameObject);
        
    }

}
