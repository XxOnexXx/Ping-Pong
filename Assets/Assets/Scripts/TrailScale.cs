
using UnityEngine;

public class TrailScale : MonoBehaviour
{
    [SerializeField] Vector2 targetScale = Vector2.zero;
    private Vector2 initialScale;
    [SerializeField] private float duration = 1.5f;
    float timer = 0;
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float t = Mathf.Clamp01(timer / duration);
        transform.localScale = Vector2.Lerp(initialScale, targetScale, t);
    }
}
