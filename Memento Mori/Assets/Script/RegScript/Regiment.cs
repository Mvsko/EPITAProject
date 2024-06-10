using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Regiment : MonoBehaviour
{

    public float regimentHealth;            // Points de vie actuels du régiment
    public float regimentMaxHealth;         // Points de vie maximum du régiment

    // Référence au HealthTracker pour mettre à jour l'interface de la vie
    public HealthTracker healthTracker;

    public string typeRegiment;
    public Unit unit {get;set;}      // Liste des unités composant ce régiment
    public bool dead = false;
    public bool Removecheck = false;
    public Material blason;                     // Matériel du blason du régiment
    public Material couleur;                     // Matériel de couleur du régiment

    public bool IAEnabled = true;
    void Start()
    {
        // Ajoute le régiment dans la liste pour pouvoir etre utilisé
        
        if(gameObject.tag =="Team1")
        {
            IAEnabled = false;
            RegimentSelectionManager.Instance.allRegimentsList.Add(gameObject);
        }
        


        //Création des unités du régiments
        
        unit = new Unit(typeRegiment);
        
        
        
        // Création des stats du régiments
        regimentMaxHealth = unit.model.vie;
        regimentHealth = regimentMaxHealth;
        
        // Met à jour l'interface utilisateur
        UpdateHealthUI() ;

        // Charge le matériau du blason du régiment
        blason = Resources.Load($"Materials/Blason/BlasonMaterial/{typeRegiment}Blason",typeof(Material)) as Material;
        gameObject.transform.GetChild(3).gameObject.GetComponent<Renderer>().material = blason;

        //Texture du Visuel (Rouge/bleu/marron)
        if(tag == "Team1")
        {
            couleur = Resources.Load("Materials/Rouge", typeof(Material)) as Material;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
            gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
        }
        if(tag == "Team2")
        {
            couleur = Resources.Load("Materials/Bleu", typeof(Material)) as Material;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
            gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
        }
        if(tag == "Team3")
        {
            couleur = Resources.Load("Materials/Marron", typeof(Material)) as Material;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
            gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = couleur;
        }
        
        
        
    }

    

    void Update ()
    {
        // Si le régiment est mort, efface la liste des unités
        if(dead )
        {
            OnDestroy();
        }
       
    }

    // Méthode pour infliger des dégâts au régiment
    public void TakeDamage(int damageToInflict)
    {
        regimentHealth -= damageToInflict;
        UpdateHealthUI();
    }

    // Méthode pour mettre à jour l'interface utilisateur
    private void UpdateHealthUI()
    {
        healthTracker.UpdateSliderValue(regimentHealth,regimentMaxHealth);
        if (regimentHealth <= 0 && dead == false)
        {
            // Dying Logic
            dead = true;
            //Update();
        }
    }
    
    // Méthode appelée à la destruction du régiment
    private void OnDestroy()
    {
        //Evite les doublons 
        if(Removecheck == false)
        {
            Removecheck = true;
            RegimentSelectionManager.Instance.killedRegiment(gameObject);
            gameObject.SetActive(false);    
        }
        
        
    }

}
