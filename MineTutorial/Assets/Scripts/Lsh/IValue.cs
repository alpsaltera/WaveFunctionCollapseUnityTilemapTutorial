using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace WaveFunctionColleps
{
	public interface IValue<T> : IEqualityComparer<IValue<T>>, IEquatable<IValue<T>>
	{
		T Value { get; }
	}

}
