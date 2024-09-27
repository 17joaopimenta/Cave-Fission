using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

   /*
        Caso haja alguma duvida em relacao a execucao de uma parte do 
        codigo, o mesmo foi documentado por via de comentarios que explicam
        a funcao de cada metodo e atributo para o seu funcionamento. Ou seja, 
        leia-os caso seja necessario.
   */

public class MenuManager : MonoBehaviour
{
    //Estados do menu
    enum MenuStates
    {
        Play,
        Config,
        ExitMenu,
        InitialScreen,
        Saves
    }
    //Estados do menu de configuracao
    enum ConfigStates
    {
        Audio,
        Controlls,
        Graphics
    }

    //Variavel que armazena os estados do menu
    private MenuStates menuController = MenuStates.InitialScreen;

    //Variavel para gerenciamento dos menus de configuracao
    private ConfigStates configStates;

    //Singleton do MenuManager 
    public static MenuManager instance;

    //Armazenar o nome do botao para saber em que menu ele esta
    [HideInInspector] public string armBtnName;

    //Armazenar as telas que serao usadas
    [SerializeField] GameObject[] screens;

    //Armazenar os estados do menu
    [SerializeField] GameObject[] configTabs;

    //Variavel para saber os estados dos saves (carregar ou novo)
    [SerializeField] TextMeshProUGUI titleSaves;

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

    /*Regiao dedicada para as trativas para cada
     situacao do menu, como sair ou desabilitar as telas*/
    #region Controllers

    /// <summary>
    /// Controle dos eventos do menu
    /// </summary>
    private void Menu()
    {        
        //Atualizar o nome do menu de saves para identificar se a sua funcao eh de carregar ou criar um novo save
        titleSaves.text = armBtnName;

        //Ativar as telas de acordo com o valor do menuController
        screens[(int)menuController].SetActive(true);
        
        //Metodo para desabilitar as telas inuteis
        Disabler((int)menuController, screens);    
    }

    /// <summary>
    /// Metodo para quando o player sair da aplicacao
    /// </summary>
    public void EndAplication()
    {
        //Uso do metodo quit do aplication para realizar fim da aplicacao
        Application.Quit();
        //Debug para o modo play (Application.Quit nao funciona dentro da engine)
        Debug.Log("O jogo foi de comes e bebes");
    }

    /// <summary>
    /// Metodo para desabilitar as telas que nao serao usadas no momento 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="screns"></param>
    private void Disabler(int index, GameObject[] screns)
    {
        //Laco de repeticao for para desativar telas
            //Se a posicao do loop for igual ao valor do index ele vai pular esse valor
        for (int i = 0; i < screns.Length; i++)
        {
            if (i == index) continue;           
            //desativar as telas de acordo com a posicao do index
            screns[i].SetActive(false);
        }
        //Checar se o player apertou o botao escape 
            //Se sim o jogador vai voltar para a tela anterior
        if (Input.GetKeyDown(KeyCode.Escape)) Back();
    }

    /// <summary>
    /// Metodo para voltar para a tela anterior
    /// </summary>
    public void Back() 
    {
        //Verificacao se o player esta no menu de saves
            //Se nao estiver, voltar para a tela inicial
            //Se estiver, voltar para a tela play
        if (menuController != MenuStates.Saves)
            menuController = MenuStates.InitialScreen;

        else
            menuController = MenuStates.Play;
    }
    #endregion

    //Regiao para metodos de ativacao de telas
    #region OnClick

    /// <summary>
    /// Ativacao da tela de jogar
    /// </summary>
    public void PlayGame()
    {
        menuController = MenuStates.Play;
    }

    /// <summary>
    /// Ativacao da tela de configuracao
    /// </summary>
    public void Configuration()
    {
        //Setar a primeira tela a ser aberta na tela de configuracoes
        configStates = ConfigStates.Audio;

        menuController = MenuStates.Config;
    }

    /// <summary>
    /// Ativacao do menu de sair
    /// </summary>
    public void ExitMenu()
    {
        menuController = MenuStates.ExitMenu;
    }

    /// <summary>
    /// Ativacao do menu de saves
    /// </summary>
    public void Saves()
    {
        menuController = MenuStates.Saves;
    }
    #endregion

    #region ConfigMenu
    /// <summary>
    /// Tratativas para o menu de configuracao
    /// </summary>
    private void ConfigMenu()
    {
        //Checar se o jogador nao esta no menu de configuracoes
            //Se nao da um retorno no metodo
        if (menuController != MenuStates.Config) return;

        //Ativar as telas de acordo com o valor dos estados de configuracao
        configTabs[(int)configStates].SetActive(true);
        Disabler((int)configStates, configTabs);
    }
    /// <summary>
    /// Ir para as opcoes de audio
    /// </summary>
    public void GoToAudio()
    {
        configStates = ConfigStates.Audio;
    }

    /// <summary>
    /// Ir para as opcoes de controles
    /// </summary>
    public void GoToKey()
    {
        configStates = ConfigStates.Controlls;
    }

    /// <summary>
    /// Ir para as opcoes de graficos
    /// </summary>
    public void GoToGraphics()
    {
        configStates = ConfigStates.Graphics;
    }

    #endregion
}