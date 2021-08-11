using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands System/Commands/Sudo_Invc")]
public class Command_Sudo_Invc : Command
{
    public override void ExecuteCommand(float timeElapsedSinceStarted, GameObject self)
    {
        Debug.Log("Player has been invincible for " + timeElapsedSinceStarted);
    }
}
