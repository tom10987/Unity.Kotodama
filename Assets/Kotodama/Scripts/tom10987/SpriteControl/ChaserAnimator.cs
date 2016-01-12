
using UnityEngine;


public class ChaserAnimator : MonoBehaviour {

  const byte animationSpan = 60;

  [SerializeField]
  Sprite[] _sprite = null;

  [SerializeField]
  SpriteRenderer _renderer = null;

  byte _time = 0;
  bool _existsSprite = false;


  void Start() {
    if (_renderer == null) { _renderer = GetComponent<SpriteRenderer>(); }
    _existsSprite = _sprite.Length > 0;
  }

  void Update() {
    if (!_existsSprite) { return; }

    ++_time;
    if (_time > animationSpan) { _time = 0; }

    var index = (_time / (animationSpan / _sprite.Length)) % _sprite.Length;
    if (_renderer.sprite != _sprite[index]) { _renderer.sprite = _sprite[index]; }
  }
}
