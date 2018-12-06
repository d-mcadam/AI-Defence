﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePlayer : MonoBehaviour {

    [SerializeField]
    private GameObject _character;
    [SerializeField]
    private TowerSelection _TowerSelect;
    [SerializeField]
    private GameObject _shopHighlight;
    [SerializeField]
    private Button _hideTowers;

    private string _button = "PlayCharacter";
    private bool _active = false;

    private void Update()
    {
        if (Input.GetButtonDown(_button))
        {
            Character();
        }
    }

    public void Character()
    {
        _active = !_active;

        _character.SetActive(_active);
        _shopHighlight.SetActive(_active);

        _TowerSelect.DisableTowers(_active);
        _hideTowers.interactable = !(_active);
    }
}
