﻿using Dopamine.Common.Services.Appearance;
using Dopamine.Common.Services.Cache;
using Dopamine.Common.Services.Metadata;
using Dopamine.Common.Services.Playback;
using Dopamine.Common.Services.Settings;

namespace Dopamine.Common.Presentation.ViewModels
{
    public class BackgroundCoverArtControlViewModel : CoverArtControlViewModel
    {
        #region Variables
        private ISettingsService settingsService;
        private IAppearanceService appearanceService;
        private ICacheService cacheService;
        private IMetadataService metadataService;
        private double opacity;
        #endregion

        #region Properties
        public double Opacity
        {
            get { return this.opacity; }
            set { SetProperty<double>(ref this.opacity, value); }
        }
        #endregion

        #region Construction
        public BackgroundCoverArtControlViewModel(ISettingsService settingsService, IPlaybackService playbackService,
            ICacheService cacheService, IAppearanceService appearanceService, 
            IMetadataService metadataService) : base(playbackService, cacheService, metadataService)
        {
            this.settingsService = settingsService;
            this.playbackService = playbackService;
            this.appearanceService = appearanceService;
            this.cacheService = cacheService;
            this.metadataService = metadataService;

            this.appearanceService.ThemeChanged += useLightTheme => this.Opacity = useLightTheme ? 1.0 : 0.5;

            this.Opacity = this.settingsService.UseLightTheme ? 1.0 : 0.5;
        }
        #endregion
    }
}
