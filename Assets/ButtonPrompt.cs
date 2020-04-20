using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPrompt : MonoBehaviour
{
    [SerializeField] GameObject prompt_KBM, prompt_DS4, prompt_XB1;
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
           { "Keyboard", prompt_KBM },
           { "Wireless Controller", prompt_DS4 },
           { "Controller (XBOX 360 For Windows)", prompt_XB1 }
        };

        foreach(var pair in devicePrompts)
        {
            if(pair.Value == null) { Debug.LogWarning("Missing " + pair.Key + " prompt"); }
        }
        InitialisePrompt();

        player = FindObjectOfType<PlayerController>();
        player.OnDeviceUpdate += ctx => ChangeDevice(ctx.device);
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
        if (other.GetComponent<PlayerController>())
        {
            isPlayerNear = true;
            prompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            isPlayerNear = false;
            prompt.SetActive(false);
        }
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
        prompt = Instantiate(prompt_KBM, transform);
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
}
