using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GemClusterSceneManager : MonoBehaviour
{
    public abstract void playerTapped(GameObject player);
    public abstract void clusterTapped(GameObject Cluster);
    public virtual void clusterCollision(GameObject Cluster, Collision other)
    {

    }


}
