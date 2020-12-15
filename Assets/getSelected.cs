using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getSelected : MonoBehaviour
{

    //GameObject selected;
    Text text;
    public GameObject selected = null;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                text.text = hit.transform.name;
                selected = hit.collider.gameObject;
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }
}
