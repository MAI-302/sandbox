using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace _2048
{
    class ValueSquare
    {
        public int m_squareNumber;
        public int m_grade;
        public int m_value;

        public ValueSquare(int grade, int squareNumber)
        {
            m_grade = grade;
            m_squareNumber = squareNumber;
        }
        public int grade { get { return m_grade; } set { m_grade = value; } }
        public int value { get { return m_value; } set { m_value = value; } }
        public int squareNumber { get { return m_squareNumber; } set { m_squareNumber = value; } }
    }
}
