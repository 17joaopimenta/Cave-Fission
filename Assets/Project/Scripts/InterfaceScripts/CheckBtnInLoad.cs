using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
        Caso haja alguma duvida em relacao a execucao de uma parte do 
        codigo, o mesmo foi documentado por via de comentarios que explicam
        a funcao de cada metodo e atributo para o seu funcionamento. Ou seja, 
        leia-os caso seja necessario.
    */
public class CheckBtnInLoad : MonoBehaviour
{
    public void ArmName()
    {
        MenuManager.instance.armBtnName = gameObject.name;
    }
}
