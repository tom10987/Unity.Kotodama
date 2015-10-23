
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  [SerializeField]
  [Range(1f, 10f)]
  float _Velocity = 3f;

  Rigidbody2D _ownRigid = null;


  void Start() {
    _ownRigid = GetComponent<Rigidbody2D>();
  }

  void Update() {
    if (!IsMoveAction()) { return; }
    Translate();
  }

  bool IsMoveAction() {
    var isPressMouse = Input.GetMouseButtonDown(0);
    var isTouching = TouchController.IsTouchBegan();
    return isPressMouse || isTouching;
  }

  void Translate() {
    var distance = Vector3.zero;
    _ownRigid.velocity = Vector2.zero;

    if (TouchController.IsSmartDevice) {
      var touchPos = TouchController.GetTouchWorldPosition();
      distance = touchPos - transform.position;
    }
    else {
      var mousePos = Input.mousePosition - ScreenInfo.center;
      var center = Camera.main.transform.position;
      center.z = 0f;

      var x = (mousePos.x / ScreenInfo.center.x) * ScreenInfo.aspect.x;
      var y = (mousePos.y / ScreenInfo.center.y) * ScreenInfo.aspect.y;
      distance = (new Vector3(x, y)) - transform.position + center;
    }

    _ownRigid.AddForce(distance.normalized * _Velocity, ForceMode2D.Impulse);
  }
}
