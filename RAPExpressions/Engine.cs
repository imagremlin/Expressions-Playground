using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Text;

namespace RAPExpressions
{
    public static class Engine
    {
        public static object Execute(string expression, List<decimal> Weights, List<decimal> Values, List<decimal> Ratings)
        {
            StringBuilder setup = new();
            setup.Append("using RAPExpressions;");
            setup.Append("using System.Linq;");
            setup.Append($"RatingSet Weight=new({string.Join(",", Weights.Select(_ => _.ToString()))});");
            setup.Append($"RatingSet Value=new({string.Join(",", Values.Select(_ => _.ToString()))});");
            setup.Append($"RatingSet Rating=new({string.Join(",", Ratings.Select(_ => _.ToString()))});");
            return CSharpScript.EvaluateAsync(setup + expression, ScriptOptions.Default.WithReferences(typeof(RatingSet).Assembly)).GetAwaiter().GetResult();
        }
    }
}