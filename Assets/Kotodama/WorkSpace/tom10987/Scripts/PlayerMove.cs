
using UnityEngine;
using System;


[Serializable]
public class SlantDirection {

  [SerializeField]
  [Range(0f, 90f)]
  [Tooltip("斜め移動の角度（単位：度数法）")]
  float _angle = 30f;

  Vector2 GetDirection() {
    var x = Mathf.Cos(_angle * Mathf.Deg2Rad);
    var y = Mathf.Sin(_angle * Mathf.Deg2Rad);
    return (new Vector2(x, y)).normalized;
  }

  public Vector2 topLeft {
    get {
      var v = GetDirection();
      v.x *= -1;
      return v;
    }
  }

  public Vector2 topRight {
    get { return GetDirection(); }
  }

  public Vector2 bottomLeft {
    get { return GetDirection() * -1; }
  }

  public Vector2 bottomRight {
    get {
      var v = GetDirection();
      v.y *= -1;
      return v;
    }
  }
}


public class PlayerMove : MonoBehaviour {

  [SerializeField]
  [Range(1f, 10f)]
  float _velocity = 3f;

  [SerializeField]
  [Tooltip("斜め移動の方向ベクトルを設定")]
  SlantDirection _direction = null;

  Rigidbody2D _ownRigid = null;


  void Start() {
    _ownRigid = GetComponent<Rigidbody2D>();

    Debug.Log(_direction.topLeft);
    Debug.Log(_direction.topRight);
    Debug.Log(_direction.bottomLeft);
    Debug.Log(_direction.bottomRight);
  }

  void Update() {
    if (TouchController.IsTouchBegan()) { Translate(); }
  }

  void Translate() {
    _ownRigid.velocity = Vector2.zero;

    var touchPos = TouchController.GetTouchWorldPositionFromCamera();
    var distance = touchPos - transform.position;
    if (distance.magnitude < 1f) { return; }

    var direction = distance.normalized * _velocity;
    _ownRigid.AddForce(direction, ForceMode2D.Impulse);
  }
}
