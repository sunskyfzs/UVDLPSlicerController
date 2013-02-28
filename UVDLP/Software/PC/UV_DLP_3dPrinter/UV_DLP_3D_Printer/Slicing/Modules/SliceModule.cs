using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace UV_DLP_3D_Printer.Slicing
{
    /*
     This is the base class for slicing modules
     * each module can perform a specific action on the object model
     * or input / output data used during the slicing process
     * various modules could include:
     * raft generation
     * Bottom layer
     * support generation
     * actual slicer (object model to polylines / lines)
     * image generation (image exporting or run-time generation)
     * first layer alterations (additional time)     
     * svg export
     * etc...
     */
    public class SliceModule
    {
        protected string m_name; // the name of this module
        protected string m_description; // a more verbose description of this module
        protected string m_help; // associated help for this module
        protected ArrayList m_parms;
        protected bool m_enabled; // is this module enabled

        public string Name
        {
            get { return m_name; }
        }
        public string Description
        {
            get { return m_description; }
        }
        public string Help
        {
            get { return m_help; }
        }
        public bool Save(XmlWriter writer)
        {
            //save the array
            return false;
        }
        public bool Load(XmlReader reader)
        {
            //load the array
            return false;
        }
    }
}
