using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectionFormation : MonoBehaviour
{

    bool isVisible = false;
    private RegimentSelectionManager.mouvementTypeList type;
    // Start is called before the first frame update
    void Start()
    {
        type = RegimentSelectionManager.mouvementTypeList.Line;
    }

    // Update is called once per frame
    void Update()
    {
        int regimentlistselect = RegimentSelectionManager.Instance.regimentsSelected.Count;
        if(regimentlistselect > 1)
        {
            if(isVisible)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
                isVisible = false;
            }
            

            type = RegimentSelectionManager.Instance.MouvementTypeGet();
            if(type is RegimentSelectionManager.mouvementTypeList.Line)
            {
                 gameObject.transform.GetChild(0).gameObject.SetActive(true);
                 gameObject.transform.GetChild(1).gameObject.SetActive(false);
                 gameObject.transform.GetChild(2).gameObject.SetActive(false);
                 gameObject.transform.GetChild(3).gameObject.SetActive(false);
                 gameObject.transform.GetChild(4).gameObject.SetActive(false);
            }

            if(type is RegimentSelectionManager.mouvementTypeList.DoubleLine)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                 gameObject.transform.GetChild(1).gameObject.SetActive(true);
                 gameObject.transform.GetChild(2).gameObject.SetActive(false);
                 gameObject.transform.GetChild(3).gameObject.SetActive(false);
                 gameObject.transform.GetChild(4).gameObject.SetActive(false);
            }

            if(type is RegimentSelectionManager.mouvementTypeList.Colonne)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                 gameObject.transform.GetChild(1).gameObject.SetActive(false);
                 gameObject.transform.GetChild(2).gameObject.SetActive(true);
                 gameObject.transform.GetChild(3).gameObject.SetActive(false);
                 gameObject.transform.GetChild(4).gameObject.SetActive(false);
            }

            if(type is RegimentSelectionManager.mouvementTypeList.Triangle)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                 gameObject.transform.GetChild(1).gameObject.SetActive(false);
                 gameObject.transform.GetChild(2).gameObject.SetActive(false);
                 gameObject.transform.GetChild(3).gameObject.SetActive(true);
                 gameObject.transform.GetChild(4).gameObject.SetActive(false);
            }

            if(type is RegimentSelectionManager.mouvementTypeList.Cercle)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                 gameObject.transform.GetChild(1).gameObject.SetActive(false);
                 gameObject.transform.GetChild(2).gameObject.SetActive(false);
                 gameObject.transform.GetChild(3).gameObject.SetActive(false);
                 gameObject.transform.GetChild(4).gameObject.SetActive(true);
            }


        }
        else
        {
            if(isVisible ==false)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                isVisible = true;
            }
            
        }
    }
}
