using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public Text displayTextElement;
    public GameObject dialogBox;

	// Use this for initialization
	void Start ()
    {
        displayTextElement.text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameLogic.game.data.activeDialog.Count > 0)
        {
            displayTextElement.text = "<b>" + GameLogic.game.data.speakerName + ":</b> " + GameLogic.game.data.activeDialog[GameLogic.game.data.activeDialogIndex];
        }
        else
        {
            displayTextElement.text = "";
        }

        if (displayTextElement.text == "")
        {
            dialogBox.SetActive(false);
        }
        else
        {
            dialogBox.SetActive(true);
        }
    }

    public void nextDialog()
    {
        GameLogic.game.data.activeDialogIndex += 1;
        if (GameLogic.game.data.activeDialogIndex >= GameLogic.game.data.activeDialog.Count)
        {
            GameLogic.game.data.activeDialog = new List<string>();
            GameLogic.game.data.activeDialogIndex = 0;
            GameLogic.game.data.speakerName = "";
            GameLogic.game.data.gamePaused = false;
            Cursor.visible = false;
        }
    }
         
}
