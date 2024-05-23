using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    // Référence au transform local de l'objet 
    private Transform localTrans;

    // Référence à la caméra que l'objet doit regarder
    public Camera facingCamera;

    private void Start()
    {
        // Récupère le transform de l'objet attaché à ce script
        localTrans = GetComponent<Transform>();
    }

    private void Update()
    {
        if (facingCamera)
        {
             // Oriente l'objet pour qu'il regarde la caméra
            // Utilise la position locale de l'objet et la position de la caméra pour calculer la direction
            localTrans.LookAt(2 * localTrans.position - facingCamera.transform.position);
        }
    }
}
