using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using robotlegs.bender.platforms.unity.extensions.mediatorMap.impl;
using prankard.extensions.score.api;
using prankard.extensions.sound.api.view;
using prankard.extensions.sound.api.events;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace prankard.hellogame.view
{
	public class SnakeGame : EventView, ISetScoreView, ISoundView
	{
		[SerializeField] private GameObject snakePiecePrefab;
		[SerializeField] private GameObject collectItemPrefab;
		[SerializeField] private SnakeGrid _snakeGrid;
		[SerializeField] private float _speed = 1;

		private float _timeSinceLastMove = 0;
		private Vector2 _direction = new Vector2(1, 0);
		private List<GameObject> snake = new List<GameObject>();
		private GameObject item;
		private GameState _state = GameState.STARTING;
		private Vector2 _snakeDirection;

		private enum GameState 
		{
			STARTING,
			IN_GAME,
			GAME_OVER
		}


		protected override void Start ()
		{
			_snakeDirection = _direction;
			Vector2 headPosition = new Vector2(5, 5);
			Vector2 tailDirection = Vector2.left;
			int startSegments = 5;
			for (int i = 0; i < startSegments; i++)
			{
				AddPiece((int)headPosition.x, (int)headPosition.y);
				headPosition += tailDirection;
				snake[i].transform.DOScale(Vector3.zero, 2f).From();
			}
			AddCollectionItem(GetRandomLocation());
			item.transform.DOScale(Vector3.zero, 2f).From();

			_snakeGrid.ON_TRANSITION_IN += StartGame;
			_snakeGrid.TransitionIn();
			base.Start ();
		}

		private void StartGame()
		{
			_state = GameState.IN_GAME;
		}

		private void AddPiece(int x, int y)
		{
			GameObject piece = Instantiate(snakePiecePrefab);
			piece.transform.parent = transform;
			piece.transform.localPosition = _snakeGrid.GridToPosition(x, y);
			snake.Add(piece);
		}

		private void AddCollectionItem(Vector2 gridPosition) { AddCollectionItem((int)gridPosition.x, (int)gridPosition.y); }
		private void AddCollectionItem(int x, int y)
		{
			item = Instantiate(collectItemPrefab);
			item.transform.parent = transform;
			item.transform.localPosition = new Vector3(_snakeGrid.CellSizeX * x, + _snakeGrid.CellSizeY * y, item.transform.localPosition.z);
		}

		private void MovePieces()
		{
			int snakeLength = snake.Count;
			Vector2 endPieceGridLocation = _snakeGrid.PositionToGrid(snake[snakeLength - 1].transform.localPosition);
			//dispatcher.Dispatch(new SoundEvent(SoundEvent.Type.PLAY_SOUND_EFFECT, "move"));
			for (int i = snakeLength - 1; i >= 0; i--)
			{
				if (i == 0)
				{
					Vector2 newGridPosition = _snakeGrid.PositionToGrid(snake[i].transform.localPosition);
					newGridPosition += _direction;
					_snakeGrid.LoopGrid(ref newGridPosition);

					// Check if we have hit an item
					if (ContainsItem(newGridPosition))
					{
						if (item != null)
						{
							Destroy(item);
							item = null;
						}
						_snakeGrid.Pulse((int)newGridPosition.x, (int)newGridPosition.y);
						// respawn item
						AddCollectionItem(GetRandomLocation());
						AddPiece((int)endPieceGridLocation.x, (int)endPieceGridLocation.y);
						dispatcher.Dispatch(new ScoreEvent(ScoreEvent.Type.ADD_TO_SCORE, 1));
						dispatcher.Dispatch(new SoundEvent(SoundEvent.Type.PLAY_SOUND_EFFECT, "collect"));
						_speed *= 0.9f;
					}

					// Check if we have hit a snake
					if (ContainsSnake(newGridPosition))
					{
						GameOver();
					}

					snake[i].transform.localPosition = _snakeGrid.GridToPosition(newGridPosition);
				}
				else
				{
					snake[i].transform.localPosition = snake[i - 1].transform.localPosition;
				}
			}
			_snakeDirection = _direction;
		}

		private Vector2 GetRandomLocation()
		{
			Vector2 location = new Vector2(UnityEngine.Random.Range(0, _snakeGrid.SizeX), UnityEngine.Random.Range(0, _snakeGrid.SizeY));
			while (true)
			{
				if (!ContainsSnake(location))
					break;
				location = new Vector2(UnityEngine.Random.Range(0, _snakeGrid.SizeX), UnityEngine.Random.Range(0, _snakeGrid.SizeY));
			}
			return location;
		}

		private bool ContainsSnake(int x, int y) { return ContainsSnake(new Vector2(x, y)); }
		private bool ContainsSnake(Vector2 gridPosition)
		{
			foreach (GameObject piece in snake)
			{
				if (gridPosition == _snakeGrid.PositionToGrid(piece.transform.localPosition))
				{
					return true;
				}
			}
			return false;
		}

		private bool ContainsItem(Vector2 gridPosition) { return ContainsItem((int)gridPosition.x, (int)gridPosition.y); }
		private bool ContainsItem(int x, int y)
		{
			if (item == null)
				return false;
			Vector2 grid = new Vector2(x, y);
			return (grid == _snakeGrid.PositionToGrid(item.transform.localPosition));
		}

		private void Update ()
		{
			if (_state != GameState.IN_GAME)
				return;
			
			if (Input.GetKeyDown(KeyCode.LeftArrow) && _snakeDirection != Vector2.right)
			{
				_direction = Vector2.left;
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) && _snakeDirection != Vector2.left)
			{
				_direction = Vector2.right;
			}
			if (Input.GetKeyDown(KeyCode.UpArrow) && _snakeDirection != Vector2.down)
			{
				_direction = Vector2.up;
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) && _snakeDirection != Vector2.up)
			{
				_direction = Vector2.down;
			}
			
			_timeSinceLastMove += Time.deltaTime;
			while (_timeSinceLastMove > _speed)
			{
				_timeSinceLastMove -= _speed;
				MovePieces();
			}
		}


		private void GameOver()
		{
			dispatcher.Dispatch(new SoundEvent(SoundEvent.Type.PLAY_SOUND_EFFECT, "gameover"));
			dispatcher.Dispatch(new SoundEvent(SoundEvent.Type.STOP_MUSIC_TRACK));
			_state = GameState.GAME_OVER;

			float totalTime = 1f;
			int snakeLength = snake.Count;
			float singleTime = totalTime / snakeLength;

			if (item != null)
			{
				item.transform.DOScale(Vector3.zero, totalTime);
			}

			for (int i = 0; i < snakeLength; i++)
			{
				Sequence sequence = TweenSnakePiece(snake[i], singleTime * i);
				if (i == snakeLength - 1)
				{
					sequence.OnComplete(CloseGrid);
				}
			}
		}

		private Sequence TweenSnakePiece(GameObject item, float delay)
		{
			float scaleTime = 0.1f;
			Sequence itemSequence = DOTween.Sequence();
			itemSequence.SetDelay(delay);
			itemSequence.Append(item.GetComponent<Renderer>().material.DOColor(Color.red, scaleTime));
			itemSequence.Append(item.transform.DOPunchScale(Vector3.one * 0.9f, 0.5f));
			itemSequence.Append(item.transform.DOScale(Vector3.zero, 0.5f));
			itemSequence.Play();
			return itemSequence;
		}

		private void CloseGrid()
		{
			_snakeGrid.TransitionOut();
			_snakeGrid.ON_TRANSITION_OUT += OnCloseGrid;
		}

		private void OnCloseGrid()
		{
			SceneManager.LoadScene("GameOver");
		}
	}
}
