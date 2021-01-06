using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cluster : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.10f;
    [SerializeField] private float catchRate = 0.10f;




    public float SpawnRate
    {
        get { return spawnRate; }
    }

    public float CatchRate
    {
        get { return catchRate; }
    }


    private void OnMouseDown()
    {
        GemClusterSceneManager[] managers = FindObjectsOfType<GemClusterSceneManager>();
        foreach (GemClusterSceneManager gemclusterSceneManager in managers)
        {
            if (gemclusterSceneManager.gameObject.activeSelf)
            {
                gemclusterSceneManager.clusterTapped(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        GemClusterSceneManager[] managers = FindObjectsOfType<GemClusterSceneManager>();
        foreach (GemClusterSceneManager gemclusterSceneManager in managers)
        {
            if (gemclusterSceneManager.gameObject.activeSelf)
            {
                gemclusterSceneManager.clusterCollision(this.gameObject, other);
            }
        }



    }



}
