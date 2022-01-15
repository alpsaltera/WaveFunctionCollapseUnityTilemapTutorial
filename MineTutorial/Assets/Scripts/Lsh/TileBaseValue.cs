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

	#region IValue 
	// ==================================================
	// TileBaseValue() : 생성자.
	// ==================================================
	public TileBase Value => tileBase;


	public bool Equals( IValue<TileBase> x , IValue<TileBase> y )
	{
		return x == y;
	}

	public bool Equals( IValue<TileBase> other )
	{
		return this.Value == other.Value;
	}

	public int GetHashCode( IValue<TileBase> obj )
	{
		return obj.GetHashCode();
	}
	#endregion

	// ==================================================
	// override GetHashCode() : 내부 해쉬코드 생성자 오버라이드
	// ==================================================
	public override int GetHashCode()
	{
		return this.tileBase.GetHashCode();
	}

}
