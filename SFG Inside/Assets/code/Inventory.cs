/*
 * Inventory
 * 
 * Contains the inventroy funtions like add, remove or check for item in inventory.
 */

using UnityEngine;
using System.Collections.Generic;

public class Inventory 
{
	//list of the players item
	private List<Item> _items = new List<Item>();

	// add an item to the inventory
	public void addItem(Item newItem)
	{
		_items.Add(newItem);
	}

	// remove an item from the inventory. if its in there
	public void removeItem(Item item)
	{
		if (_items.Contains(item))
		  {
			_items.Remove(item);
		}
	}

	// check if an item is in the inventory
	public bool hasItemInInventory(Item item)
	{
		return _items.Contains(item);
	}

	// fetch all items wihtin the inventory
	public List<Item> getItems()
	{
		return _items;
	}

	// fetch item, that is dragged by the player, returns null, if no item is dragged
	public Item getItemInHand()
	{
		for (int i = 0; i<_items.Count; i++)
		{
			if (_items[i].inHand)
			{
				return _items[i];
			}
		}
		return null;
	}
}
