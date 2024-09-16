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

  [SerializeField]
  TMP_Text pointsText;

  public bool currentlyRunning = false;
  private int points;

  void Start()
  {
    currentTime = startTime;
  }

  void Update()
  {
    if (currentlyRunning)
    {
      currentTime -= Time.deltaTime;
      if (currentTime <= 0)
      {
        SendMessage("OnStop");
        currentTime = 0;
      }
      UpdateTimeText();
    }
  }

  public void ButtonPress()
  {
    if (currentlyRunning)
    {
      SendMessage("OnStop");
    }
    else if (currentTime != startTime)
    {
      SendMessage("OnReset");
    }
    else
    {
      SendMessage("OnStart");
    }
  }

  private void OnStart()
  {
    currentlyRunning = true;
    buttonText.text = "Stop";
  }

  private void OnStop()
  {
    currentlyRunning = false;
    buttonText.text = "Reset";
  }

  private void OnReset()
  {
    currentTime = startTime;
    points = 0;

    UpdatePointsText();
    UpdateTimeText();

    buttonText.text = "Start";
  }

  public void AddPoints(int pts)
  {
    if (!currentlyRunning) return;

    points += pts;
    UpdatePointsText();
  }

  private void UpdatePointsText()
  {
    pointsText.text = $"Points: {points}";
  }

  private void UpdateTimeText()
  {
    timeText.text = $"{currentTime:00.00}";
  }
}
