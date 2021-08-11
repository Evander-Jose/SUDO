using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandExecutor : MonoBehaviour
{
    public CommandList commandList;
    [Space]
    public StringVariable lastPassedCommandRaw;
    public StringVariable lastPassedCommand; //This one's going to be shown by the UI.
    [Space]
    public BoolVariable isBusyExecutingPreviousCommand; //Busy, in a sense that a command is still being carried out.
    public BoolVariable isLastCommandValid;
    [Space]
    public FloatVariable maxCommandDuration;
    public FloatVariable currentCommandDuration;

    private Command previousCommand;

    public void ExecuteCommand()
    {
        //First, check if the command is in the command list:
        string stringReceived = lastPassedCommandRaw.CurrentValue.Trim();

        previousCommand = commandList.GetCommand(stringReceived);

        if (previousCommand == null)
        {
            Debug.LogWarning("The command, " + stringReceived + " does not exist within the command list.");
            return;
        }            

        if (isBusyExecutingPreviousCommand.CurrentValue == false)
        {
            //Sets the maximum duration of the command, so that this can be shown later in the HUD
            maxCommandDuration.Value = previousCommand.commandDuration;

            //Then, run a coroutine for that command for a given amount of time.
            StartCoroutine(CommandExecutionCoroutine(previousCommand.commandDuration));
        } else
        {
            Debug.LogWarning("Not allowed to execute two commands at once!");
        }
    }

    private IEnumerator CommandExecutionCoroutine(float commandDuration)
    {
        float timeElapsedSinceCoroutineStarted = 0f;
        while(timeElapsedSinceCoroutineStarted < commandDuration)
        {
            isBusyExecutingPreviousCommand.CurrentValue = true;
            
            previousCommand.ExecuteCommand(timeElapsedSinceCoroutineStarted, gameObject);

            timeElapsedSinceCoroutineStarted += Time.deltaTime;

            yield return null;
        }

        //Oops, forgot to reset the busy bool back to false:
        isBusyExecutingPreviousCommand.CurrentValue = false;
    }
}
