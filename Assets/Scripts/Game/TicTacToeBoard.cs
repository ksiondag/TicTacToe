using UnityEngine;

public class TicTacToeBoard {
  // 0 = empty, 1 = P0, 2 = P1
  public int[] cells = new int[9];
  public int activePlayer = 0;
  public bool terminal = false;
  // -1 none, 0/1 player, 2 draw
  public int winner = -1;

  static readonly int[][] WinLines = new int[][] {
    new int[] {0,1,2},
    new int[] {3,4,5},
    new int[] {6,7,8},
    new int[] {0,3,6},
    new int[] {1,4,7},
    new int[] {2,5,8},
    new int[] {0,4,8},
    new int[] {2,4,6}
  };

  public bool IsLegal(int index) {
    return cells[index] == 0 && !terminal;
  }

  public void ApplyMove(int index) {
    if (!IsLegal(index)) {
      return;
    }
    int mark = activePlayer + 1;
    cells[index] = mark;
    activePlayer = (activePlayer + 1) % 2;
    return;
  }

  public void CheckEnd() {
    for (int i = 0; i < WinLines.Length; i++) {
      int[] winLine = WinLines[i];
      int[] cellLine = new int[] {
        cells[winLine[0]],
        cells[winLine[1]],
        cells[winLine[2]],
      };

      if (cellLine[0] != 0 && cellLine[0] == cellLine[1] && cellLine[0] == cellLine[2]) {
        terminal = true;
        winner = cellLine[0] - 1;
        return;
      }
    }

    // Check for zeroes
    for (int i = 0; i < cells.Length; i++) {
      if (cells[i] == 0) {
        return;
      }
    }

    // No zeroes, cat's game
    terminal = true;
    winner = 2;
    return;
  }

  public void Reset() {
    cells = new int[9] {
      0, 0, 0,
      0, 0, 0,
      0, 0, 0
    };
    activePlayer = 0;
    terminal = false;
    winner = -1;
  }
}
