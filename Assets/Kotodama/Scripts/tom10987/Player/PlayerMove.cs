
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  [SerializeField]
  LayerMask _mask;

  [SerializeField]
  NavMeshAgent _agent = null;

  void Update() {
    if (!TouchController.IsTouchBegan()) { return; }

    var touch = TouchController.GetTouchScreenPosition();
    var ray = Camera.main.ScreenPointToRay(touch);
    RaycastHit hit;
    if (!Physics.Raycast(ray, out hit, 100f, _mask.value)) { return; }
    if (hit.transform == null) { return; }

    _agent.SetDestination(hit.point);
  }
}
