using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private Texture2D jigsawTexture;
    [SerializeField] private int difficulty = 4;
    [SerializeField] private Transform gameHolder;
    [SerializeField] private Transform piecePrefab;
    private List<Transform> pieces;
    private Vector2Int dimensions;
    private float width;
    private float height;
    private RayCast rayCastScript;
    public bool puzzleTime = false;
    private Transform draggingPiece = null;
    private Vector3 offset;
    private int piecesCorrect;

    // Start is called before the first frame update
    void Start()
    {
        puzzle.SetActive(false);
        rayCastScript = FindObjectOfType<RayCast>();
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleTime = true;
        //we store a list of the transform for jigsaw piece so we can track them later
        pieces = new List<Transform>();
        //calculate the size of each jigsaw piece, based on a difficulty setting
        dimensions = GetDimensions(jigsawTexture, difficulty);
        //create the pieces of the correct size with the correct texture
        CreateJigsawPieces(jigsawTexture);
        //place pieces randomly into the visible area
        Scatter();
        //makes it so the character doesnt move around once the puzzle appears
        rayCastScript.canMove = false;
        //update the border to fit the chosen puzzle
        UpdateBorder();

        //as we're starting the puzzle there will be no correct pieces
        piecesCorrect = 0;
    }

    Vector2Int GetDimensions(Texture2D puzzle, int difficulty)
    {
        Vector2Int dimensions = new Vector2Int(0, 0);
        if(puzzle.width < puzzle.height)
        {
            dimensions.x = difficulty;
            dimensions.y = (difficulty * puzzle.height) / puzzle.width;
        }
        else
        {
            dimensions.x = (difficulty * puzzle.width) / puzzle.height;
            dimensions.y = difficulty;
        }
        return dimensions;
    }

    void CreateJigsawPieces(Texture2D jigsawTexture)
    {
        //calculate piece sizes based on the dimensions
        height = 1f / dimensions.y;
        float aspect = (float)jigsawTexture.width / jigsawTexture.height;
        width = aspect / dimensions.x;

        for (int row = 0; row < dimensions.y; row++)
        {
            for (int col = 0; col < dimensions.x; col++)
            {
                //create the piece in the right location of the right size
                Transform piece = Instantiate(piecePrefab, gameHolder);
                piece.localPosition = new Vector3((-width * dimensions.x / 2) + (width * col) + (width / 2), (-height * dimensions.y / 2) + (height * row) + (height / 2)-1);
                piece.localScale = new Vector3(width, height, 1f);

                //no need to name but useful for debugging
                piece.name = $"Piece {(row * dimensions.x) + col}";
                pieces.Add(piece);

                //assign the correct part of the texture for this jigsaw puzzle
                //we need our width and height both to be normalised between 0 and 1 for the UV
                float width1 = 1f / dimensions.x;
                float height1 = 1f / dimensions.y;
                //UV coord order in anti-clockwise: (0, 0), (1, 0), (0, 1), (1, 1)
                Vector2[] uv = new Vector2[4];
                uv[0] = new Vector2(width1 * col, height1 * row);
                uv[1] = new Vector2(width1 * (col + 1), height1 * row);
                uv[2] = new Vector2(width1 * col, height1 * (row + 1));
                uv[3] = new Vector2(width1 * (col + 1), height1 * (row + 1));
                //assign our new UVs to the mesh
                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                mesh.uv = uv;
                //update the texture on the piece
                piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", jigsawTexture);
            }
    }   }

    //place the pieces randomly in the visible area
    private void Scatter()
    {
        //calculate the visible orthographic size of the screen
        float orthoHeight = Camera.main.orthographicSize;
        float screenAspect = (float)Screen.width / Screen.height;
        float orthoWidth = (screenAspect * orthoHeight);
        //ensure pieces are away from the edges of the screen
        float pieceWidth = width * gameHolder.localScale.x;
        float pieceHeight = height * gameHolder.localScale.y;

        orthoHeight -= pieceHeight;
        orthoWidth -= pieceWidth;

        //place each piece randomly in the visible area
        foreach (Transform piece in pieces)
        {
            float x = Random.Range(-orthoWidth, orthoWidth);
            float y = Random.Range(-orthoHeight, orthoHeight);
            piece.position = new Vector3(x, y, -1);
        }
    }
    //update the border to fit the chosen puzzle
    private void UpdateBorder()
    {
        LineRenderer lineRenderer = gameHolder.GetComponent<LineRenderer>();

        //calculate half sizes to simplify the code
        float halfWidth = (width * dimensions.x) / 2f;
        float halfHeight = (height * dimensions.y) / 2f;

        //we want the border to be behind the pieces
        float borderZ = 0f;

        //set border vertices, starting top left, going clockwise
        lineRenderer.SetPosition(0, new Vector3(-halfWidth, halfHeight, borderZ));
        lineRenderer.SetPosition(1, new Vector3(halfWidth, halfHeight, borderZ));
        lineRenderer.SetPosition(2, new Vector3(halfWidth, -halfHeight, borderZ));
        lineRenderer.SetPosition(3, new Vector3(-halfWidth, -halfHeight, borderZ));

        //set the thickness of the border line
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        //show the border line
        lineRenderer.enabled = true;
    }

    public void Update()
    {
        if (puzzleTime == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    //everything is moveable, so we dont need to check its a piece
                    draggingPiece = hit.transform;
                    offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    offset += Vector3.back;
                }
            }

            //when we release the mouse button stop dragging
            if (draggingPiece && Input.GetMouseButtonUp(0))
            {
                SnapAndDisableIfCorrect();
                draggingPiece.position += Vector3.forward;
                draggingPiece = null;
            }

            if (draggingPiece)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newPosition += offset;
                draggingPiece.position = newPosition;
            }
        }
    }

    private void SnapAndDisableIfCorrect()
    {
        //we need to know the index of the piece to determine its correct position
        int pieceIndex = pieces.IndexOf(draggingPiece);

        //the coordinates of the piece in the puzzle
        int col = pieceIndex % dimensions.x;
        int row = pieceIndex / dimensions.y;

        //the target position in the non-scaled coordinates
        Vector2 targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2), (-height * dimensions.y / 2) + (height * row) + (height / 2));

        //check if we're in the correct location
        if (Vector2.Distance(draggingPiece.localPosition, targetPosition) < (width / 2))
        {
            //snap to our destination
            draggingPiece.localPosition = targetPosition;

            //disable the collider so we cant click on the object anymore
            draggingPiece.GetComponent<BoxCollider>().enabled = false;

            //increases the number of correct pieces, and check for puzzle completion
            piecesCorrect++;
            if (piecesCorrect == pieces.Count)
            {
                StartCoroutine(PuzzleDone());
                SceneManager.LoadScene(4);
            }
        }
    }

    IEnumerator PuzzleDone()
    {
        yield return new WaitForSeconds(3);
    }
}

