/*
 * Riddler
 * 
 * Manages the properties of an Riddler
 */

using System.Collections.Generic;
using UnityEngine;

public class Riddler : MonoBehaviour 
{
	// accessible properties
	public string npcName = "";
	public float interactionRange = 3f;
    public RiddlerUI riddlerUI;
	public AudioClip npcAudio = null;
    public string riddleText = "1+1=?";
    public string answer_correct = "2";
    public string[] answers_wrong;

    private int correctAnswer = 0;
    private int wrongAnswerIndex = 0;
    private bool riddleActive = false;

    // unity awake
    public void Awake() 
	{
		//sets tag of gameobject
		gameObject.tag = "Riddler";
		//renames item if overwrite name is set
		if (npcName != "") 
		{
			name = npcName;
		}

        //set riddle texts
        riddlerUI.question.text = riddleText;
        correctAnswer = Random.Range(1, 5);

        for (int i = 1; i<5; i++)
        {
            if (correctAnswer == i)
            {
                riddlerUI.answers[i - 1].text = "(" + i + ") " + answer_correct;
            }
            else
            {
                riddlerUI.answers[i - 1].text = "(" + i + ") " + answers_wrong[wrongAnswerIndex];
                wrongAnswerIndex++;
            }
        }

    }

	// contains things that happen, when itme is picked up
	public void startDialog(GameObject player)
	{
		//check if pickup is within range
		if (Vector3.Distance(player.transform.position, transform.position) <= interactionRange)
		{
            //activate riddle
            riddleActive = true;
            riddlerUI.riddlerPanel.SetActive(true);

            //play audio, if available
            if (npcAudio != null)
			{
				GameLogic.game.gameAudio.play(npcAudio, transform.position);
			}
        }
		else
		{
			Debug.Log("'" + gameObject.name + "' is to far away. (" + Vector3.Distance(player.transform.position, transform.position) + ")");
		}
	}

    public void Update()
    {
        if (riddleActive && (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4)))
        { 
            if ((Input.GetKey(KeyCode.Alpha1) && correctAnswer == 1) ||
                    (Input.GetKey(KeyCode.Alpha2) && correctAnswer == 2) ||
                    (Input.GetKey(KeyCode.Alpha3) && correctAnswer == 3) ||
                    (Input.GetKey(KeyCode.Alpha4) && correctAnswer == 4))
            {
                //TODO: WIN
            }
            else
            {
                //TODO: LOOSE
            }
            riddleActive = false;
            riddlerUI.riddlerPanel.SetActive(false);
        }
    }
}