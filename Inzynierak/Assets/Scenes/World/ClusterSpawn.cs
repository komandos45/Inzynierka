using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;




public class ClusterSpawn : Singleton<ClusterSpawn>
{
    [SerializeField] private Cluster[] availableClusters;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingClusters = 5;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    private List<Cluster> liveClusters = new List<Cluster>();
    private Cluster selectedCluster;
    private Player player;

    public List<Cluster> LiveClusters
    {
        get { return liveClusters; }
    }

    public Cluster SelectedCluster
    {
        get { return selectedCluster; }
    }


    private void Awake()
    {
        Assert.IsNotNull(availableClusters);
    }

    void Start()
    {
        player = GameManager.Instance.CurrentPlayer;
        Assert.IsNotNull(player);


        for (int i = 0; i < startingClusters; i++)
        {
            InstantiateCluster();
        }
        StartCoroutine(GenerateClusters());
    }

    public void ClusterWasSelected(Cluster cluster)
    {
        selectedCluster = cluster;
    }

    private IEnumerator GenerateClusters()
    {
        while (true)
        {
            InstantiateCluster();
            yield return new WaitForSeconds(waitTime);
        }
    }


    private void InstantiateCluster()
    {
        int index = Random.Range(0, availableClusters.Length);
        float x = player.transform.position.x + GenerateRange();
        float z = player.transform.position.z + GenerateRange();
        float y = player.transform.position.y;
        liveClusters.Add(Instantiate(availableClusters[index], new Vector3(x, y, z), Quaternion.identity));
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }
}
