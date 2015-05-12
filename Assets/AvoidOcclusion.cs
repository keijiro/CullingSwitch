using UnityEngine;
using System.Collections;

public class AvoidOcclusion : MonoBehaviour
{
    Bounds originalBounds;

    void OnEnable()
    {
        var mf = GetComponent<MeshFilter>();
        originalBounds = mf.mesh.bounds;
        mf.mesh.bounds = new Bounds(Vector3.zero, Vector3.one * 1000);
    }

    void OnDisable()
    {
        var mf = GetComponent<MeshFilter>();
        mf.mesh.bounds = originalBounds;
    }
}
