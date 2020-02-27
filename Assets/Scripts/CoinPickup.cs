using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinpickUpSFX;
    [SerializeField] int Point = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(Point);
        AudioSource.PlayClipAtPoint(coinpickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
