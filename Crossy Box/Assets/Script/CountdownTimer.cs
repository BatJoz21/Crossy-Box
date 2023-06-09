using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] TMP_Text tmpText;
    public UnityEvent OnStart;
    public UnityEvent OnEnd;

    private void Start()
    {
        OnStart.Invoke();
        var sequence = DOTween.Sequence();
        tmpText.transform.localScale = Vector3.zero;
        tmpText.text = "3";
        sequence.Append(tmpText.transform.DOScale(Vector3.one, 1f).OnComplete(() => 
        {
            tmpText.transform.localScale = Vector3.zero;
            tmpText.text = "2";
        }));
        sequence.Append(tmpText.transform.DOScale(Vector3.one, 1f).OnComplete(() =>
        {
            tmpText.transform.localScale = Vector3.zero;
            tmpText.text = "1";
        }));
        sequence.Append(tmpText.transform.DOScale(Vector3.one, 1f).OnComplete(() =>
        {
            tmpText.transform.localScale = Vector3.zero;
            tmpText.text = "GO";
        }));
        sequence.Append(tmpText.transform.DOScale(Vector3.one, 1f).OnComplete(() =>
        {
            OnEnd.Invoke();
        }));
    }
}
