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
        Inventory.money += Inventory.Income-Inventory.Sales;
        
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

}
