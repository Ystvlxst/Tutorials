using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _slowdownFactor = 0.001f;
    [SerializeField] private float _slowdaownLength = 3f;

    private void Update()
    {
        Time.timeScale += (1f / _slowdaownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

       // if (Input.GetMouseButtonDown(0))
       //     DoSlowMotion();
    }

    public void DoSlowMotion()
    {
        Time.timeScale = _slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
