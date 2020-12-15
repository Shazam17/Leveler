using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{

    public getSelected selected;


    public void DeleteObject()
    {
        Destroy(selected.selected);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
