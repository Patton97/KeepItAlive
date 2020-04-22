using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dollycart : MonoBehaviour
{    
    InputMaster controls;
    [Range(0,5)]
    [SerializeField] float MOVESPEED = 1.0f;
    [Range(0,1)]
    [SerializeField] float TURNSPEED = 1.0f;
    bool isPlayerPushing = false;
    bool isPlayerNear = false;
    PlayerController player;
    ButtonPrompt prompt;

    Vector2 movement;

    void Awake()
    {
        controls = new InputMaster();
        player = FindObjectOfType<PlayerController>();
        if(prompt == null) { prompt = GetComponentInChildren<ButtonPrompt>(); }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(false);
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

    void OnTriggerEnter(Collider other)
    {
        //Ignore if player already registered as near
        if (isPlayerNear) { return; }
        //Ignore if collider is not attached to player
        if (!other.GetComponent<PlayerController>()) { return; }

        PlayerIsNear(true);
    }

    void OnTriggerExit(Collider other)
    {
        //Ignore if player not registered as near
        if (!isPlayerNear) { return; }
        //Ignore if collider is not attached to player
        if (!other.GetComponent<PlayerController>()) { return; }

        PlayerIsNear(false);
    }


    void Interact()
    {
        if (isPlayerNear && !isPlayerPushing)
            StartPushing();
        else
            StopPushing();
    }

    void StartPushing()
    {
        player.ToggleMovementControls(false);
        this.EnableMovementControls();
        Debug.Log("CART ON");
        isPlayerPushing = true;
    }

    void StopPushing()
    {
        this.DisableMovementControls();
        player.ToggleMovementControls(true);
        Debug.Log("CART OFF");
        isPlayerPushing = false;        
    }

    void UpdateMovement()
    {
        if (isPlayerPushing) { return; }
        if (Mathf.Abs(movement.x) > 0.75)
            transform.Rotate(Vector3.up, movement.x * TURNSPEED);

        transform.Translate(0, 0, movement.y * MOVESPEED * Time.deltaTime);        
    }

    void PlayerIsNear(bool isPlayerNear)
    {
        this.isPlayerNear = isPlayerNear;
        prompt.SetActive(isPlayerNear);

        if (isPlayerNear)
            player.OnInteract += Interact;
        else
            player.OnInteract -= Interact;
    }

    void EnableMovementControls()
    {
        controls.Dollycart.MovementAnalog.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Dollycart.MovementDigital.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Dollycart.MovementAnalog.Enable();
        controls.Dollycart.MovementDigital.Enable();
    }

    void DisableMovementControls()
    {
        controls.Dollycart.MovementAnalog.performed -= ctx => movement = ctx.ReadValue<Vector2>();
        controls.Dollycart.MovementDigital.performed -= ctx => movement = ctx.ReadValue<Vector2>();
        controls.Dollycart.MovementAnalog.Disable();
        controls.Dollycart.MovementDigital.Disable();
    }
}
