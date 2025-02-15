﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    // Class for every resource there will be in this game

    public string resourceName; // Variable for the name of the resource
    public int resourceYield; // Variable for yield of the resource (How many more player will have after having harvested the resource)

    public Texture2D cursorTexture;
    public Animator flickerController;

    bool canGiveVisualFeedback = true;

    private void Start()
    {
        GhostTower.ghostActivated += CanChangeCursor;
    }

    private void OnDestroy()
    {
        GhostTower.ghostActivated -= CanChangeCursor;
    }

    void CanChangeCursor(bool canChange)
    {
        canGiveVisualFeedback = canChange;
    }

    private void OnMouseOver()
    {
        if (!canGiveVisualFeedback)
            return;

        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        if (!canGiveVisualFeedback)
            return;

        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void HighlightResource()
    {
        if (!canGiveVisualFeedback)
            return;

        flickerController.SetTrigger("isFlickering");
    }
}
