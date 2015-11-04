
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  [SerializeField]
  [Range(1f, 10f)]
  float _velocity = 3f;

  [SerializeField]
  float _radius = 0.5f;

  Vector3 _direction = Vector3.zero;
  Rigidbody _ownRigid = null;


  void Start() {
    _ownRigid = GetComponent<Rigidbody>();
    CameraMove.target = transform;
  }

  void Update() {
    if (TouchController.IsTouchBegan()) { MoveStart(); }
  }

  void MoveStart() {
    _ownRigid.velocity = Vector3.zero;

    var touchPos = TouchController.GetTouchWorldPositionFromCameraXZ();
    var distance = touchPos - transform.position;
    distance.y = 0f;

    if (distance.magnitude < _radius) { return; }

    _direction = distance.normalized * _velocity;
    _ownRigid.velocity = _direction;
  }

  public void OnCollisionEnter(Collision collision) {
    if (_ownRigid.velocity.magnitude == 0f) { return; }

    var normal = _ownRigid.velocity.normalized;
    var dot = Vector3.Dot(_direction.normalized, normal);
    var radian = Mathf.Cos(Mathf.PI / 4f);

    _ownRigid.velocity = dot < radian ? Vector3.zero : normal * _velocity;
  }
}
