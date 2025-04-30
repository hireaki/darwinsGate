using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public Button inventoryButton;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
        inventoryButton.onClick.AddListener(InventoryToggle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }

    void InventoryToggle()
    {
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }
}
