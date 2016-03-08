
using UnityEngine;


public class PublicPhoneEvent : MonoBehaviour {

  [SerializeField]
  RootManager[] _rootObjects = null;

  [SerializeField]
  GameObject _amulet = null;

  bool _eventStart = false;


  void Update() {
    if (DialButton.IsInputSuccess == true && _eventStart == false) {
      //AwakeEnemy();
      _eventStart = true;
      _amulet.SetActive(true);
    }
  }

  void AwakeEnemy() {
    foreach (var root in _rootObjects) {
      EnemyManager.instance.CreateEnemy(root.spots);
    }
  }
}
