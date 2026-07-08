using System.Collections.Generic;
using UnityEngine;

public class BoardView : MonoBehaviour {
  public TicTacToeBoard board = new TicTacToeBoard();
  public GameObject[] cellObjects = new GameObject[9];
  public GameObject turnObject;

  static readonly Dictionary<string, int> RowIndices = new Dictionary<string, int> {
    { "Top", 0 },
    { "Center", 1 },
    { "Bottom", 2 },
  };

  static readonly Dictionary<string, int> ColIndices = new Dictionary<string, int> {
    { "Left", 0 },
    { "Center", 1 },
    { "Right", 2 },
  };

  static readonly Dictionary<int, float> CellRotation = new Dictionary<int, float> {
    { 0, 0f },
    { 1, 270f },
    { 2, 90f },
  };

  static readonly Dictionary<int, float> TurnRotation = new Dictionary<int, float> {
    { 0, 270f },
    { 1, 90f },
  };

  void Awake() {
    foreach (Transform child in transform) {
      if (child.name == "Turn") {
        turnObject = child.gameObject;
      }
      // Names look like "Cube (Top Left)" -> row/col words map to a 0-8 grid index.
      int openParen = child.name.IndexOf('(');
      int closeParen = child.name.IndexOf(')');
      if (openParen < 0 || closeParen < 0) {
        continue;
      }

      string[] words = child.name.Substring(openParen + 1, closeParen - openParen - 1).Split(' ');
      if (words.Length != 2 || !RowIndices.TryGetValue(words[0], out int row) || !ColIndices.TryGetValue(words[1], out int col)) {
        continue;
      }

      int index = row * 3 + col;
      cellObjects[index] = child.gameObject;

      CellScript cellScript = child.gameObject.AddComponent<CellScript>();
      cellScript.SetIndex(index);
    }
    RenderBoard();
  }

  public void OnMouseDownOnCell(int index) {
    if (board.IsLegal(index)) {
      board.ApplyMove(index);
      board.CheckEnd();
      RenderBoard();
    }
  }

  void RenderBoard() {
    // Set rotation of each cube based on its value in TicTacToeBoard
    foreach (GameObject cellObject in cellObjects) {
      CellScript cellScript = cellObject.GetComponent<CellScript>();
      int cellValue = board.cells[cellScript.index];
      float rotation = CellRotation[cellValue];
      cellObject.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
    }
    int player = board.activePlayer;
    float turnRotation = TurnRotation[player];
    turnObject.transform.rotation = Quaternion.Euler(0f, turnRotation, 0f);
  }
}
