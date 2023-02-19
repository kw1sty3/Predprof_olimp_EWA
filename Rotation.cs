using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rotation : MonoBehaviour
{
    private Button Button;
    private ProgrammScript ProgrammScriptScript;

    void Start()
    {
        ProgrammScriptScript = FindObjectOfType<ProgrammScript>();
        Button = GetComponent<Button>();
        Button.onClick.AddListener(RotFunc);
    }

    // Update is called once per frame
    void RotFunc()
    {
        if (ProgrammScriptScript.Rotation)
        {
            ProgrammScriptScript.Rotation = false;
        }
        else
        {
            ProgrammScriptScript.Rotation = true;
        }
    }
}
