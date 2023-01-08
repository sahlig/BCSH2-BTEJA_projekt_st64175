using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class Variable : Statement
    {
        public VarType? DataType { get; set; }
        public string? Name { get; set; }
        public Expr? Value { get; set; }

        public Variable(VarType type, string nam)
        {
            DataType = type;
            Name = nam;
        }

        public Variable()
        {

        }

        public override object? State(AST program, Function? func, ObservableCollection<object> output)
        {
            if (Value == null)
            {
                return null;
            }
            else
            {
                return Value.Express(program, func, output);
            }
        }
    }

}
