using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimarcisia :  IUnitType
{
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public float vitesse{get;set;}
    public Trimarcisia ()
    {
            vie = 80;
            moral = 55;
            armure = 60;
            degat = 42;
            vitesse = 3.5f;
}


}
