// Copyright (c) Files Community
// Licensed under the MIT License.

using Files.App.ViewModels.Properties;
using Microsoft.UI.Xaml;
using Windows.Media.Core;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace Files.App.ViewModels.Previews
{
	public sealed partial class MediaPreviewViewModel : BasePreviewModel
	{
		private IUserSettingsService UserSettingsService { get; } = Ioc.Default.GetRequiredService<IUserSettingsService>();

		public event EventHandler TogglePlaybackRequested;

		private MediaSource source;
		public MediaSource Source
		{
			get => source;
			private set => SetProperty(ref source, value);
		}

		private bool isFullMode;
		public bool IsFullMode
		{
			get => isFullMode;
			set => SetProperty(ref isFullMode, value);
		}

		public IRelayCommand OpenInLLPlayerCommand { get; }

		public IRelayCommand OpenInMpvNetCommand { get; }

		public IRelayCommand OpenInVideoEditorCommand { get; }

		public MediaPreviewViewModel(ListedItem item) : base(item)
		{
			OpenInLLPlayerCommand = new RelayCommand(OpenInLLPlayer);
			OpenInMpvNetCommand = new RelayCommand(OpenInMpvNet);
			OpenInVideoEditorCommand = new RelayCommand(OpenInVideoEditor);
		}

		private void OpenInLLPlayer()
		{
			var path = UserSettingsService.InfoPaneSettingsService.LLPlayerPath;
			if (string.IsNullOrEmpty(path))
				return;

			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = path,
					Arguments = $"\"{Item.ItemPath}\"",
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				// Log or show error
			}
		}

		private void OpenInMpvNet()
		{
			var path = UserSettingsService.InfoPaneSettingsService.MpvNetPath;
			if (string.IsNullOrEmpty(path))
				return;

			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = path,
					Arguments = $"\"{Item.ItemPath}\"",
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				// Log or show error
			}
		}

		private void OpenInVideoEditor()
		{
			var path = UserSettingsService.InfoPaneSettingsService.VideoEditorPath;
			if (string.IsNullOrEmpty(path))
				return;

			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = path,
					Arguments = $"\"{Item.ItemPath}\"",
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				// Log or show error
			}
		}

		public void TogglePlayback()
			=> TogglePlaybackRequested?.Invoke(this, null);

		public override Task<List<FileProperty>> LoadPreviewAndDetailsAsync()
		{
			Source = MediaSource.CreateFromStorageFile(Item.ItemFile);

			return Task.FromResult(new List<FileProperty>());
		}

		public override void PreviewControlBase_Unloaded(object sender, RoutedEventArgs e)
		{
			Source = null;

			base.PreviewControlBase_Unloaded(sender, e);
		}
	}
}
