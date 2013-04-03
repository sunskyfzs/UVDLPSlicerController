using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine3D;

namespace UV_DLP_3D_Printer._3DEngine
{
    /*
     Ray tracing utilites for the 3d engine
     */
    public class RTUtils
    {
        // 
        class TestPoint { public double X, Y;};
        static TestPoint[] TstPnt = new TestPoint[4]; //for the crossing test
        static int numTstPnt = 0;//for the crossing test

        public static int CrossingsTest(double PntX, double PntY)
        {
            if (TstPnt[0] == null)  // create if not created already
            {
                TstPnt[0] = new TestPoint();
                TstPnt[1] = new TestPoint();
                TstPnt[2] = new TestPoint();
                TstPnt[3] = new TestPoint();
            }
            int j, yflag0, yflag1, inside_flag, xflag0;
            double ty, tx;// *vtx0, *vtx1 ;
            int line_flag;
            short index = 0;
            tx = PntX;//point[X] ;
            ty = PntY;//point[Y] ;
            TestPoint vtx0, vtx1;
            vtx0 = TstPnt[numTstPnt - 1];
            yflag0 = (vtx0.Y >= ty) ? 1 : 0;
            vtx1 = TstPnt[0];
            inside_flag = 0;
            line_flag = 0;
            for (j = numTstPnt + 1; --j > 0; )
            {
                yflag1 = (vtx1.Y >= ty) ? 1 : 0;
                if (yflag0 != yflag1)
                {
                    xflag0 = (vtx0.X >= tx) ? 1 : 0;
                    if (xflag0 == ((vtx1.X >= tx) ? 1 : 0))
                    {
                        if (xflag0 != 0)
                        {
                            if (inside_flag == 1)
                            {
                                inside_flag = 0;
                            }
                            else
                            {
                                inside_flag = 1;
                            }
                            //inside_flag = !inside_flag;
                        }
                    }
                    else
                    {
                        if ((vtx1.X - (vtx1.Y - ty) *
                         (vtx0.X - vtx1.X) / (vtx0.Y - vtx1.Y)) >= tx)
                        {
                            //inside_flag = !inside_flag ;
                            if (inside_flag == 1)
                            {
                                inside_flag = 0;
                            }
                            else
                            {
                                inside_flag = 1;
                            }
                        }
                    }
                    if (line_flag != 0)
                        goto Exit;
                    line_flag = 1;
                }

                /* move to next pair of vertices, retaining info as possible */
                yflag0 = yflag1;
                vtx0 = vtx1;
                vtx1 = TstPnt[++index];
            }
        Exit: ;
            return (inside_flag);
        }

        public static bool IntersectPoly(Polygon poly, Point3d start, Point3d end,ref  Point3d intersection)
        {
            //intersect a Polygon with a ray in world space
            bool retval = false;
            double deltaX, deltaY, deltaZ, t, T, S;
            double A, B, C, D;//the Polygon plane
            double denom;

            if (TstPnt[0] == null)  // create if not created already
            {
                TstPnt[0] = new TestPoint();
                TstPnt[1] = new TestPoint();
                TstPnt[2] = new TestPoint();
                TstPnt[3] = new TestPoint();
            }

            A = poly.plane.a;
            B = poly.plane.b;
            C = poly.plane.c;
            D = poly.plane.d;
            deltaX = end.x - start.x;
            deltaY = end.y - start.y;
            deltaZ = end.z - start.z;

            denom = (A * deltaX + B * deltaY + C * deltaZ);

            if (denom == 0.0)//ray is parallel, no intersection
            {
                retval = false;
                return retval;
            }
            T = (-1) / denom;
            S = (A * start.x + B * start.y + C * start.z);
            t = (S + D) * T;
            //at this point we have a possible intersection
            //project to a major world axis and test for containment in the poly
            intersection.x = (float)(start.x + (t * deltaX));
            intersection.y = (float)(start.y + (t * deltaY));
            intersection.z = (float)(start.z + (t * deltaZ));

            numTstPnt = poly.m_points.Length;
            // test the X/Y plane
            for (long counter = 0; counter < poly.m_points.Length; counter++)
            {
                TstPnt[counter].X = poly.m_points[counter].x;
                TstPnt[counter].Y = poly.m_points[counter].y;
            }
            if (CrossingsTest(intersection.x, intersection.y) == 1) 
            { 
                retval = true; 
                return retval; 
            }
            // Test the X/Z plane
            for (long counter = 0; counter < poly.m_points.Length; counter++)
            {
                TstPnt[counter].X = poly.m_points[counter].x;
                TstPnt[counter].Y = poly.m_points[counter].z;
            }
            if (CrossingsTest(intersection.x, intersection.y) == 1) 
            { 
                retval = true; 
            }
            return retval;
        }
        public static bool IntersectSphere(Point3d start,Point3d end,ref Point3d intersect, Point3d center,double radius)
        {
	        bool retval = false;
	        double EO;//EO is distance from start of ray to center of sphere
	        double d,disc,v;//v is length of direction ray
	        Vector3d V,temp;//V is unit vector of the ray
	        temp =new Vector3d();
            V = new Vector3d();

	        temp.Set(center.x - start.x,center.y - start.y,	center.z - start.z,0);

	        EO = temp.Mag(); // unnormalized length
	        V.Set(end.x - start.x,end.y - start.y,end.z - start.z,0);
	        v = V.Mag();// magnitude of direction vector
	        V.Normalize();// normalize the direction vector
	        disc = (radius*radius) - ((EO*EO) - (v*v));
	        if(disc < 0.0f)
            {
                retval = false;// no intersection
	        }
            else
            { // compute the intersection point
		        retval = true;
		        d = Math.Sqrt(disc);
		        intersect.x = start.x + ((v-d)*V.x);
		        intersect.y = start.y + ((v-d)*V.y);
		        intersect.z = start.z + ((v-d)*V.z);
	        }
	        return retval;
        }
    }
}
