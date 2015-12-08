
using UnityEngine;


public class GimmickTrigger : MonoBehaviour {

  [SerializeField]
  GameObject Pre;

  void Awake() {

  }

  void Start() {
    //Pre = null;
  }

  void Update() {

  }


  void OnTriggerStay(Collider col) {
    if (col.gameObject.tag == "Player") {
      if (Application.isEditor) {
        if (Input.GetMouseButtonDown(1)) {
          RaycastHit hit;
          if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            if (hit.transform.gameObject.tag != "Player") {
              //var obj = GameObject.Instantiate(Pre) as GameObject;
            }
          }
        }
      }
      else {

      }
    }


  }
}
