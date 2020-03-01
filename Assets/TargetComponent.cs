using UnityEngine;
using System.Collections;

public class TargetComponent : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshCollider meshCollider;
    MeshRenderer meshRenderer;

    WMesh wMesh;

    public Material SlicedMaterial;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = GetComponent<MeshRenderer>();

        wMesh = new WMesh(meshFilter.mesh);
    }

    public WMesh GetWMesh()
    {
        return wMesh;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
