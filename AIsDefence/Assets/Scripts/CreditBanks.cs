﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditBanks : MonoBehaviour {

    public int CreditBank = 0;
    public int PlayerCreditBank = 0;

    [SerializeField]
    private Text _CreditDisplay;
    [SerializeField]
    private TowerSelection _towerSelection;

    [SerializeField]
    private Text _PlayerCreditDisplay;

    private void Start()
    {
        _CreditDisplay.text = CreditBank.ToString();
        _PlayerCreditDisplay.text = PlayerCreditBank.ToString();
    }

    public void AddCredits(int credits)
    {
        CreditBank = CreditBank + credits;

        _CreditDisplay.text = CreditBank.ToString();

        _towerSelection.CreditUpdated();
    }

    public void MinusCredits(int credits)
    {
        CreditBank = CreditBank - credits;

        _CreditDisplay.text = CreditBank.ToString();

        _towerSelection.CreditUpdated();
    }

    public void AddPlayerCredits(int credits)
    {
        PlayerCreditBank = PlayerCreditBank + credits;

        _PlayerCreditDisplay.text = PlayerCreditBank.ToString();
    }

    public void MinusPlayerCredits(int credits)
    {
        PlayerCreditBank = PlayerCreditBank - credits;

        _PlayerCreditDisplay.text = PlayerCreditBank.ToString();
    }

}
