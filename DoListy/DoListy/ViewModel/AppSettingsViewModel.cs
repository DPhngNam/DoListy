

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Specialized;

namespace DoListy.ViewModel
{
    public partial class AppSettingsViewModel: ObservableObject
    {
        [ObservableProperty]
        private bool _isSwitchToggled;


    }
}
