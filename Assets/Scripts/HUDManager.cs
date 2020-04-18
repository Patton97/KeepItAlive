using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI cameraInfo;

    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.LogWarning("Warning: multiple " + this + "s in scene!"); }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCameraInfo(string cameraInfo)
    {
        this.cameraInfo.text = cameraInfo;
    }
}
