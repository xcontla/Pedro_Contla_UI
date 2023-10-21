using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public int X_SPACE_BETWEEN_ITEM;
    public int Y_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMS;

    private Vector2 startPostion;

    public TextMeshProUGUI titulo;
    public GameObject itemSlotPrefab;
    public bool isInventoryAptitudes;
    
    private void Awake()
    {
        startPostion = new Vector2(0, 0);
        InventorySystem.Instance.onInventoryChangedEventCallback += OnUpdateInventory;
    }

    public void OnUpdateInventory()
    {

        Debug.Log("Update inventory");
        foreach (Transform t in transform)
        {
            Destroy(t.transform.gameObject);
        }
        DrawInventory();
    }
    public void DrawInventory()
    {

        Debug.Log("draw inventory");

        //Vector3 offset = new Vector3(0, 0, 0);
        if (isInventoryAptitudes)
        {
            titulo.text = "Aptitudes : " + InventorySystem.Instance.inventoryAptitudes.Count.ToString();
            int index = 0;
            foreach (InventoryItem item in InventorySystem.Instance.inventoryAptitudes)
            {
                AddInventorySlot(item, index);
                index++;
            }
        }
        else
        {
            titulo.text = "Intereses : " + InventorySystem.Instance.inventoryIntereses.Count.ToString();
            int index = 0;
            foreach (InventoryItem item in InventorySystem.Instance.inventoryIntereses)
            {

                
                AddInventorySlot(item, index);
                index++;
            }
        }

    }

    public void AddInventorySlot(InventoryItem item, int index)
    {
        GameObject obj = Instantiate(itemSlotPrefab);
        obj.transform.SetParent(transform, false);
        obj.GetComponent<RectTransform>().localPosition += GetPosition(index);
        ItemSlot slot = obj.GetComponent<ItemSlot>();
        slot.Set(item);
        
    }

    public Vector3 GetPosition(int i)
    {


        return new Vector3(startPostion.x + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMS)), startPostion.y - (Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMS)), 0f);
    }

}
