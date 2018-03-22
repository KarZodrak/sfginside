using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnabler : MonoBehaviour {

    public Canvas myCanvas;

	// Use this for initialization
	void Start ()
    {
        myCanvas = GetComponent<Canvas>();
        myCanvas.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
