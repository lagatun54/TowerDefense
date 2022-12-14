using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Vector2Int boardSize = new Vector2Int(11,11);

    [SerializeField]
    GameBoard board = default;

    [SerializeField]
    private Camera _camera;
    private Ray TouchRay => _camera.ScreenPointToRay(Input.mousePosition);


    [SerializeField]
	GameTileContentFactory tileContentFactory = default;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleTouch();
        } 
        else if (Input.GetMouseButtonDown(1))
        {
            HandleAlternativeTouch();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            board.ShowPaths = !board.ShowPaths;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            board.ShowGrid = !board.ShowGrid;
        }
    }

    void HandleTouch()
    {
        GameTile tile = board.GetTile(TouchRay);
        if (tile != null)
        {
            board.ToggleWall(tile);
        }
    }

    void HandleAlternativeTouch()
    {
        GameTile tile = board.GetTile(TouchRay);
        if (tile != null)
        {
            board.ToggleDestination(tile);
        }
    }
    void Awake() {
        board.Initialize(boardSize, tileContentFactory);
        board.ShowGrid = true;
    }
    public void OnValidate() {
        if (boardSize.x < 2)
        {
            boardSize.x = 2;
        }
        if (boardSize.y < 2)
        {
            boardSize.y = 2;
        }
    }
}
