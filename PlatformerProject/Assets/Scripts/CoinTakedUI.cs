using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTakedUI : MonoBehaviour
{
    [SerializeField] private Text _coinTextCount;
    private string _coinMaxCountString;
    private int _coinCurrentCount = 0;

    public string CoinMaxCount => _coinMaxCountString;
    public string CoinCurrentCount => _coinCurrentCount.ToString();

    private void Start()
    {
        _coinMaxCountString = GameObject.FindGameObjectsWithTag("Coin").Length.ToString();
        ChangeCountText();
    }

    public void IncreaseCoinCount()
    {
        _coinCurrentCount++;

        ChangeCountText();
    }

    private void ChangeCountText()
    {
        string _coinCurrentCountString = _coinCurrentCount.ToString();
        _coinTextCount.text = $"{_coinCurrentCountString}";
    }
}
