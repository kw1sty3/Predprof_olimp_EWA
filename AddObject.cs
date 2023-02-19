using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{
    private ProgrammScript ProgrammScriptScript;
    private Button button;
    void Start()
    {
        ProgrammScriptScript = FindObjectOfType<ProgrammScript>();
        button = GetComponent<Button>();
        button.onClick.AddListener(StartView);
    }

    // Update is called once per frame
    void StartView()
    {
        ProgrammScriptScript.flag = true;
    }
}
