using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RegimentSelectionManager : MonoBehaviour
{

   public static RegimentSelectionManager Instance {get;set;}

    public List<GameObject> allRegimentsList = new List<GameObject>();
    public List<GameObject> regimentsSelected = new List<GameObject>();
    
    public LayerMask clickable;
    public LayerMask ground;
    public GameObject groundMarker;
    private Camera cam;



    /// <summary>
    /// Determine si le script "RegimentSelectionManager" est unique dans le jeu
    /// </summary>
   private void Awake()
   {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
   }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

           if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
           {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    MultiSelect(hit.collider.gameObject);
                }
                else 
                {
                 SelectByClicking(hit.collider.gameObject);
                }
           } 
           else
           {
                if(Input.GetKey(KeyCode.LeftShift)== false)
                {
                    DeselectetAll();
                }
               
           }
        }


        if (Input.GetMouseButtonDown(1) && regimentsSelected.Count > 0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

           if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
           {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
           } 
        }
    }

    /// <summary>
    /// Permet de selectioné plusieurs régiments à la fois
    /// </summary>
    /// <param name="regiment">Le regiment selectioné</param>
    private void MultiSelect(GameObject regiment)
    {
        if(regimentsSelected.Contains(regiment)==false)
        {
            regimentsSelected.Add(regiment);
            SelectUnit(regiment,true);
    
        }
        else
        {
            SelectUnit(regiment,false);
            regimentsSelected.Remove(regiment);
        }
    }

/// <summary>
/// Selectionne un seul régiment et determine si il peut bougé
/// </summary>
/// <param name="regiment">Le regiment selectioné</param>
/// <param name="isSelected">La possibilité de se déplacer</param>
    private void SelectUnit(GameObject regiment, bool isSelected)
    {
        TriggerSelectionIndicator(regiment, isSelected);
        EnabledUnitMovement(regiment,isSelected);
        
    }
    /// <summary>
    /// Desselectione touts les régiments de la liste regimentsSelected
    /// </summary>
    public void DeselectetAll()
    {
        foreach(var regiment in regimentsSelected)
        {
            SelectUnit(regiment,false);
        }
        groundMarker.SetActive(false);
        regimentsSelected.Clear();
    }

/// <summary>
/// Selection d'un régiment en clickant
/// </summary>
/// <param name="regiment">le régiment sélectionné</param>
    private void SelectByClicking(GameObject regiment)
    {
        DeselectetAll();
        regimentsSelected.Add(regiment);
        SelectUnit(regiment,true);
    }
/// <summary>
/// OUI/NON pour le mouvement d'un regiment
/// </summary>
/// <param name="regiment"></param>
/// <param name="shouldMove"></param>
    private void EnabledUnitMovement(GameObject regiment, bool shouldMove)
    {
       regiment.GetComponent<RegimentMovement>().enabled = shouldMove;
    }

/// <summary>
/// Active l'indicateur de selection du régiment
/// </summary>
/// <param name="regiment"></param>
/// <param name="isVisible"></param>
    private void TriggerSelectionIndicator(GameObject regiment, bool isVisible)
    {
        regiment.transform.GetChild(0).gameObject.SetActive(isVisible);
    }

/// <summary>
/// Selection avec le glisser de souris
/// </summary>
/// <param name="regiment"></param>
    internal void DragSelect(GameObject regiment)
    {
        if(regimentsSelected.Contains(regiment)==false)
        {
            regimentsSelected.Add(regiment);
            SelectUnit(regiment,true);
        }
    }
}
