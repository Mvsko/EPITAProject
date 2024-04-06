using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UISpawnRegiment : MonoBehaviour
{
    public GameObject regiment;
    // Start is called before the first frame update
    public Camera cam;
    public LayerMask ground;

    private GameObject reg = null;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRegiment();
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
    public void SpawnRegiment()
    {
        
            if(reg == null)
            {
                
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    GameObject reg = Instantiate(regiment, hit.point, Quaternion.identity );
                }
            }
            
            else
            {
                reg = null;
            }
        
    }


}
