using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class VariableCall : Expr
    {
        public string? Name { get; set; }

        public VariableCall(string nam)
        {
            Name = nam;
        }

        public override object? Express(AST program, Function? func, ObservableCollection<object> output)
        {
            Variable tempVar = program.findVariable(Name);
            if (tempVar != null)
            {
                return tempVar.State(program, func, output);
            }
            if (func != null)
            {
                tempVar = func.findVariableFunc(Name);
                if (tempVar != null)
                {
                    return tempVar.State(program, func, output);
                }
            }
            throw new Exception("Unknown variable " + Name + " was called");
        }
    }
}
