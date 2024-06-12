using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Regiment : MonoBehaviour
{

    public float regimentHealth;            // Points de vie actuels du régiment
    public float regimentMaxHealth;         // Points de vie maximum du régiment

    public float armure;
    public float moral;

    // Référence au HealthTracker pour mettre à jour l'interface de la vie
    public HealthTracker healthTracker;

    public string typeRegiment;
    public Unit unit {get;set;}      // Liste des unités composant ce régiment
    public bool dead = false;
    public bool Removecheck = false;
    public Material blason;                     // Matériel du blason du régiment
    public Material couleur;                     // Matériel de couleur du régiment

    NavMeshAgent agent;
    public bool IAEnabled = true;
    void Start()
    {
        
        //Création des unités du régiments
        unit = new Unit(typeRegiment);
        agent = GetComponent<NavMeshAgent>();
        
        // Ajoute le régiment dans la liste pour pouvoir etre utilisé
        
        if(gameObject.tag =="Team1")
        {
            IAEnabled = false;
            RegimentSelectionManager.Instance.allRegimentsList.Add(gameObject);
        }
        


        
        
        
        
        // Création des stats du régiments
        regimentMaxHealth = unit.vie;
        regimentHealth = regimentMaxHealth;
        armure = unit.armure;
        agent.speed = unit.vitesse;
        moral = unit.moral;
        
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
        //Impacte de l'armure (armure)
        /*
        Avec une armure de 0, le regiment subirait tous les dégâts d'attaque. 
        Avec une armure de 50, le regiment subirait 4 dixieme des dégâts. 
        A 100 d'armure, le regiment subira deux dixième des dégâts.
        */

        //Impacte de la hauteur (y)
        /*
        La hauteur influe sur le tation des "damagetoInflict".
        Plus le régiment est en hauteur, moins il prends de dégat.
        La hauteur et l'armure sont indépendant.
        */

        float damage = damageToInflict * 100/(5 * armure + 50*transform.position.y);
        regimentHealth = regimentHealth - damage* unit.moral/moral;

        
        
        if(moral>1)
        {
            moral -=1f;
        }
        else
        {
            moral = 1;
        }
        
        if(armure>0)
        {
            //armure = armure - (damageToInflict/((int)damage)+damageToInflict/2);
            armure -= 1f;
        }
        else
        {
            armure = 0;
        }
        



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
