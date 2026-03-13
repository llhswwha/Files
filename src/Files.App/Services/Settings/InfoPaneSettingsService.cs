// Copyright (c) Files Community
// Licensed under the MIT License.

namespace Files.App.Services.Settings
{
	internal sealed partial class InfoPaneSettingsService : BaseObservableJsonSettings, IInfoPaneSettingsService
	{
		public bool IsInfoPaneEnabled
		{
			get => Get(false);
			set => Set(value);
		}

		public double HorizontalSizePx
		{
			get => Math.Max(100d, Get(300d));
			set => Set(Math.Max(100d, value));
		}

		public double VerticalSizePx
		{
			get => Math.Max(100d, Get(250d));
			set => Set(Math.Max(100d, value));
		}

		public double MediaVolume
		{
			get => Math.Min(Math.Max(Get(1d), 0d), 1d);
			set => Set(Math.Max(0d, Math.Min(value, 1d)));
		}

		public InfoPaneTabs SelectedTab
		{
			get => Get(InfoPaneTabs.Details);
			set => Set(value);
		}

		public string LLPlayerPath
		{
			get => Get(@"D:\GitHubProjects\Files\Plugins\LLPlayer\LLPlayer\bin\Debug\net10.0-windows10.0.18362.0\LLPlayer.exe");
			set => Set(value);
		}

		public string MpvNetPath
		{
			get => Get(@"D:\GitHubProjects\Files\Plugins\mpv.net\src\MpvNet.Windows\bin\Debug\mpvnet.exe");
			set => Set(value);
		}

		public string VideoEditorPath
		{
			get => Get(@"D:\GitHubProjects\Files\Plugins\VideoEditor\src\VideoEditor.Presentation\bin\Debug\net9.0-windows\VideoEditor.Presentation.exe");
			set => Set(value);
		}

		public InfoPaneSettingsService(ISettingsSharingContext settingsSharingContext)
		{
			RegisterSettingsContext(settingsSharingContext);
		}

		protected override void RaiseOnSettingChangedEvent(object sender, SettingChangedEventArgs e)
		{
			base.RaiseOnSettingChangedEvent(sender, e);
		}
	}
}
