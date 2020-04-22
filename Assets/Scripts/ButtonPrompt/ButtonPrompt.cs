using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPrompt : MonoBehaviour
{
    [SerializeField] ButtonPromptManager.ButtonPrompt prompt_KBM, prompt_PS, prompt_XB;
    [SerializeField] Camera camera;
    [Range(0, 5)]
    [SerializeField] float TURNSPEED = 2.5f;
    [Range(0, 1)]
    [SerializeField] float PULSESPEED = 1.0f;
    GameObject prompt;
    Dictionary<string, GameObject> devicePrompts;
    InputDevice device;
    bool isPlayerNear = false;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        devicePrompts = new Dictionary<string, GameObject>
        {
           { "Keyboard", ButtonPromptManager.Keyboard[prompt_KBM] },
           { "Wireless Controller", ButtonPromptManager.Playstation[prompt_PS] },
           //{ "Controller (XBOX 360 For Windows)", ButtonPromptManager.Keyboard[prompt_XB] }
        };
        
        InitialisePrompt();

        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerNear) { return; }
        UpdateRotation();
        UpdatePulse();
    }

    void OnTriggerEnter(Collider other)
    {
        //Ignore if player already near
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

    void UpdateRotation()
    {
        Vector3 direction = camera.transform.position - prompt.transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(prompt.transform.rotation, toRotation, TURNSPEED * Time.deltaTime);
    }

    void UpdatePulse()
    {
        //Bounces between 0.25 & 0.75
        float t = Mathf.PingPong(Time.time * PULSESPEED, 0.2f) + 0.4f;
        prompt.transform.localScale = Vector3.one * t;
    }

    void ChangeDevice(InputDevice device)
    {
        if(this.device == device) { return; }

        this.device = device;
        Debug.Log(device.displayName);
        ChangePrompt(devicePrompts[device.displayName]);
    }

    void InitialisePrompt()
    {
        prompt = Instantiate(devicePrompts["Keyboard"], transform);
        prompt.transform.localScale = Vector3.one * 0.5f;
        prompt.SetActive(false);
    }

    void ChangePrompt(GameObject prefab)
    {
        GameObject temp = Instantiate(prefab, transform);
        temp.transform.localScale = prompt.transform.localScale;
        temp.SetActive(prompt.activeSelf);
        Destroy(prompt);
        prompt = temp;
    }

    public void SetActive(bool active)
    {
        prompt.SetActive(active);
    }

    void PlayerIsNear(bool isPlayerNear)
    {
        this.isPlayerNear = isPlayerNear;
        prompt.SetActive(isPlayerNear);

        if (isPlayerNear)
            player.OnDeviceUpdate += ctx => ChangeDevice(ctx.device);
        else
            player.OnDeviceUpdate -= ctx => ChangeDevice(ctx.device);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .25f);
    }
}
