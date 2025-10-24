using UnityEngine;

public static class ExTween
{
    public static float EaseOutExpo(float value)
    {
        float x =(value== 1) ? 1 : 1 - Mathf.Pow(2, -10 * value);
        return x;
    }
}