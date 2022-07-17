using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RegionSelectButton : MonoBehaviour
{
    public TMP_Text regionTxt;
    public Button btn;
    public void SetupRegionBtn(string _title,Regions _region)
    {
        regionTxt.text = _title;
        
        btn.onClick.AddListener(() => SetSelectedRegion(_region));
    }

    private void SetSelectedRegion(Regions _region)
    {
        //ToDo:: inform the Score back end what the current region selected is
        ScoreBackend.Instance.SetCurrentScoreData(_region);
    }
}
