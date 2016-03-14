
using UnityEngine;
using System.Collections;

public class UnderGroundBridge : MonoBehaviour {

  [SerializeField]
  Transform _bridge = null;

  [SerializeField]
  Transform _obstacle = null;

  public void SwitchActivate() { StartCoroutine(UpdateState()); }

  IEnumerator UpdateState() {
    var distance = _bridge.position.y - _obstacle.position.y;
    var time = 0f;
    while (time < 1f) {
      time += Time.deltaTime;
      var translate = Vector3.down * Time.deltaTime * distance;
      _bridge.Translate(translate);
      _obstacle.Translate(translate * -1f);
      yield return null;
    }
  }
}
