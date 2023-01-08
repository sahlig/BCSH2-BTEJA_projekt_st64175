using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class Return : Statement
    {
        public Expr? Expression { get; set; }

        public override object? State(AST program, Function? func, ObservableCollection<object> output)
        {
            if (Expression != null)
            {
                return Expression.Express(program, func, output);
            }
            else
            {
                throw new Exception("Invalid return statement");
            }
        }
    }
}
