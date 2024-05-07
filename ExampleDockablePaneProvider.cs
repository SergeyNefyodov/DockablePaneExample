using Autodesk.Revit.UI;

namespace DockablePaneExample
{
    public class ExampleDockablePaneProvider : IDockablePaneProvider
    {
        private readonly DockablePaneProviderData _data;
        public ExampleDockablePaneProvider(DockablePaneProviderData data)
        {
            _data = data;
        }
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = _data.FrameworkElement;
            data.VisibleByDefault = _data.VisibleByDefault;
            data.InitialState = _data.InitialState;
        }
    }
}
