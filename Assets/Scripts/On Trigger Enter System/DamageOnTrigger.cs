using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OnTriggerEvent))]
public class DamageOnTrigger : MonoBehaviour
{
    private OnTriggerEvent triggerEvent;
    public float damageAmount = 1f;

    private void Start()
    {
        triggerEvent = GetComponent<OnTriggerEvent>();
        triggerEvent.onTriggerEnter += DamageOtherCollider;
    }

    //This function searches for a health component within the game object that touches this game object
    //and then calls the damage function within that health component.
    void DamageOtherCollider(Collider2D other)
    {
        Health healthComponent = other.GetComponent<Health>();
        if(healthComponent != null)
        {
            healthComponent.DealDamage(damageAmount);
        }
    }
}
