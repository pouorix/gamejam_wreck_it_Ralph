using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("deathZone") )
            Destroy(gameObject);
    }
}
