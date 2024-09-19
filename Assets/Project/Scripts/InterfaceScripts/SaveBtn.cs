using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveBtn : MonoBehaviour
{
    enum SaveStatus
    {
        Empty,
        Fill
    }

    private SaveStatus status;

    private Image saveRender;
    [SerializeField] Sprite[] saveImg;
    private string savePath;
    private const string saveTxt = "gameSave";

    private void Awake()
    {
        /*saveTxt = gameObject.name + " : is Saved";*/
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
