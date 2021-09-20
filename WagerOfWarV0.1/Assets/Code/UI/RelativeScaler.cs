using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class RelativeScaler : MonoBehaviour
{
    [SerializeField] public float _xScale = 1;
    [SerializeField] private float _yScale = 1;
    [SerializeField] private float _xPos;
    [SerializeField] private float _yPos;
    [SerializeField] private bool _debug;

    [SerializeField] private RectTransform _parent;
    [SerializeField] private RectTransform _me;

    // Start is called before the first frame update
    void Start()
    {
        _parent = gameObject.transform.parent.GetComponent<RectTransform>();
        if (gameObject.GetComponent<RectTransform>() != null)
        {
            _me = gameObject.GetComponent<RectTransform>();
        }
        _me.sizeDelta = new Vector2(_parent.rect.width, _parent.rect.height);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScale();
        UpdatePos();
        if (_me.sizeDelta != _parent.sizeDelta)
        {
            updateSize();
        }
    }

    private void UpdateScale()
    {
        _me.localScale = new Vector3(_xScale, _yScale, 1);
    }
    private void updateSize()
    {
        _me.sizeDelta = new Vector2(_parent.rect.width, _parent.rect.height);
    }
    private void UpdatePos()
    {
        _me.localPosition = new Vector3(_parent.rect.width * _xPos, _parent.rect.height * _yPos, _me.localPosition.z);
    }

}
