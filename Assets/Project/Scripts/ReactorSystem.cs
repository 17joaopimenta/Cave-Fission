using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorSystem : MonoBehaviour
{
    float reactorTemp;
    int controlRods;
    bool controlPump1, controlPump2;
    float powerConsumption;

    private void Start()
    {
        StartCoroutine(ReactorUpdate());
    }


    IEnumerator ReactorUpdate()
    {
        while (true)
        {
            float increaseTemp = (10f / controlRods);
            if (controlPump1 == true)
            {
                increaseTemp++;
            }
            if (controlPump2 == true)
            {
                increaseTemp++;
            }
            reactorTemp += increaseTemp;
            yield return new WaitForSeconds(1);
        }
    }
}
