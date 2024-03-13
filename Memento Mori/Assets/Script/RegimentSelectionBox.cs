using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RegimentSelectionBox : MonoBehaviour
{
    Camera myCam;
 
    [SerializeField]
    RectTransform boxVisual;
 
    Rect selectionBox;
 
    Vector2 startPosition;
    Vector2 endPosition;
 
    private void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }
 
    private void Update()
    {
        // Quand Clické
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
 
            // Pour la sélection des régiments
            selectionBox = new Rect();
        }
 
        // Quand faire glissé
        if (Input.GetMouseButton(0))
        {
            // Taille minimal pour lancer la zone de selection (10;10)
            if(boxVisual.rect.width > 10 && boxVisual.rect.height > 10)
            {
                RegimentSelectionManager.Instance.DeselectetAll();
                SelectUnits();
            }
            

            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
 
        // Quand relaché
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
 
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
    
    
        }
    }

    /// <summary>
    /// Dessine la zone de selection visible(SelectionBox)
    /// </summary>
    void DrawVisual()
    
    {
        // Calcule les positions de début et de fin de la zone de sélection.
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;
 
        // Calcule le centre de la zone de sélection.
        Vector2 boxCenter = (boxStart + boxEnd) / 2;
 
        // Définie la position de la zone de sélection en fonction de son centre.
        boxVisual.position = boxCenter;
 
        // Calcule la taille de la zone de sélection en largeur et en hauteur.
        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
 
        //  Définie la taille de la zone de sélection en fonction de sa taille.
        boxVisual.sizeDelta = boxSize;
    }
    /// <summary>
    /// Dessine la zone de selection invisible(SelectionBox)
    /// </summary>
    void DrawSelection()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
 
 
        if (Input.mousePosition.y < startPosition.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }
    /// <summary>
    /// Determine si le regiment est compris dans ma zone de selection (SelectionBox)
    /// </summary>
    void SelectUnits()
    {
        foreach (var regiment in RegimentSelectionManager.Instance.allRegimentsList)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(regiment.transform.position)))
            {
                RegimentSelectionManager.Instance.DragSelect(regiment);
            }
        }
    }
}
 
