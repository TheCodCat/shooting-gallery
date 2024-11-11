using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _liveText;
    [SerializeField] private ArchoryController _controller;
    private void OnEnable()
    {
        Timer.OnChangeTimeValue += ViewTime;
        ArchoryController.OnChageArchoryLive += ViewLive;
        ViewLive(0);
    }
    private void OnDisable()
    {
        Timer.OnChangeTimeValue -= ViewTime;
        ArchoryController.OnChageArchoryLive -= ViewLive;
    }
    private void ViewTime(float time)
    {
        string newTime = string.Format("{0:F2}", time);
        _timeText.text = newTime;
    }
    private void ViewLive(int count)
    {
        _liveText.text = $"{count}/{_controller.GetLiveCount()}";
    }
}
