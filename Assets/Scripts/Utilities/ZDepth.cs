using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gives depth to static 2D objects
/// </summary>
public class ZDepth : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnValidate()
    {
        var pos = transform.position;
        pos.z = pos.y;
        transform.position = pos;
    }
#endif
    private void Awake()
    {
        var pos = transform.position;
        pos.z = pos.y;
        transform.position = pos;

        Destroy(this);
    }
}
