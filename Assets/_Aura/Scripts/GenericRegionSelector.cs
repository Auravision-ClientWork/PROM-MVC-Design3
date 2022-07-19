using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericRegionSelector : MonoBehaviour
{
    string regionTag;
    private Regions region;
    private void OnEnable()
    {
        regionTag = gameObject.tag;
    }

    private void OnMouseDown()
    {
        switch (regionTag)
        {
            case "Cervical":
                region = Regions.Cervical;
                break;
            case "UpperLimb":
                region = Regions.UpperLimb;
                break;
            case "Back":
                region = Regions.Back;
                break;
            case "Hip":
                region = Regions.Hip;
                break;
            case "Knee":
                region = Regions.Knee;
                break;
            case "Foot":
                region = Regions.FootAndAnkle;
                break;
        }
        ScoreBackend.Instance.SetCurrentScoreData(region);
        UIController.Instance.ShowScorePage();
        DataManager.Instance.CommitRegionData(region.ToString());
        AudioManager.Instance.PlaySelectionActionFX();
        GameManager.Instance.GoToUI();
    }
}
