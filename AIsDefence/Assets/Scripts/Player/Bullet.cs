﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _lifeTime = 10f;

    [SerializeField]
    private EndGameStats _stats;

    private void OnEnable()
    {
        _stats.Shots = _stats.Shots + 1;

        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        float step = _speed * Time.deltaTime;
        transform.Translate(0, _speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((!other.gameObject.GetComponent<Player>()) && (!other.isTrigger))
        {
            if (other.gameObject.GetComponent<Enemy>())//attacks player and tower
            {
                _stats.Hits = _stats.Hits + 1;
                _stats.DamageDealt = _stats.DamageDealt + _damage;

                bool killed = other.gameObject.GetComponent<Enemy>().TakeDamage(_damage);

                if (other.gameObject.GetComponent<MeleeEnemy>())
                {
                    other.gameObject.GetComponent<MeleeEnemy>().Enrage();
                }

                if (killed == true)
                {
                    _stats.Kills = _stats.Kills + 1;
                }

                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
