using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    InputMaster controls;
    [SerializeField] Camera[] cameras;
    Animator anim;
    int currentCamera = 0;
    const float MOVESPEED = 1.0f;
    const float ROTSPEED = 0;

    Vector2 movement = Vector2.zero;
    float rotation = 0;

    [SerializeField] GameObject model;

    // Start is called before the first frame update
    void Awake()
    {
        InitialiseControls();
        InitialiseCameras();
        anim = GetComponentInChildren<Animator>();
        
        SwitchCamera();
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

    #region Camera
    void SwitchCamera(int newCamera = 0)
    {
        cameras[currentCamera].enabled = false;
        currentCamera = newCamera;
        ValidateCameraSelection();
        cameras[currentCamera].enabled = true;
        HUDManager.Instance.UpdateCameraInfo(cameras[currentCamera].name);
    }
    void PreviousCamera() => SwitchCamera(currentCamera - 1);
    void NextCamera() => SwitchCamera(currentCamera + 1);
    #endregion


    void UpdateMovement()
    {
        // Find "forward", relative to camera
        Vector3 forward = cameras[currentCamera].transform.forward; //NOTE: Could be cached every time camera changes
        Vector3 right = cameras[currentCamera].transform.right; //NOTE: Could be cached every time camera changes

        // Project across horizontal plane (y = 0)
        forward.y = 0f;
        forward.Normalize();
        right.y = 0f;
        right.Normalize();

        //this is the direction in the world space we want to move:
        Vector3 direction = forward * movement.y * MOVESPEED + right * movement.x * MOVESPEED;

        //now we can apply the movement:
        transform.Translate(direction * 1.0f * Time.deltaTime);

        //dumb hacky rotation
        model.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), 2.2f); 

        anim.SetBool("isWalking", movement != Vector2.zero);
    }

    void ValidateCameraSelection()
    {
        //Wrap-around cameras (n-1, n <-> 0, 1)
        if (currentCamera < 0)
            currentCamera = cameras.Length - 1; 
        if (currentCamera >= cameras.Length)
            currentCamera = 0; 
    }

    #region Initialisers
    void InitialiseControls()
    {
        controls = new InputMaster();
        controls.Player.SwitchCamera.performed += ctx => SwitchCamera(currentCamera + (int)ctx.ReadValue<float>());
        controls.Player.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
    }

    // Make sure player has a list of cameras to switch through
    void InitialiseCameras()
    {
        if (cameras == null || cameras.Length <= 0)
        {
            //Terribly inefficient, only runs if something goes wrong
            cameras = GameObject.Find("/CCTV").GetComponentsInChildren<Camera>();
        }
    }
    #endregion
}
