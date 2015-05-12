using UnityEngine;
using System.Collections;

public class CullingSwitch : MonoBehaviour
{
    MeshFilter meshFilter;
    Bounds originalBounds;
    string note;

    void DisableCulling()
    {
        meshFilter.mesh.bounds = new Bounds(Vector3.zero, Vector3.one * 1000);
    }

    void EnableCulling()
    {
        meshFilter.mesh.bounds = originalBounds;
    }

    IEnumerator Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalBounds = meshFilter.sharedMesh.bounds;

        while (true)
        {
            EnableCulling();
            note = "Culling enabled";
            yield return new WaitForSeconds(4);

            DisableCulling();
            note = "No culling";
            yield return new WaitForSeconds(4);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 100), note);
    }
}
