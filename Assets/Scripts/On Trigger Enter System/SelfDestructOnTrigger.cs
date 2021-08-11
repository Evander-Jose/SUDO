using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OnTriggerEvent))]
public class SelfDestructOnTrigger : MonoBehaviour
{
    OnTriggerEvent trigger;

    private void Start()
    {
        trigger = GetComponent<OnTriggerEvent>();
        trigger.onTriggerEnter += SelfDestruct;
    }

    void SelfDestruct(Collider2D col)
    {
        Destroy(gameObject);
    }
}
