using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private float _timeGrowUp = 1f;
    [SerializeField] private string _newTag = "PlantGrowUp";

    private Renderer _renderer;
    private Color _startColor = Color.white;
    private Color _endColor = Color.green;
    private Vector3 _originalScale = Vector3.zero;
    private Vector3 _newScale = Vector3.zero;
    private float _speed = 1f;

    void Start()
    {
        _renderer = GetComponent<Renderer>();

        _startColor = _renderer.material.color;
        _originalScale = transform.localScale;
        _newScale = _originalScale * 2;

        StartCoroutine(DelayGrowUp());
    }

    private IEnumerator DelayGrowUp()
    {
        yield return new WaitForSeconds(_timeGrowUp);

        float t = _speed;
        _renderer.material.color = Color.Lerp(_startColor, _endColor, t);
        transform.localScale = Vector3.Lerp(_originalScale, _newScale, t);

        gameObject.tag = _newTag;
    }
}