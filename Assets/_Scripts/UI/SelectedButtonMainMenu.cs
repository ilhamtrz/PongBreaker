using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedButtonMainMenu : SelectedButton
{
    protected override void Start()
    {
        base.Start();
        
        EnableBackground(buttons[selectedIndex]);
    }

    protected override void InputAction()
    {
        // Enter
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Enter(buttons[selectedIndex]);
        }
        
        // up arrow key
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            DisableBackground(buttons[selectedIndex]);
            Up();
            EnableBackground(buttons[selectedIndex]);
        }
        
        // down arrow key
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            DisableBackground(buttons[selectedIndex]);
            Down();
            EnableBackground(buttons[selectedIndex]);
        }
    }

}
