using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinsScript : MonoBehaviour
{
    private CoinsManager _coinsManager;
    
    void Start()
    {
        _coinsManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinsManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _coinsManager.removeSelf(gameObject);
            Destroy(gameObject);
        }
    }
}
