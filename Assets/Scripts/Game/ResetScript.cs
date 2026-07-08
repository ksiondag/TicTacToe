using UnityEngine;

public class ResetScript : MonoBehaviour {
  void OnMouseDown() {
    GetComponentInParent<BoardView>().Reset();
  }
}
