using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Unit : IUnitType
{
    public IUnitType model{get;set;}
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee{get;set;}
    public int degatDistance{get;set;}
    public float vitesse{get;set;}
    public float attackingRangeDistance { get; set; }


    public Unit (string type)
    {
        //ROME
        if (type == "Hastati")
        {
          model = new Hastati();
        }
        if (type == "Triarii")
        {
          model = new Triarii();
        }
        if(type == "Legat")
        {
          model = new Legat();  
        }
        if(type == "BalisteRomaine")
        {
          model = new BalisteRomaine();  
        }
        if(type == "Equites")
        {
          model = new Equites();  
        }
        if(type == "Frondeur")
        {
          model = new Frondeur();  
        }

        //PERSE

        if (type == "ArcherPerse")
        {
            model = new ArcherPerse();
        }
        if (type == "BalistePerse")
        {
            model = new BalistePerse();
        }
        if (type == "Kardake")
        {
            model = new Kardake();
        }
        if (type == "Melophore")
        {
            model = new Melophore();
        }
        if (type == "MelophoreMede")
        {
            model = new MelophoreMede();
        }
        if (type == "Sakas")
        {
            model = new Sakas();
        }

        //CELTE
        if (type == "Bretteur")
        {
          model = new Bretteur();  
        }
        if(type == "Chasseur")
        {
          model = new Chasseur();  
        }
        if(type == "GuerrierNu")
        {
          model = new GuerrierNu();  
        }
        if(type == "NobleBretteur")
        {
          model = new NobleBretteur();  
        }
        if(type == "Onagre")
        {
          model = new Onagre();  
        }
        if(type == "Trimarcisia")
        {
          model = new Trimarcisia();  
        }
        

        if (model == null)
        {
            Debug.Log("null log " + type);
        } else
        {
            Debug.Log(model.vie);
        }

        vie = model.vie;
        armure = model.armure;
        degatMelee = model.degatMelee;
        degatDistance = model.degatDistance;
        vitesse = model.vitesse;
        moral = model.moral;
        attackingRangeDistance = model.attackingRangeDistance;

    }
}
