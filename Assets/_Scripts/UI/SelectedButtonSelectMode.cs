using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButtonSelectMode : SelectedButton
{
    public Color selectedColor;
    public Color defaultColor;
    
    protected override void Start()
    {
        base.Start();
        
        SetColorBackgroundButton(buttons[selectedIndex], selectedColor);
    }

    protected override void InputAction()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("select mode");
            Enter(buttons[selectedIndex]);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetColorBackgroundButton(buttons[selectedIndex], defaultColor);
            Up();
            SetColorBackgroundButton(buttons[selectedIndex], selectedColor);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetColorBackgroundButton(buttons[selectedIndex], defaultColor);
            Down();
            SetColorBackgroundButton(buttons[selectedIndex], selectedColor);
        }
    }

    void SetColorBackgroundButton(GameObject button, Color color)
    {
        Button buttonUI = button.GetComponent<Button>();
        var colors = buttonUI.colors;
        colors.normalColor = color;
        buttonUI.colors = colors;
    }
}
