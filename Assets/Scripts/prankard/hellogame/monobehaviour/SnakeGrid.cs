using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class SnakeGrid : MonoBehaviour {

	private const float SCALE_TIME = 2f;

	public event Action ON_TRANSITION_IN;
	public event Action ON_TRANSITION_OUT;

	public int SizeX
	{
		get
		{
			return _sizeX;
		}
	}

	public int SizeY
	{
		get
		{
			return _sizeY;
		}
	}
	public int CellSizeX
	{
		get
		{
			return _cellSizeX;
		}
	}

	public int CellSizeY
	{
		get
		{
			return _cellSizeY;
		}
	}

	[SerializeField] private GameObject gridPiecePrefab;
	[SerializeField] private int _sizeX = 23;
	[SerializeField] private int _sizeY = 13;
	[SerializeField] private int _cellSizeX = 1;
	[SerializeField] private int _cellSizeY = 1;

	private GameObject[][] grid;

	void Start ()
	{
		CreateGrid();
	}

	private void CreateGrid()
	{
		grid = new GameObject[_sizeX][];
		for (int x = 0; x < _sizeX; x++)
		{
			grid[x] = new GameObject[_sizeY];
			for (int y = 0; y < _sizeY; y++)
			{
				GameObject go = GameObject.Instantiate(gridPiecePrefab);
				go.transform.position = new Vector3(_cellSizeX * x, _cellSizeY * y, 0);
				grid[x][y] = go;
				go.transform.SetParent(transform);
			}
		}
	}

	public void TransitionIn()
	{
		float hTime = SCALE_TIME / 2;
		for (int x = 0; x < _sizeX; x++)
		{
			for (int y = 0; y < _sizeY; y++)
			{
				Tweener tween = grid[x][y].transform.DOScale(Vector3.zero, 1f).From().SetDelay(x / (float)_sizeX * hTime + y / (float)_sizeY * hTime).SetEase(Ease.OutBack);
				if (x == _sizeX - 1 && y == _sizeY - 1)
					tween.OnComplete(FireOnTransitionIn);
			}
		}
	}

	public void TransitionOut()
	{
		float hTime = SCALE_TIME / 2;
		for (int x = 0; x < _sizeX; x++)
		{
			for (int y = 0; y < _sizeY; y++)
			{
				Tweener tween = grid[x][y].transform.DOScale(Vector3.zero, 1f).SetDelay(SCALE_TIME - (x / (float)_sizeX * hTime + y / (float)_sizeY * hTime)).SetEase(Ease.OutBack);
				if (x == 0 && y == 0)
					tween.OnComplete(FireOnTransitionOut);
			}
		}
	}

	private void FireOnTransitionIn()
	{
		if (ON_TRANSITION_IN != null)
			ON_TRANSITION_IN();
	}

	private void FireOnTransitionOut()
	{
		if (ON_TRANSITION_OUT != null)
			ON_TRANSITION_OUT();
	}

	public void Pulse(int gridX, int gridY)
	{
		float fadeTime = 0.2f;
		float delayTime = 0.8f;
		float hFadeTime = fadeTime * 0.5f;
		for (int x = 0; x < _sizeX; x++)
		{
			if (x == gridX)
				continue;
			float percentToCenter = Mathf.Abs(x - gridX) / (float)_sizeX;
			grid[x][gridY].GetComponent<Renderer>().material.DOColor(Color.cyan, hFadeTime).SetLoops(2, LoopType.Yoyo).SetDelay(percentToCenter * delayTime);
		}
		for (int y = 0; y < _sizeY; y++)
		{
			float percentToCenter = Mathf.Abs(y - gridY) / (float)_sizeY;
			grid[gridX][y].GetComponent<Renderer>().material.DOColor(Color.cyan, hFadeTime).SetLoops(2, LoopType.Yoyo).SetDelay(percentToCenter * delayTime);
		}
	}

	public Vector2 PositionToGrid(Vector3 position)
	{
		return new Vector2(Mathf.RoundToInt(position.x / CellSizeX), Mathf.RoundToInt(position.y / CellSizeY));
	}

	public Vector3 GridToPosition(Vector2 gridPosition) { return GridToPosition((int)gridPosition.x, (int)gridPosition.y); }
	public Vector3 GridToPosition(int x, int y)
	{
		return new Vector3(x * CellSizeX, y * CellSizeY);
	}

	public void LoopGrid(ref Vector2 gridPosition)
	{
		gridPosition.x = Mathf.Repeat(gridPosition.x, SizeX);
		gridPosition.y = Mathf.Repeat(gridPosition.y, SizeY);
	}
}
