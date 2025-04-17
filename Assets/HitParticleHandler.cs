using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleHandler : MonoBehaviour
{
    public void DoneHit()
    {
        gameObject.SetActive(false);
    }
}
