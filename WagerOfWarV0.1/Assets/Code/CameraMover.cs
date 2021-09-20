using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] public GameObject _game;
    [SerializeField] float _minSize = 1f;
    [SerializeField] float _maxSize = 10f;
    [SerializeField] float _sensitivity = 10f;
    [SerializeField] int _mouseButton;

    private Camera _me;
    private Vector2 _dragOrigin;
    private Vector2 _currentPos;
    private Vector2 _gamePos;
    private bool _buttonHeld;

    // Start is called before the first frame update
    void Start()
    {
        _dragOrigin = Input.mousePosition;
        _me = GetComponent<Camera>();
        _buttonHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        _currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(_mouseButton) && !_buttonHeld)
        {
            _dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _buttonHeld = true;
            _gamePos = _game.transform.position;
        }
        if (Input.GetMouseButton(_mouseButton) && _buttonHeld)
        {
            Vector2 newGamePos = -new Vector2(_dragOrigin.x - _currentPos.x, _dragOrigin.y - _currentPos.y);
            _game.transform.position = new Vector3(newGamePos.x + _gamePos.x, newGamePos.y + _gamePos.y, _game.transform.position.z);
        }
        if (!Input.GetMouseButton(_mouseButton))
        {
            _buttonHeld = false;
        }
    }
    private void Zoom()
    {
        float size = _me.orthographicSize;
        size += -Input.mouseScrollDelta.y * _sensitivity;
        size = Mathf.Clamp(size, _minSize, _maxSize);
        _me.orthographicSize = size;
    }
}
