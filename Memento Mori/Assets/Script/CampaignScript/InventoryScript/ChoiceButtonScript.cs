using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class ChoiceButtonScript : MonoBehaviour
{
    //Pour donner le bon parametre au PlayerInventory/AddRegimentInventory
    // Liste des types de régiments disponibles
    public List<string> RegimentType = new List<string>{"None","Hastati", "Triarii", "Frondeur","Equites","Baliste","Legat"};

    // Référence au script de gestion des icônes d'items
    public ItemIconScript IconVisaul;

     // Référence à l'inventaire du joueur
    public PlayerInventory playerInventory;

    
    void Update()
    {
        // Active l'enfant index 3 de ce GameObject, supposant qu'il s'agit du bouton de suppression
        transform.GetChild(3).gameObject.SetActive(true);
        
    }
    
    // Méthode pour gérer la sélection d'un type de régiment
    public void HandleInputData(int id)
    {
        // Met à jour l'inventaire du joueur
        int money = playerInventory.money;
        
        
        // Si l'ajout du régiment à l'inventaire réussit
        if(playerInventory.AddRegimentInventory(RegimentType[id]))
        {
             // Met à jour l'icône correspondante
            IconVisaul.IconManage(id);
        }
        
        
    }

    
    
}
