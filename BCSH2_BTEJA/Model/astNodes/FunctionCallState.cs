using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class FunctionCallState : Statement
    {
        public Expr? Func { get; set; }

        public override object? State(AST program, Function? func, ObservableCollection<object> output)
        {
            return Func.Express(program, func, output);
        }
    }
}
