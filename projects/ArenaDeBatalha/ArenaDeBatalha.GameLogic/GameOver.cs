﻿using System;
using System.Drawing;

namespace ArenaDeBatalha.GameLogic
{
    public class GameOver : GameObject
    {
        public GameOver(Size bounds, Graphics screenPainter) : base(bounds, screenPainter)
        {
            this.Left = this.Bounds.Width / 2 - this.Width / 2;
            this.Top = this.Bounds.Height / 2 - this.Height / 2;
            this.Speed = 0;
        }
        public override Bitmap GetSprite()
        {
            return Media.GameOver;
        }
    }
}
