using System;
using System.Collections.Generic;
using de.unika.ipd.grGen.graphViewerAndSequenceDebugger;
using de.unika.ipd.grGen.grShell;
using de.unika.ipd.grGen.libGr;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace HVACEarlyDesignGraphRewritting
{
    public class ShowGraph : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ShowGraph class.
        /// </summary>
        public ShowGraph()
          : base("ShowGraph", "ShowGraph",
              "Description",
              "HVAC", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph", "G", "",GH_ParamAccess.item);
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
            GH_ObjectWrapper graph = null;
            DA.GetData(0, ref graph);

            GraphViewer.ShowGraphWithDot(new DebuggerGraphProcessingEnvironment(graph.Value as IGraph), "dot","",false);
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
            get { return new Guid("A2ADB71E-A1CC-48F7-94C0-D4663F0B603A"); }
        }
    }
}