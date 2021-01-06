using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsPerSecondUpdater : MonoBehaviour
{
    [SerializeField] public Text PowerPerSecText;

    // Update is called once per frame
    void Update()
    {


        if (IdleReactov.Instance.power > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(IdleReactov.Instance.PowerPerSecond))));
            var mantissa = (IdleReactov.Instance.PowerPerSecond / System.Math.Pow(10, exponent));
            PowerPerSecText.text = "Points/s: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else
            PowerPerSecText.text = "Points/s: " + IdleReactov.Instance.PowerPerSecond.ToString("F0");
    }
}
