using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class DropdownController : MonoBehaviour
{

    public List<GameObject> animals;

    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        var list = new List<Dropdown.OptionData>();

        foreach (var obj in animals)
        {
            list.Add(new Dropdown.OptionData(obj.name));
        }
        dropdown.AddOptions(list);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DropdownValueChanged(Dropdown change)
    {
        Debug.Log("change");
        var name = change.options[change.value].text;
        GameObject temp = animals.Where(obj => obj.name == name).SingleOrDefault();
        Instantiate(temp);
    }
}
