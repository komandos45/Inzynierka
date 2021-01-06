using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSceneManager : GemClusterSceneManager
{
    [SerializeField] private int maxThrowAttempts = 3;
    [SerializeField] private GameObject orb;
    [SerializeField] private Vector3 spawnPoint;


    private int currentThrowAttempts;
    private CaptureSceneStatus status = CaptureSceneStatus.InProgress;




    public int MaxThrowAttempts
    {
        get { return maxThrowAttempts;  }
    }

    public int CurrentThrowAttempts
    {
        get { return currentThrowAttempts; }
    }


    public CaptureSceneStatus Status
    {
        get { return status; }
    }

    private void Start()
    {
        CalculateMaxThrows();
        currentThrowAttempts = maxThrowAttempts;


    }


    private void CalculateMaxThrows()
    {

    }

    public void OrbDestroyed()
    {
        currentThrowAttempts--;
        if (currentThrowAttempts <= 0)
        {
            if (status != CaptureSceneStatus.Successful)
            {
                status = CaptureSceneStatus.Failed;
                Invoke("MoveToWorldScene", 2.0f);
            }
        }
        else
        {
            Instantiate(orb, spawnPoint, Quaternion.identity);
        }
    }


    public override void playerTapped(GameObject player)
    {
        print("CaptureSceneManager.playerTapped activated");
    }

    public override void clusterTapped(GameObject Cluster)
    {
        print("CaptureSceneManager.clusterTapped activated");
    }


    public override void clusterCollision(GameObject cluster, Collision other)
    {
        status = CaptureSceneStatus.Successful;
        Invoke("MoveToWorldScene", 2.0f);
    }
    private void MoveToWorldScene()
    {
        SceneTransitionManager.Instance.GoToScene(GemClusterConstants.SCENE_WORLD, new List<GameObject>());
    }
}
