using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using SyminUI.Core;

namespace SyminUI.Views
{
    public class Text : ElementViewBase<TextBlock>
    {
        /// <summary>
        /// TextBlock
        /// 文本对象
        /// </summary>
        /// <param name="text"></param>
        public Text(string text) : base()
        {
            ViewElement.Text = text;
        }
        /// <summary>
        /// TextBlock
        /// 文本对象
        /// </summary>
        /// <param name="dynamicText"></param>
        public Text(State<string> dynamicText) : base()
        {
            ViewElement.SetBinding(TextBlock.TextProperty, (Binding)dynamicText);
        }

        #region TextBlock Properties
        //TODO:Background

        public Text BaselineOffset(double offset)
        {
            ViewElement.BaselineOffset = offset;
            return this;
        }
        public Text BaselineOffset(State<double> offset)
        {
            ViewElement.SetBinding(TextBlock.BaselineOffsetProperty, (Binding)offset);
            return this;
        }
        /// <summary>
        /// Set Text FontFamily
        /// 设置文本字体
        /// </summary>
        /// <param name="fontFamily"></param>
        /// <returns></returns>
        public Text FontFamily(FontFamily fontFamily)
        {
            ViewElement.FontFamily = fontFamily;
            return this;
        }
        /// <summary>
        /// Set Text FontFamily
        /// 设置文本字体
        /// </summary>
        /// <param name="dynamicFontFamily"></param>
        /// <returns></returns>
        public Text FontFamily(State<FontFamily> dynamicFontFamily)
        {
            ViewElement.SetBinding(TextBlock.FontFamilyProperty, (Binding)dynamicFontFamily);
            return this;
        }
        public Text FontSize(double size)
        {
            ViewElement.FontSize = size;
            return this;
        }
        public Text FontSize(State<double> dynamicSize)
        {
            ViewElement.SetBinding(TextBlock.FontSizeProperty, (Binding)dynamicSize);
            return this;
        }
        public Text FontStretch(FontStretch fontStretch)
        {
            ViewElement.FontStretch = fontStretch;
            return this;
        }
        public Text FontStretch(State<FontStretch> dynamicFontStretch)
        {
            ViewElement.SetBinding(TextBlock.FontStretchProperty, (Binding)dynamicFontStretch);
            return this;
        }
        public Text FontStyle(FontStyle fontStyle)
        {
            ViewElement.FontStyle = fontStyle;
            return this;
        }
        public Text FontStyle(State<FontStyle> dynamicFontStyle)
        {
            ViewElement.SetBinding(TextBlock.FontStyleProperty, (Binding)dynamicFontStyle);
            return this;
        }
        public Text FontWeight(FontWeight fontWeight)
        {
            ViewElement.FontWeight = fontWeight;
            return this;
        }
        public Text FontWeight(State<FontWeight> dynamicFontWeight)
        {
            ViewElement.SetBinding(TextBlock.FontWeightProperty, (Binding)dynamicFontWeight);
            return this;
        }
        public Text Foreground(Brush foreground)
        {
            ViewElement.Foreground = foreground;
            return this;
        }
        public Text Foreground(State<Brush> dynamicForeground)
        {
            ViewElement.SetBinding(TextBlock.ForegroundProperty, (Binding)dynamicForeground);
            return this;
        }
        public Text SetHyphenation(bool enabled)
        {
            ViewElement.IsHyphenationEnabled = enabled;
            return this;
        }
        public Text SetHyphenation(State<bool> enabled)
        {
            ViewElement.SetBinding(TextBlock.IsHyphenationEnabledProperty, (Binding)enabled);
            return this;
        }
        public Text LineHeight(double lineHeight)
        {
            ViewElement.LineHeight = lineHeight;
            return this;
        }
        public Text LineHeight(State<double> dynamicLineHeight)
        {
            ViewElement.SetBinding(TextBlock.LineHeightProperty, (Binding)dynamicLineHeight);
            return this;
        }
        public Text LineStackingStrategy(LineStackingStrategy strategy)
        {
            ViewElement.LineStackingStrategy = strategy;
            return this;
        }
        public Text LineStackingStrategy(State<LineStackingStrategy> dynamicStrategy)
        {
            ViewElement.SetBinding(TextBlock.LineStackingStrategyProperty, (Binding)dynamicStrategy);
            return this;
        }
        /// <summary>
        /// Set Text Padding
        /// 设置文本Padding
        /// </summary>
        /// <param name="left">Left-左</param>
        /// <param name="top">Top-上</param>
        /// <param name="right">Right-右</param>
        /// <param name="bottom">Bottom-下</param>
        /// <returns></returns>
        public Text Padding(double left, double top, double right, double bottom)
        {
            var padding = new Thickness(left, top, right, bottom);
            ViewElement.Padding = padding;
            return this;
        }
        /// <summary>
        /// Set Text Padding
        /// 设置文本Padding
        /// </summary>
        /// <param name="padding"></param>
        /// <returns></returns>
        public Text Padding(Thickness padding)
        {
            ViewElement.Padding = padding;
            return this;
        }
        /// <summary>
        /// Set Text Padding
        /// 设置文本Padding
        /// </summary>
        /// <param name="dynamicPadding"></param>
        /// <returns></returns>
        public Text Padding(State<Thickness> dynamicPadding)
        {
            ViewElement.SetBinding(TextBlock.PaddingProperty, (Binding)dynamicPadding);
            return this;
        }
        public Text TextAlignment(TextAlignment textAlignment)
        {
            ViewElement.TextAlignment = textAlignment;
            return this;
        }
        public Text TextAlignment(State<TextAlignment> dynamicTextAlignment)
        {
            ViewElement.SetBinding(TextBlock.TextAlignmentProperty, (Binding)dynamicTextAlignment);
            return this;
        }
        public Text TextDecorations(TextDecorationCollection textDecorations)
        {
            ViewElement.TextDecorations = textDecorations;
            return this;
        }
        //TODO:动态Decorations?
        public Text TextEffects(TextEffectCollection textEffects)
        {
            ViewElement.TextEffects = textEffects;
            return this;
        }
        //TODO:动态TextEffects?
        public Text TextTrimming(TextTrimming trimming)
        {
            ViewElement.TextTrimming = trimming;
            return this;
        }
        public Text TextWrapping(TextWrapping wrapping)
        {
            ViewElement.TextWrapping = wrapping;
            return this;
        }

        #endregion
    }
}
