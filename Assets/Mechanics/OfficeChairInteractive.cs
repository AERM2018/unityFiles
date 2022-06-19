using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeChairInteractive : MonoBehaviour
{
    // Start is called before the first frame update
    public void Action()
    {
        Debug.Log("The action's being performed");
        gameObject.transform.Rotate(0f,0f,40f);
       
    }
}
