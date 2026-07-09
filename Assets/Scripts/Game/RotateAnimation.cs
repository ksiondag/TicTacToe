using UnityEngine;

public class RotateAnimation : MonoBehaviour {
  public float rotation = 0f;
  public float targetRotation = 0f;
  public float speed = 100f;
  
  public void SetTargetRotation(float _targetRotate) {
    targetRotation = _targetRotate;
  }

  void Update() {
    if (rotation != targetRotation) {
      rotation += Time.deltaTime * speed;
      if (rotation > targetRotation) {
        rotation = targetRotation;
      }
      transform.rotation = Quaternion.Euler(0f, rotation, 0f);
    }
  }
}
