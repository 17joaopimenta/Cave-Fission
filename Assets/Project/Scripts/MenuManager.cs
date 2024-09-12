using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    enum MenuStates
    {
        Play,
        Config,
        Exit,
        InitialScreen,
        Saves
    }

    private MenuStates menuController = MenuStates.InitialScreen;

    public static MenuManager instance;

    private string armLastName;
    [HideInInspector] public string armBtnName;

    [SerializeField] GameObject[] screens;

    //Save and load buttons
    [SerializeField] Sprite[] buttonStates;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        ShowMenu();
        DisableMenu();
        Debug.Log("Botao apertado : "+armBtnName);
    }

    #region ShowDisableMenu
    private void ShowMenu()
    {
        armLastName = menuController.ToString();
        
        screens[(int)menuController].SetActive(true);
        
        Debug.Log(armLastName);
    }

    private void DisableMenu()
    {
        foreach (var screen in screens)
        {
            if (screen.name != armLastName) screen.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Back();
    }
    #endregion

    #region OnClick

    public void PlayGame()
    {
        menuController = MenuStates.Play;
    }

    public void Configuration()
    {
        menuController = MenuStates.Config;
    }

    public void Exit()
    {
        menuController = MenuStates.Exit;
    }

    public void Back() 
    {
        if (menuController != MenuStates.Saves)
            menuController = MenuStates.InitialScreen;
        
        else 
            menuController = MenuStates.Play;
        
        if (armBtnName != null) armBtnName = null;
    }

    public void Saves()
    {
        menuController = MenuStates.Saves;
    }
    #endregion
}