using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorInit : MonoBehaviour
{
    public Texture2D MouseCursor;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(MouseCursor, Vector2.zero, CursorMode.ForceSoftware);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
