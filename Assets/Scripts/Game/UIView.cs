using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    private void OnEnable()
    {
        Timer.OnChangeTimeValue += ViewTime;
    }
    private void OnDisable()
    {
        Timer.OnChangeTimeValue -= ViewTime;
    }
    private void ViewTime(float time)
    {
        string newTime = string.Format("{0:F2}", time);
        _timeText.text = newTime;
    }
}
