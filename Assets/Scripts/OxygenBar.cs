using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider oxygenSlider;
    public Image fillImage;
    public GameObject gameOverPanel;

    public float oxygen = 100f;
    public float decreaseSpeed = 5f;

    void Start()
    {
        oxygenSlider.maxValue = 100f;
        oxygenSlider.value = oxygen;

        fillImage.color = Color.white;

        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        oxygen -= decreaseSpeed * Time.deltaTime;

        oxygenSlider.value = oxygen;

        if (oxygen <= 30f)
        {
            fillImage.color = Color.red;
        }
        else
        {
            fillImage.color = Color.white;
        }

        if (oxygen <= 0)
        {
            oxygen = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
           
    }
}

