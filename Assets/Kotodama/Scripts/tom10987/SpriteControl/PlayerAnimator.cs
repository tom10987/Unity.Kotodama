
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
class PlayerSprite {
  public Sprite[] _default = null;
  public Sprite[] _lantern = null;
}


public enum PlayerSpriteState {
  Default,
  Lantern,
}


public class PlayerAnimator : MonoBehaviour {

  [SerializeField]
  PlayerSprite _sprite = null;

  PlayerSpriteState _state = PlayerSpriteState.Default;
  Dictionary<PlayerSpriteState, List<Sprite>> _animation = null;

  SpriteRenderer _renderer = null;
  int _time = 0;
  int _direction = 0;

  Rigidbody _ownRigid = null;
  bool _isMove = false;


  //------------------------------------------------------------
  // public method

  public void SetSpriteState(PlayerSpriteState newState) {
    _state = newState;
  }


  //------------------------------------------------------------
  // private method

  void Animation() {
    ++_time;

    var animationID = _time / (60 / _animation[_state].Count);
    var current = animationID % (_animation[_state].Count / 2) + _direction;
    if (_renderer.sprite == _animation[_state][current]) { return; }

    _renderer.sprite = _animation[_state][current];
  }

  void Direction() {
    _isMove = _ownRigid.velocity.magnitude > 0f;
    if (!_isMove) { _time = 0; Animation(); return; }

    // TIPS: 画像が右向きなので、左に移動していたら x スケールを反転する
    var isLeft = _ownRigid.velocity.x < 0f;
    transform.localScale = new Vector3(isLeft ? -1f : 1f, 1f, 1f);

    // TIPS: 上に向かって移動していたら、上向きの画像を参照するようにする
    // TIPS: 奥行きは z 軸
    _direction = (_ownRigid.velocity.z > 0f) ? 2 : 0;
  }

  void SpriteSetup(Sprite[] sprites, PlayerSpriteState state) {
    var list = new List<Sprite>();
    foreach (var sprite in sprites) { list.Add(sprite); }
    _animation.Add(state, list);
  }


  //------------------------------------------------------------
  // Behaviour

  void Awake() {
    _animation = new Dictionary<PlayerSpriteState, List<Sprite>>();
    SpriteSetup(_sprite._default, PlayerSpriteState.Default);
    SpriteSetup(_sprite._lantern, PlayerSpriteState.Lantern);
  }

  void Start() {
    _renderer = GetComponent<SpriteRenderer>();
    _ownRigid = GetComponentInParent<Rigidbody>();
  }

  void Update() {
    Direction();
    if (_isMove) { Animation(); }
  }
}
