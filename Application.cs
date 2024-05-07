using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Reflection;

namespace DockablePaneExample
{
    public class Application : IExternalApplication
    {
        static AddInId addInId = new AddInId(new Guid("B7CC71C6-6725-4D92-8044-1F16B12631DC"));
        private readonly string assemblyPath = Assembly.GetExecutingAssembly().Location;
        public Result OnStartup(UIControlledApplication application)
        {
            SetupDockablePane(application);

            SetupPanel(application);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        private static void SetupDockablePane(UIControlledApplication application)
        {
            var dockablePaneData = new DockablePaneProviderData()
            {
                FrameworkElement = new ExamplePage(),
                VisibleByDefault = true,

                InitialState = new DockablePaneState
                {
                    DockPosition = DockPosition.Right,
                    MinimumWidth = 400
                },
            };
            var dockablePaneId = new DockablePaneId(new Guid("ADC789B2-3BFB-4217-9728-B6481C9791E4"));
            var title = "Example dockable pane";

            application.RegisterDockablePane(dockablePaneId, title, new ExampleDockablePaneProvider(dockablePaneData));
        }
        private void SetupPanel(UIControlledApplication application)
        {
            string tabName = "DockablePaneExample";
            application.CreateRibbonTab(tabName);
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "DockablePaneExample");
            AddPushButton(ribbonPanel, "Show panel", assemblyPath, "DockablePaneExample.ShowCommand");
        }

        private PushButton AddPushButton(RibbonPanel ribbonPanel, string buttonName, string path, string linkToCommand)
        {
            var buttonData = new PushButtonData(buttonName, buttonName, path, linkToCommand);
            var button = ribbonPanel.AddItem(buttonData) as PushButton;
            return button;
        }
    }
}
