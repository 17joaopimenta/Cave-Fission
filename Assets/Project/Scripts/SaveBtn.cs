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
    private string savePath, saveTxt;

    private void Awake()
    {
        saveTxt = gameObject.name + " : is Saved";
        savePath = PlayerPrefs.GetString(saveTxt);
        saveRender = GetComponent<Image>();
    }

    private void Update()
    {
        ImageSet();
    }

    void DeterminedStatesSaves()
    {
        Debug.Log("Texto da mensagem que eu quero : "+saveTxt);
        
        if (savePath != saveTxt) 
            status = SaveStatus.Empty;        
        
        else status = SaveStatus.Fill;
    }

    public void SetSave()
    {
        if (savePath != saveTxt)
        {
            CreateNewSave();
        }
        else 
        { 
            if (MenuManager.instance.armBtnName == "Carregar Jogo") SceneManager.LoadScene("Usine"); 
            else DeleteSave();
        }
        Debug.Log(savePath);
    }

    void DeleteSave()
    {
        Debug.Log("Save Deletado");
    }

    void CreateNewSave()
    {
        PlayerPrefs.SetString(saveTxt, "saveTxt");
        SceneManager.LoadScene("Usine");
    }

    void ImageSet()
    {
        DeterminedStatesSaves();
        saveRender.sprite = saveImg[(int)status];
    }
}
