using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaveFunctionColleps
{

	public interface IInputReader<T>
	{
		IValue<T>[ ][ ] ReadInputToGrid();
	}
}
