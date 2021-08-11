using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEvent : MonoBehaviour
{
    public delegate void OnTriggerEnter(Collider2D col);
    public event OnTriggerEnter onTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter?.Invoke(collision);
    }
}
