using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject commitRetrievePage;
    public GameObject scorePage;
    public GameObject menuPage;
    public GameObject aboutPage;

    public void CloseAllPages()
    {
        //ToDo: modify code so that it finds all 'pages' attached to this gameobject and 
        //closes them
        commitRetrievePage.SetActive(false);
        scorePage.SetActive(false);
        menuPage.SetActive(false);
        aboutPage.SetActive(false);
    }
}
