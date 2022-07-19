using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RetrievedInfoItem : MonoBehaviour
{
    public TMP_Text visitDateTxt;
    public TMP_Text regionTxt;
    public TMP_Text scoreTxt;

    public void SetUpItem(string _visitDate,string _region, string _score)
    {
        visitDateTxt.text = _visitDate;
        regionTxt.text = _region;
        scoreTxt.text = _score;

    }
}
