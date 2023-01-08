using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class Function : Statement
    {
        public string? Name { get; set; }
        public VarType? ReturnType { get; set; }
        public List<Variable> Parameters { get; set; }
        public List<Statement> InsideStatements { get; set; }
        public List<Statement> LocalVariables { get; set; }

        public Function()
        {
            Parameters = new List<Variable>();
            InsideStatements = new List<Statement>();
            LocalVariables = new List<Statement>();
        }

        public Variable findVariableFunc(string nam)
        {
            foreach (Variable v in LocalVariables)
            {
                if (v.Name.Equals(nam))
                {
                    return v;
                }
            }
            foreach (Variable v in Parameters)
            {
                if (v.Name == nam)
                {
                    return v;
                }
            }
            return null;
        }

        public override object? State(AST program, Function? func, ObservableCollection<object> output)
        {
            Return ret = new Return();
            bool hasReturn = false;
            if (ReturnType != null)
            {
                foreach (Statement s in InsideStatements)
                {
                    if (s is Return)
                    {
                        hasReturn = true;
                        ret = (Return)s;
                    }
                }
                if (!hasReturn)
                {
                    throw new Exception("Function " + Name + " needs to return something");
                }
            }
            foreach (Statement s in InsideStatements)
            {
                if (s is Return)
                {
                    return s.State(program, this, output);
                }
                else
                {
                    s.State(program, this, output);
                }
            }
            return null;
        }
    }
}
