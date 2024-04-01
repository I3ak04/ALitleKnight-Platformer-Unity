using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlCompleteInfo : MonoBehaviour
{
    [SerializeField] private Text _coinTakedText;
    [SerializeField] private Text _enemyKilledText;
    private CoinTakedUI _coinTakedUI;
    private int _deadEnemies;
    private int _maxEnemies;

    private void Awake()
    {
        _coinTakedUI = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CoinTakedUI>();
        _deadEnemies = GameObject.FindGameObjectsWithTag("DeadCharacter").Length;
        _maxEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length + _deadEnemies;

        ChangeText();
    }

    private void ChangeText()
    {
        _coinTakedText.text = $" Coins collected - {_coinTakedUI.CoinCurrentCount} / {_coinTakedUI.CoinMaxCount}";
        _enemyKilledText.text = $"Killed enemies - {_deadEnemies} / {_maxEnemies}";
    }
}
