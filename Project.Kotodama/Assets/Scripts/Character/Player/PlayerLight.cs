
using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerLight : PlayerComponent {

  [SerializeField]
  Light _light = null;

  [SerializeField, Range(5f, 15f)]
  [Tooltip("ランプの色が変わり始める距離")]
  float _dangerRange = 10f;

  [SerializeField]
  Color _safe = Color.cyan;

  [SerializeField]
  Color _danger = Color.red;

  [SerializeField]
  Color _ambient = Color.yellow;

  protected override IEnumerator UpdateComponent() {
    var actors = GameManager.instance.enemy.actors;

    // TIPS: 最も近い位置にいる敵との距離を取得して、色情報を生成する
    while (actors.Any()) {
      var distance = actors.Min<ChaseActor, float>(GetDistance);
      _light.color = GenerateColor(Mathf.Clamp(distance - _dangerRange, 0f, _dangerRange));
      yield return null;
    }

    _light.color = GenerateColor(_dangerRange);
  }

  Color GenerateColor(float distance) {
    var safe = _safe * distance * 3f;
    var danger = _danger * (_dangerRange - distance) * 2f;
    var ambient = _ambient * (_dangerRange - distance);
    var result = (safe + danger + ambient) / 3;
    return (result / _dangerRange);
  }

  // TIPS: LINQ 用
  float GetDistance(ChaseActor actor) {
    var distance = actor.transform.position - transform.position;
    return distance.magnitude;
  }
}
