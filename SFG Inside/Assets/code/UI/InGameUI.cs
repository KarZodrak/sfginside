/*
 * MainMenuUI
 * 
 * Manages the UI elements and interactions of the ingame screen like inventory and pause menu
 */

using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    //references to the ui elements
    public Text pauseButtonText;
    public GameObject menuPanel;
    public Image dragItem;
    public Image[] inventorySlots;

    //inventory cache for update checks
    private int _inventoryCountCache = -1;

    // unity start
    public void Start ()
    {
        //update button text
        pauseButtonText.text = "Pause <ESC>";
        //deactivate pause menu
        menuPanel.SetActive(false);
    }

    // unity update
    public void Update()
    {
        //check if inventory item count was changed
        if (_inventoryCountCache != GameLogic.game.inventory.getItems().Count)
        {
            //init inventory update
            updateInventory();
            //update inventory count cache
            _inventoryCountCache = GameLogic.game.inventory.getItems().Count;
        }

        //check if player is draging an item
        if (GameLogic.game.inventory.getItemInHand() == null && dragItem.gameObject.activeSelf)
        {
            //activate drag item
            dragItem.gameObject.SetActive(false);
        }
        else
        {
            //update drag item position
            dragItem.transform.position = Input.mousePosition;
        }

        //check for escaop key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }

    //toggle pause state
    public void togglePause()
    {
        if (!GameLogic.game.data.gamePaused)
        {
            //set pause value
            GameLogic.game.data.gamePaused = true;
            //update button text
            pauseButtonText.text = "Un-Pause";

            //activate pause menu
            menuPanel.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            //set pause value
            GameLogic.game.data.gamePaused = false;
            //update button text
            pauseButtonText.text = "Pause <ESC>";
            //deactivate pause menu
            menuPanel.SetActive(false);
            Cursor.visible = false;
        }
    }

    //load new level with level index as parameter
    public void playLevel(string levelname)
    {
        //set levelindex
        GameLogic.game.data.levelName = levelname;
        //unpause game
        GameLogic.game.data.gamePaused = false;
        //switch to play state
        GameLogic.game.changeState(new PlayState());
    }

    //display credits screen
    public void showCredits()
    {
        GameLogic.game.changeState(new CreditsState());
    }

    //go to main menu
    public void showMainMenu()
    {
        GameLogic.game.changeState(new MainMenuState());
    }

    //handles a click on an inventory item
    public void inventoryItemClick(int slotIndex)
    {
        //check if there is no item in the players hand
        if (GameLogic.game.inventory.getItemInHand() == null)
        {
            //mark item as in hand
            GameLogic.game.inventory.getItems()[slotIndex].inHand = true;
            //set drag image
            dragItem.sprite = GameLogic.game.inventory.getItems()[slotIndex].image;
            //activate drag image
            dragItem.gameObject.SetActive(true);

            //init inventory update because of temporary item removel
            updateInventory();
        }
    }

    //update visual representation of the invenotry
    private void updateInventory()
    {
        //iterate over the inventory slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            //if there is an item in the inventory at index i
            if (GameLogic.game.inventory.getItems().Count > i)
            {
                //set inventory slot image
                inventorySlots[i].sprite = GameLogic.game.inventory.getItems()[i].image;
                //set item name text
                inventorySlots[i].GetComponentInChildren<Text>().text = GameLogic.game.inventory.getItems()[i].name;
                
                //check if this item is at the players hand at the moment
                if (GameLogic.game.inventory.getItems()[i].inHand)
                {
                    //disable inventory slot
                    inventorySlots[i].enabled = false;
                    //reset item name
                    inventorySlots[i].GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    //enable inventory slot
                    inventorySlots[i].enabled = true;
                }
            }
            else
            {
                //disable inventory slot
                inventorySlots[i].enabled = false;
                //reset item name
                inventorySlots[i].GetComponentInChildren<Text>().text = "";
            }    
        }
    }
}
