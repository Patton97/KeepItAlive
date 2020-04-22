using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    InputMaster controls;
    Animator anim;
    const float MOVESPEED = 1.0f;
    const float ROTSPEED = 0;
    Camera camera;
    CameraController cameraController;
    public event System.Action<InputDevice> OnDeviceUpdate;
    public event System.Action OnInteract;

    Vector2 movement = Vector2.zero;
    [SerializeField] GameObject model;


    // Start is called before the first frame update
    void Awake()
    {
        InitialiseControls();
        InitialiseCamera();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateMovement();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    #region Initialisers
    void InitialiseControls()
    {
        controls = new InputMaster();
        controls.Player.Movement.performed += Movement_performed;
        controls.Player.Camera.performed += ctx => cameraController.Rotate(ctx.ReadValue<float>());
        controls.Player.InteractionVehicle.started += _ => Interact();
    }    

    void InitialiseCamera()
    {
        if (camera == null) { camera = Camera.main; }
        if (cameraController == null) { cameraController = camera.GetComponent<CameraController>(); }
    }
    #endregion

    void UpdateMovement()
    {
        // Find "forward", relative to camera
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;

        // Project across horizontal plane (y = 0)
        forward.y = 0f;
        forward.Normalize();
        right.y = 0f;
        right.Normalize();

        //this is the direction in the world space we want to move:
        Vector3 direction = forward * movement.y + right * movement.x;


        //now we can apply the movement:
        transform.Translate(direction * MOVESPEED * Time.deltaTime);

        //Quartenion.LookRotation rejects true-zero vectors
        if (direction != Vector3.zero)
        {
            model.transform.rotation = Quaternion.LookRotation(direction.normalized);
        }

        anim.SetBool("isWalking", movement != Vector2.zero);
    }
    
    void SetMovement(Vector2 movement)
    {
        this.movement = movement;
    }

    public void ToggleMovementControls(bool active)
    {        
        if (active)
        {
            controls.Player.Movement.performed += Movement_performed;
        }            
        else
        {
            controls.Player.Movement.performed -= Movement_performed;
            SetMovement(Vector2.zero);
        }
    }

    void Interact() => OnInteract?.Invoke();

    // Runs every time we hear from a device
    // Yes it's a dumb solution, but it's a start.
    void DeviceUpdate(InputDevice device) => OnDeviceUpdate?.Invoke(device);

    // ********************************************************************************
    // Input callbacks ****************************************************************
    // ********************************************************************************
    void MovementDigital_performed(InputAction.CallbackContext ctx)
    {
        SetMovement(ctx.ReadValue<Vector2>());

        // Unity's deadzone sends an empty vector, rather than not sending anything
        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            DeviceUpdate(ctx.control.device);
        }
    }

    void MovementAnalog_performed(InputAction.CallbackContext ctx)
    {
        SetMovement(ctx.ReadValue<Vector2>());
        
        // Unity's deadzone sends an empty vector, rather than not sending anything
        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {            
            DeviceUpdate(ctx.control.device);
        }
    }

    void Movement_performed(InputAction.CallbackContext ctx)
    {
        SetMovement(ctx.ReadValue<Vector2>());

        // Unity's deadzone sends an empty vector, rather than not sending anything
        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            DeviceUpdate(ctx.control.device);
        }
    }
}
