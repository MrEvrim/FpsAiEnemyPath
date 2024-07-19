using UnityEngine;

public class DusmanKontrol : MonoBehaviour
{
    public int carpismaSayisi = 3;

    private int carpismaSayac = 0;

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışan nesnenin tag'i "Mermi" ise
        if (collision.gameObject.CompareTag("Mermi"))
        {
            carpismaSayac++;

            Debug.Log("Düşmana Mermi çarptı: " + carpismaSayac + " kere");

            // Belirlenen çarpışma sayısına ulaşıldığında düşmanı yok et
            if (carpismaSayac >= carpismaSayisi)
            {
                Debug.Log("Düşmanı yok et");

                Destroy(gameObject); // Dusman objesini yok et
            }
        }
    }
}