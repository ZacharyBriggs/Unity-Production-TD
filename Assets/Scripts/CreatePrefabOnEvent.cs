using UnityEngine;

public class CreatePrefabOnEvent : GameEventListener
{
    public GameObject Prefab;

    public Transform StartTransform;
    // Use this for initialization

    public void CreatePrefab()
    {
        var go = Instantiate(Prefab, StartTransform);
        Destroy(go, .5f);
    }
}