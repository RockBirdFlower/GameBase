using UnityEngine;

public class TimeManager
{
    private float _prevTimeScale;
    private bool _isStop = false;
    private const int _maxTimeScale = 5;
    public void Pause()
    {
        _isStop = true;
        SetTimeScale(0);
    }

    public void Play()
    {
        if (_isStop == false) return;
        SetTimeScale(_prevTimeScale);
        _isStop = false;
    }

    public void SetTimeScale(float timeScale)
    {
        _prevTimeScale = Time.timeScale;
        Time.timeScale = timeScale;
    }

    public string GetTimeString()
    {
        int totalSeconds = (int)Time.time;

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        string timeString = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        return timeString;
    }
}