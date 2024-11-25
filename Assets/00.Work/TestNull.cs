using UnityEngine;
using UnityEngine.Events;

public class TestNull : MonoBehaviour
{
    [SerializeField] GameObject GameObject;
    [SerializeField] UnityEvent UnityEvent = new();
    void Start()
    {
        Debug.Log($"Test {UnityEvent is null}");
        Debug.Log($"Test {UnityEvent == null}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
