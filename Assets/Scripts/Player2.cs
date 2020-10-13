using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.layer == 8) {
            GameState.P2Score++;
            Destroy (other.gameObject);
        }
    }
}