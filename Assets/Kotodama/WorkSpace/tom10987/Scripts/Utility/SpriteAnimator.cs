
using UnityEngine;

using Anim = System.Collections.Generic.
  List<UnityEngine.Sprite>;


public class SpriteAnimator : MonoBehaviour {

  [SerializeField]
  Sprite[] _sprite = null;

  SpriteRenderer _renderer = null;
  Anim _anim = null;
  int _time = 0;

  Rigidbody _ownRigid = null;
  bool _isMove = false;


  void Start() {
    _renderer = GetComponent<SpriteRenderer>();

    _anim = new Anim();
    _anim.Add(_sprite[0]);
    _anim.Add(_sprite[1]);
    _anim.Add(_sprite[0]);
    _anim.Add(_sprite[2]);

    _ownRigid = GetComponentInParent<Rigidbody>();
  }

  void Update() {
    Direction();
    if (_isMove) { Animation(); }
  }

  void Animation() {
    ++_time;

    var state = (_time / (60 / _anim.Count)) % _anim.Count;
    if (_renderer.sprite == _anim[state]) { return; }

    _renderer.sprite = _anim[state];
  }

  void Direction() {
    _isMove = _ownRigid.velocity.magnitude > 0f;
    if (!_isMove) { _time = 0; Animation(); return; }

    // 画像が左向きなので、右に移動していたら x スケールを反転する
    var isLeft = _ownRigid.velocity.x <= 0f;
    transform.localScale = new Vector3(isLeft ? 1f : -1f, 1f, 1f);
  }
}
