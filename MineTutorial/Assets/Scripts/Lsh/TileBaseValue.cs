using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WaveFunctionColleps;
using UnityEngine.Tilemaps;

public class TileBaseValue : IValue<TileBase>
{
	private TileBase tileBase;


	// ==================================================
	// TileBaseValue() : 생성자.
	// ==================================================
	public TileBaseValue( TileBase tileBase )
	{
		this.tileBase = tileBase;
	}

	public TileBase Value => throw new System.NotImplementedException();


	public bool Equals( IValue<TileBase> x , IValue<TileBase> y )
	{
		throw new System.NotImplementedException();
	}

	public bool Equals( IValue<TileBase> other )
	{
		throw new System.NotImplementedException();
	}

	public int GetHashCode( IValue<TileBase> obj )
	{
		throw new System.NotImplementedException();
	}
}
