using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace АnalyzerModule
{
    internal delegate double Operator(double x, double y);

    internal class BinaryExpression
    {
        protected BinaryExpression()
        {
        }

        public BinaryExpression(BinaryExpression left, BinaryExpression right,
            Operator op)
        {
            Left = left; Right = right; Operator = op;
        }

        public virtual double Value
        {
            get
            {
                try
                {
                    return Operator(Left.Value, Right.Value);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid input Parameter");
                    return 0;
                }

            }
            protected set { }
        }

        public BinaryExpression Left;
        public BinaryExpression Right;
        public Operator Operator;
    }

    internal class BinaryAtomic : BinaryExpression
    {
        protected BinaryAtomic()
        {
        }

        public BinaryAtomic(double value)
        {
            Value = value;
        }

        public override double Value
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
