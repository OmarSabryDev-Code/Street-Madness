using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0; // Static variable to keep track of the coin count
    [SerializeField] GameObject coinDisplay;
    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TMP_Text>().text = "" + coinCount;
    }
}
