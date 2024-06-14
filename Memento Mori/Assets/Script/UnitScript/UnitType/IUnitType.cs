using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitType 
{

    //Statistique
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degatMelee{get;set;}
    public int degatDistance{get;set;}
    public float vitesse{get;set;}

    public float attackingRangeDistance{get;set;}

}
