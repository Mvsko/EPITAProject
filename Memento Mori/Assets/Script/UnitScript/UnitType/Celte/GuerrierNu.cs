using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerrierNu :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}
    public GuerrierNu ()
    {
            vie = 160;
            moral = 40;
            armure = 10;
            degat = 34;
            vitesse = 2;
}


}
