
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GateKeeperAnimator : MonoBehaviour {

  enum DirectionType { Front, Back, }

  [SerializeField]
  SpriteRenderer _renderer = null;

  [SerializeField]
  [Range(0.1f, 0.5f)]
  float _animationSpan = 0.2f;

  [SerializeField]
  Sprite[] _front = null;

  [SerializeField]
  Sprite[] _back = null;

  bool _isAnimation = false;

  void Start() { StartCoroutine(UpdateAnimation()); }

  IEnumerator UpdateAnimation() {
    _isAnimation = true;
    while (_isAnimation) { yield return StartCoroutine(SpriteAnimation()); }
  }

  /// <summary> アニメーションを終了、消滅させる </summary>
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

  IEnumerator SpriteAnimation() {
    foreach (var sprite in GetSprites()) {
      yield return new WaitForSeconds(_animationSpan);
      _renderer.sprite = sprite;
    }
  }

  // TIPS: プレイヤーとの位置関係で画像を切り替える
  IEnumerable<Sprite> GetSprites() {
    var player = PlayerState.instance.transform.position;
    var isForward = transform.position.z > player.z;
    return (isForward ? _front : _back);
  }
}
