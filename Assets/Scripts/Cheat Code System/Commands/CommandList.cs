using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands System/Command List")]
public class CommandList : ScriptableObject
{
    public List<Command> validCommands = new List<Command>();

    public Command GetCommand(string command)
    {
        foreach(Command c in validCommands)
        {
            Debug.Log("Comparing the command in the list, " + c.commandName + ", with the received command - " + command);
            if(c.commandName == command)
            {
                Debug.Log("Result: match");
                return c;
            } else
            {
                string trimmed_c = c.commandName.Trim();
                string trimmed_command = command.Trim();
                if (trimmed_c.Length == trimmed_command.Length)
                    Debug.Log("Result: no match, but length of the two strings match.");
                else
                    Debug.Log("Result: no match");
            }
        }

        return null;
    }
}
