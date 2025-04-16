using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryController : MonoBehaviour
{
    public GameObject invetoryPanel;
    public GameObject slotPrefabl;
    public int slotCount;
    public GameObject[] itemPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefabl, invetoryPanel.transform).GetComponent<Slot>();
            if(i < itemPrefabs.Length)
            {
                GameObject item = Instantiate(itemPrefabs[i], slot.transform);
                slot.currentItem = item;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
