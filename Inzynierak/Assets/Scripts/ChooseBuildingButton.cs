using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class ChooseBuildingButton : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private double basePrice;

    private double CalculateFinalPrice()
    {
        return basePrice * 1;          
    }

    public void OnMouseDown()
    {
        BuildingsTileList.Instance.SetBuildingPrefab(prefab);
        this.basePrice = prefab.GetComponent<BuildingEntity>().BuildingCost();
        BuildingsTileList.Instance.SetBuildingPrice(CalculateFinalPrice());
        Debug.Log("Debug message");
    }


}
