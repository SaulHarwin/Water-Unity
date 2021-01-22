using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance; // Allows us to access a specific instance of this class from anywhere in the project assureing that there is only ever on in the existance.

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Debug.Log("instance already exists, destroying Object!");
            Destroy(this);
        }
    }

    private void Update() {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveY(float _x) {
        return amplitude * Mathf.Sin(_x / length + offset);
    }
    public float GetWaveX(float _x) {
        return amplitude * Mathf.Cos(_x / length + offset);
    }
}
