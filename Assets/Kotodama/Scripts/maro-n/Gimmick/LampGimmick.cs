
/*
using UnityEngine;


public class LampGimmick : MonoBehaviour {

  [SerializeField]
  GameObject _lampEffect;

  private bool _clearFlag;
  private bool _onEffect = false;

  void LampsInFire() {
    if (!_onEffect) {
      _clearFlag = GetComponent<TouchGimmick>()._isClear;

      if (_clearFlag) {
        _onEffect = true;

        var lampEffect_ = Instantiate(_lampEffect);
        lampEffect_.transform.parent = transform;
        lampEffect_.transform.position = gameObject.transform.position;
      }
    }
  }

  void Update() {
    LampsInFire();
  }
}
*/
