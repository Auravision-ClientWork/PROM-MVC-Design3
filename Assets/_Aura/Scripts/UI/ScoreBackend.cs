using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBackend : MonoBehaviour
{
    [Header("Score Scriptable Objects")]
    public GenericSO CervicalScoreData;
    public GenericSO UpperLimbScoreData;
    public GenericSO BackScoreData;
    public GenericSO HipScoreData;
    [NonReorderable]public GenericSO[] KneeScoreData;
    public GenericSO FootAndAnkleScoreData;
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


    public static ScoreBackend Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

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

    public void SetCurrentScoreData(Regions _region)
    {
        switch (_region)
        {
            case Regions.Cervical:
                Debug.Log("Cervical Region Selected.");
                break;
            case Regions.UpperLimb:
                LogOutMessage("Upper limb selected");
                break;
            case Regions.Back:
                LogOutMessage("Back selected");
                break;
            case Regions.Knee:
                LogOutMessage("Knee selected");
                break;
            case Regions.Hip:
                LogOutMessage("Hip selected.");
                break;
            case Regions.FootAndAnkle:
                LogOutMessage("Foot and Ankle selected");
                break;
        }
    }
    public void TurnOffAllUtilityButtons()
    {
        commitBtn.SetActive(false);
        nextBtn.SetActive(false);
        prevBtn.SetActive(false);
        undoBtn.SetActive(false);
    }


    private void LogOutMessage(string _message)
    {
        Debug.Log(_message);
    }
}
