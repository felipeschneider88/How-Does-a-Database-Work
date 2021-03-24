using System;
using System.Collections.Generic;
using System.Text;

namespace simpleDBMS.Compiler
{
    public class Statement
    {
        public StatementType statementType { get; set; }
        public PrepareResult prepareResult { get; set; }
        public string queryText { get; set; }

        public Statement(string query )
        {
            queryText = query;
        }
    }
}
