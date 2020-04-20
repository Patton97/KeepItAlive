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
    bool isPushingCart;
    public event System.Action<InputDevice> OnDeviceUpdate;

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
        controls.Player.MovementDigital.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.MovementAnalog.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.Camera.performed += ctx => cameraController.Rotate(ctx.ReadValue<float>());

        controls.Player.MovementAnalog.actionMap.actionTriggered += ctx => DeviceUpdate(ctx.control.device);
    }
    

    void InitialiseCamera()
    {
        if (camera == null) { camera = Camera.main; }
        if (cameraController == null) { cameraController = camera.GetComponent<CameraController>(); }
    }
    #endregion


    void UpdateMovement()
    {
        if (isPushingCart) { return; }
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


        if (direction != Vector3.zero)
        {
            model.transform.rotation = Quaternion.LookRotation(direction.normalized);
        }

        anim.SetBool("isWalking", movement != Vector2.zero);
    }

    public void ToggleMovementControls(bool active)
    {
        if (active)
            controls.Player.MovementDigital.performed += ctx => movement = ctx.ReadValue<Vector2>();
        else
            controls.Player.MovementAnalog.performed -= ctx => movement = ctx.ReadValue<Vector2>();
    }

    // Runs every time we hear from a device
    // Yes it's a dumb solution, but it's a start.
    void DeviceUpdate(InputDevice device)
    {
        OnDeviceUpdate?.Invoke(device);
    }
}
