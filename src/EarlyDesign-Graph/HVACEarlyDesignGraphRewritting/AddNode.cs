using System;
using System.Collections.Generic;
using de.unika.ipd.grGen.lgsp;
using de.unika.ipd.grGen.libGr;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace HVACEarlyDesignGraphRewritting
{
    public class AddNode : GH_Component
    {
        private static int nodeCount = 0;
        /// <summary>
        /// Initializes a new instance of the AddNode class.
        /// </summary>
        public AddNode()
          : base("AddNode", "AddNode",
              "Description",
              "HVAC", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ProcessingEnvironment", "P", "", GH_ParamAccess.item);
            pManager.AddGenericParameter("Node", "N", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_ObjectWrapper procEnv = null;
            GH_ObjectWrapper node = null;
            DA.GetData(0, ref procEnv);
            DA.GetData(1, ref node);
            (procEnv.Value as IGraphProcessingEnvironment).AddNode(node.Value as INode, "node" + nodeCount++);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("B5C7EFC8-9400-4CC8-B7F3-FFA439690757"); }
        }
    }
}