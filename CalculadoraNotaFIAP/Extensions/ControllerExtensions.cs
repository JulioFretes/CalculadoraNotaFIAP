﻿using CalculadoraNotaFIAP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraNotaFIAP.Extensions
{
    public static class ControllerExtensions
    {
        public static void ShowMessage(this Controller @this, string text, bool error = false)
        {
            @this.TempData["message"] = MessageViewModel.Serialize(text, error ? MessageType.Error : MessageType.Information);
        }
    }
}
