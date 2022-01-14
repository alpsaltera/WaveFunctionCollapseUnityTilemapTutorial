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
		private TileBase _inputTileBase;

		// ==================================================
		// InputReader() : 생성자
		// ==================================================
		public InputReader( TileBase inputTileBase )
		{
			_inputTileBase = inputTileBase;
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

			return tileBaseValues;
		}

		// ==================================================
		// ReadInputTileMap() : 인터페이스
		// ==================================================
		private TileBase[ ][ ] ReadInputTileMap()
		{
			throw new NotImplementedException();
		}
	}
}
