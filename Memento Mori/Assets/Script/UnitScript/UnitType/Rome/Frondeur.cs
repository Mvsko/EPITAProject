using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frondeur :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}
    public string arme{get;set;}
    public string description{get;set;}

    public Frondeur ()
    {
            vie = 70;
            moral = 40;
            armure = 40;
            degat = 40;
            vitesse = 20;
            arme = "glaive";
            description = "Ils étaient courants dans les armées antiques. Leurs projectiles pouvaient atteindre des distances de 400 mètres. Ils pouvaient facilement casser un os ou enfoncer des armure à courte portée.";
    }
    public void defendre(int dommage, string typeWeapon)
    {

    }

    public void attack()
    {

    }

}
