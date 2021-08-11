using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object Variable/String Variable")]
public class StringVariable : ScriptableObject
{
    private string currentValue;
    [SerializeField] private string defaultValue;

    public string CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            currentValue = value;
        }
    }

    private void OnEnable()
    {
        currentValue = defaultValue;
    }
}
