using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField]
  float startTime = 30f;

  float currentTime;

  [SerializeField]
  TMP_Text timeText;

  [SerializeField]
  TMP_Text buttonText;

  public bool currentlyRunning = false;

  // Start is called before the first frame update
  void Start()
  {
    currentTime = startTime;
  }

  // Update is called once per frame
  void Update()
  {
    if (currentlyRunning)
    {
      currentTime -= Time.deltaTime;
      if (currentTime <= 0)
      {
        currentTime = 0;
        currentlyRunning = false;
        buttonText.text = "Reset";
      }
      UpdateTimeText();
    }
  }

  public void ButtonPress()
  {
    if (currentlyRunning)
    {
      currentlyRunning = false;
      buttonText.text = "Reset";
    }
    else if (currentTime != startTime)
    {
      currentTime = startTime;
      UpdateTimeText();
      buttonText.text = "Start";
    }
    else
    {
      currentlyRunning = true;
      buttonText.text = "Stop";
    }
  }

  private void UpdateTimeText()
  {
    timeText.text = $"{currentTime:00.00}";
  }
}
