using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedButtonGlobal : MonoBehaviour
{
    public static SelectedButtonGlobal Current;
    
    public UIState globalUIState;
    
    private void Awake()
    {
        Current = this;
    }
}
