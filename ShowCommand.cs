using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace DockablePaneExample
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class ShowCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var dockablePaneId = new DockablePaneId(new Guid("ADC789B2-3BFB-4217-9728-B6481C9791E4"));
            var dockablePane = commandData.Application.GetDockablePane(dockablePaneId);
            if (dockablePane.IsShown())
            {
                dockablePane.Hide();
            }
            else
            {
                dockablePane.Show();
            }
            return Result.Succeeded;
        }
    }
}
