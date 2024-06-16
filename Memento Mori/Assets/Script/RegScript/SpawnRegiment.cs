using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Photon.Pun;
using UnityEngine;

public class SpawnRegiment : MonoBehaviourPun
{
    public GameObject regiment;
    public GameObject EnemyRegiment;
    public Camera cam;
    public LayerMask ground;

    private Vector3 EspacementHorizontale;
    private Vector3 EspacementVerticale;
    private int NbRegimentCreate;
    private int Colonne;
    private GameObject reg = null;

    void Start()
    {
        EspacementHorizontale = new Vector3(3, 0, 0);
        EspacementVerticale = new Vector3(0, 0, 3);
        NbRegimentCreate = 0;
        Colonne = 0;

    }

    void Update()
    {
        //dragRegimentSpawn();
    }

    public void dragRegimentSpawn()
    {
        if (reg != null)
        {
            RaycastHit hitdrag;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitdrag, Mathf.Infinity, ground))
            {
                reg.transform.position = cam.ScreenToWorldPoint(hitdrag.point);
            }
        }
    }

    public void ResetSpawnRegimentPlacement()
    {
        EspacementHorizontale = new Vector3(3, 0, 0);
        EspacementVerticale = new Vector3(0, 0, 3);
        NbRegimentCreate = 0;
        Colonne = 0;
    }

    public void SpawnEnemyRegimentMethod(string type, Vector3 vector3)
    {
        GameObject Enemy = Instantiate(EnemyRegiment, vector3, Quaternion.identity);
        Enemy.GetComponent<Regiment>().typeRegiment = type;
        Enemy.transform.GetChild(4).transform.GetChild(0).GetComponent<FaceCamera>().facingCamera = cam;
    }



    public void SpawnRegimentMethod(string type)
    {
        if (reg == null)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ground))
            {
                Vector3 spawnPosition = hit.point + EspacementHorizontale * NbRegimentCreate + EspacementVerticale * Colonne;
                if (PhotonNetwork.InRoom)
                {
                    Debug.Log($"Attempting to spawn regiment of type {type} at {spawnPosition} via RPC.");
                    photonView.RPC("RPC_SpawnRegiment", RpcTarget.AllBuffered, type, spawnPosition);
                }
                else
                {
                    GameObject reg = Instantiate(regiment, spawnPosition, Quaternion.identity);
                    reg.GetComponent<Regiment>().typeRegiment = type;
                    reg.transform.GetChild(4).transform.GetChild(0).GetComponent<FaceCamera>().facingCamera = cam;
                    NbRegimentCreate += 1;

                    Debug.Log($"Regiment of type {type} spawned at {spawnPosition} locally.");

                    if (NbRegimentCreate > 4)
                    {
                        NbRegimentCreate = 0;
                        Colonne += 1;
                    }
                }
            }
        }
        else
        {
            reg = null;
        }
    }

    [PunRPC]
    void RPC_SpawnRegiment(string type, Vector3 position)
    {
        GameObject reg = PhotonNetwork.Instantiate(regiment.name, position, Quaternion.identity);
        reg.GetComponent<Regiment>().typeRegiment = type;
        reg.transform.GetChild(4).transform.GetChild(0).GetComponent<FaceCamera>().facingCamera = cam;

        Debug.Log($"Regiment of type {type} spawned at {position} via RPC.");
    }



}