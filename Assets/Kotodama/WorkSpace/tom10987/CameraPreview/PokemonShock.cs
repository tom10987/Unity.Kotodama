
using UnityEngine;


public class PokemonShock : MonoBehaviour {

  Transform _player = null;
  Light _light = null;
  float _time = 0f;


  void Start() {
    _player = GameObject.Find("Player").transform;
    _light = GetComponent<Light>();
  }

  void Update() {
    transform.position = _player.position;
    _time += Time.deltaTime * 2f;
    //_light.color = new Color(Mathf.Sin(_time) * 0.25f + 0.5f, 0f, 1f);
  }
}
