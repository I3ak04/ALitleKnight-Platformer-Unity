using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private Text _hpText;
    private Health _health;

    private void Start()
    {
        _hpText.text = _health.CurrentHP.ToString();
    }

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void ChangeHpText()
    {
        _hpBar.fillAmount = _health.CurrentHP * 0.01f;

        if (_health.CurrentHP > 0)
            _hpText.text = _health.CurrentHP.ToString();
        else
            _hpText.text = 0.ToString();
    }
}
