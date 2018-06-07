/*
 * PlayerInteraction
 * 
 * Manages the mouse interaction of the player with the world
 * - Item pickup
 * - Item drop
 * - Interaction with interaction objects
 */

using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRadius = 2.0f;

    //unity update
    public void Update () 
	{
		// on mouse click up if game is not paused
		if(!GameLogic.game.data.gamePaused && Input.GetKeyDown(KeyCode.E))
		{
            GameObject interactionObject = null;
            float distOfClosestObject = Mathf.Infinity;
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, interactionRadius, transform.forward, 0.1f);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "Item" || hit.collider.tag == "NPC" || hit.collider.tag == "Riddler" || hit.collider.tag == "InteractionObject")
                {
                    if (interactionObject == null)
                    {
                        interactionObject = hit.collider.gameObject;
                        distOfClosestObject = Vector3.Distance(transform.position, hit.transform.position);
                    }
                    else
                    {
                        if (distOfClosestObject > Vector3.Distance(transform.position, hit.transform.position))
                        {
                            interactionObject = hit.collider.gameObject;
                            distOfClosestObject = Vector3.Distance(transform.position, hit.transform.position);
                        }
                    }
                }
            }

            // check if we interacted with an item
            if (interactionObject.tag == "Item")
			{
                // pickup item
                interactionObject.transform.GetComponent<Item>().pickUp(gameObject);
			}
            // check if we interacted with a npc
            else if (interactionObject.tag == "NPC")
            {
                // get interaction component and execute its interaction
                interactionObject.transform.GetComponent<NPC>().startDialog(gameObject);
            }
            else if (interactionObject.tag == "Riddler")
            {
                // get interaction component and execute its interaction
                interactionObject.transform.GetComponent<Riddler>().startDialog(gameObject);
            }
            //check if we interacted with an interaction object
            else if (interactionObject.tag == "InteractionObject")
			{
                // get interaction component and execute its interaction
                if (!interactionObject.transform.GetComponent<InteractionObject>().isTrigger)
                {
                    interactionObject.transform.GetComponent<InteractionObject>().doAction(gameObject);
                }
			}
		}
	}
}
