using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerhealth : MonoBehaviour
{
  public Slider Healthbar;
  public GameObject GameoverPanel;
  public Movement enemyPlayer;
  int health = 100;
  void Start()
  {
    Healthbar.maxValue = 100;
    Healthbar.value = health;
    // GameoverPanel.SetActive(false);
  }
  public void Danger()
  {
    health -= 30;
    Healthbar.value = health;
    if (health <= 0)
    {
      enemyPlayer.enabled = false;
      GameoverPanel.SetActive(true);
      
    }
  }
}

