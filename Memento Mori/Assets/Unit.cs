using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit 
{
    public int vie{get;set;}
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}

    public string arme{get;set;}

    public Unit (string type)
    {
        if (type == "legionnaire")
        {
            vie = 100;
            moral = 30;
            armure = 40;
            degat = 40;
            vitesse = 25;
            arme = "epee";
        }
        vie = 60;
        moral = 25;
        armure = 30;
        degat = 30;
        vitesse = 40;
        arme = "lance";
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void defendre(int dommage, string type)
    {
        if (type == "epee")
        {
            if (dommage/armure <= dommage/2)
            {
                if (armure > 0)
                {
                    armure -= 1;
                }
                moral -= 1;
                vie -= dommage/2;
            }
            else
            {
                moral -= 2;
                vie -= dommage;
            }
        }
        else
        {
            moral -= 2;
            vie -= dommage;
        }

    }
}
