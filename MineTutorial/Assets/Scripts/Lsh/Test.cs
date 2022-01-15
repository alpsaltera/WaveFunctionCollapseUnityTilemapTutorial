using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace WaveFunctionColleps
{

	public class Test : MonoBehaviour
	{
		public Tilemap inputTileMap;

		// Start is called before the first frame update
		void Start()
		{
			InputReader inputReader = new InputReader( inputTileMap );

			//
			IValue<TileBase>[][] valueGrid = inputReader.ReadInputToGrid();

			for ( int row = 0 ; row < valueGrid.Length ; row++ ) {
				for ( int col = 0 ; col < valueGrid[row].Length ; col++ ) {
					Debug.Log( $"row:{row} , col:{col} , valueGrid:{valueGrid[ row ][ col ].Value }" );
				}
			}
		}

	}

}