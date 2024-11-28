using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ClockHandler : MonoBehaviour
{
    private Text text;
    private int hours = 6;
    private int minutes = 0;

    void Start()
    {
        text = GetComponent<Text>();
        UpdateClock();
        InvokeRepeating("AdvanceClock", 1f, 1f); //memanggil fungsi dlm waktu 1 detik setiap 1 detik
    }

    void UpdateClock()
    {
        text.text = $"{hours:00}:{minutes:00}";
    }

    void AdvanceClock()
    {
        minutes++;
        if (minutes >= 60)
        {
            minutes = 0;
            hours++;

            if (hours >= 24) { hours = 0; }
        }
        UpdateClock();
    }
}
