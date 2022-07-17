using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommitRetrieveBackend : MonoBehaviour
{
    public DataManager dataManager;
    public UIController uiController;
    public TMP_InputField akInput;
    public TMP_InputField visitDateInput;
    public TMP_InputField comorbiditiesInput;
    public TMP_InputField complaintsInput;
  
    public void SetCurrentPatientBioData()
    {
        var ak = int.Parse(akInput.text);
        var visit = visitDateInput.text;
        var comorbid = comorbiditiesInput.text;
        var complaints = complaintsInput.text;
        dataManager.CommitBioData(ak, visit, comorbid, complaints);
        
        uiController.ShowRegionSelectPage();
    }
}
