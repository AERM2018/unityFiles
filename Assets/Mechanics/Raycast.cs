using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public new Transform camera;
    //Mask rof raycast detect
    LayerMask mask;
    public float distance = 10f;
        //Raycast point variables
    public Texture2D indicator;
    public GameObject TextDetect;
    GameObject detected = null;
    // Start is called before the first frame update
    void Start()
    {
        //Assign the raycast to the masks
        mask = LayerMask.GetMask("Raycast Detect");
        TextDetect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //Raycast(origin, direction, out hit, distance, mask)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
             Debug.Log("ENTRA AL RAYCAST");
            Active(hit.transform);

            //Verify if the object is interactive
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "OfficeChair" && Input.GetKeyDown(KeyCode.E))
            {
                //Script and method
                hit.collider.transform.GetComponent<OfficeChairInteractive>().Action();   
            }

            if (hit.collider.tag == "Mug" && Input.GetKeyDown(KeyCode.E))
            {
                //Script and method
                hit.collider.transform.GetComponent<MugInteractive>().Action();
            }

            if (hit.collider.tag == "FloorLamp" && Input.GetKeyDown(KeyCode.E))
            {
                //Script and method
                hit.collider.transform.GetComponent<LampInterective>().Action();
            }


        } else
        {
           
            Inactive();
        }
    }

    void Active(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        detected = transform.gameObject;
    }

    void Inactive()
    {
        if (detected) {
            detected.GetComponent<Renderer>().material.color = Color.gray;
            detected = null;
        }
    }

    private void OnGUI()
    {
        //Draw point 
        Rect rect = new Rect(Screen.width/ 2f, Screen.height / 2f, indicator.width, indicator.height);
        GUI.DrawTexture(rect, indicator);

        //Show text "Press 'E'..."
        TextDetect.SetActive(detected ? true : false);
    }
}
