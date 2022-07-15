using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
   public DataManager dataManager;

    public TMP_InputField akInput;
    public TMP_InputField visitDateInput;
    public TMP_InputField regionInput;
    public TMP_InputField comorbiditiesInput;
    public TMP_InputField complaintsInput;
    public TMP_InputField scoreInput;

    public TMP_Text displayInfoText;

    public void HandleCommitButton()
    {
        dataManager.TestCommitInfo(int.Parse(akInput.text), visitDateInput.text, regionInput.text,
            comorbiditiesInput.text, complaintsInput.text, float.Parse(scoreInput.text));
    }

    public void HandleRetrieveButton()
    {
        string incomingInfo = dataManager.TestRetrieveInfo();

        displayInfoText.text = incomingInfo;
    }
}
