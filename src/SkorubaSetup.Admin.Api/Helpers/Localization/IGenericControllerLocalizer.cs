﻿using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace SkorubaSetup.Admin.Api.Helpers.Localization
{
    public interface IGenericControllerLocalizer<out T>
    {
        LocalizedString this[string name] { get; }

        LocalizedString this[string name, params object[] arguments] { get; }

        IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures);
    }
}







