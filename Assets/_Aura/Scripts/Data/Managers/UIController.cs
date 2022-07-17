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

    public static UIController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        ShowCommitRetrievePage();
    }
    public void CloseAllPages()
    {
        //ToDo: modify code so that it finds all 'pages' attached to this gameobject and 
        //closes them
        commitRetrievePage.SetActive(false);
        scorePage.SetActive(false);
        regionSelectPage.SetActive(false);
        //aboutPage.SetActive(false);
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
    }
}
