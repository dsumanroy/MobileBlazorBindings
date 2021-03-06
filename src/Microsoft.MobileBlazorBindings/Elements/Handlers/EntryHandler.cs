﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.MobileBlazorBindings.Core;
using Microsoft.AspNetCore.Components;

namespace Microsoft.MobileBlazorBindings.Elements.Handlers
{
    public partial class EntryHandler : InputViewHandler
    {
        partial void Initialize(NativeComponentRenderer renderer)
        {
            RegisterEvent(
                eventName: "oncompleted",
                setId: id => CompletedEventHandlerId = id,
                clearId: () => CompletedEventHandlerId = 0);
            EntryControl.Completed += (s, e) =>
            {
                if (CompletedEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(CompletedEventHandlerId, null, e));
                }
            };
            RegisterEvent(
                eventName: "ontextchanged",
                setId: id => TextChangedEventHandlerId = id,
                clearId: () => TextChangedEventHandlerId = 0);
            EntryControl.TextChanged += (s, e) =>
            {
                if (TextChangedEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(TextChangedEventHandlerId, null, new ChangeEventArgs { Value = EntryControl.Text }));
                }
            };
        }

        public ulong CompletedEventHandlerId { get; set; }
        public ulong TextChangedEventHandlerId { get; set; }
    }
}
