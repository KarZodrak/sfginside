/*
 * Item
 * 
 * Manages the properties of an item in the world and defines the pickup and drop mechanics.
 */

using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class Item : MonoBehaviour 
{
	// accessible properties
	public string overwriteName = "";
	public Sprite image = null;
	public float pickUpRange = 3f;
	public AudioClip pickupAudio = null;

	private bool _inHand = false;
	public bool inHand {
		get{return _inHand;}
		set{_inHand = value;}
	}
	

	// unity awake
	public void Awake() 
	{
		//sets tag of gameobject
		gameObject.tag = "Item";
		//renames item if overwrite name is set
		if (overwriteName != "") 
		{
			name = overwriteName;
		}
	}

	// contains things that happen, when itme is picked up
	public void pickUp(GameObject player)
	{
		//check if pickup is within range
		if (Vector3.Distance(player.transform.position, transform.position) <= pickUpRange)
		{
            //deactivates gameobject in world (item not visible anymore)
            gameObject.SetActive(false);
            //adds item below gamelogic (kind of a hack, item is not destroied on level change)
            gameObject.transform.parent = GameLogic.game.transform;
			//add item to inventory
			GameLogic.game.inventory.addItem(this);
			//play audio, if available
			if (pickupAudio != null)
			{
				GameLogic.game.gameAudio.play(pickupAudio, transform.position);
			}
        }
		else
		{
			Debug.Log("'" + gameObject.name + "' is to far away. (" + Vector3.Distance(player.transform.position, transform.position) + ")");
		}
	}

	// places an item in the world
	public void place(Vector3 inPosition, Transform inParent)
	{
        //remove from hand
        _inHand = false;
		//set position in world
		gameObject.transform.position = inPosition;
        //set parent
        gameObject.transform.parent = inParent;
        //remove item from inventory
        GameLogic.game.inventory.removeItem(this);
		//activate gameobject in world
		gameObject.SetActive(true);
    }
}