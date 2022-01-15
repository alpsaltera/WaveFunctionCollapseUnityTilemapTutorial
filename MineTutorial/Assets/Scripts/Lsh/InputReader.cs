using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Tilemaps;

using WaveFunctionColleps;
using Helpers;

namespace WaveFunctionColleps
{
	public class InputReader : IInputReader<TileBase>
	{
		private Tilemap _inputTileMap;

		// ==================================================
		// InputReader() : 생성자
		// ==================================================
		public InputReader( Tilemap inputTileMap )
		{
			_inputTileMap = inputTileMap;
		}

		// ==================================================
		// IInputValue() : 인터페이스
		// ==================================================
		public IValue<TileBase>[ ][ ] ReadInputToGrid()
		{
			TileBase[][] tileBaseGrid = ReadInputTileMap();
			TileBaseValue[ ][ ] tileBaseValues = null;

			if ( tileBaseGrid != null ) {
				tileBaseValues = MyCollectionExtension.CreateJaggedArray<TileBaseValue[ ][ ]>( tileBaseGrid.Length , tileBaseGrid[ 0 ].Length );

				for ( int row = 0 ; row < tileBaseGrid.Length ; row++ ) {
					for ( int col = 0 ; col < tileBaseGrid[row].Length ; col++ ) {
						tileBaseValues[ row ][ col ] = new TileBaseValue( tileBaseGrid[ row ][ col ] );
					}
				}
			}

			// 이렇게 캐스팅 되는 것이 신기하네.
			return tileBaseValues;
		}

		// ==================================================
		// ReadInputTileMap() : 인터페이스
		// ==================================================
		private TileBase[ ][ ] ReadInputTileMap()
		{
			InputParameters inputParameters = new InputParameters( _inputTileMap );
			return CreateTileBaseGrid( inputParameters );
		}


		private TileBase[ ][ ] CreateTileBaseGrid( InputParameters inputParameters )
		{
			TileBase[ ][ ] gridOfInputTiles = null;
			gridOfInputTiles = MyCollectionExtension.CreateJaggedArray<TileBase[ ][ ]>( inputParameters.Height , inputParameters.Width );

			for ( int row = 0 ; row < inputParameters.Height ; row++ ) {
				for ( int col = 0 ; col < inputParameters.Width ; col++ ) {
					gridOfInputTiles[ row ][ col ] = inputParameters.StackOfTiles.Dequeue().tileBase;
				}
			}

			return gridOfInputTiles;
		}
	}
}
