
using UnityEngine;
using System.Collections;

public class PlayerLight : AbstractPlayer {

  [SerializeField]
  Light _light = null;

  [SerializeField]
  Color _safe = Color.cyan;

  [SerializeField]
  Color _danger = Color.red;

  public override IEnumerator UpdateComponent() {
    _light.color = _safe;

    // TODO: 敵が接近してきたら色を変える

    while (PlayerState.instance.isPlaying) {
      yield return null;
    }
  }

  Color GenerateColor() {
    return default(Color);
  }
}
