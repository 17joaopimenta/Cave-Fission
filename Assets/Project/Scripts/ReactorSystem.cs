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
    bool rodsMoving = false;
    private void Awake()
    {
        instance = this;
        StartCoroutine(ReactorUpdate());
    }

    public void ScramReactor()
    {

    }

    public void LiftRods()
    {
        //ergue as control rods (diminui a porcentagem)
        if (rodsMoving || ReactorSystem.instance.controlRods <= 10) return;
        StartCoroutine(MoveRods(true));
    }

    public void LowerRods()
    {
        //abaixa as control rods (aumenta a porcentagem)
        if (rodsMoving || ReactorSystem.instance.controlRods >= 100) return;
        StartCoroutine(MoveRods(false));
    }

    IEnumerator MoveRods(bool lift)
    {
        if (!rodsMoving)
        {
            rodsMoving = true;
            for (int i = 0; i < 10; i++)
            {
                if (lift)
                {
                    ReactorSystem.instance.controlRods -= 1;
                    //efeito sonoro
                }
                else
                {
                    ReactorSystem.instance.controlRods += 1;
                    //efeito sonoro
                }
                yield return new WaitForSeconds(1);

            }
            rodsMoving = false;
        }

        yield return null;
    }

    IEnumerator ReactorUpdate()
    {
        while (true)
        {
            float increaseTemp = (10f / controlRods);
            if (controlPump1 == true)
            {
                increaseTemp--;
            }
            if (controlPump2 == true)
            {
                increaseTemp--;
            }
            reactorTemp += increaseTemp;
            yield return new WaitForSeconds(1);
        }
    }
}
