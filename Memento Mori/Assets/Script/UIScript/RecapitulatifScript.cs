using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecapitulatifScript : MonoBehaviour
{
    public int DeadRegimentOwner;


    public int Victory;
    public int Defeat;

    public TextMeshProUGUI Victorytext;
    public TextMeshProUGUI Defeattext;
    public TextMeshProUGUI DeadRegimentOwnerText;


    void Start()
    {
        DeadRegimentOwner = 0;

        Victory = 0;
        Defeat = 0;
    }
    void Update()
    {
        Victorytext.text = $"Nombre de Victoire: {Victory} Batailles(s)";
        Defeattext.text = $"Nombre de Défaite: {Defeat} Batailles(s)";
        DeadRegimentOwnerText.text = $"Perte: {DeadRegimentOwner} Régiment(s)";


    }
}
