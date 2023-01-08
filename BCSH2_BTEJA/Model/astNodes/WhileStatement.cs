using BCSH2_BTEJA.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSH2_BTEJA.Model.astNodes
{
    public class WhileStatement : Statement
    {
        public List<Statement> InsideStatements { get; set; }
        public List<Statement> LocalVariables { get; set; }
        public CompExpr? WhileExpression { get; set; }

        public WhileStatement()
        {
            InsideStatements = new List<Statement>();
            LocalVariables = new List<Statement>();
        }

        public override object? State(AST program, Function? func, ObservableCollection<object> output)
        {
            while ((bool)WhileExpression.Express(program, func, output))
            {
                foreach (Statement s in InsideStatements)
                {
                    s.State(program, func, output);
                }
            }
            return null;
        }
    }
}
