using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _itemName;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private GameObject _stackObj;

    [SerializeField]
    private TextMeshProUGUI _stackNumber;
    
   // [SerializeField]
   // private GameObject hud;

    public void Set(InventoryItem item)
    {
        _itemName.text = item.data.itemName;
        _itemIcon.sprite = item.data.itemIcon;

        if (item.stackSize <= 1)
        {
            _stackObj.SetActive(false);
            return;
        }
        _stackNumber.text = item.stackSize.ToString();
    }


    public void ShowDetails()
    {
      //  hud.transform.SetParent(this.transform);
        Debug.Log("Abriendo hudDetails");
       // hud.SetActive(true);
    }

    public void UnShowDetails()
    {
        Debug.Log("Cerrand hudNoDetails");
       // hud.SetActive(false);
    }
}
