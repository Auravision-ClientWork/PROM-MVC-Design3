using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanModelsController : MonoBehaviour
{
    public GameObject maleModel;
    public GameObject femaleModel;

    private void Start()
    {
        InactivateAllModels();
    }
    public void TurnOnModel(ModelType _model)
    {
        switch (_model)
        {
            case ModelType.Male:
                InactivateAllModels();
                maleModel.SetActive(true);
                break;
            case ModelType.Female:
                InactivateAllModels();
                femaleModel.SetActive(true);
                break;
        }
    }

    public void InactivateAllModels()
    {
        maleModel.SetActive(false);
        femaleModel.SetActive(false);
    }
}
public enum ModelType
{
    Male, Female
}
