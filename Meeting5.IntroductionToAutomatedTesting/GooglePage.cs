using System;
using JetBrains.Annotations;

namespace Meeting5.IntroductionToAutomatedTesting
{
    [PageUrl("google.com")]
    internal class GooglePage
    {
        [CssName("search-button")]
        [UsedImplicitly]
        public object SearchButton;

        [CssName("search-field")]
        [UsedImplicitly]
        public object SearchField { get; set; }

        [CheckControl(nameof(SearchButton))]
        [CheckControl(nameof(SearchField))]
        public bool IsPageLoaded()
        {
            throw new NotImplementedException();
        }
    }
}