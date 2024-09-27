using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

   /*
        Caso haja alguma duvida em relacao a execucao de uma parte do 
        codigo, o mesmo foi documentado por via de comentarios que explicam
        a funcao de cada metodo e atributo para o seu funcionamento. Ou seja, 
        leia-os caso seja necessario.
   */

public class SaveBtn : MonoBehaviour
{
    /// <summary>
    /// Estados dos botoes de save
    /// </summary>
    enum SaveStatus
    {
        Empty,
        Fill
    }

    //Variavel para acessar os estados do save
    private SaveStatus status;

    //Variavel para o render da imagem
    private Image saveRender;

    [Tooltip("Vector de imagens para o save")]
    [SerializeField] Sprite[] saveImg;
    private string savePath;
    private const string saveTxt = "gameSave";

    private void Awake()
    {
        string _saveTxt = "Save :" + gameObject.name;
        savePath = PlayerPrefs.GetString(_saveTxt);
        saveRender = GetComponent<Image>();
    }

    private void Update()
    {
        ImageSet();
    }

    void DeterminedStatesSaves()
    {
        Debug.Log("Texto da mensagem que eu quero : "+saveTxt);
        
        string _armText = saveTxt + gameObject.name;
        if (savePath != _armText) 
            status = SaveStatus.Empty;        
        
        else status = SaveStatus.Fill;
    }

    public void SetSave()
    {
        string _armText = saveTxt + gameObject.name;
        if (savePath != _armText)
        {
            if (MenuManager.instance.armBtnName == "Carregar Jogo") return;

            CreateNewSave();
        }
        else
        {
            if (MenuManager.instance.armBtnName == "Carregar Jogo") SceneManager.LoadScene("Stage1");
            else DeleteSave();
        }
        Debug.Log("Caminho do save : "+savePath);
    }

    void DeleteSave()
    {
        Debug.Log("Save Deletado");
    }

    void CreateNewSave()
    {
        string _armText = saveTxt + gameObject.name;
        string _saveTxt = "Save :" + gameObject.name;

        PlayerPrefs.SetString(_saveTxt, _armText);

        SceneManager.LoadScene("Stage1");
    }

    void ImageSet()
    {
        DeterminedStatesSaves();
        saveRender.sprite = saveImg[(int)status];
    }
}
