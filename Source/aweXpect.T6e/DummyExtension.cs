using System.IO;
using aweXpect.Core;
using aweXpect.Core.Constraints;
using aweXpect.Helpers;
using aweXpect.Results;

namespace aweXpect;

public static class DummyExtensions
{
	/// <summary>
	///     Verifies that the <paramref name="subject" /> is an absolute path.
	/// </summary>
	public static AndOrResult<string, IThat<string>> IsAbsolutePath(
		this IThat<string> subject)
		=> new(subject.ThatIs().ExpectationBuilder.AddConstraint((it, grammar)
				=> new IsAbsolutePathConstraint(it)),
			subject);

	private readonly struct IsAbsolutePathConstraint(string it) : IValueConstraint<string>
	{
		public ConstraintResult IsMetBy(string actual)
		{
			if (Path.IsPathRooted(actual))
			{
				return new ConstraintResult.Success<string>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"{it} was {Formatter.Format(actual)}");
		}

		public override string ToString() => "is an absolute path";
	}
}
