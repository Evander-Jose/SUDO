using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntVariableDisplay : MonoBehaviour
{
    public IntVariable variableToDisplay;
    public TextMeshProUGUI text;

    private void Update()
    {
        float currentValue = variableToDisplay.Value;
        text.text = currentValue.ToString() ;
    }
}
