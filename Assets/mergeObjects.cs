using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeGizmos;

public class mergeObjects : MonoBehaviour
{
   bool clickStage = false;

    public TransformGizmo gizmo;
    public GameObject game;
    Transform first;

    public void OnClick()
    {
        var root = Instantiate(game);
        foreach(var item in gizmo.targetRootsOrdered)
        {
            item.parent = root.transform;
        }
    }

}
