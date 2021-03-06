﻿using System;
using System.Windows.Controls;

namespace Milki.Utils.WPF.Controls
{
    public class FrameEx : Frame
    {
        protected override void OnContentRendered(EventArgs args)
        {
            base.OnContentRendered(args);
            var page = Content;
            if (page is PageEx pageEx)
            {
                pageEx.OnContentRendered(args);
            }
        }

        public new Uri BaseUri => base.BaseUri;
    }

    public class PageEx : Page
    {
        protected internal virtual void OnContentRendered(EventArgs args)
        {
        }
    }
}
