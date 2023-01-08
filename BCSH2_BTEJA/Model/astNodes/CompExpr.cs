using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class CompExpr : Expr
    {
        public string? Comparison { get; set; }
        public Expr? LeftExpr { get; set; }
        public Expr? RightExpr { get; set; }

        private bool SameType(AST program, Function? func, ObservableCollection<object> output)
        {
            VarType left;
            VarType right;
            if (func == null)
            {
                func = new Function();
            }
            if (LeftExpr is VariableCall)
            {
                if (program.findVariable(((VariableCall)LeftExpr).Name) != null)
                {
                    left = (VarType)program.findVariable(((VariableCall)LeftExpr).Name).DataType;
                }
                else if (func.findVariableFunc(((VariableCall)LeftExpr).Name) != null)
                {
                    left = (VarType)func.findVariableFunc(((VariableCall)LeftExpr).Name).DataType;
                }
                else
                {
                    throw new Exception("Variable" + ((VariableCall)LeftExpr).Name + " does not exist");
                }
            }
            else if (LeftExpr is Literal)
            {
                left = (VarType)((Literal)LeftExpr).DataType;
            }
            else
            {
                throw new Exception("Unsupported comparison");
            }

            if (RightExpr is VariableCall)
            {
                if (program.findVariable(((VariableCall)RightExpr).Name) != null)
                {
                    right = (VarType)program.findVariable(((VariableCall)LeftExpr).Name).DataType;
                }
                else if (func.findVariableFunc(((VariableCall)RightExpr).Name) != null)
                {
                    right = (VarType)func.findVariableFunc(((VariableCall)RightExpr).Name).DataType;
                }
                else
                {
                    throw new Exception("Variable" + ((VariableCall)RightExpr).Name + " does not exist");
                }
            }
            else if (RightExpr is Literal)
            {
                right = (VarType)((Literal)RightExpr).DataType;
            }
            else
            {
                throw new Exception("Unsupported comparison");
            }

            if (left == VarType.TypeString || right == VarType.TypeString)
            {
                throw new Exception("Cant compare strings");
            }

            if (left == right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override object? Express(AST program, Function? func, ObservableCollection<object> output)
        {
            if (SameType(program, func, output))
            {
                if (Comparison == "==")
                {
                    return (dynamic)LeftExpr.Express(program, func, output) == (dynamic)RightExpr.Express(program, func, output);
                }
                else if (Comparison == "<=")
                {
                    return (dynamic)LeftExpr.Express(program, func, output) <= (dynamic)RightExpr.Express(program, func, output);
                }
                else if (Comparison == "<")
                {
                    return (dynamic)LeftExpr.Express(program, func, output) < (dynamic)RightExpr.Express(program, func, output);
                }
                else if (Comparison == ">=")
                {
                    return (dynamic)LeftExpr.Express(program, func, output) >= (dynamic)RightExpr.Express(program, func, output);
                }
                else if (Comparison == ">")
                {
                    return (dynamic)LeftExpr.Express(program, func, output) > (dynamic)RightExpr.Express(program, func, output);
                }
                else if (Comparison == "!=")
                {
                    return (dynamic)LeftExpr.Express(program, func, output) != (dynamic)RightExpr.Express(program, func, output);
                }
                else
                {
                    throw new Exception("Unknown comparison");
                }
            }
            else
            {
                throw new Exception("Cant compare different types");
            }
        }
    }
}
