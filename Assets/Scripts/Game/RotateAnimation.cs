using UnityEngine;

public class RotateAnimation : MonoBehaviour {
  public float rotation = 0f;
  public float targetRotation = 0f;
  public float speed = 100f;
  
  public void SetTargetRotation(float _targetRotation) {
    if (_targetRotation < 0) {
      speed = -Mathf.Abs(speed);
    }
    targetRotation = _targetRotation;
  }

  void Update() {
    if (rotation != targetRotation) {
      rotation += Time.deltaTime * speed;
      if (speed > 0 && rotation > targetRotation || speed < 0 && rotation < targetRotation) {
        rotation = targetRotation;
      }
      transform.rotation = Quaternion.Euler(0f, (rotation + 360f) % 360f, 0f);
    }
  }
}
