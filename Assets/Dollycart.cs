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
        controls.Dollycart.Interact.performed += _ => Interact();//Move to playercontroller?
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
        isPlayerNear = other.GetComponent<PlayerController>();
        prompt.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        isPlayerNear = !other.GetComponent<PlayerController>();
        prompt.SetActive(false);
    }


    public void Interact()
    {
        if (isPlayerNear && !isPlayerPushing)
            StartPushing();
        else
            StopPushing();
    }

    void StartPushing()
    {
        controls.Dollycart.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        player.ToggleMovementControls(false);
        controls.Dollycart.Movement.Enable();
        Debug.Log("CART ON");
        isPlayerPushing = true;
    }

    void StopPushing()
    {
        controls.Dollycart.Movement.performed -= ctx => movement = ctx.ReadValue<Vector2>();
        player.ToggleMovementControls(true);
        controls.Dollycart.Movement.Disable();
        Debug.Log("CART OFF");
        isPlayerPushing = false;        
    }

    void UpdateMovement()
    {
        if(isPlayerPushing) { return; }
        if (Mathf.Abs(movement.x) > 0.75)
            transform.Rotate(Vector3.up, movement.x * TURNSPEED);

        transform.Translate(0, 0, movement.y * MOVESPEED * Time.deltaTime);        
    }
}
