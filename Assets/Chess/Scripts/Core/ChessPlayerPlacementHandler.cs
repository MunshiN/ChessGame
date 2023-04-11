using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;
        private bool _isSelected;
        

        private void Start() {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            
        }

        private void OnMouseDown()
        {
            if (gameObject.name == "Pawn")
            {
                Debug.Log("Clicked");
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                // Get the row and column of the current pawn
                //transform.position = ChessBoardPlacementHandler.Instance.GetTile(i, j).transform.position;



                
                Debug.Log(row);
                Debug.Log(column);

                // Highlight the tile at row+1 and col
                var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(row + 1, column);
                if (tileToHighlight != null)
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row + 1, column);
                }

            }
            if (gameObject.name == "Knight")
            {
                Debug.Log("Clicked");

                // Clear the highlight from the previously selected pawn
                ChessBoardPlacementHandler.Instance.ClearHighlights();

                // Get the row and column of the current knight
                
                Debug.Log(column);
                Debug.Log(row);

                // Calculate possible moves for the knight
                List<Vector2Int> possibleMoves = new List<Vector2Int>();
                possibleMoves.Add(new Vector2Int(row + 2, column + 1));
                possibleMoves.Add(new Vector2Int(row + 2, column - 1));
                possibleMoves.Add(new Vector2Int(row - 2, column + 1));
                possibleMoves.Add(new Vector2Int(row - 2, column - 1));
                possibleMoves.Add(new Vector2Int(row + 1, column + 2));
                possibleMoves.Add(new Vector2Int(row + 1, column - 2));
                possibleMoves.Add(new Vector2Int(row - 1, column + 2));
                possibleMoves.Add(new Vector2Int(row - 1, column - 2));

                // Highlight the possible moves on the chessboard
                foreach (Vector2Int move in possibleMoves)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(move.x, move.y);
                    if (tileToHighlight != null)
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
                        if (gameObject.name == "Pawn")
                        {
                            ChessBoardPlacementHandler.Instance.ClearHighlights();
                        }
                    }
                    
                }

                
            }
            if (gameObject.name == "Rook")
            {

                ChessBoardPlacementHandler.Instance.ClearHighlights();

                // Highlight all tiles in the same row
                for (int col = 0; col < 8; col++)
                    {
                        if (col != column)
                        {
                            var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(row, col);
                            if (tileToHighlight != null)
                            {
                                ChessBoardPlacementHandler.Instance.Highlight(row, col);
                            }
                        }
                    }

                    // Highlight all tiles in the same column
                    for (int rows = 0; rows < 8; rows++)
                    {
                        if (rows != row)
                        {
                            var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(row, column);
                            if (tileToHighlight != null)
                            {
                                ChessBoardPlacementHandler.Instance.Highlight(rows, column);
                            }
                        }
                    }
                

            }
            if (gameObject.name == "Bishop")
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                // Get the row and column of the current bishop
                // Highlight valid moves for a bishop
                for (int rows = row + 1, col = column + 1; rows < 8 && col < 8; rows++, col++)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(row, col);
                    if (tileToHighlight != null)
                    {
                            ChessBoardPlacementHandler.Instance.Highlight(rows, col);
                        
                        
                    }
                }

                for (int rows = row + 1, col = column - 1; rows < 8 && col >= 0; rows++, col--)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(rows, col);
                    if (tileToHighlight != null)
                    {
                        
                            ChessBoardPlacementHandler.Instance.Highlight(rows, col);
                        
                        
                    }
                }

                for (int rows = row - 1, col = column + 1; rows >= 0 && col < 8; rows--, col++)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(rows, col);
                    if (tileToHighlight != null)
                    {
                        
                            ChessBoardPlacementHandler.Instance.Highlight(rows, col);
                        
                        
                    }
                }

                for (int rows = row - 1, col = column - 1; rows >= 0 && col >= 0; rows--, col--)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(rows, col);
                    if (tileToHighlight != null)
                    {
                          ChessBoardPlacementHandler.Instance.Highlight(rows, col);
                        
                    }
                }
            }

            if (gameObject.name == "Queen")
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                // Get the row and column of the current bishop
                // Highlight valid moves for a bishop

                for (int col = 0; col < 8; col++)
                {
                    if (col != column)
                    {
                        var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(row, col);
                        if (tileToHighlight != null)
                        {
                            ChessBoardPlacementHandler.Instance.Highlight(row, col);
                        }
                    }
                }

                // Highlight all tiles in the same column
                for (int rows = 0; rows < 8; rows++)
                {
                    if (rows != row)
                    {
                        var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(row, column);
                        if (tileToHighlight != null)
                        {
                            ChessBoardPlacementHandler.Instance.Highlight(rows, column);
                        }
                    }
                }

                for (int rows = row + 1, col = column + 1; rows < 8 && col < 8; rows++, col++)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(row, col);
                    if (tileToHighlight != null)
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(rows, col);


                    }
                }

                for (int rows = row + 1, col = column - 1; rows < 8 && col >= 0; rows++, col--)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(rows, col);
                    if (tileToHighlight != null)
                    {

                        ChessBoardPlacementHandler.Instance.Highlight(rows, col);


                    }
                }

                for (int rows = row - 1, col = column + 1; rows >= 0 && col < 8; rows--, col++)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(rows, col);
                    if (tileToHighlight != null)
                    {

                        ChessBoardPlacementHandler.Instance.Highlight(rows, col);


                    }
                }

                for (int rows = row - 1, col = column - 1; rows >= 0 && col >= 0; rows--, col--)
                {
                    var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(rows, col);
                    if (tileToHighlight != null)
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(rows, col);

                    }
                }
            }

            if (gameObject.name == "King")
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                int[] xOffset = { 1, 1, 0, -1, -1, -1, 0, 1 };
                int[] yOffset = { 0, 1, 1, 1, 0, -1, -1, -1 };

                for (int i = 0; i < 8; i++)
                {
                    int newRow = row + yOffset[i];
                    int newCol = column + xOffset[i];
                    if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                    {
                        var tileToHighlight = ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol);
                        if (tileToHighlight != null)
                        {
                            ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol);
                        }
                    }
                }
            }
        }

            private void OnMouseEnter()
        {
            if (!_isSelected && gameObject.name == "Pawn")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale *= 1.2f;
                _isSelected = true;

            }if (!_isSelected && gameObject.name == "Rook")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale *= 1.2f;
                _isSelected = true;

            }if (!_isSelected && gameObject.name == "Bishop")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale *= 1.2f;
                _isSelected = true;

            }if (!_isSelected && gameObject.name == "Knight")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale *= 1.2f;
                _isSelected = true;

            }if (!_isSelected && gameObject.name == "Queen")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale *= 1.2f;
                _isSelected = true;

            }if (!_isSelected && gameObject.name == "King")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale *= 1.2f;
                _isSelected = true;

            }
        }

        private void OnMouseExit()
        {
            if (_isSelected && gameObject.name == "Pawn")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale /= 1.2f;
                _isSelected = false;

            }if (_isSelected && gameObject.name == "Knight")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale /= 1.2f;
                _isSelected = false;

            }if (_isSelected && gameObject.name == "Rook")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale /= 1.2f;
                _isSelected = false;

            }if (_isSelected && gameObject.name == "Bishop")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale /= 1.2f;
                _isSelected = false;

            }if (_isSelected && gameObject.name == "King")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale /= 1.2f;
                _isSelected = false;

            }if (_isSelected && gameObject.name == "Queen")
            {
                //var tile = ChessBoardPlacementHandler.Instance.GetTile(i,j);

                transform.localScale /= 1.2f;
                _isSelected = false;

            }
        }
    }
}