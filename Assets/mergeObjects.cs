using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeGizmos;

public enum Mode
{
    off,
    on
}

public class mergeObjects : MonoBehaviour
{

    public GameObject gizmo;
    public GameObject game;



    public Mode mode = Mode.off;

    public List<Transform> selected = new List<Transform>();

    Transform getParent(Transform tr)
    {
        while (tr.parent != null)
        {
            tr = tr.parent;
        }
        return tr;
    }

    public void OnClick()
    {
      if(mode == Mode.off)
      {
            mode = Mode.on;
      }
      else
      {
            var parent = Instantiate(game);
            parent.transform.position = selected[0].position;

            foreach (var obj in selected)
            {
                obj.parent = parent.transform;
            }
            selected.Clear();
            mode = Mode.off;
      }




    }


    public void Update()
    {
        if (mode == Mode.on)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    selected.Add(getParent(hit.transform));
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                }
            }
        }
      
    }
}
