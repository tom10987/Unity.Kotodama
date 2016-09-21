
using UnityEngine;

public class CharacterShadow : MonoBehaviour {

  [SerializeField]
  Transform _polygon = null;

  [SerializeField]
  [Range(0f, 1f)]
  float _offset = 0.6f;

  [SerializeField]
  [Range(0.5f, 1.5f)]
  float _scale = 1f;
  static readonly float rate = 0.1f;

  void Start() {
    var baseScale = (Vector3.one - Vector3.up) * _scale * rate;
    _polygon.localScale = baseScale + Vector3.up;
    _polygon.localPosition = Vector3.back * _offset;
  }
}
