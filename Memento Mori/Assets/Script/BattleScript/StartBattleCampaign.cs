using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartBattleCampaign : MonoBehaviour
{

    // Référence au prefab du régiment
    public GameObject regimentPrefabs;

    // Référence temporaire pour le régiment instancié
    private GameObject reg = null;
     // Référence à l'inventaire du joueur
    public PlayerInventory playerInventory;

    // Variables pour stocker le nombre de régiments opérationnels de chaque type
    private uint HastatiNb = 0;
    private uint TriariiNb = 0;
    private uint FrondeurNb = 0;
    private uint EquitesNb= 0;
    private uint BalisteNb= 0;
    private uint LegatNb = 0;
    void Start()
    {
         // Initialisation des nombres de régiments opérationnels à partir de l'inventaire du joueur
        HastatiNb = playerInventory.HastatiNumber.Item1;
        TriariiNb = playerInventory.TriariiNumber.Item1;
        FrondeurNb = playerInventory.FrondeurNumber.Item1;
        LegatNb = playerInventory.LegatNumber.Item1;
        EquitesNb = playerInventory.EquitesNumber.Item1;
        BalisteNb = playerInventory.BalisteNumber.Item1;

        // Appel de la méthode pour instancier les régiments
        RegimentSpawn();

    }

    public void RegimentSpawn()
    {
        // Liste pour stocker les objets instanciés des régiments Hastati
        // (La list devra être ajouté ici pour Triarii, Frondeur, Equites, Baliste, et Legat)
        List<GameObject> HastatiList = new List<GameObject>();

        for (int i = 0; i < HastatiNb; i++)
        {   
            if(reg == null)  // Si reg est nul, cela signifie qu'aucun régiment n'a été instancié récemment
            {
                // Instancie un nouveau régiment à la position (0, 0, 0) avec une rotation par défaut
                GameObject reg  = Instantiate(regimentPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
                HastatiList.Add(reg);
            }
            else
            {
                // Si reg n'est pas nul, réinitialise-le à nul pour la prochaine itération
                reg = null;
            }
            
        }

        
    }
}
