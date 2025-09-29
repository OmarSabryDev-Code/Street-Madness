using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioSource CoinFX;

    void OnTriggerEnter(Collider other)
    {
        CoinFX.Play(); // Play coin collection sound
        MasterInfo.coinCount++; // Increment the coin count in MasterInfo
        this.gameObject.SetActive(false);
    }
}
