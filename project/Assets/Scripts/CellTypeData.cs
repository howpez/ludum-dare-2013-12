using UnityEngine;
using System;
using System.Collections.Generic;

namespace Sophie
{
	public class CellTypeData
	{
		public static readonly CellTypeData Nucleus = new CellTypeData (new Color (1, 0, 0));
		public static readonly CellTypeData Empty = new CellTypeData (new Color (0.11f, 0.44f, 0));
		public static readonly CellTypeData Dead = new CellTypeData (new Color (0, 0, 0));
		public static readonly CellTypeData Attacker = new CellTypeData (new Color (0.74f, 0, 0.56f));
		public static readonly CellTypeData Clone = new CellTypeData (new Color (1, 1, 1));
		public static readonly CellTypeData Eater = new CellTypeData (new Color (0.74f, 0, 0.18f));
		public static readonly CellTypeData Ghost = new CellTypeData (new Color (0.18f, 0.74f, 0));
		public static readonly CellTypeData Grower = new CellTypeData (new Color (0.56f, 0.74f, 0));
		public static readonly CellTypeData Lookout = new CellTypeData (new Color (0.42f, 0.22f, 1));
		public static readonly CellTypeData Shifter = new CellTypeData (new Color (0, 0.74f, 0.56f));
		public static readonly CellTypeData Stasis = new CellTypeData (new Color (0, 0.18f, 0.74f));
		public static readonly CellTypeData Swapper = new CellTypeData (new Color (0.80f, 1, 0.22f));
		public static readonly CellTypeData Trap = new CellTypeData (new Color (0.56f, 0, 0.74f));
		public static readonly CellTypeData Wall = new CellTypeData (new Color (0.74f, 0.18f, 0));

		private Color color;

		#region Properties
		public Color Color
		{
			get { return color; }
		}
		#endregion 

		public CellTypeData (Color color)
		{
			this.color = color;
		}

		public static List<CellTypeData> GetBuildable()
		{
			List<CellTypeData> res = new List<CellTypeData> ();
			res.Add (Attacker);
			res.Add (Clone);
			res.Add (Eater);
			res.Add (Ghost);
			res.Add (Grower);
			res.Add (Lookout);
			res.Add (Shifter);
			res.Add (Stasis);
			res.Add (Swapper);
			res.Add (Trap);
			res.Add (Wall);
			return res;
		}
	}
}
