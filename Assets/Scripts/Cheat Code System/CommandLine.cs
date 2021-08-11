using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CommandLine : MonoBehaviour
{
    public TMP_InputField commandLine;
    public StringVariable lastCommandPassedRaw;
    [Space]
    public BoolVariable playerCanMove;
    public IntVariable timeSlowdownPercent;
    [Space]
    public GameEvents.GameEvent commandPassedEvent;
    bool active = false;

    private UnityAction<string> _onDeselect;
    private UnityAction<string> _onFinishedEditing;

    private void Awake()
    {
        commandLine = FindObjectOfType<TMP_InputField>();
    }

    private void Start()
    {  
        _onDeselect += PassCommand;
        _onDeselect += HideCommandLine;

        _onFinishedEditing += PassCommand;
        _onFinishedEditing += HideCommandLine;

        commandLine.onDeselect.AddListener(_onDeselect);
        commandLine.onEndEdit.AddListener(_onFinishedEditing);
        commandLine.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && !active)
        {
            //This block of code does the things when the command line gets pulled up:
            
            //Sets the active variable to true, cos duh
            active = true;

            //Bring up the command line
            commandLine.gameObject.SetActive(active);

            //These two lines of code allow the player to immediately type in whatever
            //into the command lnie after it got pulled up:
            commandLine.Select();
            commandLine.ActivateInputField();

            //Debug.Log("Command line selected, type away!");

            //Slows down time (very cool):
            Time.timeScale = (float)(timeSlowdownPercent.Value / 100f);

            playerCanMove.CurrentValue = false;

        } else if (Input.GetButtonDown("Fire2") && active)
        {
            //When the command line is active, and the player presses right mouse button,
            //the command line will be hidden:
            HideCommandLine(" ");       
        }

        if(Input.GetKeyDown(KeyCode.Return) && active)
        {
            PassCommand(commandLine.text);
        }
    }

    public void PassCommand(string command)
    {
        //The 'command' parameter is actually the string that's typed in by the player
        //when the player types in the command line.

        //Debug.Log(command);
        if (command != null && lastCommandPassedRaw != null)
            lastCommandPassedRaw.CurrentValue = command;

        commandPassedEvent.CallEvent();
    }

    private void HideCommandLine(string param)
    {
        active = false;
        playerCanMove.CurrentValue = true;
        commandLine.text = "";
        commandLine.gameObject.SetActive(active);

        //And time goes back to normal:
        Time.timeScale = 1f;
    }
}
