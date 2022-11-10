using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public List<string> characterItems = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddItem(string item){
        characterItems.Add(item);
        Debug.Log("Added "+ item);
    }

    public void RemoveItem(string itemName)
    {
        foreach (string item in characterItems)
        {
            if(item == itemName){
                Debug.Log("Player has "+itemName);
                characterItems.Remove(item);
                break;
            }
        }
    }

    public bool CheckForItem(string itemName)
    {
        foreach (string item in characterItems)
        {
            if(item == itemName){
                Debug.Log("Player has "+itemName);
                return true;
            }
        }
        Debug.Log("Player does not have "+itemName);
        return false;
    }
}
