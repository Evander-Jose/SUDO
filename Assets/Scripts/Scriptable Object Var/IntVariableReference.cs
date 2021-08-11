using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntVariableReference : MonoBehaviour
{
    public IntVariable intVariable;

    public void SetInt(int value)
    {
        intVariable.Value = value;   
    }
}
