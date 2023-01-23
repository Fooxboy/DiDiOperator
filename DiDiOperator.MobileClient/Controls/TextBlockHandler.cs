using Microsoft.Maui.Handlers;

namespace DiDiOperator.MobileClient.Controls
{
    public partial class TextBlockHandler : EntryHandler
    {
        public static IPropertyMapper<IEntry, TextBlockHandler> MyMapper = new PropertyMapper<IEntry, TextBlockHandler>(ViewMapper)
        {
            // From Entry.
            [nameof(IEntry.Background)] = MapBackground,
            [nameof(IEntry.CharacterSpacing)] = MapCharacterSpacing,
            [nameof(IEntry.ClearButtonVisibility)] = MapClearButtonVisibility,
            [nameof(IEntry.Font)] = MapFont,
            [nameof(IEntry.IsPassword)] = MapIsPassword,
            [nameof(IEntry.HorizontalTextAlignment)] = MapHorizontalTextAlignment,
            [nameof(IEntry.VerticalTextAlignment)] = MapVerticalTextAlignment,
            [nameof(IEntry.IsReadOnly)] = MapIsReadOnly,
            [nameof(IEntry.IsTextPredictionEnabled)] = MapIsTextPredictionEnabled,
            [nameof(IEntry.Keyboard)] = MapKeyboard,
            [nameof(IEntry.MaxLength)] = MapMaxLength,
            [nameof(IEntry.Placeholder)] = MapPlaceholder,
            [nameof(IEntry.PlaceholderColor)] = MapPlaceholderColor,
            [nameof(IEntry.ReturnType)] = MapReturnType,
            [nameof(IEntry.Text)] = MapText,
            [nameof(IEntry.TextColor)] = MapTextColor,
            [nameof(IEntry.CursorPosition)] = MapCursorPosition,
            [nameof(IEntry.SelectionLength)] = MapSelectionLength,
        };

    }
}
