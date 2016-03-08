
using UnityEngine;
using System.Collections.Generic;


public class KeeperAnimator : MonoBehaviour {

  enum DirectionType { Front, Back, }

  const byte animationSpan = 40;

  [SerializeField]
  SpriteRenderer _renderer = null;

  [SerializeField]
  DirectionType _direction = DirectionType.Front;

  [SerializeField]
  Sprite[] _front = null;

  [SerializeField]
  Sprite[] _back = null;

  Dictionary<DirectionType, Sprite[]> _sprites = null;

  byte _time = 0;


  void Start() {
    if (_renderer == null) { _renderer = GetComponent<SpriteRenderer>(); }

    _sprites = new Dictionary<DirectionType, Sprite[]>();
    _sprites.Add(DirectionType.Front, _front);
    _sprites.Add(DirectionType.Back, _back);
  }

  void Update() {
    // TIPS: 画像が登録されてなければ何もしない
    var sprites = _sprites[_direction];
    if (sprites.Length == 0) { return; }

    ++_time;
    if (_time > animationSpan) { _time = 0; }

    var index = (_time / (animationSpan / sprites.Length)) % sprites.Length;
    if (_renderer.sprite != sprites[index]) { _renderer.sprite = sprites[index]; }
  }
}
