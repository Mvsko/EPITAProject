using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RTSCameraController : MonoBehaviour
{
    public static RTSCameraController instance;
 
    // Si nous voulons sélectionner un élément à suivre, dans le script de l'élément, ajoutez :
    // public void OnMouseDown(){
    //   CameraController.instance.followTransform = transform;
    // }
 
    [Header("General")]
    [SerializeField] Transform cameraTransform;
    public Transform followTransform;
    Vector3 newPosition;

    public Vector3 InstantPosition;
    Vector3 dragStartPosition;
    Vector3 dragCurrentPosition;
 
    [Header("Optional Functionality")]          
    // Les differentes façons de bouger la camera (bool pour activer ou desactiver)
   public bool moveWithKeyboad;
    public bool moveWithEdgeScrolling;
    public bool moveWithMouseDrag;
 
    [Header("Keyboard Movement")]
    [SerializeField] float fastSpeed = 0.1f;       //Viariable de vitesse
    [SerializeField] float normalSpeed = 0.05f;     //Viariable de vitesse
    [SerializeField] float movementSensitivity = 1f; // Hardcoded Sensitivity
    float movementSpeed; 
 
    [Header("Edge Scrolling Movement")]
    [SerializeField] float edgeSize = 50f;
    bool isCursorSet = false;
    //Texture du curseur
    public Texture2D cursorArrowUp;
    public Texture2D cursorArrowDown;
    public Texture2D cursorArrowLeft;
    public Texture2D cursorArrowRight;
 
    CursorArrow currentCursor = CursorArrow.DEFAULT;
    enum CursorArrow    // Pour tracker quel curseur on utilise
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        DEFAULT
    }
 
    private void Start()
    {
        instance = this;
 
        newPosition = transform.position;
 
        movementSpeed = normalSpeed;
        moveWithMouseDrag = false;
        moveWithKeyboad = false;
        moveWithEdgeScrolling = false;

        ActivateMovementOptions();
    }

    private void ActivateMovementOptions()
    {
        if (SceneManager.GetActiveScene().name == "MultiScene")
        {
            moveWithMouseDrag = true;
            moveWithKeyboad = true;
        }
    }

    private void Update()
    {
            // Autoriser la caméra à suivre la cible (changé la methode au début)
            if (followTransform != null)
            {
                transform.position = followTransform.position;
            }
            // Nous laisse contrôler la caméra(libre mouvement)
            else
            {
                HandleCameraMovement();
            }
 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                followTransform = null;
            }
        
    }

    public void Teleport(Vector3 InstantPosition)
    {
        transform.position = InstantPosition;
        newPosition = InstantPosition;

    }
    //Les differents types de mouvements pour la camera
    void HandleCameraMovement()
    {
        // Mouse Drag bool
        if (moveWithMouseDrag)
        {
            HandleMouseDragInput();
        }
 
        // Keyboard Control bool
        if (moveWithKeyboad)
        {
            if (Input.GetKey(KeyCode.LeftShift))     //Type de vitesse en fonction du ctrl gauche
            {
                movementSpeed = fastSpeed;
            }
            else
            {
                movementSpeed = normalSpeed;
            }
            //Double possibilités de controle
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))   // Vers le Haut
            {
                // Nouvelle position est egale :
                // (Position du vecteur vers l'avant) X (Notre vitesse juste au dessus)
                newPosition += (transform.forward * movementSpeed);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // Vers le bas
            {
                newPosition += (transform.forward * -movementSpeed);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Vers la droite
            {
                newPosition += (transform.right * movementSpeed);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  // Vers la Gauche
            {
                newPosition += (transform.right * -movementSpeed);
            }

            //TEST
             if (Input.GetKey(KeyCode.E))
             {
                var v3 = new Vector3(0, 5, 0);
                gameObject.transform.Rotate(v3 * movementSpeed);
             }
             if (Input.GetKey(KeyCode.Q))
             {
                var v3 = new Vector3(0, -5, 0);
                gameObject.transform.Rotate(v3 * movementSpeed);
             }
        }
 
        // Edge Scrolling bool 
        if (moveWithEdgeScrolling)
        {
 
            // Vers la droite
            //test si la souris est sur le bord droit de l'ecran 
            if (Input.mousePosition.x > Screen.width - edgeSize)
            {
                //Meme code que celui pour les controles claviers
                newPosition += (transform.right * movementSpeed);
                //Change la texture du curseur avec un ENUM
                ChangeCursor(CursorArrow.RIGHT);
                isCursorSet = true;
            }
 
            // Vers la Gauche
            else if (Input.mousePosition.x < edgeSize)
            {
                newPosition += (transform.right * -movementSpeed);
                ChangeCursor(CursorArrow.LEFT);
                isCursorSet = true;
            }
 
            // Vers le Haut
            else if (Input.mousePosition.y > Screen.height - edgeSize)
            {
                newPosition += (transform.forward * movementSpeed);
                ChangeCursor(CursorArrow.UP);
                isCursorSet = true;
            }
 
            // Vers le bas
            else if (Input.mousePosition.y < edgeSize)
            {
                newPosition += (transform.forward * -movementSpeed);
                ChangeCursor(CursorArrow.DOWN);
                isCursorSet = true;
            }
            else
            {
                if (isCursorSet)
                {
                    ChangeCursor(CursorArrow.DEFAULT);
                    isCursorSet = false;
                }
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementSensitivity);
        //Si nous avons un moniteur supplémentaire, nous ne voulons pas quitter les limites de l'écran
        Cursor.lockState = CursorLockMode.Confined; 
    }
 
    private void ChangeCursor(CursorArrow newCursor)
    {
        // Changer le curseur uniquement si ce n'est pas le même curseur
        if (currentCursor != newCursor)
        {
            switch (newCursor)
            {
                case CursorArrow.UP:
                    // CursorArrowUP = Texture 
                    Cursor.SetCursor(cursorArrowUp, Vector2.zero, CursorMode.Auto); 
                    break;
                case CursorArrow.DOWN:
                    // Spécificité "Vector2()"  
                    // Pour Bas et Droite : le curseur peut sortir de l'ecran 
                    // car le point est sur le bord et la texture est blit en bas à droite 
                    // Donc on change le point pour voir le curseur
                    Cursor.SetCursor(cursorArrowDown, new Vector2(cursorArrowDown.width, cursorArrowDown.height), CursorMode.Auto); // So the Cursor will stay inside view
                    break;
                case CursorArrow.LEFT:
                    Cursor.SetCursor(cursorArrowLeft, Vector2.zero, CursorMode.Auto);
                    break;
                case CursorArrow.RIGHT:
                    Cursor.SetCursor(cursorArrowRight, new Vector2(cursorArrowRight.width, cursorArrowRight.height), CursorMode.Auto); // So the Cursor will stay inside view
                    break;
                case CursorArrow.DEFAULT:
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    break;
            }
 
            currentCursor = newCursor;
        }
    }
 
 
    
    private void HandleMouseDragInput()
    {
        if (Input.GetMouseButtonDown(2) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            float entry;
 
            if (plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(2) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            float entry;
 
            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);
 
                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }
    }
}