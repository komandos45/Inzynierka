using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : GemClusterSceneManager
{

    public override void playerTapped(GameObject player)
    {

    }

    public override void clusterTapped(GameObject cluster)
    {
        //SceneManager.LoadScene(GemClusterConstants.SCENE_CAPTURE, LoadSceneMode.Additive);
        List<GameObject> list = new List<GameObject>();
        list.Add(cluster);
        SceneTransitionManager.Instance.GoToScene(GemClusterConstants.SCENE_CAPTURE, list);    
    }



}
