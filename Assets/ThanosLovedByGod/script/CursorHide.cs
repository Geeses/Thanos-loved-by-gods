using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour {

    public bool HideCursor;
    public Canvas UI;
    // Use this for initialization
    private void Awake()
    {
        Cursor.visible = !HideCursor;
    }

    private void Update()
    {
        Cursor.visible = UI.enabled;
    }
}
