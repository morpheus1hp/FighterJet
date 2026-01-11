using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
