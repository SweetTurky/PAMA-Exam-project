using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Dette script er lavet med inspiration fra et script fundet på Unity's Forum. https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
public class Lerp : MonoBehaviour
{
    public float endY;
    // Movement speed in units per second for the markers.
    public float speed = 7.0f;
    public void StartLerp()
    {
        StartCoroutine(LerpPusher());
    }
    IEnumerator LerpPusher()
    {
        endY = transform.position.y - 225;
        while (Mathf.Abs(endY - transform.position.y) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, endY, transform.position.z), speed * Time.deltaTime);
            yield return null;
        }
    }
}