﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseFireTower : Tower {
    
    private int _damage = 1;

    private float _fireRate = 1.0f;

    private TowerType _type = TowerType.PulseFire;


    private void OnTriggerEnter(Collider obj)
    {
        if (!obj.isTrigger && obj.tag == "Enemy")
        {
            _inRangeEnemies.Add(obj.gameObject);
            AllocateNewTarget();
        }
    }

    private void OnTriggerStay(Collider obj)
    {
        if (!obj.isTrigger && obj.tag == "Enemy" && _canFire)
        {
            Attack();
            _canFire = false;
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (!obj.isTrigger && obj.tag == "Enemy")
        {
            _inRangeEnemies.Remove(obj.gameObject);
            if (obj == _currentTarget)
            {
                AllocateNewTarget();
            }
        }
    }

    private void Attack()
    {
        foreach (GameObject enemy in _inRangeEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }


    public override void SetTowerFireRate(float rate)
    {
        _fireRate = rate;
    }

    public override void SetTowerDamage(int damage)
    {
        _damage = damage;
    }

    public override float GetTowerFireRate()
    {
        return _fireRate;
    }

    public override int GetTowerDamage()
    {
        return _damage;
    }

    public override TowerType GetTowerType()
    {
        return _type;
    }

    public override int BaseDamage()
    {
        return 1;
    }

    public override float BaseFireRate()
    {
        return 1.0f;
    }

    public override int BaseRange()
    {
        return 35;
    }
}