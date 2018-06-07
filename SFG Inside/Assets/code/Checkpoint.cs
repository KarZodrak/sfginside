using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject resetPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (resetPoint != null)
            {
                GameLogic.game.data.lastCheckpoint = resetPoint.transform.position;
                GameLogic.game.data.lastCheckpointRotation = resetPoint.transform.rotation;
                GameLogic.game.data.lastCheckpointRotationMouse = resetPoint.transform.rotation; 
            }
            else
            {
                GameLogic.game.data.lastCheckpoint = other.transform.position;
                GameLogic.game.data.lastCheckpointRotation = other.transform.rotation;
                GameLogic.game.data.lastCheckpointRotationMouse = other.GetComponentInChildren<SmoothMouseLook>().transform.rotation;
            }
        }
    }
}
