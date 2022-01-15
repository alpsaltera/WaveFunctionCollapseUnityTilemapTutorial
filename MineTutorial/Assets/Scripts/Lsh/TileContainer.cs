using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace WaveFunctionColleps
{
	public class TileContainer
	{
		public TileBase tileBase { get; set; }
		public int Row { get; set; }
		public int Col { get; set; }

		public TileContainer( TileBase tileBase , int row , int col )
		{
			this.tileBase = tileBase;
			Row = row;
			Col = col;
		}
	}

}