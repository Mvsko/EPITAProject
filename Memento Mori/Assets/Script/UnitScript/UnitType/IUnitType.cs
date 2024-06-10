using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitType 
{

    //Statistique
    public int vie{get;set;} 
    public int moral{get;set;}
    public int armure{get;set;}
    public int degat{get;set;}
    public int vitesse{get;set;}
    public string arme{get;}



    //Information UI

    public string description {get;set;}
}
