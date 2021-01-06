using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClusterData
{
    private float spawnRate;
    private float catchRate;
    

    public float SpawnRate
    {
        get { return spawnRate; }
    }

    public float CatchRate
    {
        get { return catchRate; }
    }

    

    public ClusterData(Cluster cluster)
    {
        spawnRate = cluster.SpawnRate;
        catchRate = cluster.CatchRate;
        
    }



}