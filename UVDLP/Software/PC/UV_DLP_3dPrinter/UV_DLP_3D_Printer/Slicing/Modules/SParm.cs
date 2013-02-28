using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Slicing.Modules
{
    // this is a slicing parameter
    /*
     Each module has a set of 0 or more defined slicing parameters 
     * These parameters are used by each module stage to perform 
     * module-specific actions
     */
    public enum eSparm 
    {
        eInt,
        eDouble,
        eString
    }

    public class SParm
    {
        public string m_name; // the name of the parameter (No Spaces)
        public int      m_ival; // the integer value (if used)
        public double   m_dval; // the double value (if used)
        public string m_sval;   // the string value (if used)
        public string m_help;
        public eSparm m_parmtype; // the type of paramter this is

        /*define some constructors here so the individual modules can define arrays of these */
        public SParm(string name, int ival, string help) 
        {
            m_name = name;
            m_ival = ival;
            m_help = help;
            m_parmtype = eSparm.eInt;
        }
        public SParm(string name, double dval, string help)
        {
            m_name = name;
            m_dval = dval;
            m_help = help;
            m_parmtype = eSparm.eDouble;
        }
        public SParm(string name, string sval, string help)
        {
            m_name = name;
            m_sval = sval;
            m_help = help;
            m_parmtype = eSparm.eString;
        }
    }
}
