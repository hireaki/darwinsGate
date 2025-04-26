using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventoryUI;
    public TabController tabController;

    private bool isOpen = false;

    public void ToggleInventory()
    {
        if (inventoryUI == null || tabController == null)
        {
            Debug.LogError("Inventory UI or Tab Controller is not assigned!");
            return;
        }

        isOpen = !isOpen;
        inventoryUI.SetActive(isOpen);

        if (isOpen)
        {
            tabController.ActivateTab(0);
        }
    }
}
