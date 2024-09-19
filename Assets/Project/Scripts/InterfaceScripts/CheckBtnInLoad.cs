using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBtnInLoad : MonoBehaviour
{
    
    public void ArmName()
    {
        MenuManager.instance.armBtnName = gameObject.name;
    }
}
