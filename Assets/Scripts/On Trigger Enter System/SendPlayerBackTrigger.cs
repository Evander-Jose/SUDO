using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OnTriggerEvent))]
public class SendPlayerBackTrigger : MonoBehaviour
{
    private OnTriggerEvent triggerEvent;

    [SerializeField]
    public Transform spawnpoint;
    public int spawnpointInstanceID = 0;

    private void Start()
    {
        triggerEvent = GetComponent<OnTriggerEvent>();
        triggerEvent.onTriggerEnter += ReturnPlayerToSpawnpoint;
    }

    private void OnDrawGizmos()
    {
        //Draws the sphere:
        Gizmos.DrawWireSphere(spawnpoint.position, 0.5f);

        //Draws the line from whatever object is sending the player back to the spawnpoint:
        Gizmos.DrawLine(transform.position, spawnpoint.position);
    }

    void ReturnPlayerToSpawnpoint(Collider2D other)
    {
        //Check if the thing that is being collided with is the player:
        //Ugh, fine, I guess I'll compare tags.
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = spawnpoint.position;
        }

        Time.timeScale = 1f;
    }
}
