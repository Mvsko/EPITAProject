using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Unit 
{
    public IUnitType model{get;set;}
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}

    public string arme{get;set;}

    public Unit (string type)
    {

        if (type == "Hastati")
        {
          model = new Hastati();
        }
        if (type == "Triarii")
        {
          model = new Triarii();
        }
        else
        {
          model = new Hastati();  
        }

        vie = model.vie;
       
        armure = model.armure;
        degat = model.degat;
        vitesse = model.vitesse;
        arme = model.arme;

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
/// <summary>
/// Fonction qui fait subir des dégats au régiment
/// </summary>
/// <param name="dommage">le montant des dégats</param>
/// <param name="type">par le type d'arme</param>
    public void defendre(int dommage, string typeWeapon)
    {
    }

    public void attack()
    {

    }
}
