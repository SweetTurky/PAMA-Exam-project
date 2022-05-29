using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldAudioManager : MonoBehaviour
{
    public static OldAudioManager Instance = null;     // Singleton instance.
    public float threshold;
    public bool trigger = false;
    public float snoozeTime = 30f;


    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of OldAudioManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        // The OldAudioManager won't be destroyed when loading a new scene.
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.acceleration.magnitude > threshold)
        {
            Debug.Log("PlayTest aktiveret");
            if (trigger == false)
            {
                trigger = true;
                AudioListener.pause = true;
                AudioListener.volume = 0;

                Invoke("TurnUpVolume", snoozeTime);
            }
        }

        else if (trigger == true)
        {
            trigger = false;
        }

    }
    void TurnUpVolume()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1;
    }
}