using System;
using System.Collections.Generic;
using System.Text;
using UV_DLP_3D_Printer;

namespace Engine3D
{
    public class Vector3d : Point3d
    {

        public double Mag()
        {
            return Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public double Dot(Vector3d v) //dot product 
        {
	        double dp = ( x * v.x ) +
		               ( y * v.y ) +
		     	       ( z * v.z );
	        return dp;
        }

       public void Normalize()  
       {
    	    double oneoverdist  = 1.0f / Mag();
            x *= oneoverdist;
            y *= oneoverdist;
            z *= oneoverdist;
       }
    }
}
