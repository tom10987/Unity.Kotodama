
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  [SerializeField]
  [Range(1f, 10f)]
  float _velocity = 3f;

  Vector2 _direction = Vector2.zero;
  Rigidbody2D _ownRigid = null;
  CircleCollider2D _collider = null;


  void Start() {
    _ownRigid = GetComponent<Rigidbody2D>();
    _collider = GetComponent<CircleCollider2D>();
  }

  void Update() {
    if (TouchController.IsTouchBegan()) { MoveStart(); }
  }

  void MoveStart() {
    _ownRigid.velocity = Vector2.zero;

    var touchPos = TouchController.GetTouchWorldPositionFromCamera();
    var distance = touchPos - transform.position;

    if (distance.magnitude < _collider.radius) { return; }

    _direction = distance.normalized * _velocity;
    _ownRigid.velocity = _direction;
  }

  public void OnCollisionEnter2D(Collision2D collision) {
    if (_ownRigid.velocity.magnitude == 0f) { return; }

    var normal = _ownRigid.velocity.normalized;
    var dot = Vector2.Dot(_direction.normalized, normal);
    var radian = Mathf.Cos(Mathf.PI / 4f);

    _ownRigid.velocity = dot < radian ? Vector2.zero : normal * _velocity;
  }
}
