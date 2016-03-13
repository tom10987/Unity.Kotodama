
using UnityEngine;
using System.Collections;

public class ChaserAnimator : MonoBehaviour {

  [SerializeField]
  [Range(0.1f, 2.0f)]
  float _animationSpan = 0.175f;

  [SerializeField]
  SpriteRenderer _renderer = null;

  [SerializeField]
  Sprite[] _sprites = null;

  /// <summary> アニメーション開始 </summary>
  public void StartAnimation() { StartCoroutine(UpdateAnimation()); }

  IEnumerator UpdateAnimation() {
    var manager = EnemyManager.instance;
    while (manager.isActive) { yield return StartCoroutine(UpdateRenderer()); }
  }

  IEnumerator UpdateRenderer() {
    foreach (var sprite in _sprites) {
      yield return new WaitForSeconds(_animationSpan);
      _renderer.sprite = sprite;
    }
  }

  /// <summary> 消滅アニメーション </summary>
  public void Destroy(ChaseActor actor) { StartCoroutine(DeadAnimation(actor)); }

  IEnumerator DeadAnimation(ChaseActor actor) {
    var alpha = 1f;
    while (alpha > 0f) {
      alpha -= Time.deltaTime;
      _renderer.color = Color.white * alpha;
      yield return null;
    }
    Destroy(actor.gameObject);
  }
}
