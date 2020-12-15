using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubDropDown : MonoBehaviour
{

    Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
    }

    public void AddList(List<GameObject> objects)
    {

        var list = new List<Dropdown.OptionData>();

        foreach(var obj in objects)
        {
            list.Add(new Dropdown.OptionData(obj.name));
        }
        dropdown.AddOptions(list);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
