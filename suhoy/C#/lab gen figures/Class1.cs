using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allfigures
{
    public class figures
    {
        public int x, y;//координаты
    }



    public class withoutangle
        :figures
    {
        public int m, n, r;//(x/m)^2+(y/n)^2=1
   
    
    }
    public class withangle
        : figures
    {
        public int a,b,c;//(ax)+(by)=c
    
    
    }

    public class triangle
        : withangle
    {
    
    
    }
    public class quadrangle
        : withangle
    {
    }
}
