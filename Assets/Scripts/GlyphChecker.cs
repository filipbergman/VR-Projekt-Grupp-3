using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GlyphChecker : MonoBehaviour
{
    public string code;
    private string input;
    public InputField field;

    public void ReadStringInput(string codeText) 
    {
        input = codeText;

        if(input.ToLower() == code.ToLower()) 
        {
            Debug.Log("RIGHT CODE!");
        } else {
            field.text = "";
            Debug.Log(input);
        }


    }
}
