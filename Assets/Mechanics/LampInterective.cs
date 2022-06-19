using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampInterective : MonoBehaviour
{
    bool isTurnedOn = true;
    public Material materialOn;
    public Material materialOff;
   public void Action()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        if (isTurnedOn)
        {
            isTurnedOn = false;
            rend.material = materialOff;
        }
        else
        {
            isTurnedOn = true;
            rend.material = materialOn;
        }
    }
}
