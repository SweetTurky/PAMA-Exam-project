using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStamp : MonoBehaviour
{
    public GameObject timeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        timeDisplay.GetComponent<Text>().text = System.DateTime.Now.ToString("HH:mm");
    }

}
