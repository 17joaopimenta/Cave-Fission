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

   
    //Armazenar o nome do botao para saber em que menu ele esta
    [HideInInspector] public string armBtnName;

    //Variavel para fazer a tratativa do menu
    //private string armLastName;
    //Armazenar as telas que serao usadas
    [SerializeField] GameObject[] screens;

    //Variavel para fazer a tratativa das janelas de configuracao
    //private string armTabName;
    //Armazenar os estados do menu
    [SerializeField] GameObject[] configTabs;

    [SerializeField] TextMeshProUGUI title;

    private void Awake()
    {
        //Setar o singleton
        instance = this;
    }

    private void Update()
    {
        Menu();
        ConfigMenu();
    }

    /*Regiao criada para selecionar as funcoes de 
      mostrar e desabilitar o menu*/
    #region ShowDisableMenu
    private void Menu()
    {        
        title.text = armBtnName;

        screens[(int)menuController].SetActive(true);
        Disabler((int)menuController, screens);    
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

        configTabs[(int)configStates].SetActive(true);
        Disabler((int)configStates, configTabs);
    }

    private void Disabler(int index, GameObject[] screns)
    {
        for (int i = 0; i < screns.Length; i++)
        {
            if (i == index) continue;           
            screns[i].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Back();
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