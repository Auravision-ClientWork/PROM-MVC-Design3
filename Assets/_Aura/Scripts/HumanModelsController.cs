using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanModelsController : MonoBehaviour
{
    public GameObject maleModel;
    public GameObject femaleModel;

    public void TurnOnModel(ModelType _model)
    {
        switch (_model)
        {
            case ModelType.Male:
                break;
                case ModelType.Female:
                break;
        }
    }
}
public enum ModelType
{
    Male,Female
}
