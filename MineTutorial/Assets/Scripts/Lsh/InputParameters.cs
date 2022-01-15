using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace WaveFunctionColleps
{
	public class InputParameters
	{
		private Tilemap _inputTileMap;

		Vector2Int? bottomLeftTileCoord = null;
		Vector2Int? topRightTileCoord = null;
		BoundsInt inputTileMapBounds;
		TileBase[ ] inputTileMapArray;
		Queue<TileContainer> stackOfTiles = new Queue<TileContainer>();
		private int width = 0, height = 0;

		public int Width => width;
		public int Height => height;
		public Queue<TileContainer> StackOfTiles { get => stackOfTiles; set => stackOfTiles = value; }

		public InputParameters( Tilemap inputTileMap )
		{
			this._inputTileMap = inputTileMap;
			this.inputTileMapBounds = inputTileMap.cellBounds;
			this.inputTileMapArray = inputTileMap.GetTilesBlock( this.inputTileMapBounds );
			ExtractNotEmptyTiles();
			VeryfyInputTiles();
		}

		private void VeryfyInputTiles()
		{
			if ( bottomLeftTileCoord == null || topRightTileCoord == null ) {
				throw new Exception( "WFC : bottomRight or TopLeft is null." );
			}

			// 이 계산이 NULL을 뺀 것들에 대한 계산이 된다.
			int xMin = bottomLeftTileCoord.Value.x;
			int xMax = topRightTileCoord.Value.x;
			int yMin = bottomLeftTileCoord.Value.y;
			int yMax = topRightTileCoord.Value.y;

			width = (xMax - xMin) + 1;
			height = (yMax - yMin) + 1;

			int tileCount = width * height;

			if ( tileCount != stackOfTiles.Count ) {
				throw new Exception( "WFC : tileCount != stackOfTiles.Count" );
			}

			if ( stackOfTiles.Any( tile => tile.Row < xMin || tile.Row > xMax || tile.Col < yMin || tile.Col > yMax )) {
				throw new Exception( "WFC : Range Error" );
			}
		}


		// ============================================================
		// ExtractNotEmptyTiles() : 엠프티 TileBase 뽑아내기.
		// ============================================================
		private void ExtractNotEmptyTiles()
		{
			for ( int row = 0 ; row < inputTileMapBounds.size.y ; row++ ) {
				for ( int col = 0 ; col < inputTileMapBounds.size.x ; col++ ) {

					int index = col + (row * inputTileMapBounds.size.x);
					TileBase tileBase = inputTileMapArray[ index ];

					// 그런데, 만약 다른 것을 할당한다면 , 이 조건을 만족할 수가 있나?
					if ( bottomLeftTileCoord == null && tileBase != null )
						bottomLeftTileCoord = new Vector2Int( col , row );

					if ( tileBase != null ) {
						stackOfTiles.Enqueue( new TileContainer( tileBase , row , col ));
						topRightTileCoord = new Vector2Int( col , row );
					}
				}
			}
		}
	}
}