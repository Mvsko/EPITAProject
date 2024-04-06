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
    public Material couleur;
    void Start()
    {
        // Ajoute le régiment dans la liste pour pouvoir etre utilisé
        RegimentSelectionManager.Instance.allRegimentsList.Add(gameObject);
        listUnite = new List<Unit>();
        for (int i = 0; i < 100; i++)
        {
            listUnite.Add(new Unit(typeRegiment));
        }

        // Texture du blason
        blason = Resources.Load($"Materials/Blason/BlasonMaterial/{typeRegiment}Blason",typeof(Material)) as Material;
        gameObject.transform.GetChild(8).gameObject.GetComponent<Renderer>().material = blason;

        //Texture du Visuel (Rouge/bleu/marron)
        if(tag == "Team1")
        {
            couleur = Resources.Load("Materials/Rouge", typeof(Material)) as Material;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
        }
        if(tag == "Team2")
        {
            couleur = Resources.Load("Materials/Bleu", typeof(Material)) as Material;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
        }
        if(tag == "Team3")
        {
            couleur = Resources.Load("Materials/Marron", typeof(Material)) as Material;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
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
        RegimentSelectionManager.Instance.regimentsSelected.Remove(gameObject);
        RegimentSelectionManager.Instance.allRegimentsList.Remove(gameObject);
        Destroy(gameObject);
        
    }

}
