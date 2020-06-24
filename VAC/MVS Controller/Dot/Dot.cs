﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVS_Controller

{
    public partial class Dot: Noda
    {
        
        public Dot(Form parent, Panel panel, Color first, Color therd, Color text) : base(parent, panel, first, therd, text)
        {

            name_of_type = "Dot";
            InitializeComponent();
            Size = new Size(10,10);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 50, 40);// сам поэксперементируй.
            Region rgn = new Region(path);
            Region = rgn;

        }
        protected override void Noda_MoseMove(object sender, MouseEventArgs e)
        {
            Point delta = new Point((e.Location.X - Mouse_pos.X), (e.Location.Y - Mouse_pos.Y));
            Noda nod = sender as Noda;
                if (Loc_change != null)
                {
                    nod.Location = new Point(nod.Location.X + (int)(delta.X * 0.5), nod.Location.Y + (int)(delta.Y * 0.5));
                    Paintt = true;
                }
            
            Mouse_pos = e.Location;
        }
        
    }
    
}
