using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class CampaingEvents 
{
    public int ID;                  // Identifiant unique pour l'événement de campagne
    public string Title;            // Titre de l'événement
    public string Description;       // Description de l'événement
    public string RepString_1;
    public string RepString_2;

   public CampaingEvents(int id,string title, string description, string repString_1, string repString_2)
    {
        //initialiser un nouvel événement
        ID = id;
        Title = title;
        Description = description;
        RepString_1 = repString_1;
        RepString_2 = repString_2;
    }
}
