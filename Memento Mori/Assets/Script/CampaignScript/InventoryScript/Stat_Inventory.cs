using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class  PlayerInventory : MonoBehaviour
{


    // Variables de statistiques de l'inventaire
    public int money;           // Montant d'argent du joueur
    public Text moneyText;       // Référence à l'objet Text qui affiche l'argent du joueur
    

    // Variables de régiments de l'inventaire
    // (Nombre de régiments opérationnels, Nombre de régiments en réserve)
    public (uint,uint) HastatiNumber;
    public (uint,uint) TriariiNumber;
    public (uint,uint) FrondeurNumber;
    public (uint,uint) EquitesNumber;
    public (uint,uint) BalisteNumber;
    public (uint,uint) LegatNumber;

    
    void Start()
    {
        // Initialisation des statistiques
        money = 10;
        

        
        // Initialisation des statistiques de régiments
        HastatiNumber = (0,0);
        TriariiNumber = (0,0);
        FrondeurNumber = (0,0);
        EquitesNumber = (0,0);
        BalisteNumber = (0,0);
        LegatNumber = (0,0);
        
    }
   
    void Update()
    {   
        if (moneyText != null)              // Met à jour l'affichage de l'argent si le texte n'est pas nul
        {
            moneyText.text = $"{money}";
        }
        

     }


    // Méthode pour enlever un régiment de l'inventaire
     public bool RemoveRegimentInventory(string type)
     {
        // Vérifie le type de régiment et le retire s'il est disponible
        if (type == "Hastati")
        {
            HastatiNumber = (HastatiNumber.Item1 - 1, HastatiNumber.Item2);
            return true;
        }
        if (type == "Triarii")
        {
            TriariiNumber = (TriariiNumber.Item1 - 1, TriariiNumber.Item2);
            return true;
        }
        if (type == "Frondeur")
        {
            FrondeurNumber = (FrondeurNumber.Item1 - 1, FrondeurNumber.Item2);
            return true;
        }
        if (type == "Equites")
        {
            EquitesNumber = (EquitesNumber.Item1 - 1, EquitesNumber.Item2);
            return true;
        }
        if (type == "Baliste")
        {
            BalisteNumber = (BalisteNumber.Item1 - 1, BalisteNumber.Item2);
            return true;
        }
        if (type == "Legat")
        {
            LegatNumber = (LegatNumber.Item1 - 1, LegatNumber.Item2);
            return true;
        }
        return false;
     }

    // Méthode pour ajouter un régiment à l'inventaire
    public bool AddRegimentInventory(string type)
    {
        bool result = false;

        // Vérifie le type de régiment et l'ajoute s'il est disponible en réserve 
        // ou si le joueur a suffisamment d'argent
        if (type == "Hastati")
        {
            if(HastatiNumber.Item2 > 0)
            {
                HastatiNumber = (HastatiNumber.Item1 + 1, HastatiNumber.Item2 - 1);
                result = true;
            }
            else
            {
                if(money >=1)
                {
                    money-=1;
                    
                    HastatiNumber = (HastatiNumber.Item1 + 1, HastatiNumber.Item2);
                    //Debug.Log(HastatiNumber.Item1);
                    result = true;
                }
            }
            
            
        }
        if (type == "Triarii")
        {
            if(TriariiNumber.Item2 > 0)
            {
                TriariiNumber = (TriariiNumber.Item1 + 1, TriariiNumber.Item2 - 1);
                result = true;
            }
            else
            {
                if(money >=3)
                {
                    money-=3;
                    TriariiNumber = (TriariiNumber.Item1 + 1, TriariiNumber.Item2);
                    result = true;
                }
            }
        }
        if (type == "Frondeur")
        {
            if(FrondeurNumber.Item2 > 0)
            {
                FrondeurNumber = (FrondeurNumber.Item1 + 1, FrondeurNumber.Item2 - 1);
                result = true;
            }
            else
            {
                if(money >=1)
                {
                    money-=1;
                    FrondeurNumber = (FrondeurNumber.Item1 + 1, FrondeurNumber.Item2);
                    result = true;
                }
            }
        }
        if (type == "Equites")
        {
            if(EquitesNumber.Item2 > 0)
            {
                EquitesNumber = (EquitesNumber.Item1 + 1, EquitesNumber.Item2 - 1);
                result = true;
            }
            else
            {
                if(money >=3)
                {
                    money-=3;
                    EquitesNumber = (EquitesNumber.Item1 + 1, EquitesNumber.Item2);
                    result = true;
                }
            }
        }
        if (type == "Baliste" )
        {
            
            if(BalisteNumber.Item2 > 0)
            {
                BalisteNumber = (BalisteNumber.Item1 + 1, BalisteNumber.Item2 - 1);
                
                result = true;
            }
            else
            {
                if(money >=4)
                {
                    money-=4;
                    BalisteNumber = (BalisteNumber.Item1 + 1, BalisteNumber.Item2);
                    result = true;
                }
            }
        }
        if (type == "Legat" )
        {
             if(LegatNumber.Item2 > 0)
            {
                LegatNumber = (LegatNumber.Item1 + 1, LegatNumber.Item2 - 1);
                result = true;
            }
            else
            {
                if(money >=3)
                {
                    money-=3;
                    LegatNumber = (LegatNumber.Item1 + 1, LegatNumber.Item2);
                    result = true;
                }
            }
        }

        return result; 
    }
}
