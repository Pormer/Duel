using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class FadeInOutUi : MonoBehaviour
{
    private UIDocument _fadeInOutPenel;
    private VisualElement _root;
    private VisualElement[] _fades = new VisualElement[2];

    private void Start()
    {
        _fadeInOutPenel = GetComponent<UIDocument>();
        _root = _fadeInOutPenel.rootVisualElement;
        _fades[0] = _root.Q<VisualElement>("FadeUp");
        _fades[1] = _root.Q<VisualElement>("FadeDown");
        GameManager.Instance.OnFadeIn += FadeIn;
        
        StartCoroutine(FadeOntStart());
    }
    public void FadeIn(int value) => StartCoroutine(FadeInStart(value));
    private IEnumerator FadeInStart(int sceneValue)
    {
        _fades[0].ToggleInClassList("IsMove");
        yield return new WaitForSeconds(0.3f);
        _fades[1].ToggleInClassList("IsMove");
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(sceneValue);
    }

    public IEnumerator FadeOntStart()
    {
        yield return new WaitForSeconds(0.3f);
        _fades[0].RemoveFromClassList("IsMove");
        yield return new WaitForSeconds(0.3f);
        _fades[1].RemoveFromClassList("IsMove");
        yield return new WaitForSeconds(0.4f);
        GameManager.Instance.OnGameStart?.Invoke();
    }

}
