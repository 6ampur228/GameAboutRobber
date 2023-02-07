using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTerritory: MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;
    [SerializeField] private float _speedDeceleration;

    private int _countFrame = 1500;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Robber>(out Robber robber))
        {
            _signaling.volume = 0f;
            _signaling.Play();

            StartCoroutine(IncreaseVolume());
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Robber>(out Robber robber))
        {
            StartCoroutine(DecreaseVolume());
        }
    }

    private IEnumerator DecreaseVolume()
    {
        for(int i = 0; i < _countFrame; i++)
        {
            _signaling.volume -= Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator IncreaseVolume()
    {
        for (int i = 0; i < _countFrame; i++)
        {
            _signaling.volume += Time.deltaTime;

            yield return null;
        }
    }
}
