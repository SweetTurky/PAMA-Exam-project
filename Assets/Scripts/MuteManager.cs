using UnityEngine;

public class MuteManager : MonoBehaviour
{
    public static MuteManager Instance = null;   // Singleton instance
    public float threshold;     // 3 feels good
    public bool trigger = false;
    public float muteTime;      // not used in this version
    public float waitTime;      // 0.2 feels good 


    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        // If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        // Ensures the OldAudioManager won't be destroyed when loading a new scene.
    }
    /*
    I had to put my if loop in FixedUpdate, 
    and adjust the "Fixed Timestep" (0.15) in Unity
    to achieve acceptable results with 
    the shakemute function in a use-case situation
    */
    void FixedUpdate()
    {

        if (Input.acceleration.sqrMagnitude > threshold * threshold)
        {
            if (trigger == false)
            {
                Invoke(nameof(Mute), waitTime);
                trigger = true;
            }


            else if (trigger == true)
            {
                Invoke(nameof(UnMute), waitTime);
                trigger = false;
            }
        }
    }

    void UnMute()
    {
        Debug.Log("Unmuted");
        AudioListener.pause = false;
        AudioListener.volume = 1;
    }

    void Mute()
    {
        Debug.Log("muted");
        AudioListener.pause = true;
        AudioListener.volume = 0;
    }
}