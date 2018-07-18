using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabOnEvent : MonoBehaviour
{
    public Transform startTransform;

    public GameObject Prefab;
    // Use this for initialization

    public void CreatePrefab()
    {
        var go = Instantiate(Prefab, startTransform);
        Destroy(go, .5f);
    }
}
