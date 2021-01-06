using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsAmountUpdater : MonoBehaviour
{
    [SerializeField] public Text PowerText;
    public void Update()
    {


        if (IdleReactov.Instance.power > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(IdleReactov.Instance.power))));
            var mantissa = (IdleReactov.Instance.power / System.Math.Pow(10, exponent));
            PowerText.text = "Punkty: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else
            PowerText.text = "Punkty: " + IdleReactov.Instance.power.ToString("F0");

    }
}
