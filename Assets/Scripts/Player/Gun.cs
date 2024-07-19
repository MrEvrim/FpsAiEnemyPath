using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 70f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Spawn noktasının yönüne göre rotasyonu ayarla ve X ekseninde -90 derece çevir
            Quaternion bulletRotation = Quaternion.LookRotation(transform.forward);
            bulletRotation *= Quaternion.Euler(-90f, 0f, 0f);

            // Mermiyi spawn et ve rotasyonu uygula
            GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, bulletRotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        }
    }
}