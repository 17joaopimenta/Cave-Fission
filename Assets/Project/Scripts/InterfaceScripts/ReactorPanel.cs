using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReactorPanel : MonoBehaviour
{
    [SerializeField] TMP_Text tempDisplay, rodsDisplay, feed1Status, feed2Status, pump1Status, pump2Status, powerProd;

    private void Update()
    {
        DisplayUpdate();
    }
   

    void DisplayUpdate()
    {
        tempDisplay.text = "Temperatura: "+ReactorSystem.instance.reactorTemp;
        rodsDisplay.text = "Control Rods: " + ReactorSystem.instance.controlRods + "%";
        powerProd.text = "Produção: " + ReactorSystem.instance.powerProduction + "Kw";
        if (ReactorSystem.instance.controlPump1)
        {
            pump1Status.text = "Bomba 1: ON";
        }
        else { pump1Status.text = "Bomba 1: OFF"; }

        if (ReactorSystem.instance.controlPump2)
        {
            pump2Status.text = "Bomba 2: ON";
        }
        else { pump2Status.text = "Bomba 2: OFF"; }

    }


}
