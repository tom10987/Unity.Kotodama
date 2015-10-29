
using UnityEngine;
using System;
using System.Collections.Generic;


[Serializable]
public class SlantDirection {

  [SerializeField]
  [Range(0f, 90f)]
  [Tooltip("斜め移動の角度（単位：度数法）")]
  float _angle = 30f;

  // 度数法の値をラジアン値に変換した上で、
  // 方向の基準となる単位ベクトルを返す
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


public class PlayerVector {

  public enum Direction {
    TopLeft,
    Top,
    TopRight,
    Right,
    BottomRight,
    Bottom,
    BottomLeft,
    Left,
  }

  static Dictionary<Direction, Vector3> _direction = null;
  static public Dictionary<Direction, Vector3> direction { get { return _direction; } }

  static public void Init() {
    _direction = new Dictionary<Direction, Vector3>();

    _direction.Add(Direction.TopLeft, new Vector3(-1f, 1f, 0f).normalized);
    _direction.Add(Direction.Top, Vector3.up);
    _direction.Add(Direction.TopRight, new Vector3(1f, 1f, 0f).normalized);
    _direction.Add(Direction.Right, Vector3.right);
    _direction.Add(Direction.BottomRight, new Vector3(1f, -1f, 0f).normalized);
    _direction.Add(Direction.Bottom, Vector3.down);
    _direction.Add(Direction.BottomLeft, new Vector3(-1f, -1f, 0f).normalized);
    _direction.Add(Direction.Left, Vector3.left);
  }

  static public void GetDirection() {
  }
}


public class PlayerMove : MonoBehaviour {

  [SerializeField]
  [Range(1f, 10f)]
  float _velocity = 3f;

  [SerializeField]
  [Tooltip("斜め移動の方向ベクトルを設定")]
  SlantDirection _slant = null;

  Vector2 _direction = Vector2.zero;
  Rigidbody2D _ownRigid = null;
  CircleCollider2D _collider = null;


  void Start() {
    _ownRigid = GetComponent<Rigidbody2D>();
    _collider = GetComponent<CircleCollider2D>();
  }

  void Update() {
    if (TouchController.IsTouchBegan()) { Translate_(); }
  }

  void Translate() {
    var touchPos = TouchController.GetTouchWorldPositionFromCamera();
  }
    
  void Translate_() {
    var touchPos = TouchController.GetTouchWorldPositionFromCamera();
    var distance = touchPos - transform.position;

    var isStop = (distance.magnitude < _collider.radius);
    var speed = distance.normalized * _velocity;
    _direction = isStop ? Vector3.zero : speed;
    _ownRigid.velocity = _direction;
  }
}
