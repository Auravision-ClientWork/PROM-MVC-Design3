using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject commitRetrievePage;
    public GameObject scorePage;
    public GameObject regionSelectPage;
    public GameObject aboutPage;
    public GameObject menuPage;
    public GameObject retrieveScorePage;

    public static UIController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
       ShowMenuPage();
    }
    public void CloseAllPages()
    {
        AudioManager.Instance.PlaySelectionActionFX();
        //ToDo: modify code so that it finds all 'pages' attached to this gameobject and 
        //closes them
        commitRetrievePage.SetActive(false);
        scorePage.SetActive(false);
        regionSelectPage.SetActive(false);
        //aboutPage.SetActive(false);
        menuPage.SetActive(false);
        retrieveScorePage.SetActive(false);
    }
    public void ShowMenuPage()
    {
        CloseAllPages();
        menuPage.SetActive(true);
        //DataManager.Instance.ResetCurrentPatientData();
    }
    public void ShowRetrievePage()
    {
        CloseAllPages();
        retrieveScorePage.SetActive(true);
    }
    public void ShowRegionSelectPage()
    {
        CloseAllPages();
        regionSelectPage.SetActive(true);
    }
    public void ShowScorePage()
    {
        CloseAllPages();
        scorePage.SetActive(true);
    }
    public void ShowCommitRetrievePage()
    {
        CloseAllPages();
        commitRetrievePage.SetActive(true);
        commitRetrievePage.GetComponent<CommitRetrieveBackend>().ResetInputs();
    }
}
