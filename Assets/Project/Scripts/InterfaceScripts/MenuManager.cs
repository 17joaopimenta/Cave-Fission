using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    //Estados do menu
    enum MenuStates
    {
        Play,
        Config,
        Exit,
        InitialScreen,
        Saves
    }

    enum ConfigStates
    {
        Audio,
        Controlls,
        Graphics
    }

    //Variavel que armazena os estados do menu
    private MenuStates menuController = MenuStates.InitialScreen;

    //Variavel para gerenciamento dos menus de configuracao
    private ConfigStates configStates = ConfigStates.Audio;

    //Singleton do MenuManager 
    public static MenuManager instance;

    //Variavel para fazer a tratativa do menu
    private string armLastName;
   
    //Armazenar o nome do botao para saber em que menu ele esta
    [HideInInspector] public string armBtnName;

    //Armazenar as telas que serao usadas
    [SerializeField] GameObject[] screens;

    [SerializeField] TextMeshProUGUI title;

    private void Awake()
    {
        //Setar o singleton
        instance = this;
    }

    private void Update()
    {
        ShowMenu();
        DisableMenu();
        ConfigMenu();
    }

    /*Regiao criada para selecionar as funcoes de 
      mostrar e desabilitar o menu*/
    #region ShowDisableMenu
    private void ShowMenu()
    {
        armLastName = menuController.ToString();
        
        title.text = armBtnName;

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

    #region ConfigMenu

    private void ConfigMenu()
    {
        if (menuController != MenuStates.Config) return; 

        switch (configStates)
        {
            case ConfigStates.Audio:
                Debug.Log("Audios");
                break;

            case ConfigStates.Controlls:
                Debug.Log("Controles");
                break;

            case ConfigStates.Graphics:
                Debug.Log("Gráficos");
                break;
        }
    }

    public void GoToAudio()
    {
        configStates = ConfigStates.Audio;
    }

    public void GoToKey()
    {
        configStates = ConfigStates.Controlls;
    }

    public void GoToGraphics()
    {
        configStates = ConfigStates.Graphics;
    }

    #endregion
}