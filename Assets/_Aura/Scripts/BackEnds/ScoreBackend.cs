using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ScoreBackend : MonoBehaviour
{
    [Header("Score Scriptable Objects")]
    public GenericSO CervicalScoreData;
    public GenericSO UpperLimbScoreData;
    public GenericSO BackScoreData;
    public GenericSO HipScoreData;
    [NonReorderable] public GenericSO[] KneeScoreData;
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

    [SerializeField] private List<GameObject> responseButtons = new List<GameObject>();
    public Transform responseButtonsParent;

    [SerializeField] private GenericSO currentRegion;
    [SerializeField] private int currentSection;
    [SerializeField] private List<float> scoreHistory = new List<float>();
    [SerializeField] private float currentMaxScore;
    public static ScoreBackend Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        commitBtn.SetActive(false);
    }


    public void SetCurrentScoreData(Regions _region)
    {
        switch (_region)
        {
            case Regions.Cervical:
                currentRegion = CervicalScoreData;
                HandleCurrentRegionSelected();
                break;
            case Regions.UpperLimb:
                currentRegion = UpperLimbScoreData;
                HandleCurrentRegionSelected();
                break;
            case Regions.Back:
                currentRegion = BackScoreData;
                HandleCurrentRegionSelected();
                break;
            case Regions.Knee:
                //ToDo:figure out what to do if the region selected is the knee
                HandleKneeRegionSelected();
                break;
            case Regions.Hip:
                currentRegion = HipScoreData;
                HandleCurrentRegionSelected();
                break;
            case Regions.FootAndAnkle:
                currentRegion = FootAndAnkleScoreData;
                HandleCurrentRegionSelected();
                break;
        }

    }

    private void HandleCurrentRegionSelected()
    {
        //spawn initial buttons on screen
        //set first prompt for the region selected on screen
        //turn off all buttons except next button

        var sections = currentRegion.GetSections();
        var responseTexts = sections[0].responses;
        promptText.text = sections[0].prompt;
        SpawnResponseButtons(responseTexts);
        currentSection = 0;
        prevBtn.SetActive(false);
    }
    public void HandleKneeRegionSelected()
    {

    }
    public void TurnOffAllUtilityButtons()
    {
        commitBtn.SetActive(false);
        nextBtn.SetActive(false);
        prevBtn.SetActive(false);
        undoBtn.SetActive(false);
    }

    public void HandleNextButtonClicked()
    {
        if(prevBtn.activeInHierarchy == false)
        {
            prevBtn.SetActive(true);
        }

        currentSection++;
        if (currentSection >= currentRegion.GetSections().Length - 1)
        {
            //we are at the end
            //disable next button
            nextBtn.SetActive(false);
        }
        else
        {
            if (nextBtn.activeInHierarchy == false)
            {
                nextBtn.SetActive(true);
            }
        }
        ShowNextSection();
    }

    public void HandlePrevButtonClicked()
    {
        
        if(nextBtn.activeInHierarchy == false)
        {
            nextBtn.SetActive(true);
        }
        currentMaxScore -= scoreHistory[currentSection-1];
        scoreHistory.RemoveAt(currentSection - 1);
        currentSection--;
        if (currentSection <= 0)
        {
            //we are back at the beginning
            //diable prev button
            prevBtn.SetActive(false);
        }
        if(currentSection >= currentRegion.GetSections().Length - 1)
        {
            if (commitBtn.activeInHierarchy == true)
            {
                commitBtn.SetActive(false);
            }
        }

        //reduce the max score
      
        ShowNextSection();
    }
    public void SetSelectedScore(int _scoreMultiplier)
    {
        SetResponseButtonsInactive(_scoreMultiplier);
        float scorePaResponse = currentRegion.ScorePaResponse;
        scoreHistory.Add(scorePaResponse * _scoreMultiplier);
        currentMaxScore += (scorePaResponse * _scoreMultiplier);

        //are we at the last section
        if (currentSection == currentRegion.GetSections().Length - 1)
        {
            //we are at the last section and have selected something so
            //can now show the commit button
            commitBtn.SetActive(true);
        }
    }
    #region Private Utility Methods
    private void ShowNextSection()
    {
        var nextSection = currentRegion.GetSections()[currentSection];
        var responseTexts = nextSection.responses;
        promptText.text = nextSection.prompt;
        SpawnResponseButtons(responseTexts);
    }
    private void SpawnResponseButtons(string[] responses)
    {
        RefreshResponseButtons();
        GameObject btnObj;
        for (int i = 0; i < responses.Length; i++)
        {
            btnObj = Instantiate(responseBtn);
            btnObj.transform.SetParent(responseBtnParent, false);
            btnObj.GetComponent<ResponseButton>().SetUpResponseButton(i, responses[i]);
            responseButtons.Add(btnObj);
        }
    }

    private void SetResponseButtonsInactive(int _activeBtn)
    {
        for(int i = 0;i< responseButtons.Count; i++)
        {
            responseButtons[i].GetComponent<Button>().enabled = false;
            responseButtons[i].GetComponent<Image>().color = nonSelectedResponseBtnColor;

            if (i == _activeBtn)
            {
                responseButtons[i].GetComponent<Button>().enabled = true;
                responseButtons[i].GetComponent<Image>().color = selectedResponseBtnColor;
            }
        }
    }
    private void RefreshResponseButtons()
    {
        foreach (var item in responseButtons)
        {
            Destroy(item);
        }
        responseButtons.Clear();
    }

    private void LogOutMessage(string _message)
    {
        Debug.Log(_message);
    }
    #endregion
}
