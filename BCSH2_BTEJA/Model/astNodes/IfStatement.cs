using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class IfStatement : Statement
    {

        public CompExpr? IfExpression { get; set; }
        public List<Statement> LocalVariables { get; set; }
        public List<Statement> InsideStatements { get; set; }
        public List<Statement> Else { get; set; }

        public IfStatement()
        {
            InsideStatements = new List<Statement>();
            Else = new List<Statement>();
            LocalVariables = new List<Statement>();
        }

        public override object? State(AST program, Function? func, ObservableCollection<object> output)
        {
            if ((bool)IfExpression.Express(program, func, output))
            {
                foreach (Statement s in InsideStatements)
                {
                    if (s is Return)
                    {
                        return s.State(program, func, output);
                    }
                    else
                    {
                        s.State(program, func, output);
                    }
                }
            }
            else
            {
                foreach (Statement s in Else)
                {
                    if (s is Return)
                    {
                        return s.State(program, func, output);
                    }
                    else
                    {
                        s.State(program, func, output);
                    }
                }
            }
            return null;
        }
    }


}
