using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventsManagerCampaign : MonoBehaviour
{   
     // Référence à l'objet qui contient le constructeurs d'evenements
    public GameObject EventsPart;

    public Text TimeText;
    private string TimePeriod;
    private List<string> TimeSaison = new List<string>(){"Printemps","Eté","Automne","Hivers"};
    private int TimeYear;
    private int TimeSaisonId;
    public PlayerInventory Inventory;

    public OpinionManager opinionManager;

    // Liste des événements de campagne
    
    private int NbEvent;
    void Start()
    {
        // Initialise le Temps 
        TimeYear = -12;
        TimePeriod = "Av J.C";
        NbEvent = EventsPart.transform.childCount;
        // Ajoute des événements prédéfinis à la liste d'événements
        
    }

    void Update()
    {   
        if (TimeText != null)              // Met à jour l'affichage de l'argent si le texte n'est pas nul
        {
            TimeText.text = $"{TimeSaison[TimeSaisonId]}  {TimeYear} {TimePeriod}";
        }
        

     }


    public void TimePassMethod()
    {
        //Changement du temps
        TimeSaisonId +=1;
        
        Inventory.money += Inventory.Income - Inventory.Sales*(100/((int)opinionManager.RegionOpinion+1));

        if(Inventory.money < 0)
        {
            opinionManager.MilitaryOpinion -= 10;
        }

        opinionManager.SenatOpinion -=5;
        opinionManager.RegionOpinion +=1;
        
        if (TimeSaisonId > 3)
        {
            TimeSaisonId = 0;
            TimeYear +=1;
             if (TimeYear == 0)
            {
            TimePeriod = "Apr J.C";
            }
        }
        
       
        // Declenche un événement aléatoire
        EventTrigger();
    }

    // Méthode pour déclencher un événement aléatoire
    public void EventTrigger()
    {
        int eventindex = Random.Range(0,NbEvent*3);

        // Si l'indice est valide, active la partie de l'événement correspondante
        if(eventindex >= 0 && eventindex < NbEvent)
        {
            // Active l'objet enfant correspondant à l'événement
            EventsPart.transform.GetChild(eventindex).gameObject.SetActive(true);
        }
        
    }

    public void Event0(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.MilitaryOpinion +=15;
            opinionManager.RegionOpinion -=10;
            Inventory.money += Random.Range(1,20);
        }
        else
        {
            opinionManager.MilitaryOpinion -=10;
            opinionManager.RegionOpinion +=10;
            opinionManager.SenatOpinion +=5;

        }
    }
    public void Event1(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.MilitaryOpinion +=5;
            
        }
        else
        {
            Inventory.money += Random.Range(1,10);

        }
    }
    public void Event2(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.RegionOpinion +=5;
            Inventory.money -= Random.Range(2,5);
        }
        else
        {
            opinionManager.RegionOpinion -= 5;
        }
    }

    public void Event3(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.RegionOpinion += 5;
            Inventory.money -= Random.Range(2,10);
            
        }
        else
        {
            opinionManager.RegionOpinion -=10;
            opinionManager.MilitaryOpinion -=15;
        }
    }
    public void Event4(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.RegionOpinion += 5;
            opinionManager.MilitaryOpinion += 1;
            
        }
        else
        {
            opinionManager.RegionOpinion -=20;
            opinionManager.SenatOpinion +=10;
            Inventory.money += Random.Range(1,10);
        }
    }

    public void Event5(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.MilitaryOpinion -= 15;
            opinionManager.SenatOpinion -=10;
            
        }
        else
        {
            opinionManager.MilitaryOpinion +=5;
            opinionManager.SenatOpinion -=5;
            Inventory.money -= Random.Range(1,5);
        }
    }

    public void Event6(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.SenatOpinion +=Random.Range(1,10);;
            Inventory.money -= Random.Range(1,5);
            
        }
        else
        {
            opinionManager.SenatOpinion -=10;
            opinionManager.MilitaryOpinion +=5;
        }
    }

    public void Event7(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.SenatOpinion +=Random.Range(1,10);;
            Inventory.money -= Random.Range(1,5);
            
        }
        else
        {
            opinionManager.SenatOpinion -=10;
        }
    }

    public void Event8(bool IsRep1)
    {
        if(IsRep1)
        {
            opinionManager.MilitaryOpinion +=10;
            opinionManager.RegionOpinion +=5;
            
            
        }
        else
        {
            opinionManager.SenatOpinion +=8;
        }
    }


}
