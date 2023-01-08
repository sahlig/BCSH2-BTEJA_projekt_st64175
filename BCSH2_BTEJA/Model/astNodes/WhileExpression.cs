using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class WhileExpression : Expr
    {
        public string? Comparison { get; set; }
        public Expr? LeftExpr { get; set; }
        public Expr? RightExpr { get; set; }

        public override object? Express(AST program, Function? func, ObservableCollection<object> output)
        {
            throw new NotImplementedException();
        }
    }
}
