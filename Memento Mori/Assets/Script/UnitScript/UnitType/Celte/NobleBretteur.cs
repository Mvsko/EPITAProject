using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleBretteur : IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}

    public NobleBretteur ()
    {
            vie = 160;
            moral = 70;
            armure = 75;
            degat = 34;
            vitesse = 2;
 }
 

}
