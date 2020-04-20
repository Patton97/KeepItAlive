using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This stupid fucking script shouldn't have to exist why can't i do this in the editor holy shit
public class RigidBodyEditor : MonoBehaviour
{
    [SerializeField] Vector3 centerOfMass = Vector3.zero;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass += centerOfMass;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(centerOfMass, .1f);
    }
}
