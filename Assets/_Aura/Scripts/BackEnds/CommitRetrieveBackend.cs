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
    private bool isMale = false;
    private bool isFemale = false;
    [SerializeField]private ModelType modelType;
    public void SetCurrentPatientBioData()
    {
        var ak = int.Parse(akInput.text);
        var visit = visitDateInput.text;
        var comorbid = comorbiditiesInput.text;
        var complaints = complaintsInput.text;
        dataManager.CommitBioData(ak, visit, comorbid, complaints);

        if (isMale)
        {
            modelType = ModelType.Male;
        }
        else if (isFemale)
        {
            modelType =ModelType.Female;    
        }
   
        uiController.CloseAllPages();
        GameManager.Instance.GoTo3D(modelType);
    }

    public void SetIsMale(bool _value)
    {
        isMale = _value;
    }
    public void SetIsFemale(bool _value)
    {
        isFemale = _value;
    }

    public void ResetInputs()
    {
        akInput.text = "";
        visitDateInput.text = "";
        comorbiditiesInput.text = "";
        complaintsInput.text = "";
    }
}
