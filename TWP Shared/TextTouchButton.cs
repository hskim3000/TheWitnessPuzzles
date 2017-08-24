﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TWP_Shared
{
    public class TextTouchButton : TouchButton
    {
        SpriteFont font;
        string text;
        Color textColor;
        Color textColorPressed;
        Texture2D texPixel;
        float scale;
        Vector2 position;

        public TextTouchButton(Rectangle bounds, SpriteFont font, string text, Texture2D texPixel, Color? textColor = null, Color? textColorPressed = null) 
            : base(bounds, null, null)
        {
            this.font = font;
            this.texPixel = texPixel;
            this.text = text;
            this.textColor = textColor ?? Color.White;
            this.textColorPressed = textColorPressed ?? Color.DarkGray;

            Vector2 renderSize = font.MeasureString(text);
            float xScale = bounds.Width / renderSize.X;
            float yScale = bounds.Height / renderSize.Y;
            scale = Math.Min(xScale, yScale);
            renderSize.X *= scale;
            renderSize.Y *= scale;
            position = new Vector2(bounds.X + (bounds.Width - renderSize.X) / 2, bounds.Y + (bounds.Height - renderSize.Y) / 2);
        }

        public override void Draw(SpriteBatch sb, float alpha = 1f)
        {
            sb.DrawString(font, text, position, (isPressedDown ? textColorPressed : textColor) * alpha, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}