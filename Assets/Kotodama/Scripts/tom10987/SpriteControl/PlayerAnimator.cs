
using UnityEngine;
using System.Collections.Generic;


public class PlayerAnimator : MonoBehaviour {

  [System.Serializable]
  class PlayerSprite {
    public Sprite[] _defaultUp = null;
    public Sprite[] _defaultDown = null;
    public Sprite[] _lanternUp = null;
    public Sprite[] _lanternDown = null;
  }

  enum SpriteState { Default, Lantern, }
  enum DirectionState { Up, Down, }

  const byte animationSpan = 40;

  [SerializeField]
  SpriteRenderer _renderer = null;

  [SerializeField]
  PlayerSprite _sprite = null;

  SpriteState _state = SpriteState.Default;
  bool IsDefault() { return _state == SpriteState.Default; }
  SpriteState OtherState() { return IsDefault() ? SpriteState.Lantern : SpriteState.Default; }

  DirectionState _direction = DirectionState.Up;
  Dictionary<SpriteState, Dictionary<DirectionState, Sprite[]>> _animation = null;

  byte _time = 0;


  public void ChangeSpriteState() { _state = OtherState(); }

  public void UpdateDirection(Vector3 velocity) {
    // TIPS: 左に進んでいたら左向きにする
    transform.localScale = new Vector3((velocity.x < 0f) ? -1f : 1f, 1f, 1f);

    // TIPS: 画面奥に向かって進んでいたら上向きの画像にする
    _direction = (velocity.z > 0f) ? DirectionState.Up : DirectionState.Down;
  }

  public void StopAnimation() {
    _time = 0;
    SetAnimationState();
  }

  public void UpdateAnimation() {
    ++_time;
    if (_time > animationSpan) { _time = 0; }
    SetAnimationState();
  }

  void SetAnimationState() {
    var array = _animation[_state][_direction];
    var index = (_time / (animationSpan / array.Length)) % array.Length;
    if (_renderer.sprite != array[index]) { _renderer.sprite = array[index]; }
  }

  void Awake() {
    _animation = new Dictionary<SpriteState, Dictionary<DirectionState, Sprite[]>>();

    System.Action<Sprite[], Sprite[], SpriteState> spriteSetup = null;
    spriteSetup = (up, down, type) => {
      var dictionary = new Dictionary<DirectionState, Sprite[]>();
      dictionary.Add(DirectionState.Up, up);
      dictionary.Add(DirectionState.Down, down);
      _animation.Add(type, dictionary);
    };

    spriteSetup(_sprite._defaultUp, _sprite._defaultDown, SpriteState.Default);
    spriteSetup(_sprite._lanternUp, _sprite._lanternDown, SpriteState.Lantern);

    _time = 0;
  }
}
