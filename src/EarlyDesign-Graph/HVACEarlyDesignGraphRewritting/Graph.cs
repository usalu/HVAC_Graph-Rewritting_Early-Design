using System;
using System.Collections.Generic;
using de.unika.ipd.grGen.Action_hvacRules;
using de.unika.ipd.grGen.lgsp;
using de.unika.ipd.grGen.Model_hvacRules;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace HVACEarlyDesignGraphRewritting
{
    public class Graph : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Graph class.
        /// </summary>
        public Graph()
          : base("Graph", "Graph",
              "Description",
              "HVAC", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph", "G", "", GH_ParamAccess.item);
            pManager.AddGenericParameter("Actions", "A", "", GH_ParamAccess.item);
            pManager.AddGenericParameter("ProcessingEnvironment", "P", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var graph = new hvacRulesNamedGraph(new LGSPGlobalVariables());
            var actions = new hvacRulesActions(graph);
            var procEnv = new LGSPGraphProcessingEnvironment(graph, actions);
            DA.SetData(0, new GH_ObjectWrapper(graph));
            DA.SetData(1, new GH_ObjectWrapper(actions));
            DA.SetData(2, new GH_ObjectWrapper(procEnv));
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
            get { return new Guid("012F518F-3512-47EC-A58B-F880CEA6343C"); }
        }
    }
}