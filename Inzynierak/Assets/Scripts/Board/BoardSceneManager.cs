using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardSceneManager : MonoBehaviour
{
    [SerializeField] public Text PowerText;

    public void onMouseDown()
    {
        MoveToWorldScene();
    }


    private void MoveToWorldScene()
    {
        SceneManager.LoadScene("World");
    }
    public void Update()
    { 
     
    
        if (IdleReactov.Instance.power > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(IdleReactov.Instance.power))));
            var mantissa = (IdleReactov.Instance.power / System.Math.Pow(10, exponent));
            PowerText.text = "Power: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else
            PowerText.text = "Power: " + IdleReactov.Instance.power.ToString("F0");
    
    }
}
