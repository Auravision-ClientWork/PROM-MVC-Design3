using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBackend : MonoBehaviour
{
    [Header("Score Scriptable Objects")]
    public List<GenericSO> scoreBackEnds;
    [Space(50)]

    #region Utility members
    public Transform responseBtnParent;
    public GameObject responseBtn;
    public TMP_Text promptText;
    public GameObject commitBtn;
    public GameObject nextBtn;
    public GameObject prevBtn;
    public GameObject undoBtn;

    public Color baseResponseBtnColor;
    public Color selectedResponseBtnColor;
    public Color nonSelectedResponseBtnColor; 
    #endregion

    [SerializeField]private List<GameObject> responseButtons = new List<GameObject>();
    [SerializeField] private Regions currentRegion;


    private void Start()
    {
        SpawnResponseButtons(5);
    }

    private void SpawnResponseButtons(int _btnCount)
    {
        GameObject btnObj;
        for (int i = 0; i < _btnCount; i++)
        {
            btnObj = Instantiate(responseBtn);
            btnObj.transform.SetParent(responseBtnParent, false);
            responseButtons.Add(btnObj);
        }
    }

    public void TurnOffAllUtilityButtons()
    {
        commitBtn.SetActive(false);
        nextBtn.SetActive(false);
        prevBtn.SetActive(false);
        undoBtn.SetActive(false);
    }
}
