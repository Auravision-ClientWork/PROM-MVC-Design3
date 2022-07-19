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
    public GameObject SelectRegionButton;
    public GameObject warningPanel;
    public TMP_Text digitsOnlyText;


    private void Start()
    {
        warningPanel.SetActive(false);
        SelectRegionButton.SetActive(false);
    }
    public void SetCurrentPatientBioData()
    {
        //input validation
        int ak;
        if (int.TryParse(akInput.text,out ak))
        {
            var visit = visitDateInput.text;
            var comorbid = comorbiditiesInput.text;
            var complaints = complaintsInput.text;
            dataManager.CommitBioData(ak, visit, comorbid, complaints);
            uiController.CloseAllPages();
            GameManager.Instance.GoTo3D(modelType);
        }
        else
        {
            //ToDo:show error message
            warningPanel.SetActive(true);
            SelectRegionButton.SetActive(false);
            digitsOnlyText.text = "AK No should be whole numbers only.";
           
            return;
        }
      
        
    }

    public void SetIsMale(bool _value)
    {
       
        if (_value == true)
        {
            modelType = ModelType.Male;
            SelectRegionButton.SetActive(true);
        }
        else
        {
            SelectRegionButton.SetActive(false);

        }

    }
    public void SetIsFemale(bool _value)
    {
        
        if (_value == true)
        {
            modelType = ModelType.Female;
            isFemale = _value;
            SelectRegionButton.SetActive(true);
        }
        else
        {
            SelectRegionButton.SetActive(false);

        }
    }

    public void ResetInputs()
    {
        akInput.text = "";
        visitDateInput.text = "";
        comorbiditiesInput.text = "";
        complaintsInput.text = "";
    }
    public void HandleOKDismissWarningButton()
    {
        ResetInputs();
        warningPanel.SetActive(false);
    }
}
