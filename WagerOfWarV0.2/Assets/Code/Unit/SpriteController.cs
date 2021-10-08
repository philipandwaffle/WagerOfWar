using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] public SpriteRenderer _spriteRenderer;
    [SerializeField] public string _path;
    [SerializeField] public bool _flipX;

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer.sprite = Resources.Load<Sprite>(_path);
        _spriteRenderer.flipX = _flipX;
    }

    public void SetFlipX(bool b)
    {
        this._flipX = b;
        _spriteRenderer.flipX = _flipX;
    }
}
