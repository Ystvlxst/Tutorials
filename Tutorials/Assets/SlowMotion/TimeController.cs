using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float _slowdownFactor = 0.025f;
    private float _slowdaownLength = 3f;

    private void Update()
    {
        Time.timeScale += (1f / _slowdaownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowMotion()
    {
        Time.timeScale = _slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
