
using UnityEngine;


// TODO: タッチ判定の修正
//     : UI（ボタン）などにタッチした時は移動しないようにする

public class PlayerMove : MonoBehaviour {

  [SerializeField]
  [Range(1f, 10f)]
  float _velocity = 3f;

  [SerializeField]
  float _colliderRadius = 0.5f;

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

    var touchPos_ = TouchController.GetTouchWorldPositionXZ();
    if (touchPos_.magnitude < _colliderRadius) { return; }

    _direction = touchPos_.normalized * _velocity;
    _ownRigid.AddForce(_direction, ForceMode.Impulse);
  }

  // TODO: 削除予定
  public void OnCollisionEnter(Collision collision) {
    if (_ownRigid.velocity.magnitude == 0f) { return; }

    var normal_ = _ownRigid.velocity.normalized;
    var dot_ = Vector3.Dot(_direction.normalized, normal_);
    var radian_ = Mathf.Cos(Mathf.PI / 4f);

    _ownRigid.velocity = dot_ < radian_ ? Vector3.zero : normal_ * _velocity;
  }
}
