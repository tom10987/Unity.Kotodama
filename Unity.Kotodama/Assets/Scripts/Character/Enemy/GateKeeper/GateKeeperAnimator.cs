
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GateKeeperAnimator : MonoBehaviour {

  enum DirectionType { Front, Back, }

  [SerializeField]
  SpriteRenderer _renderer = null;

  [SerializeField]
  Sprite[] _front = null;

  [SerializeField]
  Sprite[] _back = null;

  bool _isAnimation = false;

  void Start() { StartCoroutine(UpdateAnimation()); }

  IEnumerator UpdateAnimation() {
    _isAnimation = true;

    const byte animationSpan = 40;
    byte time = 0;
    while (_isAnimation) {
      ++time;
      if (time > animationSpan) { time = 0; }
      yield return null;
    }
  }

  public IEnumerator DestroyEnemy() {
    _isAnimation = false;

    var alpha = 0f;
    while (alpha < 1f) {
      alpha += Time.deltaTime;
      _renderer.color *= (1f - alpha);
      yield return null;
    }

    Destroy(gameObject);
  }

  // TIPS: プレイヤーとの位置関係で画像を切り替える
  IEnumerable<Sprite> GetSprites() {
    var player = PlayerState.instance.transform.position;
    var isForward = transform.position.z > player.z;
    return (isForward ? _front : _back);
  }

  void Update() {
    /*
    // TIPS: 画像が登録されてなければ何もしない
    var sprites = _sprites[_direction];
    if (sprites.Length == 0) { return; }

    ++_time;
    if (_time > animationSpan) { _time = 0; }

    var index = (_time / (animationSpan / sprites.Length)) % sprites.Length;
    if (_renderer.sprite != sprites[index]) { _renderer.sprite = sprites[index]; }
    */
  }
}
