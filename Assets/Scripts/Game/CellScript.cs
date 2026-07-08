using UnityEngine;

public class CellScript : MonoBehaviour {
  public int index;

  public void SetIndex(int _index) {
    index = _index;
  }

  void OnMouseDown() {
    GetComponentInParent<BoardView>().OnMouseDownOnCell(index);
  }
}
