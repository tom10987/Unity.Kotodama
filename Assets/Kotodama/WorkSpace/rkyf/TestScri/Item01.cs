
using UnityEngine;


public class Item01 : MonoBehaviour {

  //ItemState itemState;

  //private GameObject View;

  void Start() {
    //View = GameObject.Find("ItemStateView");
    //itemState = View.GetComponent<ItemState>();
  }

  void Update() {

  }

  void OnTriggerEnter(Collider col) {
    if (col.gameObject.tag == "Player") {
      //itemState.GetKey(1);
      //itemState.Item2++;
      //ItemState.Item3++;

    }

    Destroy(this.gameObject);
  }
}
