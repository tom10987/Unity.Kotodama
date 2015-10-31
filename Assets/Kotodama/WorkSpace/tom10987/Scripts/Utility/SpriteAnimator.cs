
using UnityEngine;


public class SpriteAnimator : MonoBehaviour {

  [SerializeField]
  float _width = 0f;

  [SerializeField]
  float _height = 0f;

  Sprite _sprite = null;
  float _anim = 0f;


  void Start() {
    _sprite = GetComponent<SpriteRenderer>().sprite;
  }

  void Update() {
  }
}
