
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    public InventoryItemData itemData;

    public void onHandlePickUp()
    {
        InventorySystem.Instance.Add(itemData);
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onHandlePickUp();
        }
    }
}
