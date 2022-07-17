using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionSelectBackend : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject regionSelectButton;
    public Transform regionSelectButtonsHolder;
    public string[] regions;

    private void Start()
    {
        SetUpRegionSelectButtons();
    }
    public void SetUpRegionSelectButtons()
    {
        GameObject obj;
        foreach (var item in regions)
        {
            obj = Instantiate(regionSelectButton);
            obj.transform.SetParent(regionSelectButtonsHolder, false);
            var btnComponent = obj.GetComponent<RegionSelectButton>();
            switch (item)
            {
                case "cervical":
                    btnComponent.SetupRegionBtn(item, Regions.Cervical);
                    break;
                case "upperLimb":
                    btnComponent.SetupRegionBtn(item, Regions.UpperLimb);
                    break;
                case "back":
                    btnComponent.SetupRegionBtn(item, Regions.Back);
                    break;
                case "hip":
                    btnComponent.SetupRegionBtn(item, Regions.Hip);
                    break;
                case "knee":
                    btnComponent.SetupRegionBtn(item, Regions.Knee);
                    break;
                case "foot":
                    btnComponent.SetupRegionBtn(item, Regions.FootAndAnkle);
                    break;

            }
        }
    }
}
