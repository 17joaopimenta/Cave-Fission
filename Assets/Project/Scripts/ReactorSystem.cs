using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorSystem : MonoBehaviour
{
    public float reactorTemp;
    public int controlRods;
    public bool controlPump1, controlPump2;
    public float powerProduction;
    public static ReactorSystem instance;
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
