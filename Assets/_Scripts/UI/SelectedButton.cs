using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButton : MonoBehaviour
{

    public UIState uiState;
    public List<GameObject> buttons;

    private SelectedButtonGlobal globalState;
    [SerializeField] protected int selectedIndex;

    protected virtual void Start()
    {
        globalState = GetComponent<SelectedButtonGlobal>();
        selectedIndex = 0;
    }

    protected virtual void Update()
    {
        if (globalState.globalUIState != UIState.MainMenuStart)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                globalState.globalUIState = UIState.MainMenuStart;
                UIController.Instance.BackToMenu();
            }
        }
        
        if (globalState.globalUIState == uiState)
        {
            InputAction();
        }
    }

    protected virtual void InputAction()
    {
        
    }

    protected void Enter(GameObject button)
    {
        Button buttonUI = button.GetComponent<Button>();
        buttonUI.onClick.Invoke();
    }

    protected void Up()
    {
        selectedIndex -= 1;
        if (selectedIndex < 0) selectedIndex = buttons.Count - 1;
    }

    protected void Down()
    {
        selectedIndex += 1;
        if (selectedIndex >= buttons.Count) selectedIndex = 0;
    }

    protected void EnableBackground(GameObject button)
    {
        GameObject background = button.transform.GetChild(0).gameObject;
        background.SetActive(true);
    }

    protected void DisableBackground(GameObject button)
    {
        GameObject background = button.transform.GetChild(0).gameObject;
        background.SetActive(false);
    }
}

public enum UIState
{
    MainMenuStart,
    SelectMode,
    Process,
    Credit
}
