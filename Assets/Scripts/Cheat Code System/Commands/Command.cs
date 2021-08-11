using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ScriptableObject
{
    public string commandName = "sudo something-something";
    public float commandDuration = 5f;

    public abstract void ExecuteCommand(float timeElapsedSinceStarted, GameObject self);
}
