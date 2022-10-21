using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        DataKeeper.Instance.LoadScore();
        nameInput.text=DataKeeper.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        DataKeeper.playerName = nameInput.text;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }
}
