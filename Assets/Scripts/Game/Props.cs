using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigibody;

    public void AddForce(Vector3 force, Vector3 position)
    {
        _rigibody.AddForceAtPosition(force, position,ForceMode.Impulse);
    }
}
