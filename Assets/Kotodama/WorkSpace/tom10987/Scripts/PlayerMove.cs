
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  [SerializeField]
  [Range(1f, 10f)]
  float _velocity = 3f;

  Rigidbody2D _ownRigid = null;


  void Start() {
    _ownRigid = GetComponent<Rigidbody2D>();
  }

  void Update() {
    if (TouchController.IsTouchBegan()) { Translate(); }
  }

  void Translate() {
    _ownRigid.velocity = Vector2.zero;
    var distance = TouchController.GetTouchWorldPosition() - transform.position;
    if (distance.magnitude < 1f) { return; }

    var direction = distance.normalized * _velocity;
    _ownRigid.AddForce(direction, ForceMode2D.Impulse);
  }
}
