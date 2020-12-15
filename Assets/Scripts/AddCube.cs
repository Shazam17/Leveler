using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AddCube : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;
    
    public void AddObject()
    {
        Instantiate(spawnObject);
    }
}
