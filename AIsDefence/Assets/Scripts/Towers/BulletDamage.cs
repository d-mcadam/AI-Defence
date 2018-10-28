﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    private void OnEnable()
    {
        Invoke("DestroyBullet", 2f);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (!obj.isTrigger && obj.tag == "Enemy")
        {
            if (this.gameObject.name.Contains("Bullet"))
            {
                obj.gameObject.SetActive(false);
            }
            else if (this.gameObject.name.Contains("Bomb"))
            {
                Transform bombChild = this.gameObject.transform.GetChild(0);
                
                Vector3 vect = new Vector3(bombChild.position.x, bombChild.position.y, bombChild.position.z);

                Collider[] detectedColliders = Physics.OverlapSphere(vect, 0.1f);

                foreach (Collider col in detectedColliders)
                {
                    if (col.gameObject.tag == "Enemy")
                    {
                        col.gameObject.SetActive(false);
                    }
                }
            }

            this.DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.SetActive(false);
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}