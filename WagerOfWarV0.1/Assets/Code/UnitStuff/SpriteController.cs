using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpriteController : MonoBehaviour
{
    [SerializeField] public SpriteRenderer _spriteRenderer;
    [SerializeField] public string _path;
    [SerializeField] public bool _flipX;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = Resources.Load<Sprite>(_path);
        UpdateFlipX();
    }

    public void SetFlipX(bool b)
    {
        this._flipX = b;
        UpdateFlipX();
    }

    private void UpdateFlipX()
    {
        _spriteRenderer.flipX = _flipX;
    }
}
