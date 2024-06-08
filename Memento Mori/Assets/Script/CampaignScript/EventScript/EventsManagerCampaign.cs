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
    public List<CampaingEvents> eventsList= new List<CampaingEvents>();
    void Start()
    {
        // Initialise le Temps 
        TimeYear = -12;
        TimePeriod = "Av J.C";

        // Ajoute des événements prédéfinis à la liste d'événements

        eventsList.Add(new CampaingEvents(
        1,
        "Un village abandonné",
        "Vous arrivez près d'un village, la famine est passée par ici. Point d’âmes y vivent, les villageois l’ont quitté du jour au lendemain et ne reviendront sûrement jamais.",
        " Entrée dans le village et autorisé vos hommes à le piller. ",
        "Se détourner du village. Qui sait, peut-être qu'il est maudit."
        )) ;

        eventsList.Add(new CampaingEvents(2,
        "Le temps de la hache et du mépris ",
        "Sur une colline, un de vos éclaireur vous parle d'un village à quelques kilomètres qu’il aurait vue. Cependant il affirme avoir vu des colonnes de fumées noires en sortir.  Après le retour d'un second éclaireur, celui-ci vous affirme que certains bâtiments ont été brulé. ",
        "Allons voir ceci de plus près pour savoir ce que fait l’ennemi sans nous faire découvrir.",
        "Rentrons dans ce village, nous en prendront le contrôle. "
        ));

        eventsList.Add(new CampaingEvents(3,
        "Marchands sur la route ",
        "Sur la route en direction du nord, vous rencontrer une caravane de marchand. ",
        "Allons voir ce qu’ils ont à nous échanger. ",
        "Nous arrêtons ce convoie et nous prenons toutes vos marchandises."
        ));

        eventsList.Add(new CampaingEvents(4,
        "Exode Romaine ",
        "Vous rencontré un convoi de villageois fuyant la guerre et la famine. En vous rapprochant vous remarquer qu'ils sont des citoyens romains.",
        "Au nom de Rome il est de notre devoir de leur venir en aide. ",
        "Nous ne pouvons pas les aider, ils trouveront le chemin tous seuls. "
        ));

        
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
        int eventindex = Random.Range(1,eventsList.Count*3);

        // Si l'indice est valide, active la partie de l'événement correspondante
        if(eventindex > 0&& eventindex < 3)
        {
            Debug.Log(eventsList[eventindex].Title);
            // Active l'objet enfant correspondant à l'événement
            EventsPart.transform.GetChild(eventindex+3).gameObject.SetActive(true);
        }
        
    }

}
