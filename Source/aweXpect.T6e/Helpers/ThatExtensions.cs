﻿using System;
using aweXpect.Core;

namespace aweXpect.Helpers;

internal static class ThatExtensions
{
	public static IThatIs<T> ThatIs<T>(this IThat<T> subject)
	{
		if (subject is IThatIs<T> thatIs)
		{
			return thatIs;
		}

		if (subject is IThatVerb<T> thatVerb)
		{
			return new ThatSubject<T>(thatVerb.ExpectationBuilder);
		}

		throw new NotSupportedException("IThat<T> must also implement IThatIs<T>");
	}
}
