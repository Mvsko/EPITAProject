using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceBattle 
{
    public GameObject ButtonName;
    public GameObject Next;


    public ProvinceBattle(GameObject button,GameObject next)
    {
        ButtonName = button;
        Next = next;
    }
}
public class BattleManager : MonoBehaviour
{
    public GameObject FrisonsButton;
    public GameObject NerviensButton;
    public GameObject SequaneButton;
    public GameObject CherusqueButton;
    public GameObject BoiensButton;
    public GameObject RugesButton;
    public GameObject SuevesButton;
    public GameObject GutoneButton;
    public GameObject LugiensButton;
    public GameObject AstiusButton;

    public ProvinceBattle Current;
    public RecapitulatifScript recap;

    private List<ProvinceBattle> ListProv;
    List<Button> ListButton;

    public BattleStart battleStart;
    public BattleEnd battleEnd;

    public GameObject EscapeMenu;
    public GameObject MusicManager;
    public OpinionManager opinionManager;

    void Start()
    {   
        ProvinceBattle Frisons = new ProvinceBattle(FrisonsButton,CherusqueButton);
        ProvinceBattle  Nerviens = new ProvinceBattle(NerviensButton,SequaneButton);
        ProvinceBattle Sequane = new ProvinceBattle(SequaneButton,CherusqueButton);
        ProvinceBattle Cherusque = new ProvinceBattle(CherusqueButton,BoiensButton);
        ProvinceBattle Boiens = new ProvinceBattle(BoiensButton,SuevesButton);
        ProvinceBattle Sueves = new ProvinceBattle(SuevesButton,RugesButton);
        ProvinceBattle Ruges = new ProvinceBattle(RugesButton,GutoneButton);
        ProvinceBattle Gutone = new ProvinceBattle(GutoneButton,LugiensButton);
        ProvinceBattle Lugiens = new ProvinceBattle(LugiensButton,AstiusButton);
        ProvinceBattle Astius = new ProvinceBattle(AstiusButton,AstiusButton);
        ListProv = new List<ProvinceBattle>(){Frisons,Nerviens,Sequane,Cherusque,Boiens,Ruges,Sueves,Gutone,Lugiens,Astius};
        Current = null;


        
    }

    public void BattleButtonStart(int ID)
    {
        MusicManager.GetComponent<MusicScriptManager>().RightToPlay = false;
       
        battleStart.BattleProvinceStart(ID);
        Current = ListProv[ID];
    }

    public void AfterMatch(bool win)
    {
        if(win && Current!=null)
        {
            Current.Next.SetActive(true);
            Current.ButtonName.SetActive(false);
            opinionManager.SenatOpinion +=10;
            recap.Victory +=1;
        
        }
        else
        {
            recap.Defeat +=1;
            opinionManager.SenatOpinion -=25;
        }
        battleEnd.BattleProvinceEnd();
        Current = null;
        EscapeMenu.SetActive(false);
        MusicManager.GetComponent<MusicScriptManager>().RightToPlay = true;
    }


    private void Update()
    {
        if (Current!= null && Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeMenu.SetActive(true);
        }
    }




}
