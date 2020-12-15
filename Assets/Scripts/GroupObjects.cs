using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeGizmos;
using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

public class GroupObjects : MonoBehaviour
{
    [SerializeField]
    private TransformGizmo gizmo;

    // Buggy: parent game objects does not get deleted
    // Выделяй фигуры и жми на кнопку объединения с зажатым Shift
    public void GroupToOneParent()
    {
        Debug.Log($"Clicked! Objects count: {gizmo.highlightedRenderers.Count}");
        if (gizmo.highlightedRenderers.Count <= 1) return;
        
        GameObject parentObject = new GameObject(
            string.Join(", ", gizmo.highlightedRenderers.Select(t => t.gameObject.name)));
        parentObject.transform.position = CenterOfMass(
            gizmo.highlightedRenderers.Select(r => r.transform.position).ToList());
        parentObject.tag = "Parent";

        foreach (var r in gizmo.highlightedRenderers)
        {
            Debug.Log($"Processing object: {r.gameObject.name}");
            r.transform.parent = parentObject.transform;

            if (!(r.gameObject.gameObject is null) && r.gameObject.gameObject.tag == "Parent")
            {
                GameObject.Destroy(r.gameObject.gameObject);
            }
        }

        gizmo.ClearTargets();
        gizmo.AddTarget(parentObject.transform);
    }

    public static Vector3 CenterOfMass(ICollection<Vector3> transforms)
    {
        Vector3 result = new Vector3(0, 0, 0);

        foreach (var t in transforms)
            result += t;

        return result / transforms.Count;
    }
}
