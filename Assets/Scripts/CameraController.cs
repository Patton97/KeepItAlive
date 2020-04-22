using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [Range(0, 2)]
    [SerializeField] float CAMSPEED = 1.0f;

    float rotation = 0f;   

    // Start is called before the first frame update
    void Start()
    {
        offset += player.position;
        if(player == null) { player = FindObjectOfType<PlayerController>().gameObject.transform;  }
    }

    // LateUpdate is called after all Updates
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(rotation * CAMSPEED, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

    public void Rotate(float amount)
    {
        rotation = amount;
    }
}
