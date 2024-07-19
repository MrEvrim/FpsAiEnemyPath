using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{



    private void OnCollisionEnter(Collision collision)
    {
        //vurulma kod satırı
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(15);
        }
        Destroy(gameObject);
    }
}
