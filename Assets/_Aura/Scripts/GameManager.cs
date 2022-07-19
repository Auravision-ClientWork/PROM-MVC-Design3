using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HumanModelsController humanModels;

    public ManController modelUIController;

    public UIController uiController;

    public bool in3Dmode { get; private set; }

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void GoTo3D(ModelType _modelType)
    {
        in3Dmode = true;
        modelUIController.ToggleTurnController();
        UIController.Instance.CloseAllPages();
        humanModels.TurnOnModel(_modelType);
    }

    public void GoToUI()
    {
        modelUIController.ToggleTurnController();
        humanModels.InactivateAllModels();
    }
}
