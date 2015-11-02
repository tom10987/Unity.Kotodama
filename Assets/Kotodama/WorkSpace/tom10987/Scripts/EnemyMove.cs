
using UnityEngine;


public class EnemyMove : MonoBehaviour {

  [SerializeField]
  Transform _target = null;
  NavMeshAgent _agent = null;


  void Start() {
    _agent = GetComponent<NavMeshAgent>();
  }

  void Update() {
    _agent.SetDestination(_target.position);
  }
}
