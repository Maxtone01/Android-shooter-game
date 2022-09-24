using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<TgridObject>
{
    public const int sortingOrderDefault = 5000;
    private int _width;
    private int _height;
    private float cellSize;
    private Vector3 _originPosition;
    private TgridObject[,] _gridArray;
    private TextMesh[,] _debugTextArray;

    public EventHandler<OnGridObjectChangedEventArgs> onGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    public Grid(LayerMask unwalkableMask, int width, int height, float cellSize, Vector2 originPosition, Func<Grid<TgridObject>, int, int, bool, TgridObject> createGridObject)
    {
        this._width = width;
        this._height = height;
        this.cellSize = cellSize;
        this._originPosition = originPosition;

        _gridArray = new TgridObject[_width, _height];

        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                bool _walkable = (Physics2D.OverlapCircle(GetNodePosition(x, y), cellSize, unwalkableMask) == null);
                _gridArray[x, y] = createGridObject(this, x, y, _walkable);
            }
        }

        bool showDebug = true;
        if (showDebug)
        {
            TextMesh[,] _debugTextArray = new TextMesh[width, height];
            for (int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < _gridArray.GetLength(1); y++)
                {
                    Debug.DrawLine(GetNodePosition(x, y), GetNodePosition(x, y + 1), Color.blue, 100f);
                    Debug.DrawLine(GetNodePosition(x, y), GetNodePosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetNodePosition(0, height), GetNodePosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetNodePosition(width, 0), GetNodePosition(width, height), Color.white, 100f);

            onGridObjectChanged += (object sender, OnGridObjectChangedEventArgs eventArgs) =>
            {
                _debugTextArray[eventArgs.x, eventArgs.y].text = _gridArray[eventArgs.x, eventArgs.y]?.ToString();
            };
        }
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public int GetWidth()
    { 
        return _width;
    }

    public int GetHeight()
    {
        return _height;
    }

    public Vector3 GetNodePosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + _originPosition;
    }

    public void SetGridObject(int x, int y, TgridObject value)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            _gridArray[x, y] = value;
        }
        onGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, y = y });

        _debugTextArray[x, y].text = _gridArray[x, y]?.ToString();
    }

    public void OnTriggerGridChanged(int x, int y)
    {
        onGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }

    public void SetGridObject(Vector3 worldPosition, TgridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }

    public TgridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            return _gridArray[x, y];
        }
        else
        {
            return default(TgridObject);
        }
    }

    public TgridObject GetGridObject(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetGridObject(x, y);
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition  - _originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - _originPosition).y / cellSize);
    }

    // Create Text in the World
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 2, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    // Create Text in the World
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}
