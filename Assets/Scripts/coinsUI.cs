using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class coinsUI : MonoBehaviour
{
    public float CoinsCount = 0;
    [SerializeField] TextMeshProUGUI CoinsNumberText;
    void Update()
    {
        CoinsNumberText.text = "Coins : " + CoinsCount.ToString("0");
    }
}
