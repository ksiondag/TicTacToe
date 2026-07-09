using UnityEngine;

public class RotateAnimation : MonoBehaviour {
  public float rotation = 0f;
  public float speed = 100f;

  void Update() {
    rotation += Time.deltaTime * speed;
    transform.rotation = Quaternion.Euler(0f, rotation, 0f);
  }
}
