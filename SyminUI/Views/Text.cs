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
using System.Xml.Linq;

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
            Element.Text = text;
        }
        /// <summary>
        /// TextBlock
        /// 文本对象
        /// </summary>
        /// <param name="dynamicText"></param>
        public Text(State<string> dynamicText) : base()
        {
            Element.SetBinding(TextBlock.TextProperty, (Binding)dynamicText);
        }


        #region TextBlock Properties


        /// <summary>
        /// Set Text FontFamily
        /// 设置文本字体
        /// </summary>
        /// <param name="fontFamily"></param>
        /// <returns></returns>
        public Text FontFamily(FontFamily fontFamily)
        {
            Element.FontFamily = fontFamily;
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
            Element.SetBinding(TextBlock.FontFamilyProperty, (Binding)dynamicFontFamily);
            return this;
        }
        public Text FontSize(double size)
        {
            Element.FontSize = size;
            return this;
        }
        public Text FontSize(State<double> dynamicSize)
        {
            Element.SetBinding(TextBlock.FontSizeProperty, (Binding)dynamicSize);
            return this;
        }
        public Text FontStretch(FontStretch fontStretch)
        {
            Element.FontStretch = fontStretch;
            return this;
        }
        public Text FontStretch(State<FontStretch> dynamicFontStretch)
        {
            Element.SetBinding(TextBlock.FontStretchProperty, (Binding)dynamicFontStretch);
            return this;
        }
        public Text FontStyle(FontStyle fontStyle)
        {
            Element.FontStyle = fontStyle;
            return this;
        }
        public Text FontStyle(State<FontStyle> dynamicFontStyle)
        {
            Element.SetBinding(TextBlock.FontStyleProperty, (Binding)dynamicFontStyle);
            return this;
        }
        public Text FontWeight(FontWeight fontWeight)
        {
            Element.FontWeight = fontWeight;
            return this;
        }
        public Text FontWeight(State<FontWeight> dynamicFontWeight)
        {
            Element.SetBinding(TextBlock.FontWeightProperty, (Binding)dynamicFontWeight);
            return this;
        }
        public Text Foreground(Brush foreground)
        {
            Element.Foreground = foreground;
            return this;
        }
        public Text Foreground(State<Brush> dynamicForeground)
        {
            Element.SetBinding(TextBlock.ForegroundProperty, (Binding)dynamicForeground);
            return this;
        }
        public Text SetHyphenation(bool enabled)
        {
            Element.IsHyphenationEnabled = enabled;
            return this;
        }
        public Text SetHyphenation(State<bool> enabled)
        {
            Element.SetBinding(TextBlock.IsHyphenationEnabledProperty, (Binding)enabled);
            return this;
        }
        public Text LineHeight(double lineHeight)
        {
            Element.LineHeight = lineHeight;
            return this;
        }
        public Text LineHeight(State<double> dynamicLineHeight)
        {
            Element.SetBinding(TextBlock.LineHeightProperty, (Binding)dynamicLineHeight);
            return this;
        }
        public Text LineStackingStrategy(LineStackingStrategy strategy)
        {
            Element.LineStackingStrategy = strategy;
            return this;
        }
        public Text LineStackingStrategy(State<LineStackingStrategy> dynamicStrategy)
        {
            Element.SetBinding(TextBlock.LineStackingStrategyProperty, (Binding)dynamicStrategy);
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
            Element.Padding = padding;
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
            Element.Padding = padding;
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
            Element.SetBinding(TextBlock.PaddingProperty, (Binding)dynamicPadding);
            return this;
        }
        public Text TextAlignment(TextAlignment textAlignment)
        {
            Element.TextAlignment = textAlignment;
            return this;
        }
        public Text TextAlignment(State<TextAlignment> dynamicTextAlignment)
        {
            Element.SetBinding(TextBlock.TextAlignmentProperty, (Binding)dynamicTextAlignment);
            return this;
        }
        public Text TextDecorations(TextDecorationCollection textDecorations)
        {
            Element.TextDecorations = textDecorations;
            return this;
        }
        //TODO:动态Decorations?
        public Text TextEffects(TextEffectCollection textEffects)
        {
            Element.TextEffects = textEffects;
            return this;
        }
        //TODO:动态TextEffects?
        public Text TextTrimming(TextTrimming trimming)
        {
            Element.TextTrimming = trimming;
            return this;
        }
        public Text TextWrapping(TextWrapping wrapping)
        {
            Element.TextWrapping = wrapping;
            return this;
        }

        #endregion
    }

    public static class TextExtension
    {
        #region TextBlock Properties
        //TODO:Background

        /// <summary>
        /// Set text baseline offset
        /// 设置文本基线偏移
        /// </summary>
        /// <param name="view"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static T BaselineOffset<T>(this T view, double offset) where T : Text
        {
            view.Element.BaselineOffset = offset;
            return view;
        }
        /// <summary>
        /// Set text baseline offset
        /// 设置文本基线偏移
        /// </summary>
        /// <param name="view"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static T BaselineOffset<T>(this T view, State<double> offset) where T : Text
        {
            view.Element.SetBinding(TextBlock.BaselineOffsetProperty, (Binding)offset);
            return view;
        }

        #endregion
    }
}
