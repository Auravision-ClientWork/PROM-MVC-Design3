using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RetrievePageBackend : MonoBehaviour
{
    public TMP_InputField akSearchInput;
   public void HandleRetrieveDataButtonClicked()
    {
        DataManager.Instance.RetrieveDataForAk(akSearchInput.text);
    }
}
