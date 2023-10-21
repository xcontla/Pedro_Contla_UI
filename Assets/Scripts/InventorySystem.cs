using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance;

    public delegate void onInventoryChangedEvent();
    public event onInventoryChangedEvent onInventoryChangedEventCallback;

    public Dictionary<InventoryItemData, InventoryItem> _itemDictionaryAptitudes;
    public Dictionary<InventoryItemData, InventoryItem> _itemDictionaryIntereses;
    public List<InventoryItem> inventoryAptitudes;
    public List<InventoryItem> inventoryIntereses;
    private void Awake()
    {

        inventoryAptitudes = new List<InventoryItem>();
        inventoryIntereses = new List<InventoryItem>();
        _itemDictionaryAptitudes = new Dictionary<InventoryItemData, InventoryItem>();
        _itemDictionaryIntereses = new Dictionary<InventoryItemData, InventoryItem>();

        if (Instance == null)
            Instance = this;
    }

    public void Add(InventoryItemData itemData)
    {

        if (itemData.isAptitud) { 

        if(_itemDictionaryAptitudes.TryGetValue(itemData, out InventoryItem value))
        {
            Debug.Log("Sumar Stack en Item");
            value.AddStack();
            onInventoryChangedEventCallback.Invoke();
        }
        else
        {
            Debug.Log("Agrega un nuevo Item");
            InventoryItem newItem = new InventoryItem(itemData);
            inventoryAptitudes.Add(newItem);
            _itemDictionaryAptitudes.Add(itemData,newItem);


            onInventoryChangedEventCallback.Invoke();
        }
        }
        else
        {

            if (_itemDictionaryIntereses.TryGetValue(itemData, out InventoryItem value))
            {
                Debug.Log("Sumar Stack en Item");
                value.AddStack();
                onInventoryChangedEventCallback.Invoke();
            }
            else
            {
                Debug.Log("Agrega un nuevo Item");
                InventoryItem newItem = new InventoryItem(itemData);
                inventoryIntereses.Add(newItem);
                _itemDictionaryIntereses.Add(itemData, newItem);
                onInventoryChangedEventCallback.Invoke();
            }
        }
    }

    public void Remove(InventoryItemData itemData)
    {
        if (itemData.isAptitud)
        {
            if (_itemDictionaryAptitudes.TryGetValue(itemData, out InventoryItem value))
            {
                value.RemoveFromStack();
                if (value.stackSize == 0)
                {
                    inventoryAptitudes.Remove(value);
                    _itemDictionaryAptitudes.Remove(itemData);
                }
            }
        }
        else
        {
            if (_itemDictionaryIntereses.TryGetValue(itemData, out InventoryItem value))
            {
                value.RemoveFromStack();
                if (value.stackSize == 0)
                {
                    inventoryIntereses.Remove(value);
                    _itemDictionaryIntereses.Remove(itemData);
                }
            }
        }
    }
}
