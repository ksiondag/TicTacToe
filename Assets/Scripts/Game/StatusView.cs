using UnityEngine;

public class StatusView : MonoBehaviour {
  public void SetStatusRotation(bool terminal, int winner) {
    if (!terminal) {
      transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    } else {
      if (winner == 0) {
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
      } else if (winner == 1) {
        transform.rotation = Quaternion.Euler(180f, 0f, 0f);
      } else {
        transform.rotation = Quaternion.Euler(270f, 0f, 0f);
      }
    }
  }
}
