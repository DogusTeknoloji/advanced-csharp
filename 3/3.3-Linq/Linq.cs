using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdvancedCSharp {

    public class Linq : ITutorial {

        public void Run() {
            // http://www.umutozel.com/javascript-linq-01
            
            var expList = new List<Expression>();
            var calls1 =    from exp in expList
                            where exp.NodeType == ExpressionType.Call
                            select exp;
            // turns into this
            var calls2 = expList.Where(e => e.NodeType == ExpressionType.Call);
            
            Action<string> normalLambda = (string message) => Console.WriteLine(message);
            // same syntax, compiler magic!
            Expression<Action<string>> expressionLambda = (string message) => Console.WriteLine(message);

            Console.WriteLine(expressionLambda.ToString());

            var visitor = new MyVisitor();
            var newExp = (LambdaExpression)visitor.Visit(expressionLambda);
            Console.WriteLine(newExp.ToString());

            // only Lambda can be compiled
            var newAction = (Action<string>)newExp.Compile();
            Console.WriteLine(newAction);
            
            newAction("Merhaba");
        }

        public class MyVisitor : ExpressionVisitor {

            protected override Expression VisitMethodCall(MethodCallExpression node) {
                var oldArg = node.Arguments.Single();
                var concat = Expression.Add(
                    oldArg,
                    Expression.Constant(" HEYOO"),
                    typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string) })
                );

                return Expression.Call(
                    node.Object,
                    node.Method,
                    new Expression[] { concat }
                );
            }
        }
    }
}
