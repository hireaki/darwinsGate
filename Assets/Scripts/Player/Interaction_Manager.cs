using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Manager : MonoBehaviour
{
    public static Interaction_Manager instance;
    public int interactionLevel = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
