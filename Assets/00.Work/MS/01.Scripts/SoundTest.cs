using UnityEngine;

public class SoundTest : MonoBehaviour
{
    [SerializeField] SoundSO data;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SoundManager.Instance.PlaySFX(data);
        }
    }
}
