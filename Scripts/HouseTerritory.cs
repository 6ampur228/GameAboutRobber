using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTerritory: MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void Start()
    {
        _signaling.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Robber>(out Robber robber))
        {
            _signaling.IncreaseVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Robber>(out Robber robber))
        {
            _signaling.DecreaseVolume(); 
        }
    }
}
