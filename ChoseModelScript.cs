using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoseModelScript : MonoBehaviour
{
    
    private Button button;

    public GameObject ChooseObject;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseObjectFunc);
        
    }

    void ChooseObjectFunc()
    {
        Object.ChooseObject = ChooseObject;
        SceneManager.LoadScene(2);
    }
}
