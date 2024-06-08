using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRegiment : MonoBehaviour
{
    public GameObject regiment;
    // Start is called before the first frame update
    public Camera cam;
    public LayerMask ground;

    private Vector3 EspacementHorizontale;
    private Vector3 EspacementVerticale;
    private int NbRegimentCreate;

    private int Colonne;
    private GameObject reg = null;
    void Start()
    {
        EspacementHorizontale = new Vector3(3,0,0);
        EspacementVerticale = new Vector3(0,0,3);
        NbRegimentCreate = 0;
        Colonne = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRegimentMethod("Legat");
        }
        
        dragRegimentSpawn();

    
    }
    public void dragRegimentSpawn()
    {
        if (reg != null)
        {
            RaycastHit hitdrag;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hitdrag, Mathf.Infinity, ground))
            {
                reg.transform.position = cam.ScreenToWorldPoint(hitdrag.point);
            }
            
        }
    }
    public void SpawnRegimentMethod(string type)
    {
        
            if(reg == null)
            {
                
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    
                    GameObject reg = Instantiate(regiment, hit.point + EspacementHorizontale*NbRegimentCreate + EspacementVerticale*Colonne, Quaternion.identity );
                    reg.GetComponent<Regiment>().typeRegiment = type;
                    reg.transform.GetChild(4).transform.GetChild(0).GetComponent<FaceCamera>().facingCamera = cam;
                    NbRegimentCreate +=1;
                }

                if(NbRegimentCreate > 4)
                {
                    NbRegimentCreate = 0;
                    Colonne+=1;
                }
            }
            
            else
            {
                reg = null;
            }
        
    }


}
