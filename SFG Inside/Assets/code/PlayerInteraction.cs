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
	private Item _itemAtHand = null;

	//unity update
	public void Update () 
	{
		// fetch item at hand, if there is any (function returns 'null' if theres none)
		_itemAtHand = GameLogic.game.inventory.getItemInHand();

		// on mouse click up if game is not paused
		if(!GameLogic.game.data.gamePaused && Input.GetMouseButtonUp(0))
		{
			// cast ray from mouse position into the world
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				// check if we clicked on an item
				if (hit.collider.tag == "Item")
				{
					// fetch item component
					Item clickedItem = hit.transform.GetComponent<Item>();
					if (_itemAtHand == null)
					{
						// pickup item
						clickedItem.pickUp(gameObject);
					}
				}
                // check if we clicked on an npc
                if (hit.collider.tag == "NPC")
                {
                    // get interaction component and execute its interaction
                    hit.transform.GetComponent<NPC>().startDialog(gameObject);
                }
                else if (hit.collider.tag == "Riddler")
                {
                    // get interaction component and execute its interaction
                    hit.transform.GetComponent<Riddler>().startDialog(gameObject);
                }
                //check if we clicked on an interaction object
                else if (hit.collider.tag == "InteractionObject")
				{
                    // get interaction component and execute its interaction
                    if (!hit.transform.GetComponent<InteractionObject>().isTrigger)
                    {
                        hit.transform.GetComponent<InteractionObject>().doAction(gameObject, _itemAtHand);
                    }
				}
				//chek if we hit not the player
				else if (hit.collider.tag != "Player")
				{
					//if we are dragging an item
					if (_itemAtHand != null)
					{
						// calculate item drop point
						Vector3 offset = new Vector3 (
							hit.normal.x * _itemAtHand.GetComponent<Collider>().bounds.extents.x,
							hit.normal.y * _itemAtHand.GetComponent<Collider>().bounds.extents.y,
							hit.normal.z * _itemAtHand.GetComponent<Collider>().bounds.extents.z
							);
						// drop item
						_itemAtHand.place(hit.point + offset + Vector3.up*2.0f, hit.transform);
					}
				}
			}
		}
	}
}
