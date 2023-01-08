using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class VariableEq : Statement
    {
        public string? VariableName { get; set; }
        public Expr? Expression { get; set; }

        public override object? State(AST program, Function? func, ObservableCollection<object> output)
        {
            Variable tempVar = program.findVariable(VariableName);
            if (tempVar != null)
            {
                tempVar.Value = Expression;
                return tempVar;
            }
            if (func != null)
            {
                tempVar = func.findVariableFunc(VariableName);
                if (tempVar != null)
                {
                    tempVar.Value = Expression;
                    return tempVar;
                }
            }
            throw new Exception("Unknown variable " + VariableName + " was referenced");
        }
    }
}
