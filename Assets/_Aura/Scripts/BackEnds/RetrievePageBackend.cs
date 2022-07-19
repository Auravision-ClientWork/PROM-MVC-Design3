using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RetrievePageBackend : MonoBehaviour
{
    public TMP_InputField akSearchInput;
    public GameObject warningPanel;
    public TMP_Text warningText;
    public GameObject searchButton;

    private void Start()
    {
        warningPanel.SetActive(false);
        searchButton.SetActive(true);
    }
    public void HandleRetrieveDataButtonClicked()
    {
        if(int.TryParse(akSearchInput.text, out int index))
        {
            DataManager.Instance.RetrieveDataForAk(index.ToString());
        }
        else
        {
            warningPanel.SetActive(true);
            warningText.text = "Ak number should be whole numbers only.";
        }
    }

    public void HandleOkDismissWarningPanelBtn()
    {
        warningPanel.SetActive(false);
        searchButton?.SetActive(true);
        akSearchInput.text = "";
    }

    public void HandleNoPatientError()
    {
        warningPanel.SetActive(true);
        warningText.text = "No such patient in data registry";
    }
}
