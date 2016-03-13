
using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerLight : AbstractPlayer {

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

  public override IEnumerator UpdateComponent() {
    var state = PlayerState.instance;
    var manager = EnemyManager.instance;

    while (state.isPlaying) {
      if (!manager.isActive) { break; }
      var actors = manager.actors.Select(actor => actor.transform);
      yield return null;

      if (!manager.isActive) { break; }
      var vector = actors.Select(actor => actor.position - transform.position);
      yield return null;

      if (!manager.isActive) { break; }
      var distance = vector.Min(dist => dist.magnitude);
      yield return null;

      if (!manager.isActive) { break; }
      var clamp = Mathf.Clamp(distance - _dangerRange, 0f, _dangerRange);
      yield return null;

      if (!manager.isActive) { break; }
      _light.color = GenerateColor(clamp);
      yield return null;
    }

    GenerateColor(_dangerRange);
  }

  Color GenerateColor(float rate) {
    var safe = _safe * rate * 3f;
    var danger = _danger * (_dangerRange - rate) * 2f;
    var ambient = _ambient * (_dangerRange - rate) * 0.5f;
    var result = (safe + danger + ambient) / 3;
    return (result / _dangerRange) + Color.black;
  }
}
