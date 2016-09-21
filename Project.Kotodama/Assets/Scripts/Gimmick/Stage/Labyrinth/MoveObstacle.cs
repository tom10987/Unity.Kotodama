
using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour {

  [SerializeField]
  Vector3 _destination = Vector3.zero;

  [SerializeField]
  [Range(0.1f, 1.0f)]
  float _velocityRate = 0.5f;

  public void StartMove() { StartCoroutine(UpdateObstacle()); }

  IEnumerator UpdateObstacle() {
    var start = Vector3.zero;

    while (start.magnitude < _destination.magnitude) {
      var translate = _destination * Time.deltaTime * _velocityRate;
      transform.Translate(translate);
      start += translate;
      yield return null;
    }
  }
}
