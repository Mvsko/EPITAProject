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
        //CELTE
        if(type == "Bretteur")
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
}
