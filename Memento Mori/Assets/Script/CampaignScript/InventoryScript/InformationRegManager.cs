using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationRegManager : MonoBehaviour
{
    // Référence à l'objet visuel qui contient les informations des régiments
    public GameObject Visual;
    // Compteur pour suivre l'index actuel du visuel
    public int visualCompteur = 0;

    // Méthode pour mettre à jour l'index d'information visuelle
    public void InformationIndex(int mvt)
    {   
        visualCompteur = visualCompteur +mvt;
        if(visualCompteur < 0 || visualCompteur >5)
        {
              // Si le compteur est inférieur à 0 ou supérieur à 5, effectue un ajustement circulaire
            visualCompteur = visualCompteur % 6;
        }

        for (int i = 2; i < Visual.transform.childCount; i++)
        {
            Visual.transform.GetChild(i).gameObject.SetActive(i == visualCompteur+2);
        }

    }
}
