using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Regiment : MonoBehaviour
{

    public float regimentHealth;
    public float regimentMaxHealth;
    public HealthTracker healthTracker;

    public string typeRegiment;
    public List<Unit> listUnite {get;set;}
    public bool dead = false;
    public Material blason;
    public Material couleur;
    void Start()
    {
        // Ajoute le régiment dans la liste pour pouvoir etre utilisé
        RegimentSelectionManager.Instance.allRegimentsList.Add(gameObject);


        //Création des unités du régiments
        listUnite = new List<Unit>();
        for (int i = 0; i < 10; i++)
        {
            listUnite.Add(new Unit(typeRegiment));
        }
        
        regimentMaxHealth = listUnite[0].model.vie;
        regimentHealth = regimentMaxHealth;
        // Création des stats du régiments
        //regimentHealth = regimentMaxHealth;
        
        UpdateHealthUI() ;

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
    public void TakeDamage(int damageToInflict)
    {
        regimentHealth -= damageToInflict;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthTracker.UpdateSliderValue(regimentHealth,regimentMaxHealth);
        if (regimentHealth <= 0)
        {
            // Dying Logic
            dead = true;
            Update();
        }
    }

    private void OnDestroy()
    {
        RegimentSelectionManager.Instance.regimentsSelected.Remove(gameObject);
        RegimentSelectionManager.Instance.allRegimentsList.Remove(gameObject);
        Destroy(gameObject);
        
    }

}
